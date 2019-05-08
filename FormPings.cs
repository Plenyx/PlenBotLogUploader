using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlenBotLogUploader.RemotePing;

namespace PlenBotLogUploader
{
    public partial class FormPings : Form
    {
        #region definitions
        // properties
        public Dictionary<int, PingConfiguration> AllPings { get; set; }

        // fields
        private FormMain mainLink;
        private int settingsIdsKey = 0;
        #endregion

        public FormPings(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            if (File.Exists($@"{mainLink.LocalDir}\remote_pings.txt"))
            {
                AllPings = new Dictionary<int, PingConfiguration>();
                try
                {
                    using (StreamReader reader = new StreamReader($@"{mainLink.LocalDir}\remote_pings.txt"))
                    {
                        string line = reader.ReadLine();
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] values = line.Split(new string[] { "<;>" }, StringSplitOptions.None);
                            int.TryParse(values[0], out int active);
                            int.TryParse(values[3], out int method);
                            int.TryParse(values[4], out int authActive);
                            int.TryParse(values[5], out int useAsAuth);
                            if (method > 3 || method < 0)
                            {
                                method = 0;
                            }
                            var auth = new PingAuthentication() { Active = authActive == 1, UseAsAuth = useAsAuth == 1, AuthName = values[6], AuthToken = values[7] };
                            AddPing(new PingConfiguration() { Active = active == 1 ? true : false, Name = values[1], URL = values[2], Method = (PingMethod)method, Authentication = auth });
                        }
                    }
                }
                catch
                {
                    AllPings = new Dictionary<int, PingConfiguration>();
                }
            }
            else
            {
                AllPings = new Dictionary<int, PingConfiguration>();
            }
            foreach (int key in AllPings.Keys)
            {
                listViewDiscordWebhooks.Items.Add(new ListViewItem() { Name = key.ToString(), Text = AllPings[key].Name, Checked = AllPings[key].Active });
            }
        }

        private async void FormPings_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            using (StreamWriter writer = new StreamWriter($@"{mainLink.LocalDir}\remote_pings.txt"))
            {
                await writer.WriteLineAsync("## Edit the contents of this file at your own risk, use the application interface instead.");
                foreach (int key in AllPings.Keys)
                {
                    string active = AllPings[key].Active ? "1" : "0";
                    string method = ((int)AllPings[key].Method).ToString();
                    string authActive = AllPings[key].Authentication.Active ? "1" : "0";
                    string useAsAuth = AllPings[key].Authentication.UseAsAuth ? "1" : "0";
                    await writer.WriteLineAsync($"{active}<;>{AllPings[key].Name}<;>{AllPings[key].URL}<;>{method}<;>{authActive}<;>{useAsAuth}<;>{AllPings[key].Authentication.AuthName}<;>{AllPings[key].Authentication.AuthToken}");
                }
            }
        }

        public void AddPing(PingConfiguration config)
        {
            settingsIdsKey++;
            AllPings.Add(settingsIdsKey, config);
        }

        public async Task ExecuteAllPingsAsync(DPSReport.DPSReportJSONMinimal reportJSON)
        {
            foreach (var ping in AllPings.Keys)
            {
                if (AllPings[ping].Active)
                {
                    await AllPings[ping].PingServerAsync(mainLink, reportJSON);
                }
            }
        }

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            settingsIdsKey++;
            new FormEditPing(mainLink, this, settingsIdsKey, true, null).Show();
        }

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if (listViewDiscordWebhooks.SelectedItems.Count > 0)
            {
                var selected = listViewDiscordWebhooks.SelectedItems[0];
                int.TryParse(selected.Name, out int reservedId);
                new FormEditPing(mainLink, this, reservedId, false, AllPings[reservedId]).Show();
            }
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (listViewDiscordWebhooks.SelectedItems.Count > 0)
            {
                var selected = listViewDiscordWebhooks.SelectedItems[0];
                int.TryParse(selected.Name, out int reservedId);
                listViewDiscordWebhooks.Items.RemoveByKey(reservedId.ToString());
                AllPings.Remove(reservedId);
            }
        }

        private void contextMenuStripInteract_Opening(object sender, CancelEventArgs e)
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

        private void listViewDiscordWebhooks_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            string name = e.Item.Name;
            int.TryParse(e.Item.Name, out int reservedId);
            AllPings[reservedId].Active = e.Item.Checked;
        }

        private async void toolStripMenuItemTest_Click(object sender, EventArgs e)
        {
            if (listViewDiscordWebhooks.SelectedItems.Count > 0)
            {
                var selected = listViewDiscordWebhooks.SelectedItems[0];
                int.TryParse(selected.Name, out int reservedId);
                var result = await AllPings[reservedId].TestPingAsync(mainLink);
                if (result.Success)
                {
                    MessageBox.Show(result.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(result.Message, "Failure", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
    }
}
