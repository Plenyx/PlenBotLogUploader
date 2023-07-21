﻿using Newtonsoft.Json;
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
                    Checked = webHook.Value.Active
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
                var extraJSON = (reportJSON.ExtraJson is null) ? "" : $"Recorded by: {reportJSON.ExtraJson.RecordedBy}\nDuration: {reportJSON.ExtraJson.Duration}\nElite Insights version: {reportJSON.ExtraJson.EliteInsightsVersion}";
                var icon = "";
                var bossData = Bosses.GetBossDataFromId(1);
                if (bossData is not null)
                {
                    icon = bossData.Icon;
                }
                const int colour = 16752238;
                var discordContentEmbedThumbnail = new DiscordApiJsonContentEmbedThumbnail()
                {
                    Url = icon
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
                    Thumbnail = discordContentEmbedThumbnail
                };
                // fields
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
                    squadSummary.SetColumnWidthRange(0, 3, 3);
                    squadSummary.SetColumnWidthRange(1, 10, 10);
                    squadSummary.SetColumnWidthRange(2, 10, 10);
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
                        Value = $"```{squadSummary.Render()}```"
                    };
                    // enemy summary field
                    var enemyField = new DiscordApiJsonContentEmbedField()
                    {
                        Name = "Enemy summary:",
                        Value = "```Summary could not have been generated.\nToggle detailed WvW to enable this feature.```"
                    };

                    var enemyClasses = new List<string>();

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
                        enemySummary.SetColumnWidthRange(0, 3, 3);
                        enemySummary.SetColumnWidthRange(1, 10, 10);
                        enemySummary.SetColumnWidthRange(2, 10, 10);
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
                            Value = $"```{enemySummary.Render()}```"
                        };

                        if (allWebhooks?.Any(w => w.Value?.ClassEmojis?.Any() == true) == true)
                        {
                            enemyClasses = reportJSON.ExtraJson.Targets
                            .Where(x => x.EnemyPlayer)
                            .GroupBy(x => x.Name.Split(' ').FirstOrDefault().ToUpper())
                            .OrderByDescending(x => x.Count())
                            .Select(x => $"{x.Count()} {{{x.Key}}}")
                            .ToList();
                        }
                    }
                    // damage summary
                    var damageStats = reportJSON.ExtraJson.Players
                        .Where(x => !x.FriendlyNpc && !x.NotInSquad && (x.DpsTargets.Sum(y => y[0].Damage) > 0))
                        .OrderByDescending(x => x.DpsTargets.Sum(y => y[0].Damage))
                        .Take(10)
                        .ToArray();
                    var damageSummary = new TextTable(4, tableStyle, tableBorders);
                    damageSummary.SetColumnWidthRange(0, 3, 3);
                    damageSummary.SetColumnWidthRange(1, 25, 25);
                    damageSummary.SetColumnWidthRange(2, 7, 7);
                    damageSummary.SetColumnWidthRange(3, 6, 6);
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
                        Value = $"```{damageSummary.Render()}```"
                    };
                    // cleanses summary
                    var cleansesStats = reportJSON.ExtraJson.Players
                        .Where(x => !x.FriendlyNpc && !x.NotInSquad && (x.Support[0].CondiCleanseTotal > 0))
                        .OrderByDescending(x => x.Support[0].CondiCleanseTotal)
                        .Take(10)
                        .ToArray();
                    var cleansesSummary = new TextTable(3, tableStyle, tableBorders);
                    cleansesSummary.SetColumnWidthRange(0, 3, 3);
                    cleansesSummary.SetColumnWidthRange(1, 27, 27);
                    cleansesSummary.SetColumnWidthRange(2, 12, 12);
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
                        Value = $"```{cleansesSummary.Render()}```"
                    };
                    // boon strips summary
                    var boonStripsStats = reportJSON.ExtraJson.Players
                        .Where(x => !x.FriendlyNpc && !x.NotInSquad && (x.Support[0].BoonStrips > 0))
                        .OrderByDescending(x => x.Support[0].BoonStrips)
                        .Take(10)
                        .ToArray();
                    var boonStripsSummary = new TextTable(3, tableStyle, tableBorders);
                    boonStripsSummary.SetColumnWidthRange(0, 3, 3);
                    boonStripsSummary.SetColumnWidthRange(1, 27, 27);
                    boonStripsSummary.SetColumnWidthRange(2, 12, 12);
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
                        Value = $"```{boonStripsSummary.Render()}```"
                    };

                    // healing summary
                    var healingStats = reportJSON.ExtraJson.Players
                        .Where(x => !x.FriendlyNpc && !x.NotInSquad && (x.ExtHealingStats?.OutgoingHealingAllies?.Any() == true))
                        .OrderByDescending(x => x.ExtHealingStats.OutgoingHealingAllies.Aggregate(0, (sum, next) => sum + (next.FirstOrDefault()?.Healing ?? 0), sum => sum))
                        .Take(10)
                        .ToArray();
                    var healingSummary = new TextTable(3, tableStyle, tableBorders);
                    healingSummary.SetColumnWidthRange(0, 3, 3);
                    healingSummary.SetColumnWidthRange(1, 27, 27);
                    healingSummary.SetColumnWidthRange(2, 12, 12);
                    healingSummary.AddCell("#", tableCellCenterAlign);
                    healingSummary.AddCell("Name");
                    healingSummary.AddCell("Healing", tableCellRightAlign);
                    rank = 0;
                    foreach (var player in healingStats)
                    {
                        rank++;
                        healingSummary.AddCell($"{rank}", tableCellCenterAlign);
                        healingSummary.AddCell($"{player.Name} ({player.ProfessionShort})");
                        healingSummary.AddCell($"{player.ExtHealingStats.OutgoingHealingAllies.Aggregate(0, (sum, next) => sum + (next.FirstOrDefault()?.Healing ?? 0), sum => sum)}", tableCellRightAlign);
                    }
                    var healingField = new DiscordApiJsonContentEmbedField()
                    {
                        Name = "Healing summary:",
                        Value = $"```{healingSummary.Render()}```"
                    };

                    // barrier summary
                    var barrierStats = reportJSON.ExtraJson.Players
                        .Where(x => !x.FriendlyNpc && !x.NotInSquad && (x.ExtBarrierStats?.OutgoingBarrierAllies?.Any() == true))
                        .OrderByDescending(x => x.ExtBarrierStats.OutgoingBarrierAllies.Aggregate(0, (sum, next) => sum + (next.FirstOrDefault()?.Barrier ?? 0), sum => sum))
                        .Take(10)
                        .ToArray();
                    var barrierSummary = new TextTable(3, tableStyle, tableBorders);
                    barrierSummary.SetColumnWidthRange(0, 3, 3);
                    barrierSummary.SetColumnWidthRange(1, 27, 27);
                    barrierSummary.SetColumnWidthRange(2, 12, 12);
                    barrierSummary.AddCell("#", tableCellCenterAlign);
                    barrierSummary.AddCell("Name");
                    barrierSummary.AddCell("Barrier", tableCellRightAlign);
                    rank = 0;
                    foreach (var player in barrierStats)
                    {
                        rank++;
                        barrierSummary.AddCell($"{rank}", tableCellCenterAlign);
                        barrierSummary.AddCell($"{player.Name} ({player.ProfessionShort})");
                        barrierSummary.AddCell($"{player.ExtBarrierStats.OutgoingBarrierAllies.Aggregate(0, (sum, next) => sum + (next.FirstOrDefault()?.Barrier ?? 0), sum => sum)}", tableCellRightAlign);
                    }
                    var barrierField = new DiscordApiJsonContentEmbedField()
                    {
                        Name = "Barrier summary:",
                        Value = $"```{barrierSummary.Render()}```"
                    };

                    // add the fields
                    discordContentEmbed.Fields = new List<DiscordApiJsonContentEmbedField>();

                    discordContentEmbed.Fields.Add(squadField);
                    discordContentEmbed.Fields.Add(enemyField);

                    if (enemyClasses.Count > 0)
                    {
                        discordContentEmbed.Fields.Add(new DiscordApiJsonContentEmbedField
                        {
                            Name = string.Join("    ", enemyClasses.Take(4)),
                            Value = "",
                            Inline = true
                        });
                    }
                    if (enemyClasses.Count > 4)
                    {
                        discordContentEmbed.Fields.Add(new DiscordApiJsonContentEmbedField
                        {
                            Name = string.Join("    ", enemyClasses.Skip(4).Take(4)),
                            Value = "",
                            Inline = true
                        });
                    }
                    if (enemyClasses.Count > 8)
                    {
                        discordContentEmbed.Fields.Add(new DiscordApiJsonContentEmbedField
                        {
                            Name = "",
                            Value = "",
                            Inline = false
                        });
                        discordContentEmbed.Fields.Add(new DiscordApiJsonContentEmbedField
                        {
                            Name = $"  {string.Join("     ", enemyClasses.Skip(8).Take(4))}",
                            Value = "",
                            Inline = true
                        });
                    }
                    if (enemyClasses.Count > 12)
                    {
                        discordContentEmbed.Fields.Add(new DiscordApiJsonContentEmbedField
                        {
                            Name = string.Join("    ", enemyClasses.Skip(12).Take(4)),
                            Value = "",
                            Inline = true
                        });
                    }

                    discordContentEmbed.Fields.Add(damageField);
                    discordContentEmbed.Fields.Add(healingField);
                    discordContentEmbed.Fields.Add(barrierField);
                    discordContentEmbed.Fields.Add(cleansesField);
                    discordContentEmbed.Fields.Add(boonStripsField);                    
                }
                // post to discord
                var discordContentWvW = new DiscordApiJsonContent()
                {
                    Embeds = new List<DiscordApiJsonContentEmbed>() { discordContentEmbed }
                };
                var jsonContentWvW = JsonConvert.SerializeObject(discordContentWvW);
                foreach (var key in allWebhooks.Keys)
                {
                    var webhook = allWebhooks[key];
                    if (!webhook.Active
                        || (webhook.SuccessFailToggle.Equals(DiscordWebhookDataSuccessToggle.OnSuccessOnly) && !(reportJSON.Encounter.Success ?? false))
                        || (webhook.SuccessFailToggle.Equals(DiscordWebhookDataSuccessToggle.OnFailOnly) && (reportJSON.Encounter.Success ?? false))
                        || (webhook.BossesDisable.Contains(reportJSON.Encounter.BossId))
                        || (!webhook.Team.IsSatisfied(players)))
                    {
                        continue;
                    }
                    try
                    {
                        foreach (var (className, emojiCode) in webhook.ClassEmojis)
                        {
                            jsonContentWvW = jsonContentWvW.Replace($"{{{className}}}", emojiCode);
                        }
                        var uri = new Uri(webhook.Url);
                        using var content = new StringContent(jsonContentWvW, Encoding.UTF8, "application/json");
                        using var response = await mainLink.HttpClientController.PostAsync(uri, content);
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
                var extraJSON = (reportJSON.ExtraJson is null) ? "" : $"Recorded by: {reportJSON.ExtraJson.RecordedBy}\nDuration: {reportJSON.ExtraJson.Duration}\nElite Insights version: {reportJSON.ExtraJson.EliteInsightsVersion}\n";
                var icon = "";
                var bossData = Bosses.GetBossDataFromId(reportJSON.Encounter.BossId);
                if (bossData is not null)
                {
                    bossName = bossData.Name + (reportJSON.ChallengeMode ? " CM" : "");
                    icon = bossData.Icon;
                }
                var colour = (reportJSON.Encounter.Success ?? false) ? 32768 : 16711680;
                var discordContentEmbedThumbnail = new DiscordApiJsonContentEmbedThumbnail()
                {
                    Url = icon
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
                    Thumbnail = discordContentEmbedThumbnail
                };
                var discordContentWithoutPlayers = new DiscordApiJsonContent()
                {
                    Embeds = new List<DiscordApiJsonContentEmbed>() { discordContentEmbed }
                };
                var discordContentEmbedForPlayers = new DiscordApiJsonContentEmbed()
                {
                    Title = bossName,
                    Url = reportJSON.ConfigAwarePermalink,
                    Description = $"{extraJSON}Result: {successString}\narcdps version: {reportJSON.Evtc.Type}{reportJSON.Evtc.Version}",
                    Colour = colour,
                    TimeStamp = timestamp,
                    Thumbnail = discordContentEmbedThumbnail
                };
                if (reportJSON.Players.Values.Count <= 10)
                {
                    var fields = new List<DiscordApiJsonContentEmbedField>();
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
                        fields.Add(new DiscordApiJsonContentEmbedField()
                        {
                            Name = "Players in squad/group:",
                            Value = $"```{playerNames.Render()}```"
                        });
                    }
                    else
                    {
                        // player list
                        var playerNames = new TextTable(2, tableStyle, tableBorders);
                        playerNames.SetColumnWidthRange(0, 21, 21);
                        playerNames.SetColumnWidthRange(1, 20, 20);
                        playerNames.AddCell("Character");
                        playerNames.AddCell("Account name");
                        foreach (var player in reportJSON.ExtraJson.Players.Where(x => !x.FriendlyNpc).OrderBy(x => x.Name))
                        {
                            playerNames.AddCell($"{player.Name}");
                            playerNames.AddCell($"{player.Account}");
                        }
                        fields.Add(new DiscordApiJsonContentEmbedField()
                        {
                            Name = "Players in squad/group:",
                            Value = $"```{playerNames.Render()}```"
                        });
                        var numberOfRealTargers = reportJSON.ExtraJson.Targets
                            .Count(x => !x.IsFake);
                        // damage summary
                        var targetDps = reportJSON.ExtraJson.GetPlayerTargetDPS();
                        var damageStats = reportJSON.ExtraJson.Players
                            .Where(x => !x.FriendlyNpc)
                            .Select(x => new
                            {
                                Player = x,
                                DPS = (numberOfRealTargers > 0) ? targetDps[x] : x.DpsAll[0].Dps
                            })
                            .OrderByDescending(x => x.DPS)
                            .Take(10)
                            .ToArray();
                        var dpsTargetSummary = new TextTable(3, tableStyle, TableVisibleBorders.HEADER_AND_FOOTER);
                        dpsTargetSummary.SetColumnWidthRange(0, 5, 5);
                        dpsTargetSummary.SetColumnWidthRange(1, 27, 27);
                        dpsTargetSummary.SetColumnWidthRange(2, 8, 8);
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
                        fields.Add(new DiscordApiJsonContentEmbedField()
                        {
                            Name = "DPS target summary:",
                            Value = $"```{dpsTargetSummary.Render()}```"
                        });
                    }
                    discordContentEmbedForPlayers.Fields = fields;
                }
                var discordContentWithPlayers = new DiscordApiJsonContent()
                {
                    Embeds = new List<DiscordApiJsonContentEmbed>() { discordContentEmbedForPlayers }
                };
                var jsonContentWithoutPlayers = JsonConvert.SerializeObject(discordContentWithoutPlayers);
                var jsonContentWithPlayers = JsonConvert.SerializeObject(discordContentWithPlayers);
                foreach (var key in allWebhooks.Keys)
                {
                    var webhook = allWebhooks[key];
                    if (!webhook.Active
                        || (webhook.SuccessFailToggle.Equals(DiscordWebhookDataSuccessToggle.OnSuccessOnly) && !(reportJSON.Encounter.Success ?? false))
                        || (webhook.SuccessFailToggle.Equals(DiscordWebhookDataSuccessToggle.OnFailOnly) && (reportJSON.Encounter.Success ?? false))
                        || (webhook.BossesDisable.Contains(reportJSON.Encounter.BossId))
                        || (!webhook.AllowUnknownBossIds && (bossData is null))
                        || (!webhook.Team.IsSatisfied(players)))
                    {
                        continue;
                    }
                    try
                    {
                        var uri = new Uri(webhook.Url);
                        if (webhook.ShowPlayers)
                        {
                            using var content = new StringContent(jsonContentWithPlayers, Encoding.UTF8, "application/json");
                            await mainLink.HttpClientController.PostAsync(uri, content);
                        }
                        else
                        {
                            using var content = new StringContent(jsonContentWithoutPlayers, Encoding.UTF8, "application/json");
                            await mainLink.HttpClientController.PostAsync(uri, content);
                        }
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
                if (allWebhooks.Count > 0)
                {
                    mainLink.AddToText(">:> All active webhooks executed.");
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
                Embeds = discordEmbeds.SuccessFailure
            });
            var jsonContentSuccess = JsonConvert.SerializeObject(new DiscordApiJsonContent()
            {
                Content = contentText,
                Embeds = discordEmbeds.Success
            });
            var jsonContentFailure = JsonConvert.SerializeObject(new DiscordApiJsonContent()
            {
                Content = contentText,
                Embeds = discordEmbeds.Failure
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

                var uri = new Uri(webhook.Url);
                using var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                await mainLink.HttpClientController.PostAsync(uri, content);
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
