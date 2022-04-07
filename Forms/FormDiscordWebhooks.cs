﻿using Newtonsoft.Json;
using PlenBotLogUploader.DiscordAPI;
using PlenBotLogUploader.DPSReport;
using PlenBotLogUploader.Tools;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly FormWebhookTeams teamsLink;
        private int webhookIdsKey;
        private readonly IDictionary<int, DiscordWebhookData> allWebhooks;
        private readonly CellStyle tableCellRightAlign = new CellStyle(CellHorizontalAlignment.Right);
        private readonly CellStyle tableCellCenterAlign = new CellStyle(CellHorizontalAlignment.Center);
        private readonly TableBordersStyle tableStyle = TableBordersStyle.HORIZONTAL_ONLY;
        private readonly TableVisibleBorders tableBorders = TableVisibleBorders.HEADER_ONLY;
        #endregion

        public FormDiscordWebhooks(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            teamsLink = new FormWebhookTeams();
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
            DiscordWebhooks.SaveToJson(allWebhooks,DiscordWebhooks.JsonFileLocation);
        }

        public async Task ExecuteAllActiveWebhooksAsync(DPSReportJSON reportJSON)
        {
            if (reportJSON.Encounter.BossId.Equals(1)) // WvW
            {
                var extraJSONFightName = (reportJSON.ExtraJSON is null) ? reportJSON.Encounter.Boss : reportJSON.ExtraJSON.FightName;
                var extraJSON = (reportJSON.ExtraJSON is null) ? "" : $"Recorded by: {reportJSON.ExtraJSON.RecordedBy}\nDuration: {reportJSON.ExtraJSON.Duration}\nElite Insights version: {reportJSON.ExtraJSON.EliteInsightsVersion}";
                var icon = "";
                var bossData = Bosses.GetBossDataFromId(1);
                if (!(bossData is null))
                {
                    icon = bossData.Icon;
                }
                var colour = 16752238;
                var discordContentEmbedThumbnail = new DiscordAPIJSONContentEmbedThumbnail()
                {
                    Url = icon
                };
                var timestampDateTime = DateTime.UtcNow;
                if (!(reportJSON.ExtraJSON is null))
                {
                    timestampDateTime = reportJSON.ExtraJSON.TimeStart;
                }
                var timestamp = timestampDateTime.ToString("o");
                var discordContentEmbed = new DiscordAPIJSONContentEmbed()
                {
                    Title = extraJSONFightName,
                    Url = reportJSON.Permalink,
                    Description = $"{extraJSON}\narcdps version: {reportJSON.EVTC.Type}{reportJSON.EVTC.Version}",
                    Colour = colour,
                    TimeStamp = timestamp,
                    Thumbnail = discordContentEmbedThumbnail
                };
                // fields
                if (!(reportJSON.ExtraJSON is null))
                {
                    // squad summary
                    var squadPlayers = reportJSON.ExtraJSON.Players
                        .Where(x => !x.FriendNPC && !x.NotInSquad)
                        .Count();
                    var squadDamage = reportJSON.ExtraJSON.Players
                        .Where(x => !x.FriendNPC && !x.NotInSquad)
                        .Select(x => x.DpsAll.First().Damage)
                        .Sum();
                    var squadDps = reportJSON.ExtraJSON.Players
                        .Where(x => !x.FriendNPC && !x.NotInSquad)
                        .Select(x => x.DpsAll.First().DPS)
                        .Sum();
                    var squadDowns = reportJSON.ExtraJSON.Players
                        .Where(x => !x.FriendNPC && !x.NotInSquad)
                        .Select(x => x.Defenses.First().DownCount)
                        .Sum();
                    var squadDeaths = reportJSON.ExtraJSON.Players
                        .Where(x => !x.FriendNPC && !x.NotInSquad)
                        .Select(x => x.Defenses.First().DeadCount)
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
                    var squadField = new DiscordAPIJSONContentEmbedField()
                    {
                        Name = "Squad summary:",
                        Value = $"```{squadSummary.Render()}```"
                    };
                    // enemy summary field
                    var enemyField = new DiscordAPIJSONContentEmbedField()
                    {
                        Name = "Enemy summary:",
                        Value = $"```Summary could not have been generated.\nToggle detailed WvW to enable this feature.```"
                    };
                    if (reportJSON.ExtraJSON.Targets.Count > 1)
                    {
                        var enemyPlayers = reportJSON.ExtraJSON.Targets
                            .Count() - 1;
                        var enemyDamage = reportJSON.ExtraJSON.Targets
                            .Where(x => !x.Name.Equals("Dummy WvW Agent"))
                            .Select(x => x.DpsAll.First().Damage)
                            .Sum();
                        var enemyDps = reportJSON.ExtraJSON.Targets
                            .Where(x => !x.Name.Equals("Dummy WvW Agent"))
                            .Select(x => x.DpsAll.First().DPS)
                            .Sum();
                        var enemyDowns = reportJSON.ExtraJSON.Players
                            .Where(x => !x.FriendNPC && !x.NotInSquad)
                            .Select(x => x.StatsAll.First().Downed)
                            .Sum();
                        var enemyDeaths = reportJSON.ExtraJSON.Players
                            .Where(x => !x.FriendNPC && !x.NotInSquad)
                            .Select(x => x.StatsAll.First().Killed)
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
                        enemyField = new DiscordAPIJSONContentEmbedField()
                        {
                            Name = "Enemy summary:",
                            Value = $"```{enemySummary.Render()}```"
                        };
                    }
                    // damage summary
                    var damageStats = reportJSON.ExtraJSON.Players
                        .Where(x => !x.FriendNPC && !x.NotInSquad)
                        .OrderByDescending(x => x.DpsTargets.Sum(y => y.First().Damage))
                        .Take(10)
                        .ToList();
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
                        damageSummary.AddCell($"{player.DpsTargets.Sum(y => y.First().Damage).ParseAsK()}", tableCellRightAlign);
                        damageSummary.AddCell($"{player.DpsTargets.Sum(y => y.First().DPS).ParseAsK()}", tableCellRightAlign);
                    }
                    var damageField = new DiscordAPIJSONContentEmbedField()
                    {
                        Name = "Damage summary:",
                        Value = $"```{damageSummary.Render()}```"
                    };
                    // cleanses summary
                    var cleansesStats = reportJSON.ExtraJSON.Players
                        .Where(x => !x.FriendNPC && !x.NotInSquad)
                        .Where(x => x.Support.First().CondiCleanse > 0)
                        .OrderByDescending(x => x.Support.First().CondiCleanse)
                        .Take(10)
                        .ToList();
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
                        cleansesSummary.AddCell($"{player.Support.First().CondiCleanseTotal}", tableCellRightAlign);
                    }
                    var cleansesField = new DiscordAPIJSONContentEmbedField()
                    {
                        Name = "Cleanses summary:",
                        Value = $"```{cleansesSummary.Render()}```"
                    };
                    // boon strips summary
                    var boonStripsStats = reportJSON.ExtraJSON.Players
                        .Where(x => !x.FriendNPC && !x.NotInSquad)
                        .Where(x => x.Support.First().BoonStrips > 0)
                        .OrderByDescending(x => x.Support.First().BoonStrips)
                        .Take(10)
                        .ToList();
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
                        boonStripsSummary.AddCell($"{player.Support.First().BoonStrips}", tableCellRightAlign);
                    }
                    var boonStripsField = new DiscordAPIJSONContentEmbedField()
                    {
                        Name = "Boon strips summary:",
                        Value = $"```{boonStripsSummary.Render()}```"
                    };
                    // add the fields
                    discordContentEmbed.Fields = new List<DiscordAPIJSONContentEmbedField>()
                    {
                        squadField,
                        enemyField,
                        damageField,
                        cleansesField,
                        boonStripsField
                    };
                }
                // post to discord
                var discordContentWvW = new DiscordAPIJSONContent()
                {
                    Embeds = new List<DiscordAPIJSONContentEmbed>() { discordContentEmbed }
                };
                try
                {
                    var jsonContentWvW = JsonConvert.SerializeObject(discordContentWvW);
                    foreach (var key in allWebhooks.Keys)
                    {
                        var webhook = allWebhooks[key];
                        if (!webhook.Active
                            || (webhook.SuccessFailToggle.Equals(DiscordWebhookDataSuccessToggle.OnSuccessOnly) && !(reportJSON.Encounter.Success ?? false))
                            || (webhook.SuccessFailToggle.Equals(DiscordWebhookDataSuccessToggle.OnFailOnly) && (reportJSON.Encounter.Success ?? false))
                            || (webhook.BossesDisable.Contains(reportJSON.Encounter.BossId))
                            || (!webhook.Team.IsSatisfied(reportJSON.Players)))
                        {
                            continue;
                        }
                        var uri = new Uri(webhook.URL);
                        using var content = new StringContent(jsonContentWvW, Encoding.UTF8, "application/json");
                        using var response = await mainLink.HttpClientController.PostAsync(uri, content);
                    }
                    if (allWebhooks.Count > 0)
                    {
                        mainLink.AddToText(">:> All active webhooks successfully executed.");
                    }
                }
                catch
                {
                    mainLink.AddToText(">:> Unable to execute active webhooks.");
                }
            }
            else // not WvW
            {
                var bossName = $"{reportJSON.Encounter.Boss}{(reportJSON.ChallengeMode ? " CM" : "")}";
                var successString = (reportJSON.Encounter.Success ?? false) ? ":white_check_mark:" : "❌";
                var extraJSON = (reportJSON.ExtraJSON is null) ? "" : $"Recorded by: {reportJSON.ExtraJSON.RecordedBy}\nDuration: {reportJSON.ExtraJSON.Duration}\nElite Insights version: {reportJSON.ExtraJSON.EliteInsightsVersion}\n";
                var icon = "";
                var bossData = Bosses.GetBossDataFromId(reportJSON.Encounter.BossId);
                if (!(bossData is null))
                {
                    bossName = $"{bossData.Name}{(reportJSON.ChallengeMode ? " CM" : "")}";
                    icon = bossData.Icon;
                }
                var colour = (reportJSON.Encounter.Success ?? false) ? 32768 : 16711680;
                var discordContentEmbedThumbnail = new DiscordAPIJSONContentEmbedThumbnail()
                {
                    Url = icon
                };
                var timestampDateTime = DateTime.UtcNow;
                if (!(reportJSON.ExtraJSON is null))
                {
                    timestampDateTime = reportJSON.ExtraJSON.TimeStart;
                }
                var timestamp = timestampDateTime.ToString("o");
                var discordContentEmbed = new DiscordAPIJSONContentEmbed()
                {
                    Title = bossName,
                    Url = reportJSON.Permalink,
                    Description = $"{extraJSON}Result: {successString}\narcdps version: {reportJSON.EVTC.Type}{reportJSON.EVTC.Version}",
                    Colour = colour,
                    TimeStamp = timestamp,
                    Thumbnail = discordContentEmbedThumbnail
                };
                var discordContentWithoutPlayers = new DiscordAPIJSONContent()
                {
                    Embeds = new List<DiscordAPIJSONContentEmbed>() { discordContentEmbed }
                };
                var discordContentEmbedForPlayers = new DiscordAPIJSONContentEmbed()
                {
                    Title = bossName,
                    Url = reportJSON.Permalink,
                    Description = $"{extraJSON}Result: {successString}\narcdps version: {reportJSON.EVTC.Type}{reportJSON.EVTC.Version}",
                    Colour = colour,
                    TimeStamp = timestamp,
                    Thumbnail = discordContentEmbedThumbnail
                };
                if (reportJSON.Players.Values.Count <= 10)
                {
                    var fields = new List<DiscordAPIJSONContentEmbedField>();
                    if (reportJSON.ExtraJSON is null)
                    {
                        foreach (var player in reportJSON.Players.Values)
                        {
                            fields.Add(new DiscordAPIJSONContentEmbedField() { Name = player.CharacterName, Value = $"```\n{player.DisplayName}\n\n{Players.ResolveSpecName(player.Profession, player.EliteSpec)}\n```", Inline = true });
                        }
                    }
                    else
                    {
                        // player list
                        var playerNames = new TextTable(2, tableStyle, tableBorders);
                        playerNames.SetColumnWidthRange(0, 21, 21);
                        playerNames.SetColumnWidthRange(1, 20, 20);
                        playerNames.AddCell("Character");
                        playerNames.AddCell("Account name");
                        foreach (var player in reportJSON.ExtraJSON.Players.Where(x => !x.FriendNPC).OrderBy(x => x.Name))
                        {
                            playerNames.AddCell($"{player.Name}");
                            playerNames.AddCell($"{player.Account}");
                        }
                        fields.Add(new DiscordAPIJSONContentEmbedField()
                        {
                            Name = "Players in squad/group:",
                            Value = $"```{playerNames.Render()}```"
                        });
                        var numberOfRealTargers = reportJSON.ExtraJSON.Targets
                            .Where(x => !x.IsFake)
                            .Count();
                        // damage summary
                        var damageStats = reportJSON.ExtraJSON.Players
                            .Where(x => !x.FriendNPC)
                            .Select(x => new
                            {
                                Player = x,
                                DPS = numberOfRealTargers > 0 ? reportJSON.ExtraJSON.PlayerTargetDPS[x] : x.DpsAll.First().DPS
                            })
                            .OrderByDescending(x => x.DPS)
                            .Take(10)
                            .ToList();
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
                        fields.Add(new DiscordAPIJSONContentEmbedField()
                        {
                            Name = "DPS target summary:",
                            Value = $"```{dpsTargetSummary.Render()}```"
                        });
                    }
                    discordContentEmbedForPlayers.Fields = fields;
                }
                var discordContentWithPlayers = new DiscordAPIJSONContent()
                {
                    Embeds = new List<DiscordAPIJSONContentEmbed>() { discordContentEmbedForPlayers }
                };
                try
                {
                    var jsonContentWithoutPlayers = JsonConvert.SerializeObject(discordContentWithoutPlayers);
                    var jsonContentWithPlayers = JsonConvert.SerializeObject(discordContentWithPlayers);
                    foreach (var key in allWebhooks.Keys)
                    {
                        var webhook = allWebhooks[key];
                        if (!webhook.Active
                            || (webhook.SuccessFailToggle.Equals(DiscordWebhookDataSuccessToggle.OnSuccessOnly) && !(reportJSON.Encounter.Success ?? false))
                            || (webhook.SuccessFailToggle.Equals(DiscordWebhookDataSuccessToggle.OnFailOnly) && (reportJSON.Encounter.Success ?? false))
                            || (webhook.BossesDisable.Contains(reportJSON.Encounter.BossId))
                            || (!webhook.Team.IsSatisfied(reportJSON.Players)))
                        {
                            continue;
                        }
                        var uri = new Uri(webhook.URL);
                        if (webhook.ShowPlayers)
                        {
                            using var content = new StringContent(jsonContentWithPlayers, Encoding.UTF8, "application/json");
                            using (await mainLink.HttpClientController.PostAsync(uri, content)) { }
                        }
                        else
                        {
                            using var content = new StringContent(jsonContentWithoutPlayers, Encoding.UTF8, "application/json");
                            using (await mainLink.HttpClientController.PostAsync(uri, content)) { }
                        }
                    }
                    if (allWebhooks.Count > 0)
                    {
                        mainLink.AddToText(">:> All active webhooks successfully executed.");
                    }
                }
                catch
                {
                    mainLink.AddToText(">:> Unable to execute active webhooks.");
                }
            }
        }

        public async Task ExecuteSessionWebhooksAsync(List<DPSReportJSON> reportsJSON, LogSessionSettings logSessionSettings)
        {
            var discordEmbeds = SessionTextConstructor.ConstructSessionEmbeds(reportsJSON, logSessionSettings);
            if (logSessionSettings.UseSelectedWebhooksInstead)
            {
                await SendDiscordMessageToSelectedWebhooksAsync(logSessionSettings.SelectedWebhooks, discordEmbeds, logSessionSettings.ContentText);
            }
            else
            {
                await SendDiscordMessageToAllActiveWebhooksAsync(discordEmbeds, logSessionSettings.ContentText);
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

        private async Task SendDiscordMessageToAllActiveWebhooksAsync(SessionTextConstructor.DiscordEmbeds discordEmbeds, string contentText)
        {
            var jsonContentSuccessFailure = JsonConvert.SerializeObject(new DiscordAPIJSONContent()
            {
                Content = contentText,
                Embeds = discordEmbeds.SuccessFailure
            });
            var jsonContentSuccess = JsonConvert.SerializeObject(new DiscordAPIJSONContent()
            {
                Content = contentText,
                Embeds = discordEmbeds.Success
            });
            var jsonContentFailure = JsonConvert.SerializeObject(new DiscordAPIJSONContent()
            {
                Content = contentText,
                Embeds = discordEmbeds.Failure
            });
            try
            {
                foreach (var key in allWebhooks.Keys)
                {
                    var webhook = allWebhooks[key];
                    if (!webhook.Active)
                    {
                        continue;
                    }
                    var jsonContent =
                        (webhook.SuccessFailToggle.Equals(DiscordWebhookDataSuccessToggle.OnSuccessAndFailure)) ? jsonContentSuccessFailure :
                        ((webhook.SuccessFailToggle.Equals(DiscordWebhookDataSuccessToggle.OnSuccessOnly) ? jsonContentSuccess : jsonContentFailure));
                    var uri = new Uri(webhook.URL);
                    using var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    using (await mainLink.HttpClientController.PostAsync(uri, content)) { }
                }
            }
            catch
            {
                mainLink.AddToText(">:> Unable to execute active webhooks with a finished log session.");
            }
        }

        private async Task SendDiscordMessageToSelectedWebhooksAsync(List<DiscordWebhookData> webhooks, SessionTextConstructor.DiscordEmbeds discordEmbeds, string contentText)
        {
            var jsonContentSuccessFailure = JsonConvert.SerializeObject(new DiscordAPIJSONContent()
            {
                Content = contentText,
                Embeds = discordEmbeds.SuccessFailure
            });
            var jsonContentSuccess = JsonConvert.SerializeObject(new DiscordAPIJSONContent()
            {
                Content = contentText,
                Embeds = discordEmbeds.Success
            });
            var jsonContentFailure = JsonConvert.SerializeObject(new DiscordAPIJSONContent()
            {
                Content = contentText,
                Embeds = discordEmbeds.Failure
            });
            try
            {
                foreach (var webhook in webhooks)
                {
                    var jsonContent =
                        (webhook.SuccessFailToggle.Equals(DiscordWebhookDataSuccessToggle.OnSuccessAndFailure)) ? jsonContentSuccessFailure :
                        ((webhook.SuccessFailToggle.Equals(DiscordWebhookDataSuccessToggle.OnSuccessOnly) ? jsonContentSuccess : jsonContentFailure));
                    var uri = new Uri(webhook.URL);
                    using var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    using (await mainLink.HttpClientController.PostAsync(uri, content)) { }
                }
            }
            catch
            {
                mainLink.AddToText(">:> Unable to execute selected webhooks with a finished log session.");
            }
        }

        private void ToolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            webhookIdsKey++;
            new FormEditDiscordWebhook(this, null, webhookIdsKey).Show();
        }

        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (listViewDiscordWebhooks.SelectedItems.Count > 0)
            {
                var selected = listViewDiscordWebhooks.SelectedItems[0];
                int.TryParse(selected.Name, out int reservedId);
                listViewDiscordWebhooks.Items.RemoveByKey(reservedId.ToString());
                allWebhooks.Remove(reservedId);
            }
        }

        private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if (listViewDiscordWebhooks.SelectedItems.Count > 0)
            {
                var selected = listViewDiscordWebhooks.SelectedItems[0];
                int.TryParse(selected.Name, out int reservedId);
                new FormEditDiscordWebhook(this, allWebhooks[reservedId], reservedId).Show();
            }
        }

        private void ListViewDiscordWebhooks_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int.TryParse(e.Item.Name, out int reservedId);
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
            if (listViewDiscordWebhooks.SelectedItems.Count > 0)
            {
                var selected = listViewDiscordWebhooks.SelectedItems[0];
                int.TryParse(selected.Name, out int reservedId);
                if (await allWebhooks[reservedId].TestWebhookAsync(mainLink.HttpClientController))
                {
                    MessageBox.Show("Webhook is valid.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Webhook is not valid.\nCheck your URL.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonAddNew_Click(object sender, EventArgs e)
        {
            webhookIdsKey++;
            new FormEditDiscordWebhook(this, null, webhookIdsKey).Show();
        }

        private void ButtonConfigureTeams_Click(object sender, EventArgs e)
        {
            teamsLink.Show();
        }
    }
}
