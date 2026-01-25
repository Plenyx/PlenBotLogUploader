using PlenBotLogUploader.DiscordApi;
using PlenBotLogUploader.DpsReport;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ZLinq;

namespace PlenBotLogUploader.Tools;

internal static class SessionTextConstructor
{
    // constants
    private const int maxAllowedMessageSize = 1750;

    // fields
    private static readonly DiscordApiJsonContentEmbedThumbnail DefaultThumbnail = new()
    {
        Url = "https://wiki.guildwars2.com/images/5/5e/Legendary_Insight.png",
    };
    private static readonly DiscordApiJsonContentEmbedThumbnail DefaultWvWSummaryThumbnail = new()
    {
        Url = "https://wiki.guildwars2.com/images/5/54/Commander_tag_(blue).png",
    };

    private static DiscordApiJsonContentEmbed MakeEmbedFromText(string title, string text)
        => new()
        {
            Title = title,
            Description = text,
            Colour = 32768,
            TimeStamp = DateTime.UtcNow.ToString("o"),
            Thumbnail = DefaultThumbnail,
        };

    internal static DiscordEmbeds ConstructSessionEmbeds(List<DpsReportJson> reportsJson, LogSessionSettings logSessionSettings)
    {
        var discordEmbedsSuccessFailure = new List<DiscordApiJsonContentEmbed>();
        var discordEmbedsSuccess = new List<DiscordApiJsonContentEmbed>();
        var discordEmbedsFailure = new List<DiscordApiJsonContentEmbed>();
        DiscordApiJsonContentEmbed discordEmbedSummary = null;

        var raidEncounterLogs = logSessionSettings.SortBy.Equals(LogSessionSortBy.RaidEncounterCategories) ?
            reportsJson
                .AsValueEnumerable()
                .Where(x => Bosses.GetCategoryForBoss(x.Evtc.BossId) > 0)
                .Select(x => new { LogData = x, RaidEncounterCategory = Bosses.GetCategoryForBoss(x.Evtc.BossId) })
                .OrderBy(x => (int)x.RaidEncounterCategory)
                .ThenBy(x => Bosses.GetBossOrder(x.LogData.Encounter.BossId))
                .ThenBy(x => x.LogData.UploadTime)
                .ToArray() :
            reportsJson
                .AsValueEnumerable()
                .Where(x => Bosses.GetCategoryForBoss(x.Evtc.BossId) > 0)
                .Select(x => new { LogData = x, RaidEncounterCategory = Bosses.GetCategoryForBoss(x.Evtc.BossId) })
                .OrderBy(x => x.LogData.UploadTime)
                .ToArray();
        var fractalLogs = reportsJson
            .AsValueEnumerable()
            .Where(x => Bosses.All.AsValueEnumerable()
                .Any(y => y.BossId.Equals(x.Evtc.BossId) && y.Type.Equals(BossType.Fractal)))
            .ToArray();
        var golemLogs = reportsJson
            .AsValueEnumerable()
            .Where(x => Bosses.All.AsValueEnumerable()
                .Any(y => y.BossId.Equals(x.Evtc.BossId) && y.Type.Equals(BossType.Golem)))
            .ToArray();
        var wvwLogs = reportsJson
            .AsValueEnumerable()
            .Where(x => Bosses.All.AsValueEnumerable()
                .Any(y => y.BossId.Equals(x.Evtc.BossId) && y.Type.Equals(BossType.WvW)))
            .ToArray();
        var otherLogs = reportsJson
            .AsValueEnumerable()
            .Where(x =>
                Bosses.All.AsValueEnumerable()
                    .Any(y => y.BossId.Equals(x.Evtc.BossId) && y.Type.Equals(BossType.None)) ||
                !Bosses.All
                    .Any(y => y.BossId.Equals(x.Evtc.BossId)))
            .ToArray();

        var durationText = $"Session duration: **{logSessionSettings.ElapsedTime}**";
        var builderSuccessFailure = wvwLogs.Length > 0 && logSessionSettings.MakeWvWSummaryEmbed ? new StringBuilder() : new StringBuilder($"{durationText}\n\n");
        var builderSuccess = wvwLogs.Length > 0 && logSessionSettings.MakeWvWSummaryEmbed ? new StringBuilder() : new StringBuilder($"{durationText}\n\n");
        var builderFailure = wvwLogs.Length > 0 && logSessionSettings.MakeWvWSummaryEmbed ? new StringBuilder() : new StringBuilder($"{durationText}\n\n");
        int messageSuccessFailureCount = 0, messageSuccessCount = 0, messageFailureCount = 0;

        if (raidEncounterLogs.Length > 0)
        {
            builderSuccessFailure.Append("***Raid encounter logs:***\n");
            if (logSessionSettings.SortBy.Equals(LogSessionSortBy.UploadTime))
            {
                foreach (var data in raidEncounterLogs.AsValueEnumerable())
                {
                    var bossName = data.LogData.Encounter.Boss + (data.LogData.ChallengeMode ? " CM" : "");
                    var bossData = Bosses.GetBossDataFromId(data.LogData.Encounter.BossId);
                    if (bossData is not null)
                    {
                        bossName = bossData.FightName(data.LogData);
                    }
                    var duration = data.LogData.ExtraJson is null ? "" : $" {data.LogData.ExtraJson.Duration}";
                    var successText = "";
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
                        discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + (messageSuccessFailureCount > 1 ? $" part {messageSuccessFailureCount}" : ""), builderSuccessFailure.ToString()));
                        builderSuccessFailure.Clear();
                        builderSuccessFailure.Append("***Raid encounter logs:***\n");
                    }
                    if (data.LogData.Encounter.Success ?? false)
                    {
                        builderSuccess.Append('[').Append(bossName).Append("](").Append(data.LogData.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                        if (builderSuccess.Length >= maxAllowedMessageSize)
                        {
                            messageSuccessCount++;
                            discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + (messageSuccessCount > 1 ? $" part {messageSuccessCount}" : ""), builderSuccess.ToString()));
                            builderSuccess.Clear();
                            builderSuccess.Append("***Raid encounter logs:***\n");
                        }
                    }
                    else
                    {
                        builderFailure.Append('[').Append(bossName).Append("](").Append(data.LogData.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                        if (builderFailure.Length >= maxAllowedMessageSize)
                        {
                            messageFailureCount++;
                            discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + (messageFailureCount > 1 ? $" part {messageFailureCount}" : ""), builderFailure.ToString()));
                            builderFailure.Clear();
                            builderFailure.Append("***Raid encounter logs:***\n");
                        }
                    }
                }
            }
            else
            {
                var lastCategory = RaidEncounterCategory.Unknown;
                foreach (var data in raidEncounterLogs.AsValueEnumerable())
                {
                    if (!lastCategory.Equals(Bosses.GetCategoryForBoss(data.LogData.Evtc.BossId)))
                    {
                        builderSuccessFailure.Append("**").Append(Bosses.GetRaidEncounterCategoryName(data.RaidEncounterCategory)).Append("**\n");
                        builderSuccess.Append("**").Append(Bosses.GetRaidEncounterCategoryName(data.RaidEncounterCategory)).Append("**\n");
                        builderFailure.Append("**").Append(Bosses.GetRaidEncounterCategoryName(data.RaidEncounterCategory)).Append("**\n");
                        lastCategory = Bosses.GetCategoryForBoss(data.LogData.Evtc.BossId);
                    }
                    var bossName = data.LogData.Encounter.Boss + (data.LogData.ChallengeMode ? " CM" : "");
                    var bossData = Bosses.GetBossDataFromId(data.LogData.Encounter.BossId);
                    if (bossData is not null)
                    {
                        bossName = bossData.FightName(data.LogData);
                    }
                    var duration = data.LogData.ExtraJson is null ? "" : $" {data.LogData.ExtraJson.Duration}";
                    var successText = "";
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
                        discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + (messageSuccessFailureCount > 1 ? $" part {messageSuccessFailureCount}" : ""), builderSuccessFailure.ToString()));
                        builderSuccessFailure.Clear();
                        builderSuccessFailure.Append("**").Append(Bosses.GetRaidEncounterCategoryName(data.RaidEncounterCategory)).Append("**\n");
                    }
                    if (data.LogData.Encounter.Success ?? false)
                    {
                        builderSuccess.Append('[').Append(bossName).Append("](").Append(data.LogData.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                        if (builderSuccess.Length >= maxAllowedMessageSize)
                        {
                            messageSuccessCount++;
                            discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + (messageSuccessCount > 1 ? $" part {messageSuccessCount}" : ""), builderSuccess.ToString()));
                            builderSuccess.Clear();
                            builderSuccess.Append("***Raid encounter logs:***\n");
                        }
                    }
                    else
                    {
                        builderFailure.Append('[').Append(bossName).Append("](").Append(data.LogData.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                        if (builderFailure.Length >= maxAllowedMessageSize)
                        {
                            messageFailureCount++;
                            discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + (messageFailureCount > 1 ? $" part {messageFailureCount}" : ""), builderFailure.ToString()));
                            builderFailure.Clear();
                            builderFailure.Append("***Raid encounter logs:***\n");
                        }
                    }
                }
            }
        }
        if (fractalLogs.Length > 0)
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
            foreach (var log in fractalLogs.AsValueEnumerable())
            {
                var bossName = log.Encounter.Boss;
                var bossData = Bosses.GetBossDataFromId(log.Encounter.BossId);
                if (bossData is not null)
                {
                    bossName = bossData.FightName(log);
                }
                var duration = log.ExtraJson is not null ? $" {log.ExtraJson.Duration}" : "";
                var successText = "";
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
                    discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + (messageSuccessFailureCount > 1 ? $" part {messageSuccessFailureCount}" : ""), builderSuccessFailure.ToString()));
                    builderSuccessFailure.Clear();
                    builderSuccessFailure.Append("***Fractal logs:***\n");
                }
                if (log.Encounter.Success ?? false)
                {
                    builderSuccess.Append('[').Append(bossName).Append("](").Append(log.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                    if (builderSuccess.Length >= maxAllowedMessageSize)
                    {
                        messageSuccessCount++;
                        discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + (messageSuccessCount > 1 ? $" part {messageSuccessCount}" : ""), builderSuccess.ToString()));
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
                        discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + (messageFailureCount > 1 ? $" part {messageFailureCount}" : ""), builderFailure.ToString()));
                        builderFailure.Clear();
                        builderFailure.Append("***Fractal logs:***\n");
                    }
                }
            }
        }
        if (golemLogs.Length > 0)
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
            foreach (var log in golemLogs.AsValueEnumerable())
            {
                builderSuccessFailure.Append(log.ConfigAwarePermalink).Append('\n');
                if (builderSuccessFailure.Length >= maxAllowedMessageSize)
                {
                    messageSuccessFailureCount++;
                    discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + (messageSuccessFailureCount > 1 ? $" part {messageSuccessFailureCount}" : ""), builderSuccessFailure.ToString()));
                    builderSuccessFailure.Clear();
                    builderSuccessFailure.Append("***Golem logs:***\n");
                }
                if (log.Encounter.Success ?? false)
                {
                    builderSuccess.Append(log.ConfigAwarePermalink).Append('\n');
                    if (builderSuccess.Length >= maxAllowedMessageSize)
                    {
                        messageSuccessCount++;
                        discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + (messageSuccessCount > 1 ? $" part {messageSuccessCount}" : ""), builderSuccess.ToString()));
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
                        discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + (messageFailureCount > 1 ? $" part {messageFailureCount}" : ""), builderFailure.ToString()));
                        builderFailure.Clear();
                        builderFailure.Append("***Golem logs:***\n");
                    }
                }
            }
        }
        if (wvwLogs.Length > 0)
        {
            if (logSessionSettings.MakeWvWSummaryEmbed)
            {
                var totalEnemyKills = wvwLogs.Select(x =>
                        x.ExtraJson?.Players
                            .Where(y => !y.FriendlyNpc && !y.NotInSquad)
                            .Select(y => y.StatsTargets.Select(z => z[0].Killed).Sum())
                            .Sum()
                        ?? 0)
                    .Sum();
                var totalSquadDeaths = wvwLogs.Select(x =>
                        x.ExtraJson?.Players
                            .Where(y => !y.FriendlyNpc && !y.NotInSquad)
                            .Select(y => y.Defenses[0].DeadCount)
                            .Sum()
                        ?? 0)
                    .Sum();
                discordEmbedSummary = MakeEmbedFromText($"{logSessionSettings.Name} - WvW Summary", $"{durationText}\n\n" +
                                                                                                    $"Total kills: **{totalEnemyKills}**\nTotal kills per minute: **{Math.Round(totalEnemyKills / logSessionSettings.ElapsedTimeSpan.TotalMinutes, 3).ToString(CultureInfo.InvariantCulture.NumberFormat)}**\n\n" +
                                                                                                    $"Total squad deaths: **{totalSquadDeaths}**\nTotal squad deaths per minute: **{Math.Round(totalSquadDeaths / logSessionSettings.ElapsedTimeSpan.TotalMinutes, 3).ToString(CultureInfo.InvariantCulture.NumberFormat)}**\n\n" +
                                                                                                    $"Kill Death Ratio: **{Math.Round((double)(totalEnemyKills / (totalSquadDeaths == 0 ? 1 : totalSquadDeaths)), 2).ToString(CultureInfo.InvariantCulture.NumberFormat)}**");
                discordEmbedSummary.Thumbnail = DefaultWvWSummaryThumbnail;
            }
            if (logSessionSettings.EnableWvWLogList)
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
                builderSuccessFailure.Append("***WvW logs:***\n");
                builderSuccess.Append("***WvW logs:***\n");
                builderFailure.Append("***WvW logs:***\n");
                foreach (var log in wvwLogs.AsValueEnumerable())
                {
                    builderSuccessFailure.Append(log.ConfigAwarePermalink).Append('\n');
                    if (builderSuccessFailure.Length >= maxAllowedMessageSize)
                    {
                        messageSuccessFailureCount++;
                        discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + (messageSuccessFailureCount > 1 ? $" part {messageSuccessFailureCount}" : ""), builderSuccessFailure.ToString()));
                        builderSuccessFailure.Clear();
                        builderSuccessFailure.Append("***WvW logs:***\n");
                    }
                    if (log.Encounter.Success ?? false)
                    {
                        builderSuccess.Append(log.ConfigAwarePermalink).Append('\n');
                        if (builderSuccess.Length >= maxAllowedMessageSize)
                        {
                            messageSuccessCount++;
                            discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + (messageSuccessCount > 1 ? $" part {messageSuccessCount}" : ""), builderSuccess.ToString()));
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
                            discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + (messageFailureCount > 1 ? $" part {messageFailureCount}" : ""), builderFailure.ToString()));
                            builderFailure.Clear();
                            builderFailure.Append("***WvW logs:***\n");
                        }
                    }
                }
            }
        }
        if (otherLogs.Length > 0)
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
            foreach (var log in otherLogs.AsValueEnumerable())
            {
                var bossName = Bosses.GetBossDataFromId(log.Encounter.BossId)?.Name ?? log.Encounter.Boss;
                var duration = log.ExtraJson is not null ? $" {log.ExtraJson.Duration}" : "";
                var successText = "";
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
                    discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + (messageSuccessFailureCount > 1 ? $" part {messageSuccessFailureCount}" : ""), builderSuccessFailure.ToString()));
                    builderSuccessFailure.Clear();
                    builderSuccessFailure.Append("***Other logs:***\n");
                }
                if (log.Encounter.Success ?? false)
                {
                    builderSuccess.Append('[').Append(bossName).Append("](").Append(log.ConfigAwarePermalink).Append(')').Append(duration).Append(successText).Append('\n');
                    if (builderSuccess.Length >= maxAllowedMessageSize)
                    {
                        messageSuccessCount++;
                        discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + (messageSuccessCount > 1 ? $" part {messageSuccessCount}" : ""), builderSuccess.ToString()));
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
                        discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + (messageFailureCount > 1 ? $" part {messageFailureCount}" : ""), builderFailure.ToString()));
                        builderFailure.Clear();
                        builderFailure.Append("***Other logs:***\n");
                    }
                }
            }
        }
        if (!builderSuccessFailure.ToString().EndsWith("***\n"))
        {
            if (builderSuccessFailure.Length != 0)
            {
                messageSuccessFailureCount++;
                discordEmbedsSuccessFailure.Add(MakeEmbedFromText(logSessionSettings.Name + (messageSuccessFailureCount > 1 ? $" part {messageSuccessFailureCount}" : ""), builderSuccessFailure.ToString()));
            }
        }
        if (!builderSuccess.ToString().EndsWith("***\n"))
        {
            if (builderSuccess.Length != 0)
            {
                messageSuccessCount++;
                discordEmbedsSuccess.Add(MakeEmbedFromText(logSessionSettings.Name + (messageSuccessCount > 1 ? $" part {messageSuccessCount}" : ""), builderSuccess.ToString()));
            }
        }
        if (!builderFailure.ToString().EndsWith("***\n"))
        {
            if (builderFailure.Length != 0)
            {
                messageFailureCount++;
                discordEmbedsFailure.Add(MakeEmbedFromText(logSessionSettings.Name + (messageFailureCount > 1 ? $" part {messageFailureCount}" : ""), builderFailure.ToString()));
            }
        }
        if (discordEmbedSummary is not null)
        {
            discordEmbedsSuccessFailure.Insert(0, discordEmbedSummary);
            discordEmbedsSuccess.Insert(0, discordEmbedSummary);
            discordEmbedsFailure.Insert(0, discordEmbedSummary);
        }
        return new DiscordEmbeds
        {
            Summary = discordEmbedSummary,
            SuccessFailure = discordEmbedsSuccessFailure,
            Success = discordEmbedsSuccess,
            Failure = discordEmbedsFailure,
        };
    }

    public class DiscordEmbeds
    {
        public DiscordApiJsonContentEmbed Summary { get; internal set; }

        public List<DiscordApiJsonContentEmbed> SuccessFailure { get; internal set; }

        public List<DiscordApiJsonContentEmbed> Success { get; internal set; }

        public List<DiscordApiJsonContentEmbed> Failure { get; internal set; }
    }
}
