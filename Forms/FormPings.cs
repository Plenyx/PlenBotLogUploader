using PlenBotLogUploader.DPSReport;
using PlenBotLogUploader.RemotePing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormPings : Form
    {
        #region definitions
        // properties
        public Dictionary<int, PingConfiguration> AllPings { get; set; }

        // fields
        private readonly FormMain mainLink;
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
                    using (var reader = new StreamReader($@"{mainLink.LocalDir}\remote_pings.txt"))
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
                            var auth = new PingAuthentication()
                            {
                                Active = authActive == 1,
                                UseAsAuth = useAsAuth == 1,
                                AuthName = values[6],
                                AuthToken = values[7]
                            };
                            AddPing(new PingConfiguration()
                            {
                                Active = active == 1,
                                Name = values[1],
                                URL = values[2],
                                Method = (PingMethod)method,
                                Authentication = auth
                            });
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
                listViewPings.Items.Add(new ListViewItem() { Name = key.ToString(), Text = AllPings[key].Name, Checked = AllPings[key].Active });
            }
        }

        private async void FormPings_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            using (var writer = new StreamWriter($@"{mainLink.LocalDir}\remote_pings.txt"))
            {
                await writer.WriteLineAsync("## Edit the contents of this file at your own risk, use the application interface instead.");
                foreach (int key in AllPings.Keys)
                {
                    var ping = AllPings[key];
                    string active = ping.Active ? "1" : "0";
                    string method = ((int)ping.Method).ToString();
                    string authActive = ping.Authentication.Active ? "1" : "0";
                    string useAsAuth = ping.Authentication.UseAsAuth ? "1" : "0";
                    await writer.WriteLineAsync($"{active}<;>{ping.Name}<;>{ping.URL}<;>{method}<;>{authActive}<;>{useAsAuth}<;>{ping.Authentication.AuthName}<;>{ping.Authentication.AuthToken}");
                }
            }
        }

        public void AddPing(PingConfiguration config)
        {
            settingsIdsKey++;
            AllPings.Add(settingsIdsKey, config);
        }

        public async Task ExecuteAllPingsAsync(DPSReportJSON reportJSON)
        {
            foreach (int key in AllPings.Keys)
            {
                if (AllPings[key].Active)
                {
                    await AllPings[key].PingServerAsync(mainLink, reportJSON);
                }
            }
        }

        private void ToolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            settingsIdsKey++;
            new FormEditPing(this, settingsIdsKey, true, null).Show();
        }

        private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if (listViewPings.SelectedItems.Count > 0)
            {
                var selected = listViewPings.SelectedItems[0];
                int.TryParse(selected.Name, out int reservedId);
                new FormEditPing(this, reservedId, false, AllPings[reservedId]).Show();
            }
        }

        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (listViewPings.SelectedItems.Count > 0)
            {
                var selected = listViewPings.SelectedItems[0];
                int.TryParse(selected.Name, out int reservedId);
                listViewPings.Items.RemoveByKey(reservedId.ToString());
                AllPings.Remove(reservedId);
            }
        }

        private void ContextMenuStripInteract_Opening(object sender, CancelEventArgs e)
        {
            var toggle = listViewPings.SelectedItems.Count > 0;
            toolStripMenuItemEdit.Enabled = toggle;
            toolStripMenuItemDelete.Enabled = toggle;
            toolStripMenuItemTest.Enabled = toggle;
        }

        private void ListViewDiscordWebhooks_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int.TryParse(e.Item.Name, out int reservedId);
            AllPings[reservedId].Active = e.Item.Checked;
        }

        private async void ToolStripMenuItemTest_Click(object sender, EventArgs e)
        {
            if (listViewPings.SelectedItems.Count > 0)
            {
                var selected = listViewPings.SelectedItems[0];
                int.TryParse(selected.Name, out int reservedId);
                var result = await AllPings[reservedId].PingServerAsync(null, null);
                if (result)
                {
                    MessageBox.Show("Ping test successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ping test unsuccessful\nCheck your settings", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void ButtonAddNew_Click(object sender, EventArgs e)
        {
            settingsIdsKey++;
            new FormEditPing(this, settingsIdsKey, true, null).Show();
        }
    }
}
