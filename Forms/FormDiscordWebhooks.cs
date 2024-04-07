using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.DiscordApi;
using PlenBotLogUploader.DpsReport;
using PlenBotLogUploader.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextTableFormatter;

namespace PlenBotLogUploader
{
    public partial class FormDiscordWebhooks : Form
    {
        #region definitions
        // fields
        private readonly FormMain mainLink;
        private int webhookIdsKey;
        private readonly IDictionary<int, DiscordWebhookData> allWebhooks;
        private readonly CellStyle tableCellRightAlign = new(CellHorizontalAlignment.Right);
        private readonly CellStyle tableCellCenterAlign = new(CellHorizontalAlignment.Center);
        private readonly TableBordersStyle tableStyle = TableBordersStyle.HORIZONTAL_ONLY;
        private readonly TableVisibleBorders tableBorders = TableVisibleBorders.HEADER_ONLY;
        #endregion

        internal FormDiscordWebhooks(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;

            allWebhooks = DiscordWebhooks.LoadDiscordWebhooks();

            webhookIdsKey = allWebhooks.Count;

            foreach (var webHook in allWebhooks)
            {
                listViewDiscordWebhooks.Items.Add(new ListViewItem
                {
                    Name = webHook.Key.ToString(),
                    Text = webHook.Value.Name,
                    Checked = webHook.Value.Active,
                });
            }
        }

        private void FormDiscordPings_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            DiscordWebhooks.SaveToJson(allWebhooks, DiscordWebhooks.JsonFileLocation);
        }

        internal async Task ExecuteAllActiveWebhooksAsync(DpsReportJson reportJSON, List<LogPlayer> players)
        {
            if (reportJSON.Encounter.BossId.Equals(1)) // WvW
            {
                var extraJSONFightName = (reportJSON.ExtraJson is null) ? reportJSON.Encounter.Boss : reportJSON.ExtraJson.FightName;
                var extraJSON = (reportJSON.ExtraJson is null) ? "" : $"Recorded by: {reportJSON.ExtraJson.RecordedByAccountName}\nDuration: {reportJSON.ExtraJson.Duration}\nElite Insights version: {reportJSON.ExtraJson.EliteInsightsVersion}";
                var icon = "";
                var bossData = Bosses.GetBossDataFromId(1);
                if (bossData is not null)
                {
                    icon = bossData.Icon;
                }
                const int colour = 16752238;
                var discordContentEmbedThumbnail = new DiscordApiJsonContentEmbedThumbnail()
                {
                    Url = icon,
                };
                var timestampDateTime = DateTime.UtcNow;
                if (reportJSON.ExtraJson is not null)
                {
                    timestampDateTime = reportJSON.ExtraJson.TimeStart;
                }
                var timestamp = timestampDateTime.ToString("o");
                var discordContentEmbed = new DiscordApiJsonContentEmbed()
                {
                    Title = extraJSONFightName,
                    Url = reportJSON.ConfigAwarePermalink,
                    Description = $"{extraJSON}\narcdps version: {reportJSON.Evtc.Type}{reportJSON.Evtc.Version}",
                    Colour = colour,
                    TimeStamp = timestamp,
                    Thumbnail = discordContentEmbedThumbnail,
                };
                var discordContentEmbedSpacer = new DiscordApiJsonContentEmbed()
                {
                    Title = "Log summary",
                    Description = DiscordApiJsonContent.Spacer,
                    Colour = colour,
                    TimeStamp = timestamp,
                };
                // fields
                var discordContentEmbedSquadAndPlayers = new List<DiscordApiJsonContentEmbedField>();
                var discordContentEmbedSquad = new List<DiscordApiJsonContentEmbedField>();
                var discordContentEmbedPlayers = new List<DiscordApiJsonContentEmbedField>();
                var discordContentEmbedNone = new List<DiscordApiJsonContentEmbedField>();
                if (reportJSON.ExtraJson is not null)
                {
                    // squad summary
                    var squadPlayers = reportJSON.ExtraJson.Players
                        .Count(x => !x.FriendlyNpc && !x.NotInSquad);
                    var squadDamage = reportJSON.ExtraJson.Players
                        .Where(x => !x.FriendlyNpc && !x.NotInSquad)
                        .Select(x => x.DpsTargets.Sum(y => y.Sum(z => z.Damage)))
                        .Sum();
                    var squadDps = reportJSON.ExtraJson.Players
                        .Where(x => !x.FriendlyNpc && !x.NotInSquad)
                        .Select(x => x.DpsTargets.Sum(y => y.Sum(z => z.Dps)))
                        .Sum();
                    var squadDowns = reportJSON.ExtraJson.Players
                        .Where(x => !x.FriendlyNpc && !x.NotInSquad)
                        .Select(x => x.Defenses[0].DownCount)
                        .Sum();
                    var squadDeaths = reportJSON.ExtraJson.Players
                        .Where(x => !x.FriendlyNpc && !x.NotInSquad)
                        .Select(x => x.Defenses[0].DeadCount)
                        .Sum();
                    var squadSummary = new TextTable(5, tableStyle, tableBorders);
                    squadSummary.SetColumnWidthRange(0, 4, 4);
                    squadSummary.SetColumnWidthRange(1, 13, 13);
                    squadSummary.SetColumnWidthRange(2, 11, 11);
                    squadSummary.SetColumnWidthRange(3, 8, 8);
                    squadSummary.SetColumnWidthRange(4, 8, 8);
                    squadSummary.AddCell("#", tableCellCenterAlign);
                    squadSummary.AddCell("DMG", tableCellCenterAlign);
                    squadSummary.AddCell("DPS", tableCellCenterAlign);
                    squadSummary.AddCell("Downs", tableCellCenterAlign);
                    squadSummary.AddCell("Deaths", tableCellCenterAlign);
                    squadSummary.AddCell($"{squadPlayers}", tableCellCenterAlign);
                    squadSummary.AddCell($"{squadDamage.ParseAsK()}", tableCellCenterAlign);
                    squadSummary.AddCell($"{squadDps.ParseAsK()}", tableCellCenterAlign);
                    squadSummary.AddCell($"{squadDowns}", tableCellCenterAlign);
                    squadSummary.AddCell($"{squadDeaths}", tableCellCenterAlign);
                    var squadField = new DiscordApiJsonContentEmbedField()
                    {
                        Name = "Squad summary:",
                        Value = $"```{squadSummary.Render()}```",
                    };
                    // enemy summary
                    var enemyField = new DiscordApiJsonContentEmbedField()
                    {
                        Name = "Enemy summary:",
                        Value = "```Summary could not have been generated.\nToggle detailed WvW to enable this feature.```",
                    };
                    if (reportJSON.ExtraJson.Targets.Length > 1)
                    {
                        var enemyPlayers = reportJSON.ExtraJson.Targets
                            .Length - 1;
                        var enemyDamage = reportJSON.ExtraJson.Targets
                            .Where(x => !x.IsFake)
                            .Select(x => x.DpsAll[0].Damage)
                            .Sum();
                        var enemyDps = reportJSON.ExtraJson.Targets
                            .Where(x => !x.IsFake)
                            .Select(x => x.DpsAll[0].Dps)
                            .Sum();
                        var enemyDowns = reportJSON.ExtraJson.Players
                            .Where(x => !x.FriendlyNpc && !x.NotInSquad)
                            .Select(x => x.StatsTargets.Select(y => y[0].Downed).Sum())
                            .Sum();
                        var enemyDeaths = reportJSON.ExtraJson.Players
                            .Where(x => !x.FriendlyNpc && !x.NotInSquad)
                            .Select(x => x.StatsTargets.Select(y => y[0].Killed).Sum())
                            .Sum();
                        var enemySummary = new TextTable(5, tableStyle, tableBorders);
                        enemySummary.SetColumnWidthRange(0, 4, 4);
                        enemySummary.SetColumnWidthRange(1, 13, 13);
                        enemySummary.SetColumnWidthRange(2, 11, 11);
                        enemySummary.SetColumnWidthRange(3, 8, 8);
                        enemySummary.SetColumnWidthRange(4, 8, 8);
                        enemySummary.AddCell("#", tableCellCenterAlign);
                        enemySummary.AddCell("DMG", tableCellCenterAlign);
                        enemySummary.AddCell("DPS", tableCellCenterAlign);
                        enemySummary.AddCell("Downs", tableCellCenterAlign);
                        enemySummary.AddCell("Deaths", tableCellCenterAlign);
                        enemySummary.AddCell($"{enemyPlayers}", tableCellCenterAlign);
                        enemySummary.AddCell($"{enemyDamage.ParseAsK()}", tableCellCenterAlign);
                        enemySummary.AddCell($"{enemyDps.ParseAsK()}", tableCellCenterAlign);
                        enemySummary.AddCell($"{enemyDowns}", tableCellCenterAlign);
                        enemySummary.AddCell($"{enemyDeaths}", tableCellCenterAlign);
                        enemyField = new DiscordApiJsonContentEmbedField()
                        {
                            Name = "Enemy summary:",
                            Value = $"```{enemySummary.Render()}```",
                        };
                    }
                    // damage summary
                    var damageStats = reportJSON.ExtraJson.Players
                        .Where(x => !x.FriendlyNpc && !x.NotInSquad && (x.DpsTargets.Sum(y => y[0].Damage) > 0))
                        .OrderByDescending(x => x.DpsTargets.Sum(y => y[0].Damage))
                        .Take(10)
                        .ToArray();
                    var damageSummary = new TextTable(4, tableStyle, tableBorders);
                    damageSummary.SetColumnWidthRange(0, 3, 3);
                    damageSummary.SetColumnWidthRange(1, 22, 22);
                    damageSummary.SetColumnWidthRange(2, 11, 11);
                    damageSummary.SetColumnWidthRange(3, 9, 9);
                    damageSummary.AddCell("#", tableCellCenterAlign);
                    damageSummary.AddCell("Name");
                    damageSummary.AddCell("DMG", tableCellRightAlign);
                    damageSummary.AddCell("DPS", tableCellRightAlign);
                    var rank = 0;
                    foreach (var player in damageStats)
                    {
                        rank++;
                        damageSummary.AddCell($"{rank}", tableCellCenterAlign);
                        damageSummary.AddCell($"{player.Name} ({player.ProfessionShort})");
                        damageSummary.AddCell($"{player.DpsTargets.Sum(y => y[0].Damage).ParseAsK()}", tableCellRightAlign);
                        damageSummary.AddCell($"{player.DpsTargets.Sum(y => y[0].Dps).ParseAsK()}", tableCellRightAlign);
                    }
                    var damageField = new DiscordApiJsonContentEmbedField()
                    {
                        Name = "Damage summary:",
                        Value = $"```{damageSummary.Render()}```",
                    };
                    // cleanses summary
                    var cleansesStats = reportJSON.ExtraJson.Players
                        .Where(x => !x.FriendlyNpc && !x.NotInSquad && (x.Support[0].CondiCleanseTotal > 0))
                        .OrderByDescending(x => x.Support[0].CondiCleanseTotal)
                        .Take(10)
                        .ToArray();
                    var cleansesSummary = new TextTable(3, tableStyle, tableBorders);
                    cleansesSummary.SetColumnWidthRange(0, 3, 3);
                    cleansesSummary.SetColumnWidthRange(1, 29, 29);
                    cleansesSummary.SetColumnWidthRange(2, 14, 14);
                    cleansesSummary.AddCell("#", tableCellCenterAlign);
                    cleansesSummary.AddCell("Name");
                    cleansesSummary.AddCell("Cleanses", tableCellRightAlign);
                    rank = 0;
                    foreach (var player in cleansesStats)
                    {
                        rank++;
                        cleansesSummary.AddCell($"{rank}", tableCellCenterAlign);
                        cleansesSummary.AddCell($"{player.Name} ({player.ProfessionShort})");
                        cleansesSummary.AddCell($"{player.Support[0].CondiCleanseTotal}", tableCellRightAlign);
                    }
                    var cleansesField = new DiscordApiJsonContentEmbedField()
                    {
                        Name = "Cleanses summary:",
                        Value = $"```{cleansesSummary.Render()}```",
                    };
                    // boon strips summary
                    var boonStripsStats = reportJSON.ExtraJson.Players
                        .Where(x => !x.FriendlyNpc && !x.NotInSquad && (x.Support[0].BoonStrips > 0))
                        .OrderByDescending(x => x.Support[0].BoonStrips)
                        .Take(10)
                        .ToArray();
                    var boonStripsSummary = new TextTable(3, tableStyle, tableBorders);
                    boonStripsSummary.SetColumnWidthRange(0, 3, 3);
                    boonStripsSummary.SetColumnWidthRange(1, 29, 29);
                    boonStripsSummary.SetColumnWidthRange(2, 14, 14);
                    boonStripsSummary.AddCell("#", tableCellCenterAlign);
                    boonStripsSummary.AddCell("Name");
                    boonStripsSummary.AddCell("Strips", tableCellRightAlign);
                    rank = 0;
                    foreach (var player in boonStripsStats)
                    {
                        rank++;
                        boonStripsSummary.AddCell($"{rank}", tableCellCenterAlign);
                        boonStripsSummary.AddCell($"{player.Name} ({player.ProfessionShort})");
                        boonStripsSummary.AddCell($"{player.Support[0].BoonStrips}", tableCellRightAlign);
                    }
                    var boonStripsField = new DiscordApiJsonContentEmbedField()
                    {
                        Name = "Boon strips summary:",
                        Value = $"```{boonStripsSummary.Render()}```",
                    };
                    // healing summary
                    DiscordApiJsonContentEmbedField healingField = null;
                    if ((reportJSON?.ExtraJson?.Players?[0]?.StatsHealing ?? null) is not null)
                    {
                        var healingStats = reportJSON.ExtraJson.Players
                            .Where(x => !x.FriendlyNpc && !x.NotInSquad && ((x.StatsHealing?.TotalHealingOnSquad ?? 0) > 0))
                            .OrderByDescending(x => x.StatsHealing?.TotalHealingOnSquad ?? 0)
                            .Take(10)
                            .ToArray();
                        var healingSummary = new TextTable(3, tableStyle, tableBorders);
                        healingSummary.SetColumnWidthRange(0, 3, 3);
                        healingSummary.SetColumnWidthRange(1, 29, 29);
                        healingSummary.SetColumnWidthRange(2, 14, 14);
                        healingSummary.AddCell("#", tableCellCenterAlign);
                        healingSummary.AddCell("Name");
                        healingSummary.AddCell("Healing", tableCellRightAlign);
                        rank = 0;
                        foreach (var player in healingStats)
                        {
                            rank++;
                            healingSummary.AddCell($"{rank}", tableCellCenterAlign);
                            healingSummary.AddCell($"{player.Name} ({player.ProfessionShort})");
                            healingSummary.AddCell($"{(player.StatsHealing?.TotalHealingOnSquad ?? 0).ParseAsK()}", tableCellRightAlign);
                        }
                        healingField = new DiscordApiJsonContentEmbedField()
                        {
                            Name = "Healing summary:",
                            Value = $"```{healingSummary.Render()}```",
                        };
                    }
                    // barrier summary
                    DiscordApiJsonContentEmbedField barrierField = null;
                    if ((reportJSON?.ExtraJson?.Players?[0]?.StatsBarrier ?? null) is not null)
                    {
                        var barrierStats = reportJSON.ExtraJson.Players
                            .Where(x => !x.FriendlyNpc && !x.NotInSquad && ((x.StatsBarrier?.TotalBarrierOnSquad ?? 0) > 0))
                            .OrderByDescending(x => x.StatsBarrier?.TotalBarrierOnSquad ?? 0)
                            .Take(10)
                            .ToArray();
                        var barrierSummary = new TextTable(3, tableStyle, tableBorders);
                        barrierSummary.SetColumnWidthRange(0, 3, 3);
                        barrierSummary.SetColumnWidthRange(1, 29, 29);
                        barrierSummary.SetColumnWidthRange(2, 14, 14);
                        barrierSummary.AddCell("#", tableCellCenterAlign);
                        barrierSummary.AddCell("Name");
                        barrierSummary.AddCell("Barrier", tableCellRightAlign);
                        rank = 0;
                        foreach (var player in barrierStats)
                        {
                            rank++;
                            barrierSummary.AddCell($"{rank}", tableCellCenterAlign);
                            barrierSummary.AddCell($"{player.Name} ({player.ProfessionShort})");
                            barrierSummary.AddCell($"{(player.StatsBarrier?.TotalBarrierOnSquad ?? 0).ParseAsK()}", tableCellRightAlign);
                        }
                        barrierField = new DiscordApiJsonContentEmbedField()
                        {
                            Name = "Barrier summary:",
                            Value = $"```{barrierSummary.Render()}```",
                        };
                    }
                    // add the fields
                    discordContentEmbedSquadAndPlayers.AddRange(squadField, enemyField, damageField, cleansesField, boonStripsField, healingField, barrierField);
                    discordContentEmbedSquad.AddRange(squadField, enemyField);
                    discordContentEmbedPlayers.AddRange(damageField, cleansesField, boonStripsField, healingField, barrierField);
                }
                // post to discord
                var discordContentWvW = new DiscordApiJsonContent()
                {
                    Embeds = [discordContentEmbed],
                };
                discordContentWvW.Embeds[0].Fields = discordContentEmbedNone;
                var jsonContentWvWNone = JsonConvert.SerializeObject(discordContentWvW);
                discordContentWvW.Embeds.Add(discordContentEmbedSpacer);

                discordContentWvW.Embeds[1].Fields = discordContentEmbedSquadAndPlayers;
                var jsonContentWvWSquadAndPlayers = JsonConvert.SerializeObject(discordContentWvW);
                discordContentWvW.Embeds[1].Fields = discordContentEmbedSquad;
                var jsonContentWvWSquad = JsonConvert.SerializeObject(discordContentWvW);
                discordContentWvW.Embeds[1].Fields = discordContentEmbedPlayers;
                var jsonContentWvWPlayers = JsonConvert.SerializeObject(discordContentWvW);

                await SendLogViaWebhooks(reportJSON.Encounter.Success ?? false,
                    reportJSON.Encounter.BossId,
                    false,
                    false,
                    bossData, players,
                    jsonContentWvWNone, jsonContentWvWSquad, jsonContentWvWPlayers, jsonContentWvWSquadAndPlayers);

                if (allWebhooks.Count > 0)
                {
                    mainLink.AddToText(">:> All active webhooks executed.");
                }
                return;
            }
            else // not WvW
            {
                var bossName = $"{reportJSON.Encounter.Boss}{(reportJSON.ChallengeMode ? " CM" : "")}";
                var successString = (reportJSON.Encounter.Success ?? false) ? ":white_check_mark:" : "❌";
                var lastTarget = (reportJSON?.ExtraJson?.PossiblyLastTarget is not null) ? $"\n{reportJSON.ExtraJson.PossiblyLastTarget.Name} ({Math.Round(100 - reportJSON.ExtraJson.PossiblyLastTarget.HealthPercentBurned, 2)}%)" : "";
                var extraJSON = (reportJSON.ExtraJson is null) ? "" : $"Recorded by: {reportJSON.ExtraJson.RecordedByAccountName}\nDuration: {reportJSON.ExtraJson.Duration}{lastTarget}\nElite Insights version: {reportJSON.ExtraJson.EliteInsightsVersion}\n";
                var icon = "";
                var bossData = Bosses.GetBossDataFromId(reportJSON.Encounter.BossId);
                if (bossData is not null)
                {
                    bossName = bossData.FightName(reportJSON);
                    icon = bossData.Icon;
                }
                var colour = (reportJSON.Encounter.Success ?? false) ? 32768 : 16711680;
                var discordContentEmbedThumbnail = new DiscordApiJsonContentEmbedThumbnail()
                {
                    Url = icon,
                };
                var timestampDateTime = DateTime.UtcNow;
                if (reportJSON.ExtraJson is not null)
                {
                    timestampDateTime = reportJSON.ExtraJson.TimeStart;
                }
                var timestamp = timestampDateTime.ToString("o");
                var discordContentEmbed = new DiscordApiJsonContentEmbed()
                {
                    Title = bossName,
                    Url = reportJSON.ConfigAwarePermalink,
                    Description = $"{extraJSON}Result: {successString}\narcdps version: {reportJSON.Evtc.Type}{reportJSON.Evtc.Version}",
                    Colour = colour,
                    TimeStamp = timestamp,
                    Thumbnail = discordContentEmbedThumbnail,
                };
                var discordContentEmbedSpacer = new DiscordApiJsonContentEmbed()
                {
                    Title = "Log summary",
                    Description = DiscordApiJsonContent.Spacer,
                    Colour = colour,
                    TimeStamp = timestamp,
                };
                var discordContentEmbedSquadAndPlayers = new List<DiscordApiJsonContentEmbedField>();
                var discordContentEmbedSquad = new List<DiscordApiJsonContentEmbedField>();
                var discordContentEmbedPlayers = new List<DiscordApiJsonContentEmbedField>();
                var discordContentEmbedNone = new List<DiscordApiJsonContentEmbedField>();
                if (reportJSON.Players.Values.Count <= 10)
                {
                    if (reportJSON.ExtraJson is null)
                    {
                        // player list
                        var playerNames = new TextTable(2, tableStyle, tableBorders);
                        playerNames.SetColumnWidthRange(0, 21, 21);
                        playerNames.SetColumnWidthRange(1, 20, 20);
                        playerNames.AddCell("Character");
                        playerNames.AddCell("Account name");
                        foreach (var player in reportJSON.Players.Values)
                        {
                            playerNames.AddCell($"{player.CharacterName}");
                            playerNames.AddCell($"{player.DisplayName}");
                        }
                        var squadEmbedField = new DiscordApiJsonContentEmbedField()
                        {
                            Name = "Players in squad/group:",
                            Value = $"```{playerNames.Render()}```",
                        };
                        discordContentEmbedSquadAndPlayers.Add(squadEmbedField);
                        discordContentEmbedSquad.Add(squadEmbedField);
                    }
                    else
                    {
                        // player list
                        var playerNames = new TextTable(2, tableStyle, tableBorders);
                        playerNames.SetColumnWidthRange(0, 23, 23);
                        playerNames.SetColumnWidthRange(1, 23, 23);
                        playerNames.AddCell("Character");
                        playerNames.AddCell("Account name");
                        foreach (var player in reportJSON.ExtraJson.Players.Where(x => !x.FriendlyNpc).OrderBy(x => x.Name))
                        {
                            playerNames.AddCell($"{player.Name}");
                            playerNames.AddCell($"{player.Account}");
                        }
                        var squadEmbedField = new DiscordApiJsonContentEmbedField()
                        {
                            Name = "Players in squad/group:",
                            Value = $"```{playerNames.Render()}```",
                        };
                        discordContentEmbedSquadAndPlayers.Add(squadEmbedField);
                        discordContentEmbedSquad.Add(squadEmbedField);
                        var numberOfRealTargers = reportJSON.ExtraJson.Targets
                            .Count(x => !x.IsFake);
                        // damage summary
                        var targetDps = reportJSON.ExtraJson.GetPlayerTargetDPS();
                        var damageStats = reportJSON.ExtraJson.Players
                            .Where(x => !x.FriendlyNpc)
                            .Select(x => new
                            {
                                Player = x,
                                DPS = (numberOfRealTargers > 0) ? targetDps[x] : x.DpsAll[0].Dps,
                            })
                            .OrderByDescending(x => x.DPS)
                            .Take(10)
                            .ToArray();
                        var dpsTargetSummary = new TextTable(3, tableStyle, TableVisibleBorders.HEADER_AND_FOOTER);
                        dpsTargetSummary.SetColumnWidthRange(0, 5, 5);
                        dpsTargetSummary.SetColumnWidthRange(1, 31, 31);
                        dpsTargetSummary.SetColumnWidthRange(2, 10, 10);
                        dpsTargetSummary.AddCell("#", tableCellCenterAlign);
                        dpsTargetSummary.AddCell("Name");
                        dpsTargetSummary.AddCell("DPS", tableCellRightAlign);
                        var rank = 0;
                        foreach (var player in damageStats)
                        {
                            rank++;
                            dpsTargetSummary.AddCell($"{rank}", tableCellCenterAlign);
                            dpsTargetSummary.AddCell($"{player.Player.Name} ({player.Player.ProfessionShort})");
                            dpsTargetSummary.AddCell($"{player.DPS.ParseAsK()}", tableCellRightAlign);
                        }
                        dpsTargetSummary.AddCell("");
                        dpsTargetSummary.AddCell("Total");
                        var totalDPS = damageStats
                            .Select(x => x.DPS)
                            .Sum();
                        dpsTargetSummary.AddCell($"{totalDPS.ParseAsK()}", tableCellRightAlign);
                        var playersEmbedField = new DiscordApiJsonContentEmbedField()
                        {
                            Name = "DPS target summary:",
                            Value = $"```{dpsTargetSummary.Render()}```",
                        };
                        discordContentEmbedSquadAndPlayers.Add(playersEmbedField);
                        discordContentEmbedPlayers.Add(playersEmbedField);
                    }
                }

                var discordContent = new DiscordApiJsonContent()
                {
                    Embeds = [discordContentEmbed],
                };
                discordContent.Embeds[0].Fields = discordContentEmbedNone;
                var jsonContentNone = JsonConvert.SerializeObject(discordContent);
                discordContent.Embeds.Add(discordContentEmbedSpacer);

                discordContent.Embeds[1].Fields = discordContentEmbedSquadAndPlayers;
                var jsonContentSquadAndPlayers = JsonConvert.SerializeObject(discordContent);
                discordContent.Embeds[1].Fields = discordContentEmbedSquad;
                var jsonContentSquad = JsonConvert.SerializeObject(discordContent);
                discordContent.Embeds[1].Fields = discordContentEmbedPlayers;
                var jsonContentPlayers = JsonConvert.SerializeObject(discordContent);

                await SendLogViaWebhooks(reportJSON.Encounter.Success ?? false,
                    reportJSON.Encounter.BossId,
                    reportJSON.ChallengeMode,
                    reportJSON?.ExtraJson?.IsLegendaryCm ?? false,
                    bossData, players,
                    jsonContentNone, jsonContentSquad, jsonContentPlayers, jsonContentSquadAndPlayers);

                if (allWebhooks.Count > 0)
                {
                    mainLink.AddToText(">:> All active webhooks executed.");
                }
            }
        }

        internal async Task SendLogViaWebhooks(bool success, int bossId, bool isCm, bool isLegendaryCm, BossData bossData, List<LogPlayer> players, string jsonContentNone, string jsonContentSquad, string jsonContentPlayers, string jsonContentSquadAndPlayers)
        {
            foreach (var key in allWebhooks.Keys)
            {
                var webhook = allWebhooks[key];
                if (!webhook.Active
                    || (webhook.SuccessFailToggle.Equals(DiscordWebhookDataSuccessToggle.OnSuccessOnly) && !success)
                    || (webhook.SuccessFailToggle.Equals(DiscordWebhookDataSuccessToggle.OnFailOnly) && success)
                    || (!webhook.IncludeNormalLogs && !isCm)
                    || (!webhook.IncludeChallengeModeLogs && isCm && !isLegendaryCm)
                    || (!webhook.IncludeLegendaryChallengeModeLogs && isLegendaryCm)
                    || webhook.BossesDisable.Contains(bossId)
                    || (!webhook.AllowUnknownBossIds && (bossData is null))
                    || (!webhook.Team.IsSatisfied(players)))
                {
                    continue;
                }
                try
                {
                    var jsonToSend = webhook.SummaryType switch
                    {
                        DiscordWebhookDataLogSummaryType.None => jsonContentNone,
                        DiscordWebhookDataLogSummaryType.SquadOnly => jsonContentSquad,
                        DiscordWebhookDataLogSummaryType.PlayersOnly => jsonContentPlayers,
                        _ => jsonContentSquadAndPlayers,
                    };

                    using var content = new StringContent(jsonToSend, Encoding.UTF8, "application/json");
                    using var response = await mainLink.HttpClientController.PostAsync(webhook.Url, content);
                }
                catch (UriFormatException ex)
                {
                    mainLink.AddToText($">:> An error has occured while processing URL for the webhook \"{webhook.Name}\": {ex.Message}");
                }
                catch (Exception ex)
                {
                    mainLink.AddToText($">:> An error has occured while processing the webhook \"{webhook.Name}\": {ex.Message}");
                }
            }
        }

        internal async Task ExecuteSessionWebhooksAsync(List<DpsReportJson> reportsJSON, LogSessionSettings logSessionSettings)
        {
            if (logSessionSettings.UseSelectedWebhooksInstead)
            {
                foreach (var webhook in logSessionSettings.SelectedWebhooks)
                {
                    var discordEmbeds = SessionTextConstructor.ConstructSessionEmbeds(reportsJSON.Where(x => webhook.Team.IsSatisfied(x.GetLogPlayers())).ToList(), logSessionSettings);
                    await SendDiscordMessageWebhooksAsync(webhook, discordEmbeds, logSessionSettings.ContentText);
                }
            }
            else
            {
                foreach (var webhook in allWebhooks.Values.Where(x => x.Active))
                {
                    var discordEmbeds = SessionTextConstructor.ConstructSessionEmbeds(reportsJSON.Where(x => webhook.Team.IsSatisfied(x.GetLogPlayers())).ToList(), logSessionSettings);
                    await SendDiscordMessageWebhooksAsync(webhook, discordEmbeds, logSessionSettings.ContentText);
                }
            }
            if (logSessionSettings.UseSelectedWebhooksInstead && logSessionSettings.SelectedWebhooks.Count > 0)
            {
                mainLink.AddToText(">:> All selected webhooks successfully executed with finished log session.");
            }
            else if (allWebhooks.Count > 0)
            {
                mainLink.AddToText(">:> All active webhooks successfully executed with finished log session.");
            }
        }

        private async Task SendDiscordMessageWebhooksAsync(DiscordWebhookData webhook, SessionTextConstructor.DiscordEmbeds discordEmbeds, string contentText)
        {
            var jsonContentSuccessFailure = JsonConvert.SerializeObject(new DiscordApiJsonContent()
            {
                Content = contentText,
                Embeds = discordEmbeds.SuccessFailure,
            });
            var jsonContentSuccess = JsonConvert.SerializeObject(new DiscordApiJsonContent()
            {
                Content = contentText,
                Embeds = discordEmbeds.Success,
            });
            var jsonContentFailure = JsonConvert.SerializeObject(new DiscordApiJsonContent()
            {
                Content = contentText,
                Embeds = discordEmbeds.Failure,
            });
            try
            {
                string jsonContent;
                if (webhook.SuccessFailToggle.Equals(DiscordWebhookDataSuccessToggle.OnSuccessAndFailure))
                {
                    jsonContent = jsonContentSuccessFailure;
                }
                else if (webhook.SuccessFailToggle.Equals(DiscordWebhookDataSuccessToggle.OnSuccessOnly))
                {
                    jsonContent = jsonContentSuccess;
                }
                else
                {
                    jsonContent = jsonContentFailure;
                }

                using var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                await mainLink.HttpClientController.PostAsync(webhook.Url, content);
            }
            catch
            {
                mainLink.AddToText($">:> Unable to execute webhook \"{webhook.Name}\" with a finished log session.");
            }
        }

        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (listViewDiscordWebhooks.SelectedItems.Count == 0)
            {
                return;
            }
            var selected = listViewDiscordWebhooks.SelectedItems[0];
            if (int.TryParse(selected.Name, out var reservedId))
            {
                listViewDiscordWebhooks.Items.RemoveByKey(reservedId.ToString());
                allWebhooks.Remove(reservedId);
            }
        }

        private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if (listViewDiscordWebhooks.SelectedItems.Count == 0)
            {
                return;
            }
            var selected = listViewDiscordWebhooks.SelectedItems[0];
            if (int.TryParse(selected.Name, out var reservedId))
            {
                new FormEditDiscordWebhook(this, allWebhooks[reservedId], reservedId).ShowDialog();
            }
        }

        private void ListViewDiscordWebhooks_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!int.TryParse(e.Item.Name, out var reservedId))
            {
                return;
            }
            allWebhooks[reservedId].Active = e.Item.Checked;
        }

        private void ContextMenuStripInteract_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var toggle = listViewDiscordWebhooks.SelectedItems.Count > 0;
            toolStripMenuItemEdit.Enabled = toggle;
            toolStripMenuItemDelete.Enabled = toggle;
            toolStripMenuItemTest.Enabled = toggle;
        }

        private async void ToolStripMenuItemTest_Click(object sender, EventArgs e)
        {
            if (listViewDiscordWebhooks.SelectedItems.Count == 0)
            {
                return;
            }
            var selected = listViewDiscordWebhooks.SelectedItems[0];
            if (!int.TryParse(selected.Name, out var reservedId))
            {
                return;
            }
            if (await allWebhooks[reservedId].TestWebhookAsync(mainLink.HttpClientController))
            {
                MessageBox.Show("Webhook is valid.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Webhook is not valid.\nCheck your URL.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewClick()
        {
            webhookIdsKey++;
            new FormEditDiscordWebhook(this, null, webhookIdsKey).ShowDialog();
        }

        private void ButtonAddNew_Click(object sender, EventArgs e) => AddNewClick();

        private void ToolStripMenuItemAdd_Click(object sender, EventArgs e) => AddNewClick();

        internal void CheckBoxShortenThousands_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.ShortenThousands = checkBoxShortenThousands.Checked;
            ApplicationSettings.Current.Save();
        }
    }
}
