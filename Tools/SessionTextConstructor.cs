using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using PlenBotLogUploader.DPSReport;
using PlenBotLogUploader.DiscordAPI;

namespace PlenBotLogUploader.Tools
{
    public static class SessionTextConstructor
    {
        #region definitions
        // fields
        private static readonly Dictionary<int, BossData> allBosses = Bosses.GetAllBosses();
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
            var builder = new StringBuilder($"Session duration: {logSessionSettings.ElapsedTime}\n\n");
            int messageCount = 0;
            if (RaidLogs.Count > 0)
            {
                builder.Append("***Raid logs:***\n");
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
                        builder.Append($"[{bossName}]({data.LogData.Permalink}){duration}{successText}\n");
                        if (builder.Length >= maxAllowedMessageSize)
                        {
                            messageCount++;
                            discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString()));
                            builder.Clear();
                            builder.Append("***Raid logs:***\n");
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
                            builder.Append($"**{Bosses.GetWingName(data.RaidWing)} (wing {data.RaidWing})**\n");
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
                        builder.Append($"[{bossName}]({data.LogData.Permalink}){duration}{successText}\n");
                        if (builder.Length >= maxAllowedMessageSize)
                        {
                            messageCount++;
                            discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString()));
                            builder.Clear();
                            builder.Append($"**{Bosses.GetWingName(data.RaidWing)} (wing {data.RaidWing})**\n");
                        }
                    }
                }
            }
            if (FractalLogs.Count > 0)
            {
                if (!builder.ToString().EndsWith("***\n"))
                {
                    builder.Append("\n\n");
                }
                builder.Append("***Fractal logs:***\n");
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
                    builder.Append($"[{bossName}]({log.Permalink}){duration}{successText}\n");
                    if (builder.Length >= maxAllowedMessageSize)
                    {
                        messageCount++;
                        discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString()));
                        builder.Clear();
                        builder.Append("***Fractal logs:***\n");
                    }
                }
            }
            if (StrikeLogs.Count > 0)
            {
                if (!builder.ToString().EndsWith("***\n"))
                {
                    builder.Append("\n\n");
                }
                builder.Append("***Strike mission logs:***\n");
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
                    builder.Append($"[{bossName}]({log.Permalink}){duration}{successText}\n");
                    if (builder.Length >= maxAllowedMessageSize)
                    {
                        messageCount++;
                        discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString()));
                        builder.Clear();
                        builder.Append("***Strike mission logs:***\n");
                    }
                }
            }
            if (GolemLogs.Count > 0)
            {
                if (!builder.ToString().EndsWith("***\n"))
                {
                    builder.Append("\n\n");
                }
                builder.Append("***Golem logs:***\n");
                foreach (var log in GolemLogs)
                {
                    builder.Append($"{log.Permalink}\n");
                    if (builder.Length >= maxAllowedMessageSize)
                    {
                        messageCount++;
                        discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString()));
                        builder.Clear();
                        builder.Append("***Golem logs:***\n");
                    }
                }
            }
            if (WvWLogs.Count > 0)
            {
                if (!builder.ToString().EndsWith("***\n"))
                {
                    builder.Append("\n\n");
                }
                builder.Append("***WvW logs:***\n");
                foreach (var log in WvWLogs)
                {
                    builder.Append($"{log.Permalink}\n");
                    if (builder.Length >= maxAllowedMessageSize)
                    {
                        messageCount++;
                        discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString()));
                        builder.Clear();
                        builder.Append("***WvW logs:***\n");
                    }
                }
            }
            if (OtherLogs.Count > 0)
            {
                if (!builder.ToString().EndsWith("***\n"))
                {
                    builder.Append("\n\n");
                }
                builder.Append("***Other logs:***\n");
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
                    builder.Append($"[{bossName}]({log.Permalink}){duration}{successText}\n");
                    if (builder.Length >= maxAllowedMessageSize)
                    {
                        messageCount++;
                        discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString()));
                        builder.Clear();
                        builder.Append("***Other logs:***\n");
                    }
                }
            }
            if (!builder.ToString().EndsWith("***\n"))
            {
                messageCount++;
                discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString()));
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
