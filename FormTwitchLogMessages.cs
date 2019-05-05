using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using PlenBotLogUploader.DPSReport;

namespace PlenBotLogUploader
{
    public partial class FormTwitchLogMessages : Form
    {
        #region definitions
        // properties
        public Dictionary<int, BossData> AllBosses { get; set; }

        // fields
        private FormMain mainLink;
        #endregion

        public FormTwitchLogMessages(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            if (File.Exists($@"{mainLink.LocalDir}\twitch_messages.txt"))
            {
                AllBosses = new Dictionary<int, BossData>();
                try
                {
                    using (StreamReader reader = new StreamReader($@"{mainLink.LocalDir}\twitch_messages.txt"))
                    {
                        string line = reader.ReadLine();
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] values = line.Split(new string[] { "<;>" }, StringSplitOptions.None);
                            int.TryParse(values[0], out int bossId);
                            AllBosses.Add(bossId, new BossData(bossId, values[1], values[2], values[3], values[4]));
                        }
                    }
                }
                catch
                {
                    AllBosses = Bosses.GetDefaultSettingsForBossesAsDictionary();
                }
            }
            else
            {
                AllBosses = Bosses.GetDefaultSettingsForBossesAsDictionary();
            }
            foreach (int key in AllBosses.Keys)
            {
                listViewBosses.Items.Add(new ListViewItem() { Name = key.ToString(), Text = AllBosses[key].Name });
            }
        }

        private void listViewBosses_DoubleClick(object sender, EventArgs e)
        {
            var selected = listViewBosses.SelectedItems[0];
            int.TryParse(selected.Name, out int bossId);
            new FormEditBossData(this, AllBosses[bossId]).Show();
        }

        private async void FormTwitchLogMessages_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            using (StreamWriter writer = new StreamWriter($@"{mainLink.LocalDir}\twitch_messages.txt"))
            {
                await writer.WriteLineAsync("## Edit the contents of this file at your own risk, use the application interface instead.");
                foreach (int key in AllBosses.Keys)
                {
                    await writer.WriteLineAsync($"{AllBosses[key].BossId}<;>{AllBosses[key].Name}<;>{AllBosses[key].SuccessMsg}<;>{AllBosses[key].FailMsg}<;>{AllBosses[key].Icon}");
                }
            }
        }
    }
}
