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
            var bossData = Bosses.GetBossDataFromId(reportJSON.Encounter.BossId);
            if (bossData != null)
            {
                bossName = bossData.Name + (reportJSON.ChallengeMode ? " CM" : "");
                icon = bossData.Icon;
            }
            int colour = (reportJSON.Encounter.Success ?? false) ? 32768 : 16711680;
            var discordContentEmbedThumbnail = new DiscordAPIJSONContentEmbedThumbnail()
            {
                Url = icon
            };
            var timestampDateTime = DateTime.UtcNow;
            if (DateTime.TryParse(reportJSON.ExtraJSON.TimeStart, out DateTime timeStart))
            {
                timestampDateTime = timeStart;
            }
            var timestamp = timestampDateTime.ToString("yyyy'-'MM'-'ddTHH':'mm':'ssZ");
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
                List<DiscordAPIJSONContentEmbedField> fields = new List<DiscordAPIJSONContentEmbedField>();
                foreach (var player in reportJSON.Players.Values)
                {
                    fields.Add(new DiscordAPIJSONContentEmbedField() { Name = player.CharacterName, Value = $"```\n{player.DisplayName}\n\n{Players.ResolveSpecName(player.Profession, player.EliteSpec)}\n```", Inline = true });
                }
                discordContentEmbedForPlayers.Fields = fields;
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
                        || (webhook.SuccessFailToggle.Equals(DiscordWebhookDataSuccessToggle.OnSuccessOnly) && !(reportJSON.Encounter.Success ?? false))
                        || (webhook.SuccessFailToggle.Equals(DiscordWebhookDataSuccessToggle.OnFailOnly) && (reportJSON.Encounter.Success ?? false))
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
            var discordEmbedsSuccessFailure = new List<DiscordAPIJSONContentEmbed>();

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
                            discordEmbedsSuccessFailure.Add(SessionTextConstructor.MakeEmbedFromText(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString()));
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
                            discordEmbedsSuccessFailure.Add(SessionTextConstructor.MakeEmbedFromText(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString()));
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
                        discordEmbedsSuccessFailure.Add(SessionTextConstructor.MakeEmbedFromText(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString()));
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
                        discordEmbedsSuccessFailure.Add(SessionTextConstructor.MakeEmbedFromText(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString()));
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
                        discordEmbedsSuccessFailure.Add(SessionTextConstructor.MakeEmbedFromText(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString()));
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
                        discordEmbedsSuccessFailure.Add(SessionTextConstructor.MakeEmbedFromText(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString()));
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
                        discordEmbedsSuccessFailure.Add(SessionTextConstructor.MakeEmbedFromText(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString()));
                        builder.Clear();
                        builder.Append("***Other logs:***\n");
                    }
                }
            }
            if (!builder.ToString().EndsWith("***\n"))
            {
                messageCount++;
                discordEmbedsSuccessFailure.Add(SessionTextConstructor.MakeEmbedFromText(logSessionSettings.Name + ((messageCount > 1) ? $" part {messageCount}" : ""), builder.ToString()));
            }
            if (logSessionSettings.UseSelectedWebhooksInstead)
            {
                await SendDiscordMessageToSelectedWebhooksAsync(logSessionSettings.SelectedWebhooks, discordEmbedsSuccessFailure, logSessionSettings.ContentText);
            }
            else
            {
                await SendDiscordMessageToAllActiveWebhooksAsync(discordEmbedsSuccessFailure, logSessionSettings.ContentText);
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

        private async Task SendDiscordMessageToAllActiveWebhooksAsync(List<DiscordAPIJSONContentEmbed> embeds, string contentText)
        {
            var discordContent = new DiscordAPIJSONContent()
            {
                Content = contentText,
                Embeds = embeds
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

        private async Task SendDiscordMessageToSelectedWebhooksAsync(List<DiscordWebhookData> webhooks, List<DiscordAPIJSONContentEmbed> embeds, string contentText)
        {
            var discordContent = new DiscordAPIJSONContent()
            {
                Content = contentText,
                Embeds = embeds
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
    }
}
