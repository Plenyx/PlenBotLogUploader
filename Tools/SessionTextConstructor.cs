using PlenBotLogUploader.DiscordAPI;
using PlenBotLogUploader.DPSReport;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PlenBotLogUploader.Tools
{
    internal static class SessionTextConstructor
    {
        #region definitions
        // fields
        private static readonly DiscordAPIJSONContentEmbedThumbnail defaultThumbnail = new()
        {
            Url = "https://wiki.guildwars2.com/images/5/5e/Legendary_Insight.png"
        };
        private static readonly DiscordAPIJSONContentEmbedThumbnail defaultWvWSummaryThumbnail = new()
        {
            Url = "https://wiki.guildwars2.com/images/5/54/Commander_tag_(blue).png"
        };
        // consts
        private const int maxAllowedMessageSize = 1750;
        #endregion

        internal static DiscordAPIJSONContentEmbed MakeEmbedFromText(string title, string text)
            => new()
            {
                Title = title,
                Description = text,
                Colour = 32768,
                TimeStamp = DateTime.UtcNow.ToString("o"),
                Thumbnail = defaultThumbnail
            };

        internal static DiscordEmbeds ConstructSessionEmbeds(List<DPSReportJSON> reportsJSON, LogSessionSettings logSessionSettings)
        {
            var discordEmbedsSuccessFailure = new List<DiscordAPIJSONContentEmbed>();
            var discordEmbedsSuccess = new List<DiscordAPIJSONContentEmbed>();
            var discordEmbedsFailure = new List<DiscordAPIJSONContentEmbed>();
            DiscordAPIJSONContentEmbed discordEmbedSummary = null;

            var RaidLogs = (logSessionSettings.SortBy.Equals(LogSessionSortBy.Wing)) ?
                reportsJSON
                    .Where(x => Bosses.GetWingForBoss(x.EVTC.BossId) > 0)
                    .Select(x => new { LogData = x, RaidWing = Bosses.GetWingForBoss(x.EVTC.BossId) })
                    .OrderBy(x => Bosses.GetWingForBoss(x.LogData.EVTC.BossId))
                    .ThenBy(x => Bosses.GetBossOrder(x.LogData.Encounter.BossId))
                    .ThenBy(x => x.LogData.UploadTime)
                    .ToArray() :
                reportsJSON
                    .Where(x => Bosses.GetWingForBoss(x.EVTC.BossId) > 0)
                    .Select(x => new { LogData = x, RaidWing = Bosses.GetWingForBoss(x.EVTC.BossId) })
                    .OrderBy(x => x.LogData.UploadTime)
                    .ToArray();
            var FractalLogs = reportsJSON
                .Where(x => Bosses.All
                    .Any(y => y.BossId.Equals(x.EVTC.BossId) && y.Type.Equals(BossType.Fractal)))
                .ToArray();
            var StrikeLogs = reportsJSON
                .Where(x => Bosses.All
                    .Any(y => y.BossId.Equals(x.EVTC.BossId) && y.Type.Equals(BossType.Strike)))
                .ToArray();
            var GolemLogs = reportsJSON
                .Where(x => Bosses.All
                    .Any(y => y.BossId.Equals(x.EVTC.BossId) && y.Type.Equals(BossType.Golem)))
                .ToArray();
            var WvWLogs = reportsJSON
                .Where(x => Bosses.All
                    .Any(y => y.BossId.Equals(x.EVTC.BossId) && y.Type.Equals(BossType.WvW)))
                .ToArray();
            var OtherLogs = reportsJSON
                .Where(x =>
                    Bosses.All
                        .Any(y => y.BossId.Equals(x.EVTC.BossId) && y.Type.Equals(BossType.None)) ||
                    !Bosses.All
                        .Any(y => y.BossId.Equals(x.EVTC.BossId)))
                .ToArray();

            var durationText = $"Session duration: **{logSessionSettings.ElapsedTime}**";
            var builderSuccessFailure = ((WvWLogs.Length > 0) && logSessionSettings.MakeWvWSummaryEmbed) ? new StringBuilder() : new StringBuilder($"{durationText}\n\n");
            var builderSuccess = ((WvWLogs.Length > 0) && logSessionSettings.MakeWvWSummaryEmbed) ? new StringBuilder() : new StringBuilder($"{durationText}\n\n");
            var builderFailure = ((WvWLogs.Length > 0) && logSessionSettings.MakeWvWSummaryEmbed) ? new StringBuilder() : new StringBuilder($"{durationText}\n\n");
            int messageSuccessFailureCount = 0, messageSuccessCount = 0, messageFailureCount = 0;

            if (RaidLogs.Length > 0)
            {
                builderSuccessFailure.Append("***Raid logs:***\n");
                if (logSessionSettings.SortBy.Equals(LogSessionSortBy.UploadTime))
                {
                    foreach (var data in RaidLogs.AsSpan())
                    {
                        var bossName = data.LogData.Encounter.Boss + (data.LogData.ChallengeMode ? " CM" : string.Empty);
                        var bossData = Bosses.GetBossDataFromId(data.LogData.Encounter.BossId);
                        if (bossData is not null)
                        {
                            bossName = bossData.Name + (data.LogData.ChallengeMode ? " CM" : string.Empty);
                        }
                        var duration = (data.LogData.ExtraJSON is null) ? string.Empty : $" {data.LogData.ExtraJSON.Duration}";
                        string successText = string.Empty;
                        if (logSessionSettings.ShowSuccess)
                        {
                            if (data.LogData.Encounter.Success ?? false)
                            {
                                successText = " :white_check_mark:";
                            }
                            else
                            {
                                successText = " ❌";
                            }
                        }

                        builderSuccessFailure.Append('[').Append(bossName).Append("](").Append(data.LogData.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                        if (builderSuccessFailure.Length >= maxAllowedMessageSize)
                        {
                            messageSuccessFailureCount++;
                            discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessFailureCount > 1) ? $" part {messageSuccessFailureCount}" : string.Empty), builderSuccessFailure.ToString()));
                            builderSuccessFailure.Clear();
                            builderSuccessFailure.Append("***Raid logs:***\n");
                        }
                        if (data.LogData.Encounter.Success ?? false)
                        {
                            builderSuccess.Append('[').Append(bossName).Append("](").Append(data.LogData.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                            if (builderSuccess.Length >= maxAllowedMessageSize)
                            {
                                messageSuccessCount++;
                                discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessCount > 1) ? $" part {messageSuccessCount}" : string.Empty), builderSuccess.ToString()));
                                builderSuccess.Clear();
                                builderSuccess.Append("***Raid logs:***\n");
                            }
                        }
                        else
                        {
                            builderFailure.Append('[').Append(bossName).Append("](").Append(data.LogData.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                            if (builderFailure.Length >= maxAllowedMessageSize)
                            {
                                messageFailureCount++;
                                discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageFailureCount > 1) ? $" part {messageFailureCount}" : string.Empty), builderFailure.ToString()));
                                builderFailure.Clear();
                                builderFailure.Append("***Raid logs:***\n");
                            }
                        }
                    }
                }
                else
                {
                    var lastWing = 0;
                    foreach (var data in RaidLogs.AsSpan())
                    {
                        if (!lastWing.Equals(Bosses.GetWingForBoss(data.LogData.EVTC.BossId)))
                        {
                            builderSuccessFailure.Append("**").Append(Bosses.GetWingName(data.RaidWing)).Append(" (wing ").Append(data.RaidWing).Append(")**\n");
                            builderSuccess.Append("**").Append(Bosses.GetWingName(data.RaidWing)).Append(" (wing ").Append(data.RaidWing).Append(")**\n");
                            builderFailure.Append("**").Append(Bosses.GetWingName(data.RaidWing)).Append(" (wing ").Append(data.RaidWing).Append(")**\n");
                            lastWing = Bosses.GetWingForBoss(data.LogData.EVTC.BossId);
                        }
                        var bossName = data.LogData.Encounter.Boss + (data.LogData.ChallengeMode ? " CM" : string.Empty);
                        var bossData = Bosses.GetBossDataFromId(data.LogData.Encounter.BossId);
                        if (bossData is not null)
                        {
                            bossName = bossData.Name + (data.LogData.ChallengeMode ? " CM" : string.Empty);
                        }
                        var duration = (data.LogData.ExtraJSON is null) ? string.Empty : $" {data.LogData.ExtraJSON.Duration}";
                        string successText = string.Empty;
                        if (logSessionSettings.ShowSuccess)
                        {
                            if (data.LogData.Encounter.Success ?? false)
                            {
                                successText = " :white_check_mark:";
                            }
                            else
                            {
                                successText = " ❌";
                            }
                        }

                        builderSuccessFailure.Append('[').Append(bossName).Append("](").Append(data.LogData.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                        if (builderSuccessFailure.Length >= maxAllowedMessageSize)
                        {
                            messageSuccessFailureCount++;
                            discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessFailureCount > 1) ? $" part {messageSuccessFailureCount}" : string.Empty), builderSuccessFailure.ToString()));
                            builderSuccessFailure.Clear();
                            builderSuccessFailure.Append("**").Append(Bosses.GetWingName(data.RaidWing)).Append(" (wing ").Append(data.RaidWing).Append(")**\n");
                        }
                        if (data.LogData.Encounter.Success ?? false)
                        {
                            builderSuccess.Append('[').Append(bossName).Append("](").Append(data.LogData.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                            if (builderSuccess.Length >= maxAllowedMessageSize)
                            {
                                messageSuccessCount++;
                                discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessCount > 1) ? $" part {messageSuccessCount}" : string.Empty), builderSuccess.ToString()));
                                builderSuccess.Clear();
                                builderSuccess.Append("***Raid logs:***\n");
                            }
                        }
                        else
                        {
                            builderFailure.Append('[').Append(bossName).Append("](").Append(data.LogData.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                            if (builderFailure.Length >= maxAllowedMessageSize)
                            {
                                messageFailureCount++;
                                discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageFailureCount > 1) ? $" part {messageFailureCount}" : string.Empty), builderFailure.ToString()));
                                builderFailure.Clear();
                                builderFailure.Append("***Raid logs:***\n");
                            }
                        }
                    }
                }
            }
            if (FractalLogs.Length > 0)
            {
                if (!builderSuccessFailure.ToString().EndsWith("***\n"))
                {
                    builderSuccessFailure.Append("\n\n");
                }
                if (!builderSuccess.ToString().EndsWith("***\n"))
                {
                    builderSuccess.Append("\n\n");
                }
                if (!builderFailure.ToString().EndsWith("***\n"))
                {
                    builderFailure.Append("\n\n");
                }
                builderSuccessFailure.Append("***Fractal logs:***\n");
                builderSuccess.Append("***Fractal logs:***\n");
                builderFailure.Append("***Fractal logs:***\n");
                foreach (var log in FractalLogs.AsSpan())
                {
                    var bossName = log.Encounter.Boss;
                    var bossData = Bosses.GetBossDataFromId(log.Encounter.BossId);
                    if (bossData is not null)
                    {
                        bossName = bossData.Name + (log.ChallengeMode ? " CM" : string.Empty);
                    }
                    var duration = (log.ExtraJSON is null) ? string.Empty : $" {log.ExtraJSON.Duration}";
                    string successText = string.Empty;
                    if (logSessionSettings.ShowSuccess)
                    {
                        if (log.Encounter.Success ?? false)
                        {
                            successText = " :white_check_mark:";
                        }
                        else
                        {
                            successText = " ❌";
                        }
                    }

                    builderSuccessFailure.Append('[').Append(bossName).Append("](").Append(log.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                    if (builderSuccessFailure.Length >= maxAllowedMessageSize)
                    {
                        messageSuccessFailureCount++;
                        discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessFailureCount > 1) ? $" part {messageSuccessFailureCount}" : string.Empty), builderSuccessFailure.ToString()));
                        builderSuccessFailure.Clear();
                        builderSuccessFailure.Append("***Fractal logs:***\n");
                    }
                    if (log.Encounter.Success ?? false)
                    {
                        builderSuccess.Append('[').Append(bossName).Append("](").Append(log.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                        if (builderSuccess.Length >= maxAllowedMessageSize)
                        {
                            messageSuccessCount++;
                            discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessCount > 1) ? $" part {messageSuccessCount}" : string.Empty), builderSuccess.ToString()));
                            builderSuccess.Clear();
                            builderSuccess.Append("***Fractal logs:***\n");
                        }
                    }
                    else
                    {
                        builderFailure.Append('[').Append(bossName).Append("](").Append(log.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                        if (builderFailure.Length >= maxAllowedMessageSize)
                        {
                            messageFailureCount++;
                            discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageFailureCount > 1) ? $" part {messageFailureCount}" : string.Empty), builderFailure.ToString()));
                            builderFailure.Clear();
                            builderFailure.Append("***Fractal logs:***\n");
                        }
                    }
                }
            }
            if (StrikeLogs.Length > 0)
            {
                if (!builderSuccessFailure.ToString().EndsWith("***\n"))
                {
                    builderSuccessFailure.Append("\n\n");
                }
                if (!builderSuccess.ToString().EndsWith("***\n"))
                {
                    builderSuccess.Append("\n\n");
                }
                if (!builderFailure.ToString().EndsWith("***\n"))
                {
                    builderFailure.Append("\n\n");
                }
                builderSuccessFailure.Append("***Strike mission logs:***\n");
                builderSuccess.Append("***Strike mission logs:***\n");
                builderFailure.Append("***Strike mission logs:***\n");
                foreach (var log in StrikeLogs.AsSpan())
                {
                    var bossName = log.Encounter.Boss;
                    var bossData = Bosses.GetBossDataFromId(log.Encounter.BossId);
                    if (bossData is not null)
                    {
                        bossName = bossData.Name;
                    }
                    var duration = (log.ExtraJSON is null) ? string.Empty : $" {log.ExtraJSON.Duration}";
                    string successText = string.Empty;
                    if (logSessionSettings.ShowSuccess)
                    {
                        if (log.Encounter.Success ?? false)
                        {
                            successText = " :white_check_mark:";
                        }
                        else
                        {
                            successText = " ❌";
                        }
                    }

                    builderSuccessFailure.Append('[').Append(bossName).Append("](").Append(log.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                    if (builderSuccessFailure.Length >= maxAllowedMessageSize)
                    {
                        messageSuccessFailureCount++;
                        discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessFailureCount > 1) ? $" part {messageSuccessFailureCount}" : string.Empty), builderSuccessFailure.ToString()));
                        builderSuccessFailure.Clear();
                        builderSuccessFailure.Append("***Strike mission logs:***\n");
                    }
                    if (log.Encounter.Success ?? false)
                    {
                        builderSuccess.Append('[').Append(bossName).Append("](").Append(log.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                        if (builderSuccess.Length >= maxAllowedMessageSize)
                        {
                            messageSuccessCount++;
                            discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessCount > 1) ? $" part {messageSuccessCount}" : string.Empty), builderSuccess.ToString()));
                            builderSuccess.Clear();
                            builderSuccess.Append("***Strike mission logs:***\n");
                        }
                    }
                    else
                    {
                        builderFailure.Append('[').Append(bossName).Append("](").Append(log.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                        if (builderFailure.Length >= maxAllowedMessageSize)
                        {
                            messageFailureCount++;
                            discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageFailureCount > 1) ? $" part {messageFailureCount}" : string.Empty), builderFailure.ToString()));
                            builderFailure.Clear();
                            builderFailure.Append("***Strike mission logs:***\n");
                        }
                    }
                }
            }
            if (GolemLogs.Length > 0)
            {
                if (!builderSuccessFailure.ToString().EndsWith("***\n"))
                {
                    builderSuccessFailure.Append("\n\n");
                }
                if (!builderSuccess.ToString().EndsWith("***\n"))
                {
                    builderSuccess.Append("\n\n");
                }
                if (!builderFailure.ToString().EndsWith("***\n"))
                {
                    builderFailure.Append("\n\n");
                }
                builderSuccessFailure.Append("***Golem logs:***\n");
                builderSuccess.Append("***Golem logs:***\n");
                builderFailure.Append("***Golem logs:***\n");
                foreach (var log in GolemLogs.AsSpan())
                {
                    builderSuccessFailure.Append(log.ConfigAwarePermalink).Append('\n');
                    if (builderSuccessFailure.Length >= maxAllowedMessageSize)
                    {
                        messageSuccessFailureCount++;
                        discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessFailureCount > 1) ? $" part {messageSuccessFailureCount}" : string.Empty), builderSuccessFailure.ToString()));
                        builderSuccessFailure.Clear();
                        builderSuccessFailure.Append("***Golem logs:***\n");
                    }
                    if (log.Encounter.Success ?? false)
                    {
                        builderSuccess.Append(log.ConfigAwarePermalink).Append('\n');
                        if (builderSuccess.Length >= maxAllowedMessageSize)
                        {
                            messageSuccessCount++;
                            discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessCount > 1) ? $" part {messageSuccessCount}" : string.Empty), builderSuccess.ToString()));
                            builderSuccess.Clear();
                            builderSuccess.Append("***Golem logs:***\n");
                        }
                    }
                    else
                    {
                        builderFailure.Append(log.ConfigAwarePermalink).Append('\n');
                        if (builderFailure.Length >= maxAllowedMessageSize)
                        {
                            messageFailureCount++;
                            discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageFailureCount > 1) ? $" part {messageFailureCount}" : string.Empty), builderFailure.ToString()));
                            builderFailure.Clear();
                            builderFailure.Append("***Golem logs:***\n");
                        }
                    }
                }
            }
            if (WvWLogs.Length > 0)
            {
                if (logSessionSettings.MakeWvWSummaryEmbed)
                {
                    var totalEnemyKills = WvWLogs.Select(x =>
                        x.ExtraJSON?.Players
                            .Where(y => !y.FriendNPC && !y.NotInSquad)
                            .Select(y => y.StatsTargets.Select(z => z[0].Killed).Sum())
                            .Sum()
                        ?? 0)
                    .Sum();
                    var totalSquadDeaths = WvWLogs.Select(x =>
                        x.ExtraJSON?.Players
                            .Where(y => !y.FriendNPC && !y.NotInSquad)
                            .Select(y => y.Defenses[0].DeadCount)
                            .Sum()
                        ?? 0)
                    .Sum();
                    discordEmbedSummary = MakeEmbedFromText($"{logSessionSettings.Name} - WvW Summary", $"{durationText}\n\n" +
                        $"Total kills: **{totalEnemyKills}**\nTotal kills per minute: **{Math.Round(totalEnemyKills / logSessionSettings.ElapsedTimeSpan.TotalMinutes, 3).ToString(CultureInfo.InvariantCulture.NumberFormat)}**\n\n" +
                        $"Total squad deaths: **{totalSquadDeaths}**\nTotal squad deaths per minute: **{Math.Round(totalSquadDeaths / logSessionSettings.ElapsedTimeSpan.TotalMinutes, 3).ToString(CultureInfo.InvariantCulture.NumberFormat)}**\n\n" +
                        $"Kill Death Ratio:: **{Math.Round((double)(totalEnemyKills / totalSquadDeaths), 2).ToString(CultureInfo.InvariantCulture.NumberFormat)}**");
                    discordEmbedSummary.Thumbnail = defaultWvWSummaryThumbnail;
                }
                if (!builderSuccessFailure.ToString().EndsWith("***\n"))
                {
                    builderSuccessFailure.Append("\n\n");
                }
                if (!builderSuccess.ToString().EndsWith("***\n"))
                {
                    builderSuccess.Append("\n\n");
                }
                if (!builderFailure.ToString().EndsWith("***\n"))
                {
                    builderFailure.Append("\n\n");
                }
                builderSuccessFailure.Append("***WvW logs:***\n");
                builderSuccess.Append("***WvW logs:***\n");
                builderFailure.Append("***WvW logs:***\n");
                foreach (var log in WvWLogs.AsSpan())
                {
                    builderSuccessFailure.Append(log.ConfigAwarePermalink).Append('\n');
                    if (builderSuccessFailure.Length >= maxAllowedMessageSize)
                    {
                        messageSuccessFailureCount++;
                        discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessFailureCount > 1) ? $" part {messageSuccessFailureCount}" : string.Empty), builderSuccessFailure.ToString()));
                        builderSuccessFailure.Clear();
                        builderSuccessFailure.Append("***WvW logs:***\n");
                    }
                    if (log.Encounter.Success ?? false)
                    {
                        builderSuccess.Append(log.ConfigAwarePermalink).Append('\n');
                        if (builderSuccess.Length >= maxAllowedMessageSize)
                        {
                            messageSuccessCount++;
                            discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessCount > 1) ? $" part {messageSuccessCount}" : string.Empty), builderSuccess.ToString()));
                            builderSuccess.Clear();
                            builderSuccess.Append("***WvW logs:***\n");
                        }
                    }
                    else
                    {
                        builderFailure.Append(log.ConfigAwarePermalink).Append('\n');
                        if (builderFailure.Length >= maxAllowedMessageSize)
                        {
                            messageFailureCount++;
                            discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageFailureCount > 1) ? $" part {messageFailureCount}" : string.Empty), builderFailure.ToString()));
                            builderFailure.Clear();
                            builderFailure.Append("***WvW logs:***\n");
                        }
                    }
                }
            }
            if (OtherLogs.Length > 0)
            {
                if (!builderSuccessFailure.ToString().EndsWith("***\n"))
                {
                    builderSuccessFailure.Append("\n\n");
                }
                if (!builderSuccess.ToString().EndsWith("***\n"))
                {
                    builderSuccess.Append("\n\n");
                }
                if (!builderFailure.ToString().EndsWith("***\n"))
                {
                    builderFailure.Append("\n\n");
                }
                builderSuccessFailure.Append("***Other logs:***\n");
                builderSuccess.Append("***Other logs:***\n");
                builderFailure.Append("***Other logs:***\n");
                foreach (var log in OtherLogs.AsSpan())
                {
                    var bossName = log.Encounter.Boss;
                    var bossData = Bosses.GetBossDataFromId(log.Encounter.BossId);
                    if (bossData is not null)
                    {
                        bossName = bossData.Name;
                    }
                    var duration = (log.ExtraJSON is null) ? string.Empty : $" {log.ExtraJSON.Duration}";
                    string successText = string.Empty;
                    if (logSessionSettings.ShowSuccess)
                    {
                        if (log.Encounter.Success ?? false)
                        {
                            successText = " :white_check_mark:";
                        }
                        else
                        {
                            successText = " ❌";
                        }
                    }

                    builderSuccessFailure.Append('[').Append(bossName).Append("](").Append(log.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                    if (builderSuccessFailure.Length >= maxAllowedMessageSize)
                    {
                        messageSuccessFailureCount++;
                        discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessFailureCount > 1) ? $" part {messageSuccessFailureCount}" : string.Empty), builderSuccessFailure.ToString()));
                        builderSuccessFailure.Clear();
                        builderSuccessFailure.Append("***Other logs:***\n");
                    }
                    if (log.Encounter.Success ?? false)
                    {
                        builderSuccess.Append('[').Append(bossName).Append("](").Append(log.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                        if (builderSuccess.Length >= maxAllowedMessageSize)
                        {
                            messageSuccessCount++;
                            discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessCount > 1) ? $" part {messageSuccessCount}" : string.Empty), builderSuccess.ToString()));
                            builderSuccess.Clear();
                            builderSuccess.Append("***Other logs:***\n");
                        }
                    }
                    else
                    {
                        builderFailure.Append('[').Append(bossName).Append("](").Append(log.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                        if (builderFailure.Length >= maxAllowedMessageSize)
                        {
                            messageFailureCount++;
                            discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageFailureCount > 1) ? $" part {messageFailureCount}" : string.Empty), builderFailure.ToString()));
                            builderFailure.Clear();
                            builderFailure.Append("***Other logs:***\n");
                        }
                    }
                }
            }
            if (!builderSuccessFailure.ToString().EndsWith("***\n"))
            {
                messageSuccessFailureCount++;
                discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessFailureCount > 1) ? $" part {messageSuccessFailureCount}" : string.Empty), builderSuccessFailure.ToString()));
            }
            if (!builderSuccess.ToString().EndsWith("***\n"))
            {
                messageSuccessCount++;
                discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageSuccessCount > 1) ? $" part {messageSuccessCount}" : string.Empty), builderSuccess.ToString()));
            }
            if (!builderFailure.ToString().EndsWith("***\n"))
            {
                messageFailureCount++;
                discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + ((messageFailureCount > 1) ? $" part {messageFailureCount}" : string.Empty), builderFailure.ToString()));
            }
            if (discordEmbedSummary is not null)
            {
                discordEmbedsSuccessFailure.Insert(0, discordEmbedSummary);
                discordEmbedsSuccess.Insert(0, discordEmbedSummary);
                discordEmbedsFailure.Insert(0, discordEmbedSummary);
            }
            return new DiscordEmbeds() { Summary = discordEmbedSummary, SuccessFailure = discordEmbedsSuccessFailure, Success = discordEmbedsSuccess, Failure = discordEmbedsFailure };
        }

        public class DiscordEmbeds
        {
            public DiscordAPIJSONContentEmbed Summary { get; internal set; }

            public List<DiscordAPIJSONContentEmbed> SuccessFailure { get; internal set; }

            public List<DiscordAPIJSONContentEmbed> Success { get; internal set; }

            public List<DiscordAPIJSONContentEmbed> Failure { get; internal set; }
        }
    }
}
