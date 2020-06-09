using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using PlenBotLogUploader.Tools;
using PlenBotLogUploader.DPSReport;
using PlenBotLogUploader.DiscordAPI;
using Newtonsoft.Json;

namespace PlenBotLogUploader
{
    public partial class FormDiscordWebhooks : Form
    {
        #region definitions
        // fields
        private readonly FormMain mainLink;
        private readonly Dictionary<int, BossData> allBosses = Bosses.GetAllBosses();
        private int webhookIdsKey = 0;
        private readonly Dictionary<int, DiscordWebhookData> allWebhooks = DiscordWebhooks.GetAllWebhooks();

        // consts
        private const int maxAllowedMessageSize = 1800;
        #endregion

        public FormDiscordWebhooks(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            if (File.Exists($@"{mainLink.LocalDir}\discord_webhooks.txt"))
            {
                try
                {
                    allWebhooks = DiscordWebhooks.FromFile($@"{mainLink.LocalDir}\discord_webhooks.txt");
                    webhookIdsKey = allWebhooks.Count();
                }
                catch
                {
                    allWebhooks.Clear();
                    webhookIdsKey = 0;
                }
            }
            else
            {
                allWebhooks.Clear();
            }
            foreach (int key in allWebhooks.Keys)
            {
                listViewDiscordWebhooks.Items.Add(new ListViewItem() { Name = key.ToString(), Text = allWebhooks[key].Name, Checked = allWebhooks[key].Active});
            }
        }

        private async void FormDiscordPings_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            using (StreamWriter writer = new StreamWriter($@"{mainLink.LocalDir}\discord_webhooks.txt"))
            {
                await writer.WriteLineAsync("## Edit the contents of this file at your own risk, use the application interface instead.");
                foreach (int key in allWebhooks.Keys)
                {
                    await writer.WriteLineAsync(allWebhooks[key].ToString(true));
                }
            }
        }

        public async Task ExecuteAllActiveWebhooksAsync(DPSReportJSON reportJSON)
        {
            string bossName = reportJSON.Encounter.Boss + (reportJSON.ChallengeMode ? " CM" : "");
            string successString = (reportJSON.Encounter.Success ?? false) ? ":white_check_mark:" : "❌";
            string extraJSON = (reportJSON.ExtraJSON == null) ? "" : $"Recorded by: {reportJSON.ExtraJSON.RecordedBy}\nDuration: {reportJSON.ExtraJSON.Duration}\nElite Insights version: {reportJSON.ExtraJSON.EliteInsightsVersion}\n";
            string icon = "";
            var bossDataRef = allBosses
                .Where(anon => anon.Value.BossId.Equals(reportJSON.Encounter.BossId))
                .Select(anon => anon.Value);
            if (bossDataRef.Count() == 1)
            {
                bossName = bossDataRef.First().Name + (reportJSON.ChallengeMode ? " CM" : "");
                icon = bossDataRef.First().Icon;
            }
            int color = (reportJSON.Encounter.Success ?? false) ? 32768 : 16711680;
            var discordContentEmbedThumbnail = new DiscordAPIJSONContentEmbedThumbnail()
            {
                Url = icon
            };
            var discordContentEmbed = new DiscordAPIJSONContentEmbed()
            {
                Title = bossName,
                Url = reportJSON.Permalink,
                Description = $"{extraJSON}Result: {successString}\narcdps version: {reportJSON.EVTC.Type}{reportJSON.EVTC.Version}",
                Color = color,
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
                Color = color,
                Thumbnail = discordContentEmbedThumbnail
            };
            if (reportJSON.Players.Values.Count <= 10)
            {
                List<DiscordAPIJSONContentEmbedField> fields = new List<DiscordAPIJSONContentEmbedField>();
                foreach (var player in reportJSON.Players.Values)
                {
                    fields.Add(new DiscordAPIJSONContentEmbedField() { Name = player.CharacterName, Value = $"```\n{player.DisplayName}\n\n{Players.ResolveSpecName(player.Profession, player.EliteSpec)}\n```", Inline = true });
                }
                discordContentEmbedForPlayers.Fields = fields.ToArray();
            }
            var discordContentWithPlayers = new DiscordAPIJSONContent()
            {
                Embeds = new List<DiscordAPIJSONContentEmbed>() { discordContentEmbedForPlayers }
            };
            try
            {
                string jsonContentWithoutPlayers = JsonConvert.SerializeObject(discordContentWithoutPlayers);
                string jsonContentWithPlayers = JsonConvert.SerializeObject(discordContentWithPlayers);
                foreach (var key in allWebhooks.Keys)
                {
                    var webhook = allWebhooks[key];
                    if (!webhook.Active
                        || (webhook.SuccessFailToggle == DiscordWebhookDataSuccessToggle.OnSuccessOnly && !(reportJSON.Encounter.Success ?? false))
                        || (webhook.SuccessFailToggle == DiscordWebhookDataSuccessToggle.OnFailOnly && (reportJSON.Encounter.Success ?? false))
                        || webhook.BossesDisable.Contains(reportJSON.Encounter.BossId))
                    {
                        continue;
                    }
                    var uri = new Uri(webhook.URL);
                    if (webhook.ShowPlayers)
                    {
                        using (var content = new StringContent(jsonContentWithPlayers, Encoding.UTF8, "application/json"))
                        {
                            using (await mainLink.HttpClientController.PostAsync(uri, content)) { }
                        }
                    }
                    else
                    {
                        using (var content = new StringContent(jsonContentWithoutPlayers, Encoding.UTF8, "application/json"))
                        {
                            using (await mainLink.HttpClientController.PostAsync(uri, content)) { }
                        }
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

        public async Task ExecuteSessionWebhooksAsync(List<DPSReportJSON> reportsJSON, LogSessionSettings logSessionSettings)
        {
            var RaidLogs = reportsJSON
                    .Where(anon => Bosses.GetWingForBoss(anon.EVTC.BossId) > 0)
                    .Select(anon => new { LogData = anon, RaidWing = Bosses.GetWingForBoss(anon.EVTC.BossId) })
                    .OrderBy(anon => anon.LogData.UploadTime)
                    .ToList();
            if (logSessionSettings.SortBy.Equals(LogSessionSortBy.Wing))
            {
                RaidLogs = reportsJSON
                    .Where(anon => Bosses.GetWingForBoss(anon.EVTC.BossId) > 0)
                    .Select(anon => new { LogData = anon, RaidWing = Bosses.GetWingForBoss(anon.EVTC.BossId) })
                    .OrderBy(anon => Bosses.GetWingForBoss(anon.LogData.EVTC.BossId))
                    .ThenBy(anon => Bosses.GetBossOrder(anon.LogData.Encounter.BossId))
                    .ThenBy(anon => anon.LogData.UploadTime)
                    .ToList();
            }
            var FractalLogs = reportsJSON
                .Where(anon => allBosses
                    .Where(anon2 => anon2.Value.BossId.Equals(anon.EVTC.BossId))
                    .First().Value.Type.Equals(BossType.Fractal))
                .ToList();
            var StrikeLogs = reportsJSON
                .Where(anon => allBosses
                    .Where(anon2 => anon2.Value.BossId.Equals(anon.EVTC.BossId))
                    .First().Value.Type.Equals(BossType.Strike))
                .ToList();
            var GolemLogs = reportsJSON
                .Where(anon => allBosses
                    .Where(anon2 => anon2.Value.BossId.Equals(anon.EVTC.BossId))
                    .First().Value.Type.Equals(BossType.Golem))
                .ToList();
            var WvWLogs = reportsJSON
                .Where(anon => allBosses
                    .Where(anon2 => anon2.Value.BossId.Equals(anon.EVTC.BossId))
                    .First().Value.Type.Equals(BossType.WvW))
                .ToList();
            StringBuilder builder = new StringBuilder();
            builder.Append($"Session duration: {logSessionSettings.ElapsedTime}\n\n");
            int messageCount = 0;
            if (RaidLogs.Count > 0)
            {
                builder.Append("***Raid logs:***\n");
                if (logSessionSettings.SortBy.Equals(LogSessionSortBy.UploadTime))
                {
                    foreach (var data in RaidLogs)
                    {
                        string bossName = data.LogData.Encounter.Boss + (data.LogData.ChallengeMode ? " CM" : "");
                        var bossDataRef = allBosses
                            .Where(anon => anon.Value.BossId.Equals(data.LogData.Encounter.BossId))
                            .Select(anon => anon.Value);
                        if (bossDataRef.Count() == 1)
                        {
                            bossName = bossDataRef.First().Name + (data.LogData.ChallengeMode ? " CM" : "");
                        }
                        string duration = (data.LogData.ExtraJSON == null) ? "" : $" {data.LogData.ExtraJSON.Duration}";
                        string successText = (logSessionSettings.ShowSuccess) ? ((data.LogData.Encounter.Success ?? false) ? " :white_check_mark:" : " ❌") : "";
                        builder.Append($"[{bossName}]({data.LogData.Permalink}){duration}{successText}\n");
                        if (builder.Length >= maxAllowedMessageSize)
                        {
                            messageCount++;
                            if (logSessionSettings.UseSelectedWebhooksInstead)
                            {
                                await SendDiscordMessageToSelectedWebhooksAsync(logSessionSettings.SelectedWebhooks, logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString(), logSessionSettings.ContentText);
                            }
                            else
                            {
                                await SendDiscordMessageToAllActiveWebhooksAsync(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString(), logSessionSettings.ContentText);
                            }
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
                        var bossDataRef = allBosses
                            .Where(anon => anon.Value.BossId.Equals(data.LogData.Encounter.BossId))
                            .Select(anon => anon.Value);
                        if (bossDataRef.Count() == 1)
                        {
                            bossName = bossDataRef.First().Name + (data.LogData.ChallengeMode ? " CM" : "");
                        }
                        string duration = (data.LogData.ExtraJSON == null) ? "" : $" {data.LogData.ExtraJSON.Duration}";
                        string successText = (logSessionSettings.ShowSuccess) ? ((data.LogData.Encounter.Success ?? false) ? " :white_check_mark:" : " ❌") : "";
                        builder.Append($"[{bossName}]({data.LogData.Permalink}){duration}{successText}\n");
                        if (builder.Length >= maxAllowedMessageSize)
                        {
                            messageCount++;
                            if (logSessionSettings.UseSelectedWebhooksInstead)
                            {
                                await SendDiscordMessageToSelectedWebhooksAsync(logSessionSettings.SelectedWebhooks, logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString(), logSessionSettings.ContentText);
                            }
                            else
                            {
                                await SendDiscordMessageToAllActiveWebhooksAsync(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString(), logSessionSettings.ContentText);
                            }
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
                    var bossDataRef = allBosses
                        .Where(anon => anon.Value.BossId.Equals(log.Encounter.BossId))
                        .Select(anon => anon.Value);
                    if (bossDataRef.Count() == 1)
                    {
                        bossName = bossDataRef.First().Name;
                    }
                    string duration = (log.ExtraJSON == null) ? "" : $" {log.ExtraJSON.Duration}";
                    string successText = (logSessionSettings.ShowSuccess) ? ((log.Encounter.Success ?? false) ? " :white_check_mark:" : " ❌") : "";
                    builder.Append($"[{bossName}]({log.Permalink}){duration}{successText}\n");
                    if (builder.Length >= maxAllowedMessageSize)
                    {
                        messageCount++;
                        if (logSessionSettings.UseSelectedWebhooksInstead)
                        {
                            await SendDiscordMessageToSelectedWebhooksAsync(logSessionSettings.SelectedWebhooks, logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString(), logSessionSettings.ContentText);
                        }
                        else
                        {
                            await SendDiscordMessageToAllActiveWebhooksAsync(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString(), logSessionSettings.ContentText);
                        }
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
                    var bossDataRef = allBosses
                        .Where(anon => anon.Value.BossId.Equals(log.Encounter.BossId))
                        .Select(anon => anon.Value);
                    if (bossDataRef.Count() == 1)
                    {
                        bossName = bossDataRef.First().Name;
                    }
                    string duration = (log.ExtraJSON == null) ? "" : $" {log.ExtraJSON.Duration}";
                    string successText = (logSessionSettings.ShowSuccess) ? ((log.Encounter.Success ?? false) ? " :white_check_mark:" : " ❌") : "";
                    builder.Append($"[{bossName}]({log.Permalink}){duration}{successText}\n");
                    if (builder.Length >= maxAllowedMessageSize)
                    {
                        messageCount++;
                        if (logSessionSettings.UseSelectedWebhooksInstead)
                        {
                            await SendDiscordMessageToSelectedWebhooksAsync(logSessionSettings.SelectedWebhooks, logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString(), logSessionSettings.ContentText);
                        }
                        else
                        {
                            await SendDiscordMessageToAllActiveWebhooksAsync(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString(), logSessionSettings.ContentText);
                        }
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
                        if (logSessionSettings.UseSelectedWebhooksInstead)
                        {
                            await SendDiscordMessageToSelectedWebhooksAsync(logSessionSettings.SelectedWebhooks, logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString(), logSessionSettings.ContentText);
                        }
                        else
                        {
                            await SendDiscordMessageToAllActiveWebhooksAsync(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString(), logSessionSettings.ContentText);
                        }
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
                foreach(var log in WvWLogs)
                {
                    builder.Append($"{log.Permalink}\n");
                    if (builder.Length >= maxAllowedMessageSize)
                    {
                        messageCount++;
                        if (logSessionSettings.UseSelectedWebhooksInstead)
                        {
                            await SendDiscordMessageToSelectedWebhooksAsync(logSessionSettings.SelectedWebhooks, logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString(), logSessionSettings.ContentText);
                        }
                        else
                        {
                            await SendDiscordMessageToAllActiveWebhooksAsync(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString(), logSessionSettings.ContentText);
                        }
                        builder.Clear();
                        builder.Append("***WvW logs:***\n");
                    }
                }
            }
            if (!builder.ToString().EndsWith("***\n"))
            {
                messageCount++;
                if (logSessionSettings.UseSelectedWebhooksInstead)
                {
                    await SendDiscordMessageToSelectedWebhooksAsync(logSessionSettings.SelectedWebhooks, logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString(), logSessionSettings.ContentText);
                }
                else
                {
                    await SendDiscordMessageToAllActiveWebhooksAsync(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString(), logSessionSettings.ContentText);
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

        private async Task SendDiscordMessageToAllActiveWebhooksAsync(string title, string description, string contentText)
        {
            var discordContentEmbedThumbnail = new DiscordAPIJSONContentEmbedThumbnail()
            {
                Url = "https://wiki.guildwars2.com/images/5/5e/Legendary_Insight.png"
            };
            var discordContentEmbed = new DiscordAPIJSONContentEmbed()
            {
                Title = title,
                Description = description,
                Color = 32768,
                Thumbnail = discordContentEmbedThumbnail
            };
            var discordContent = new DiscordAPIJSONContent()
            {
                Content = contentText,
                Embeds = new List<DiscordAPIJSONContentEmbed>() { discordContentEmbed }
            };
            try
            {
                string jsonContent = JsonConvert.SerializeObject(discordContent);
                foreach (var key in allWebhooks.Keys)
                {
                    var webhook = allWebhooks[key];
                    if (!webhook.Active)
                    {
                        continue;
                    }
                    var uri = new Uri(webhook.URL);
                    using (var content = new StringContent(jsonContent, Encoding.UTF8, "application/json"))
                    {
                        using (await mainLink.HttpClientController.PostAsync(uri, content)) { }
                    }
                }
            }
            catch
            {
                mainLink.AddToText(">:> Unable to execute active webhooks with a finished log session.");
            }
        }

        private async Task SendDiscordMessageToSelectedWebhooksAsync(List<DiscordWebhookData> webhooks, string title, string description, string contentText)
        {
            var discordContentEmbedThumbnail = new DiscordAPIJSONContentEmbedThumbnail()
            {
                Url = "https://wiki.guildwars2.com/images/5/5e/Legendary_Insight.png"
            };
            var discordContentEmbed = new DiscordAPIJSONContentEmbed()
            {
                Title = title,
                Description = description,
                Color = 32768,
                Thumbnail = discordContentEmbedThumbnail
            };
            var discordContent = new DiscordAPIJSONContent()
            {
                Content = contentText,
                Embeds = new List<DiscordAPIJSONContentEmbed>() { discordContentEmbed }
            };
            try
            {
                string jsonContent = JsonConvert.SerializeObject(discordContent);
                foreach (var webhook in webhooks)
                {
                    var uri = new Uri(webhook.URL);
                    using (var content = new StringContent(jsonContent, Encoding.UTF8, "application/json"))
                    {
                        using (await mainLink.HttpClientController.PostAsync(uri, content)) { }
                    }
                }
            }
            catch
            {
                mainLink.AddToText(">:> Unable to execute selected webhooks with a finished log session.");
            }
        }

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            webhookIdsKey++;
            new FormEditDiscordWebhook(this, null, webhookIdsKey).Show();
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (listViewDiscordWebhooks.SelectedItems.Count > 0)
            {
                var selected = listViewDiscordWebhooks.SelectedItems[0];
                int.TryParse(selected.Name, out int reservedId);
                listViewDiscordWebhooks.Items.RemoveByKey(reservedId.ToString());
                allWebhooks.Remove(reservedId);
            }
        }

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if (listViewDiscordWebhooks.SelectedItems.Count > 0)
            {
                var selected = listViewDiscordWebhooks.SelectedItems[0];
                int.TryParse(selected.Name, out int reservedId);
                new FormEditDiscordWebhook(this, allWebhooks[reservedId], reservedId).Show();
            }
        }

        private void listViewDiscordWebhooks_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int.TryParse(e.Item.Name, out int reservedId);
            allWebhooks[reservedId].Active = e.Item.Checked;
        }

        private void contextMenuStripInteract_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var toggle = listViewDiscordWebhooks.SelectedItems.Count > 0;
            toolStripMenuItemEdit.Enabled = toggle;
            toolStripMenuItemDelete.Enabled = toggle;
            toolStripMenuItemTest.Enabled = toggle;
        }

        private async void toolStripMenuItemTest_Click(object sender, EventArgs e)
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
    }
}
