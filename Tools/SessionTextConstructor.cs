using PlenBotLogUploader.DiscordAPI;
using PlenBotLogUploader.DPSReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlenBotLogUploader.Tools
{
    public static class SessionTextConstructor
    {
        #region definitions
        // fields
        private static readonly Dictionary<int, BossData> allBosses = Bosses.All;
        private static readonly DiscordAPIJSONContentEmbedThumbnail defaultThumbnail = new DiscordAPIJSONContentEmbedThumbnail()
        {
            Url = "https://wiki.guildwars2.com/images/5/5e/Legendary_Insight.png"
        };
        // consts
        private const int maxAllowedMessageSize = 1800;
        #endregion

        public static DiscordAPIJSONContentEmbed MakeEmbedFromText(string title, string text)
        {
            return new DiscordAPIJSONContentEmbed()
            {
                Title = title,
                Description = text,
                Colour = 32768,
                TimeStamp = DateTime.UtcNow.ToString("yyyy'-'MM'-'ddTHH':'mm':'ssZ"),
                Thumbnail = defaultThumbnail
            };
        }

        public static DiscordEmbeds ConstructSessionEmbeds(List<DPSReportJSON> reportsJSON, LogSessionSettings logSessionSettings)
        {
            var discordEmbedsSuccessFailure = new List<DiscordAPIJSONContentEmbed>();
            var discordEmbedsSuccess = new List<DiscordAPIJSONContentEmbed>();
            var discordEmbedsFailure = new List<DiscordAPIJSONContentEmbed>();

            var RaidLogs = reportsJSON
                .Where(x => Bosses.GetWingForBoss(x.EVTC.BossId) > 0)
                .Select(x => new { LogData = x, RaidWing = Bosses.GetWingForBoss(x.EVTC.BossId) })
                .OrderBy(x => x.LogData.UploadTime)
                .ToList();
            if (logSessionSettings.SortBy.Equals(LogSessionSortBy.Wing))
            {
                RaidLogs = reportsJSON
                    .Where(x => Bosses.GetWingForBoss(x.EVTC.BossId) > 0)
                    .Select(x => new { LogData = x, RaidWing = Bosses.GetWingForBoss(x.EVTC.BossId) })
                    .OrderBy(x => Bosses.GetWingForBoss(x.LogData.EVTC.BossId))
                    .ThenBy(x => Bosses.GetBossOrder(x.LogData.Encounter.BossId))
                    .ThenBy(x => x.LogData.UploadTime)
                    .ToList();
            }
            var FractalLogs = reportsJSON
                .Where(x => allBosses
                    .Where(y => y.Value.BossId.Equals(x.EVTC.BossId))
                    .Where(y => y.Value.Type.Equals(BossType.Fractal))
                    .Count() > 0)
                .ToList();
            var StrikeLogs = reportsJSON
                .Where(x => allBosses
                    .Where(y => y.Value.BossId.Equals(x.EVTC.BossId))
                    .Where(y => y.Value.Type.Equals(BossType.Strike))
                    .Count() > 0)
                .ToList();
            var GolemLogs = reportsJSON
                .Where(x => allBosses
                    .Where(y => y.Value.BossId.Equals(x.EVTC.BossId))
                    .Where(y => y.Value.Type.Equals(BossType.Golem))
                    .Count() > 0)
                .ToList();
            var WvWLogs = reportsJSON
                .Where(x => allBosses
                    .Where(y => y.Value.BossId.Equals(x.EVTC.BossId))
                    .Where(y => y.Value.Type.Equals(BossType.WvW))
                    .Count() > 0)
                .ToList();
            var OtherLogs = reportsJSON
                .Where(x => allBosses
                    .Where(y => y.Value.BossId.Equals(x.EVTC.BossId))
                    .Where(y => y.Value.Type.Equals(BossType.None))
                    .Count() > 0 || allBosses
                    .Where(y => y.Value.BossId.Equals(x.EVTC.BossId))
                    .Count() == 0)
                .ToList();

            var durationText = $"Session duration: {logSessionSettings.ElapsedTime}\n\n";
            var builderSuccessFailure = new StringBuilder(durationText);
            var builderSuccess = new StringBuilder(durationText);
            var builderFailure = new StringBuilder(durationText);
            int messageSuccessFailureCount = 0, messageSuccessCount = 0, messageFailureCount = 0;

            if (RaidLogs.Count > 0)
            {
                builderSuccessFailure.Append("***Raid logs:***\n");
                if (logSessionSettings.SortBy.Equals(LogSessionSortBy.UploadTime))
                {
                    foreach (var data in RaidLogs)
                    {
                        string bossName = data.LogData.Encounter.Boss + (data.LogData.ChallengeMode ? " CM" : "");
                        var bossData = Bosses.GetBossDataFromId(data.LogData.Encounter.BossId);
                        if (bossData != null)
                        {
                            bossName = bossData.Name + (data.LogData.ChallengeMode ? " CM" : "");
                        }
                        string duration = (data.LogData.ExtraJSON == null) ? "" : $" {data.LogData.ExtraJSON.Duration}";
                        string successText = (logSessionSettings.ShowSuccess) ? ((data.LogData.Encounter.Success ?? false) ? " :white_check_mark:" : " ❌") : "";
                        builderSuccessFailure.Append($"[{bossName}]({data.LogData.Permalink}){duration}{successText}\n");
                        if (builderSuccessFailure.Length >= maxAllowedMessageSize)
                        {
                            messageSuccessFailureCount++;
                            discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessFailureCount > 1) ? $" part {messageSuccessFailureCount}" : ""), builderSuccessFailure.ToString()));
                            builderSuccessFailure.Clear();
                            builderSuccessFailure.Append("***Raid logs:***\n");
                        }
                        if (data.LogData.Encounter.Success ?? false)
                        {
                            builderSuccess.Append($"[{bossName}]({data.LogData.Permalink}){duration}{successText}\n");
                            if (builderSuccess.Length >= maxAllowedMessageSize)
                            {
                                messageSuccessCount++;
                                discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessCount > 1) ? $" part {messageSuccessCount}" : ""), builderSuccess.ToString()));
                                builderSuccess.Clear();
                                builderSuccess.Append("***Raid logs:***\n");
                            }
                        }
                        else
                        {
                            builderFailure.Append($"[{bossName}]({data.LogData.Permalink}){duration}{successText}\n");
                            if (builderFailure.Length >= maxAllowedMessageSize)
                            {
                                messageFailureCount++;
                                discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageFailureCount > 1) ? $" part {messageFailureCount}" : ""), builderFailure.ToString()));
                                builderFailure.Clear();
                                builderFailure.Append("***Raid logs:***\n");
                            }
                        }
                    }
                }
                else
                {
                    int lastWing = 0;
                    foreach (var data in RaidLogs)
                    {
                        if (!lastWing.Equals(Bosses.GetWingForBoss(data.LogData.EVTC.BossId)))
                        {
                            builderSuccessFailure.Append($"**{Bosses.GetWingName(data.RaidWing)} (wing {data.RaidWing})**\n");
                            lastWing = Bosses.GetWingForBoss(data.LogData.EVTC.BossId);
                        }
                        string bossName = data.LogData.Encounter.Boss + (data.LogData.ChallengeMode ? " CM" : "");
                        var bossData = Bosses.GetBossDataFromId(data.LogData.Encounter.BossId);
                        if (bossData != null)
                        {
                            bossName = bossData.Name + (data.LogData.ChallengeMode ? " CM" : "");
                        }
                        string duration = (data.LogData.ExtraJSON == null) ? "" : $" {data.LogData.ExtraJSON.Duration}";
                        string successText = (logSessionSettings.ShowSuccess) ? ((data.LogData.Encounter.Success ?? false) ? " :white_check_mark:" : " ❌") : "";
                        builderSuccessFailure.Append($"[{bossName}]({data.LogData.Permalink}){duration}{successText}\n");
                        if (builderSuccessFailure.Length >= maxAllowedMessageSize)
                        {
                            messageSuccessFailureCount++;
                            discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessFailureCount > 1) ? $" part {messageSuccessFailureCount}" : ""), builderSuccessFailure.ToString()));
                            builderSuccessFailure.Clear();
                            builderSuccessFailure.Append($"**{Bosses.GetWingName(data.RaidWing)} (wing {data.RaidWing})**\n");
                        }
                        if (data.LogData.Encounter.Success ?? false)
                        {
                            builderSuccess.Append($"[{bossName}]({data.LogData.Permalink}){duration}{successText}\n");
                            if (builderSuccess.Length >= maxAllowedMessageSize)
                            {
                                messageSuccessCount++;
                                discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessCount > 1) ? $" part {messageSuccessCount}" : ""), builderSuccess.ToString()));
                                builderSuccess.Clear();
                                builderSuccess.Append("***Raid logs:***\n");
                            }
                        }
                        else
                        {
                            builderFailure.Append($"[{bossName}]({data.LogData.Permalink}){duration}{successText}\n");
                            if (builderFailure.Length >= maxAllowedMessageSize)
                            {
                                messageFailureCount++;
                                discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageFailureCount > 1) ? $" part {messageFailureCount}" : ""), builderFailure.ToString()));
                                builderFailure.Clear();
                                builderFailure.Append("***Raid logs:***\n");
                            }
                        }
                    }
                }
            }
            if (FractalLogs.Count > 0)
            {
                if (!builderSuccessFailure.ToString().EndsWith("***\n"))
                {
                    builderSuccessFailure.Append("\n\n");
                }
                builderSuccessFailure.Append("***Fractal logs:***\n");
                foreach (var log in FractalLogs)
                {
                    string bossName = log.Encounter.Boss;
                    var bossData = Bosses.GetBossDataFromId(log.Encounter.BossId);
                    if (bossData != null)
                    {
                        bossName = bossData.Name + (log.ChallengeMode ? " CM" : "");
                    }
                    string duration = (log.ExtraJSON == null) ? "" : $" {log.ExtraJSON.Duration}";
                    string successText = (logSessionSettings.ShowSuccess) ? ((log.Encounter.Success ?? false) ? " :white_check_mark:" : " ❌") : "";
                    builderSuccessFailure.Append($"[{bossName}]({log.Permalink}){duration}{successText}\n");
                    if (builderSuccessFailure.Length >= maxAllowedMessageSize)
                    {
                        messageSuccessFailureCount++;
                        discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessFailureCount > 1) ? $" part {messageSuccessFailureCount}" : ""), builderSuccessFailure.ToString()));
                        builderSuccessFailure.Clear();
                        builderSuccessFailure.Append("***Fractal logs:***\n");
                    }
                    if (log.Encounter.Success ?? false)
                    {
                        builderSuccess.Append($"[{bossName}]({log.Permalink}){duration}{successText}\n");
                        if (builderSuccess.Length >= maxAllowedMessageSize)
                        {
                            messageSuccessCount++;
                            discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessCount > 1) ? $" part {messageSuccessCount}" : ""), builderSuccess.ToString()));
                            builderSuccess.Clear();
                            builderSuccess.Append("***Fractal logs:***\n");
                        }
                    }
                    else
                    {
                        builderFailure.Append($"[{bossName}]({log.Permalink}){duration}{successText}\n");
                        if (builderFailure.Length >= maxAllowedMessageSize)
                        {
                            messageFailureCount++;
                            discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageFailureCount > 1) ? $" part {messageFailureCount}" : ""), builderFailure.ToString()));
                            builderFailure.Clear();
                            builderFailure.Append("***Fractal logs:***\n");
                        }
                    }
                }
            }
            if (StrikeLogs.Count > 0)
            {
                if (!builderSuccessFailure.ToString().EndsWith("***\n"))
                {
                    builderSuccessFailure.Append("\n\n");
                }
                builderSuccessFailure.Append("***Strike mission logs:***\n");
                foreach (var log in StrikeLogs)
                {
                    string bossName = log.Encounter.Boss;
                    var bossData = Bosses.GetBossDataFromId(log.Encounter.BossId);
                    if (bossData != null)
                    {
                        bossName = bossData.Name;
                    }
                    string duration = (log.ExtraJSON == null) ? "" : $" {log.ExtraJSON.Duration}";
                    string successText = (logSessionSettings.ShowSuccess) ? ((log.Encounter.Success ?? false) ? " :white_check_mark:" : " ❌") : "";
                    builderSuccessFailure.Append($"[{bossName}]({log.Permalink}){duration}{successText}\n");
                    if (builderSuccessFailure.Length >= maxAllowedMessageSize)
                    {
                        messageSuccessFailureCount++;
                        discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessFailureCount > 1) ? $" part {messageSuccessFailureCount}" : ""), builderSuccessFailure.ToString()));
                        builderSuccessFailure.Clear();
                        builderSuccessFailure.Append("***Strike mission logs:***\n");
                    }
                    if (log.Encounter.Success ?? false)
                    {
                        builderSuccess.Append($"[{bossName}]({log.Permalink}){duration}{successText}\n");
                        if (builderSuccess.Length >= maxAllowedMessageSize)
                        {
                            messageSuccessCount++;
                            discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessCount > 1) ? $" part {messageSuccessCount}" : ""), builderSuccess.ToString()));
                            builderSuccess.Clear();
                            builderSuccess.Append("***Strike mission logs:***\n");
                        }
                    }
                    else
                    {
                        builderFailure.Append($"[{bossName}]({log.Permalink}){duration}{successText}\n");
                        if (builderFailure.Length >= maxAllowedMessageSize)
                        {
                            messageFailureCount++;
                            discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageFailureCount > 1) ? $" part {messageFailureCount}" : ""), builderFailure.ToString()));
                            builderFailure.Clear();
                            builderFailure.Append("***Strike mission logs:***\n");
                        }
                    }
                }
            }
            if (GolemLogs.Count > 0)
            {
                if (!builderSuccessFailure.ToString().EndsWith("***\n"))
                {
                    builderSuccessFailure.Append("\n\n");
                }
                builderSuccessFailure.Append("***Golem logs:***\n");
                foreach (var log in GolemLogs)
                {
                    builderSuccessFailure.Append($"{log.Permalink}\n");
                    if (builderSuccessFailure.Length >= maxAllowedMessageSize)
                    {
                        messageSuccessFailureCount++;
                        discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessFailureCount > 1) ? $" part {messageSuccessFailureCount}" : ""), builderSuccessFailure.ToString()));
                        builderSuccessFailure.Clear();
                        builderSuccessFailure.Append("***Golem logs:***\n");
                    }
                    if (log.Encounter.Success ?? false)
                    {
                        builderSuccess.Append($"{log.Permalink}\n");
                        if (builderSuccess.Length >= maxAllowedMessageSize)
                        {
                            messageSuccessCount++;
                            discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessCount > 1) ? $" part {messageSuccessCount}" : ""), builderSuccess.ToString()));
                            builderSuccess.Clear();
                            builderSuccess.Append("***Golem logs:***\n");
                        }
                    }
                    else
                    {
                        builderFailure.Append($"{log.Permalink}\n");
                        if (builderFailure.Length >= maxAllowedMessageSize)
                        {
                            messageFailureCount++;
                            discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageFailureCount > 1) ? $" part {messageFailureCount}" : ""), builderFailure.ToString()));
                            builderFailure.Clear();
                            builderFailure.Append("***Golem logs:***\n");
                        }
                    }
                }
            }
            if (WvWLogs.Count > 0)
            {
                if (!builderSuccessFailure.ToString().EndsWith("***\n"))
                {
                    builderSuccessFailure.Append("\n\n");
                }
                builderSuccessFailure.Append("***WvW logs:***\n");
                foreach (var log in WvWLogs)
                {
                    builderSuccessFailure.Append($"{log.Permalink}\n");
                    if (builderSuccessFailure.Length >= maxAllowedMessageSize)
                    {
                        messageSuccessFailureCount++;
                        discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessFailureCount > 1) ? $" part {messageSuccessFailureCount}" : ""), builderSuccessFailure.ToString()));
                        builderSuccessFailure.Clear();
                        builderSuccessFailure.Append("***WvW logs:***\n");
                    }
                    if (log.Encounter.Success ?? false)
                    {
                        builderSuccess.Append($"{log.Permalink}\n");
                        if (builderSuccess.Length >= maxAllowedMessageSize)
                        {
                            messageSuccessCount++;
                            discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessCount > 1) ? $" part {messageSuccessCount}" : ""), builderSuccess.ToString()));
                            builderSuccess.Clear();
                            builderSuccess.Append("***WvW logs:***\n");
                        }
                    }
                    else
                    {
                        builderFailure.Append($"{log.Permalink}\n");
                        if (builderFailure.Length >= maxAllowedMessageSize)
                        {
                            messageFailureCount++;
                            discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageFailureCount > 1) ? $" part {messageFailureCount}" : ""), builderFailure.ToString()));
                            builderFailure.Clear();
                            builderFailure.Append("***WvW logs:***\n");
                        }
                    }
                }
            }
            if (OtherLogs.Count > 0)
            {
                if (!builderSuccessFailure.ToString().EndsWith("***\n"))
                {
                    builderSuccessFailure.Append("\n\n");
                }
                builderSuccessFailure.Append("***Other logs:***\n");
                foreach (var log in OtherLogs)
                {
                    string bossName = log.Encounter.Boss;
                    var bossData = Bosses.GetBossDataFromId(log.Encounter.BossId);
                    if (bossData != null)
                    {
                        bossName = bossData.Name;
                    }
                    string duration = (log.ExtraJSON == null) ? "" : $" {log.ExtraJSON.Duration}";
                    string successText = (logSessionSettings.ShowSuccess) ? ((log.Encounter.Success ?? false) ? " :white_check_mark:" : " ❌") : "";
                    builderSuccessFailure.Append($"[{bossName}]({log.Permalink}){duration}{successText}\n");
                    if (builderSuccessFailure.Length >= maxAllowedMessageSize)
                    {
                        messageSuccessFailureCount++;
                        discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessFailureCount > 1) ? $" part {messageSuccessFailureCount}" : ""), builderSuccessFailure.ToString()));
                        builderSuccessFailure.Clear();
                        builderSuccessFailure.Append("***Other logs:***\n");
                    }
                    if (log.Encounter.Success ?? false)
                    {
                        builderSuccess.Append($"[{bossName}]({log.Permalink}){duration}{successText}\n");
                        if (builderSuccess.Length >= maxAllowedMessageSize)
                        {
                            messageSuccessCount++;
                            discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessCount > 1) ? $" part {messageSuccessCount}" : ""), builderSuccess.ToString()));
                            builderSuccess.Clear();
                            builderSuccess.Append("***Other logs:***\n");
                        }
                    }
                    else
                    {
                        builderFailure.Append($"[{bossName}]({log.Permalink}){duration}{successText}\n");
                        if (builderFailure.Length >= maxAllowedMessageSize)
                        {
                            messageFailureCount++;
                            discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageFailureCount > 1) ? $" part {messageFailureCount}" : ""), builderFailure.ToString()));
                            builderFailure.Clear();
                            builderFailure.Append("***Other logs:***\n");
                        }
                    }
                }
            }
            if (!builderSuccessFailure.ToString().EndsWith("***\n"))
            {
                messageSuccessFailureCount++;
                discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessFailureCount > 1) ? $" part {messageSuccessFailureCount}" : ""), builderSuccessFailure.ToString()));
            }
            if (!builderSuccess.ToString().EndsWith("***\n"))
            {
                messageSuccessCount++;
                discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessCount > 1) ? $" part {messageSuccessCount}" : ""), builderSuccess.ToString()));
            }
            if (!builderFailure.ToString().EndsWith("***\n"))
            {
                messageFailureCount++;
                discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageFailureCount > 1) ? $" part {messageFailureCount}" : ""), builderFailure.ToString()));
            }
            return new DiscordEmbeds() { SuccessFailure = discordEmbedsSuccessFailure, Success = discordEmbedsSuccess, Failure = discordEmbedsFailure };
        }

        public class DiscordEmbeds
        {
            public List<DiscordAPIJSONContentEmbed> SuccessFailure { get; internal set; }

            public List<DiscordAPIJSONContentEmbed> Success { get; internal set; }

            public List<DiscordAPIJSONContentEmbed> Failure { get; internal set; }
        }
    }
}
