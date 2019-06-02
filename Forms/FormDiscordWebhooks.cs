using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using PlenBotLogUploader.DiscordAPI;
using PlenBotLogUploader.DPSReport;

namespace PlenBotLogUploader
{
    public partial class FormDiscordWebhooks : Form
    {
        #region definitions
        // properties
        public Dictionary<int, DiscordWebhookData> AllWebhooks { get; set; }

        // fields
        private FormMain mainLink;
        private int webhookIdsKey = 0;
        #endregion

        public FormDiscordWebhooks(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            if (File.Exists($@"{mainLink.LocalDir}\discord_webhooks.txt"))
            {
                AllWebhooks = new Dictionary<int, DiscordWebhookData>();
                try
                {
                    using (StreamReader reader = new StreamReader($@"{mainLink.LocalDir}\discord_webhooks.txt"))
                    {
                        string line = reader.ReadLine();
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] values = line.Split(new string[] { "<;>" }, StringSplitOptions.None);
                            int.TryParse(values[0], out int active);
                            int.TryParse(values[3], out int onlySuccess);
                            // compatibility with build < 32
                            int showPlayers = 1;
                            if (values.Count() > 4)
                            {
                                int.TryParse(values[4], out showPlayers);
                            }
                            AddWebhook(new DiscordWebhookData()
                            {
                                Active = active == 1,
                                Name = values[1],
                                URL = values[2],
                                OnlySuccess = onlySuccess == 1,
                                ShowPlayers = showPlayers == 1
                            });
                        }
                    }
                }
                catch
                {
                    AllWebhooks = new Dictionary<int, DiscordWebhookData>();
                }
            }
            else
            {
                AllWebhooks = new Dictionary<int, DiscordWebhookData>();
            }
            foreach (int key in AllWebhooks.Keys)
            {
                listViewDiscordWebhooks.Items.Add(new ListViewItem() { Name = key.ToString(), Text = AllWebhooks[key].Name, Checked = AllWebhooks[key].Active});
            }
        }

        private async void FormDiscordPings_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            using (StreamWriter writer = new StreamWriter($@"{mainLink.LocalDir}\discord_webhooks.txt"))
            {
                await writer.WriteLineAsync("## Edit the contents of this file at your own risk, use the application interface instead.");
                foreach (int key in AllWebhooks.Keys)
                {
                    var webhook = AllWebhooks[key];
                    string active = webhook.Active ? "1" : "0";
                    string onlySuccess = webhook.OnlySuccess ? "1" : "0";
                    string showPlayers = webhook.ShowPlayers ? "1" : "0";
                    await writer.WriteLineAsync($"{active}<;>{webhook.Name}<;>{webhook.URL}<;>{onlySuccess}<;>{showPlayers}");
                }
            }
        }

        public void AddWebhook(DiscordWebhookData data)
        {
            webhookIdsKey++;
            AllWebhooks.Add(webhookIdsKey, data);
        }

        public async Task ExecuteAllActiveWebhooksAsync(DPSReportJSON reportJSON, Dictionary<int, BossData> allBosses)
        {
            string bossName = reportJSON.Encounter.Boss;
            string successString = (reportJSON.Encounter.Success ?? false) ? "success" : "fail";
            string icon = "";
            if (allBosses.ContainsKey(reportJSON.Encounter.BossId))
            {
                bossName = allBosses[reportJSON.Encounter.BossId].Name;
                icon = allBosses[reportJSON.Encounter.BossId].Icon;
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
                Description = $"Result: {successString}\narcdps version: {reportJSON.Evtc.Type}{reportJSON.Evtc.Version}",
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
                Description = $"Result: {successString}\narcdps version: {reportJSON.Evtc.Type}{reportJSON.Evtc.Version}",
                Color = color,
                Thumbnail = discordContentEmbedThumbnail
            };
            if (reportJSON.Players.Values.Count <= 10)
            {
                List<DiscordAPIJSONContentEmbedField> fields = new List<DiscordAPIJSONContentEmbedField>();
                foreach (var player in reportJSON.Players.Values)
                {
                    fields.Add(new DiscordAPIJSONContentEmbedField() { Name = player.Character_name, Value = $"```{player.Display_name}\n\n{Players.ResolveSpecName(player.Profession, player.Elite_spec)}```", Inline = true });
                }
                discordContentEmbedForPlayers.Fields = fields.ToArray();
            }
            var discordContentWithPlayers = new DiscordAPIJSONContent()
            {
                Embeds = new List<DiscordAPIJSONContentEmbed>() { discordContentEmbedForPlayers }
            };
            try
            {
                var serialiser = new JavaScriptSerializer();
                serialiser.RegisterConverters(new[] { new DiscordAPIJSONContentConverter() });
                string jsonContentWithoutPlayers = serialiser.Serialize(discordContentWithoutPlayers);
                string jsonContentWithPlayers = serialiser.Serialize(discordContentWithPlayers);
                foreach (var key in AllWebhooks.Keys)
                {
                    var webhook = AllWebhooks[key];
                    if (!webhook.Active || (webhook.OnlySuccess && !(reportJSON.Encounter.Success ?? false)))
                    {
                        continue;
                    }
                    var uri = new Uri(webhook.URL);
                    if (webhook.ShowPlayers)
                    {
                        using (var content = new StringContent(jsonContentWithPlayers, Encoding.UTF8, "application/json"))
                        {
                            using (await mainLink.HttpClientController.MainHttpClient.PostAsync(uri, content)) { }
                        }
                    }
                    else
                    {
                        using (var content = new StringContent(jsonContentWithoutPlayers, Encoding.UTF8, "application/json"))
                        {
                            using (await mainLink.HttpClientController.MainHttpClient.PostAsync(uri, content)) { }
                        }
                    }
                }
                if (AllWebhooks.Count > 0)
                {
                    mainLink.AddToText(">:> All active webhooks successfully executed.");
                }
            }
            catch
            {
                mainLink.AddToText(">:> Unable to execute active webhooks.");
            }
        }

        public async Task ExecuteSessionAllActiveWebhooksAsync(List<DPSReportJSON> reportsJSON, Dictionary<int, BossData> allBosses)
        {
            var RaidLogs = reportsJSON
                .Where(anon => Bosses.GetWingForBoss(anon.Evtc.BossId) > 0)
                .Select(anon => new { LogData = anon, RaidWing = Bosses.GetWingForBoss(anon.Evtc.BossId) })
                .OrderBy(anon => Bosses.GetWingForBoss(anon.LogData.Evtc.BossId)).ThenBy(anon => Bosses.GetBossOrder(anon.LogData.Encounter.BossId))
                .ToList();
            var FractalLogs = reportsJSON
                .Where(anon => Bosses.IsFractal(anon.Evtc.BossId))
                .ToList();
            var GolemLogs = reportsJSON
                .Where(anon => Bosses.IsGolem(anon.Evtc.BossId))
                .ToList();
            var WvWLogs = reportsJSON
                .Where(anon => Bosses.IsWvW(anon.Evtc.BossId))
                .ToList();
            StringBuilder builder = new StringBuilder();
            if (RaidLogs.Count > 0)
            {
                builder.Append("***Raid logs:***\n");
                int lastWing = 0;
                foreach (var data in RaidLogs)
                {
                    if (!lastWing.Equals(Bosses.GetWingForBoss(data.LogData.Evtc.BossId)))
                    {
                        builder.Append($"**{Bosses.GetWingName(data.RaidWing)} (wing {data.RaidWing})**\n");
                        lastWing = Bosses.GetWingForBoss(data.LogData.Evtc.BossId);
                    }
                    string bossName = data.LogData.Encounter.Boss;
                    if (allBosses.ContainsKey(data.LogData.Evtc.BossId))
                    {
                        bossName = allBosses[data.LogData.Evtc.BossId].Name;
                    }
                    builder.Append($"[{bossName}]({data.LogData.Permalink})\n");
                }
            }
            if (FractalLogs.Count > 0)
            {
                if (builder.Length > 0)
                {
                    builder.Append("\n\n");
                }
                builder.Append("***Fractal logs:***\n");
                foreach (var log in FractalLogs)
                {
                    string bossName = log.Encounter.Boss;
                    if (allBosses.ContainsKey(log.Evtc.BossId))
                    {
                        bossName = allBosses[log.Evtc.BossId].Name;
                    }
                    builder.Append($"[{bossName}]({log.Permalink})\n");
                }
            }
            if (GolemLogs.Count > 0)
            {
                if (builder.Length > 0)
                {
                    builder.Append("\n\n");
                }
                builder.Append("***Golem logs:***\n");
                foreach (var log in GolemLogs)
                {
                    builder.Append($"{log.Permalink}\n");
                }
            }
            if (WvWLogs.Count > 0)
            {
                if (builder.Length > 0)
                {
                    builder.Append("\n\n");
                }
                builder.Append("***WvW logs:***\n");
                foreach(var log in WvWLogs)
                {
                    builder.Append($"{log.Permalink}\n");
                }
            }
            var discordContentEmbedThumbnail = new DiscordAPIJSONContentEmbedThumbnail()
            {
                Url = "https://wiki.guildwars2.com/images/5/5e/Legendary_Insight.png"
            };
            var discordContentEmbed = new DiscordAPIJSONContentEmbed()
            {
                Title = "Log session",
                Description = builder.ToString(),
                Color = 32768,
                Thumbnail = discordContentEmbedThumbnail
            };
            var discordContent = new DiscordAPIJSONContent()
            {
                Embeds = new List<DiscordAPIJSONContentEmbed>() { discordContentEmbed }
            };
            try
            {
                var serialiser = new JavaScriptSerializer();
                serialiser.RegisterConverters(new[] { new DiscordAPIJSONContentConverter() });
                string jsonContentWithoutPlayers = serialiser.Serialize(discordContent);
                foreach (var key in AllWebhooks.Keys)
                {
                    var webhook = AllWebhooks[key];
                    if (!webhook.Active)
                    {
                        continue;
                    }
                    var uri = new Uri(webhook.URL);
                    using (var content = new StringContent(jsonContentWithoutPlayers, Encoding.UTF8, "application/json"))
                    {
                        using (await mainLink.HttpClientController.MainHttpClient.PostAsync(uri, content)) { }
                    }
                }
                if (AllWebhooks.Count > 0)
                {
                    mainLink.AddToText(">:> All active webhooks successfully executed with finished log session.");
                }
            }
            catch
            {
                mainLink.AddToText(">:> Unable to execute active webhooks with finished log session.");
            }
        }

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            webhookIdsKey++;
            new FormEditDiscordWebhook(this, webhookIdsKey, true, null).Show();
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (listViewDiscordWebhooks.SelectedItems.Count > 0)
            {
                var selected = listViewDiscordWebhooks.SelectedItems[0];
                int.TryParse(selected.Name, out int reservedId);
                listViewDiscordWebhooks.Items.RemoveByKey(reservedId.ToString());
                AllWebhooks.Remove(reservedId);
            }
        }

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if (listViewDiscordWebhooks.SelectedItems.Count > 0)
            {
                var selected = listViewDiscordWebhooks.SelectedItems[0];
                int.TryParse(selected.Name, out int reservedId);
                new FormEditDiscordWebhook(this, reservedId, false, AllWebhooks[reservedId]).Show();
            }
        }

        private void listViewDiscordWebhooks_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int.TryParse(e.Item.Name, out int reservedId);
            AllWebhooks[reservedId].Active = e.Item.Checked;
        }

        private void contextMenuStripInteract_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listViewDiscordWebhooks.SelectedItems.Count > 0)
            {
                toolStripMenuItemEdit.Enabled = true;
                toolStripMenuItemDelete.Enabled = true;
                toolStripMenuItemTest.Enabled = true;
            }
            else
            {
                toolStripMenuItemEdit.Enabled = false;
                toolStripMenuItemDelete.Enabled = false;
                toolStripMenuItemTest.Enabled = false;
            }
        }

        private async void toolStripMenuItemTest_Click(object sender, EventArgs e)
        {
            if (listViewDiscordWebhooks.SelectedItems.Count > 0)
            {
                var selected = listViewDiscordWebhooks.SelectedItems[0];
                int.TryParse(selected.Name, out int reservedId);
                if (await AllWebhooks[reservedId].TestWebhookAsync(mainLink))
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
            new FormEditDiscordWebhook(this, webhookIdsKey, true, null).Show();
        }
    }
}
