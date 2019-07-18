using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using PlenBotLogUploader.DPSReport;

namespace PlenBotLogUploader
{
    public partial class FormBossData : Form
    {
        #region definitions
        // properties
        public Dictionary<int, BossData> AllBosses { get; private set; }

        // fields
        private FormMain mainLink;
        private FormTemplateBossData templateLink;
        private int bossesIdsKey = 0;
        #endregion

        public FormBossData(FormMain mainLink)
        {
            this.mainLink = mainLink;
            templateLink = new FormTemplateBossData(this);
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            if (File.Exists($@"{mainLink.LocalDir}\twitch_messages.txt"))
            {
                File.Move($@"{mainLink.LocalDir}\twitch_messages.txt", $@"{mainLink.LocalDir}\boss_data.txt");
            }
            if (File.Exists($@"{mainLink.LocalDir}\boss_data.txt"))
            {
                AllBosses = new Dictionary<int, BossData>();
                try
                {
                    using (StreamReader reader = new StreamReader($@"{mainLink.LocalDir}\boss_data.txt"))
                    {
                        string line = reader.ReadLine();
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] values = line.Split(new string[] { "<;>" }, StringSplitOptions.None);
                            int.TryParse(values[0], out int bossId);
                            AddBoss(new BossData() { BossId = bossId, Name = values[1], SuccessMsg = values[2], FailMsg = values[3], Icon = values[4] });
                        }
                    }
                }
                catch
                {
                    AllBosses = Bosses.GetDefaultSettingsForBossesAsDictionary();
                    bossesIdsKey = AllBosses.Count;
                }
            }
            else
            {
                AllBosses = Bosses.GetDefaultSettingsForBossesAsDictionary();
                bossesIdsKey = AllBosses.Count;
            }
            foreach (int key in AllBosses.Keys)
            {
                listViewBosses.Items.Add(new ListViewItem() { Name = key.ToString(), Text = AllBosses[key].Name });
            }
        }

        public void AddBoss(BossData data)
        {
            bossesIdsKey++;
            AllBosses.Add(bossesIdsKey, data);
        }

        private void listViewBosses_DoubleClick(object sender, EventArgs e)
        {
            var selected = listViewBosses.SelectedItems[0];
            int.TryParse(selected.Name, out int reservedId);
            new FormEditBossData(this, AllBosses[reservedId], reservedId).Show();
        }

        private async void FormTwitchLogMessages_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            using (StreamWriter writer = new StreamWriter($@"{mainLink.LocalDir}\boss_data.txt"))
            {
                await writer.WriteLineAsync("## Edit the contents of this file at your own risk, use the application interface instead.");
                foreach (int key in AllBosses.Keys)
                {
                    await writer.WriteLineAsync($"{AllBosses[key].BossId}<;>{AllBosses[key].Name}<;>{AllBosses[key].SuccessMsg}<;>{AllBosses[key].FailMsg}<;>{AllBosses[key].Icon}");
                }
            }
        }

        private void ButtonResetSettings_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to reset all the bosses?\nThis will undo all Discord webhook icon and Twitch messages settings and reset them to their default state.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                listViewBosses.Items.Clear();
                AllBosses = Bosses.GetDefaultSettingsForBossesAsDictionary();
                bossesIdsKey = AllBosses.Count;
                foreach (int key in AllBosses.Keys)
                {
                    listViewBosses.Items.Add(new ListViewItem() { Name = key.ToString(), Text = AllBosses[key].Name });
                }
            }
        }

        private void ButtonAddNew_Click(object sender, EventArgs e)
        {
            bossesIdsKey++;
            new FormEditBossData(this, null, bossesIdsKey).Show();
        }

        private void ToolStripMenuItemAddNew_Click(object sender, EventArgs e)
        {
            bossesIdsKey++;
            new FormEditBossData(this, null, bossesIdsKey).Show();
        }

        private void ToolStripMenuItemDeleteBoss_Click(object sender, EventArgs e)
        {
            if (listViewBosses.SelectedItems.Count > 0)
            {
                var selected = listViewBosses.SelectedItems[0];
                int.TryParse(selected.Name, out int reservedId);
                DialogResult result = MessageBox.Show("Are you sure you want to delete this boss?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    listViewBosses.Items.RemoveByKey(reservedId.ToString());
                    AllBosses.Remove(reservedId);
                }
            }
        }

        private void ContextMenuStripInteract_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            toolStripMenuItemDeleteBoss.Enabled = listViewBosses.SelectedItems.Count > 0;
        }

        private void ButtonOpenTemplate_Click(object sender, EventArgs e)
        {
            templateLink.Show();
            templateLink.BringToFront();
        }
    }
}
