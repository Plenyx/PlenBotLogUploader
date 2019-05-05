using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlenBotLogUploader.DPSReport;
using PlenBotLogUploader.DiscordAPI;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.IO;

namespace PlenBotLogUploader
{
    public partial class FormDiscordPings : Form
    {
        #region definitions
        // properties
        public Dictionary<int, DiscordWebhookData> AllWebhooks { get; set; }

        // fields
        private FormMain mainLink;
        private int webhookIdsKey = 0;
        #endregion

        public FormDiscordPings(FormMain mainLink)
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
                            int.TryParse(values[3], out int success);
                            AddWebhook(new DiscordWebhookData(active == 1 ? true : false, values[1], values[2], success == 1 ? true : false));
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
                    string active = AllWebhooks[key].Active ? "1" : "0";
                    string success = AllWebhooks[key].OnlySuccess ? "1" : "0";
                    await writer.WriteLineAsync($"{active}<;>{AllWebhooks[key].Name}<;>{AllWebhooks[key].URL}<;>{success}");
                }
            }
        }

        public void AddWebhook(DiscordWebhookData data)
        {
            webhookIdsKey++;
            AllWebhooks.Add(webhookIdsKey, data);
        }

        public async Task ExecuteAllActiveWebhooks(DPSReportJSONMinimal reportJSON, Dictionary<int, BossData> allBosses)
        {
            try
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
                    url = icon
                };
                var discordContentEmbed = new DiscordAPIJSONContentEmbed()
                {
                    title = bossName,
                    url = reportJSON.Permalink,
                    description = $"Result: {successString}\narcdps version: {reportJSON.Evtc.Type}{reportJSON.Evtc.Version}",
                    color = color,
                    thumbnail = discordContentEmbedThumbnail
                };
                var discordContent = new DiscordAPIJSONContent()
                {
                    embeds = new List<DiscordAPIJSONContentEmbed>() { discordContentEmbed }
                };
                string jsonContent = new JavaScriptSerializer().Serialize(discordContent);
                foreach (var key in AllWebhooks.Keys)
                {
                    if (!AllWebhooks[key].Active || (AllWebhooks[key].OnlySuccess && !(reportJSON.Encounter.Success ?? false)))
                    {
                        continue;
                    }
                    using (var content = new StringContent(jsonContent, Encoding.UTF8, "application/json"))
                    {
                        var responseMessage = await mainLink.MainHttpClient.PostAsync(new Uri(AllWebhooks[key].URL), content);
                        responseMessage?.Dispose();
                    }
                }
            }
            catch
            {
                mainLink.AddToText("Unable to execute active webhooks.");
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
            string name = e.Item.Name;
            int.TryParse(e.Item.Name, out int reservedId);
            AllWebhooks[reservedId].Active = e.Item.Checked;
        }
    }
}
