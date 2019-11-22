using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using PlenBotLogUploader.DPSReport;

namespace PlenBotLogUploader
{
    public partial class FormBossData : Form
    {
        #region definitions
        // fields
        private FormMain mainLink;
        private FormTemplateBossData templateLink;
        private int bossesIdsKey = 0;
        private Dictionary<int, BossData> allBosses = Bosses.GetAllBosses();
        #endregion

        public FormBossData(FormMain mainLink)
        {
            this.mainLink = mainLink;
            templateLink = new FormTemplateBossData();
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            if (File.Exists($@"{mainLink.LocalDir}\twitch_messages.txt"))
            {
                File.Move($@"{mainLink.LocalDir}\twitch_messages.txt", $@"{mainLink.LocalDir}\boss_data.txt");
            }
            if (File.Exists($@"{mainLink.LocalDir}\boss_data.txt"))
            {
                try
                {
                    using (StreamReader reader = new StreamReader($@"{mainLink.LocalDir}\boss_data.txt"))
                    {
                        string line = reader.ReadLine();
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] values = line.Split(new string[] { "<;>" }, StringSplitOptions.None);
                            int.TryParse(values[0], out int bossId);
                            int.TryParse(values[5], out int type);
                            int.TryParse(values[6], out int isEvent);
                            AddBoss(new BossData() { BossId = bossId, Name = values[1], SuccessMsg = values[2], FailMsg = values[3], Icon = values[4], Type = (BossType)(type), Event = (isEvent == 1) ? true : false });
                        }
                    }
                    if(allBosses.Where(anon => anon.Value.BossId.Equals((int)BossIds.IcebroodConstruct)).Count() == 0)
                    {
                        allBosses.Clear();
                        foreach (var keyPair in Bosses.GetDefaultSettingsForBossesAsDictionary())
                        {
                            allBosses.Add(keyPair.Key, keyPair.Value);
                        }
                        bossesIdsKey = allBosses.Count;
                    }
                }
                catch
                {
                    allBosses.Clear();
                    foreach (var keyPair in Bosses.GetDefaultSettingsForBossesAsDictionary())
                    {
                        allBosses.Add(keyPair.Key, keyPair.Value);
                    }
                    bossesIdsKey = allBosses.Count;
                }
            }
            else
            {
                allBosses.Clear();
                foreach (var keyPair in Bosses.GetDefaultSettingsForBossesAsDictionary())
                {
                    allBosses.Add(keyPair.Key, keyPair.Value);
                }
                bossesIdsKey = allBosses.Count;
            }
            foreach (int key in allBosses.Keys)
            {
                listViewBosses.Items.Add(new ListViewItem() { Name = key.ToString(), Text = allBosses[key].Name });
            }
        }

        public void AddBoss(BossData data)
        {
            bossesIdsKey++;
            allBosses.Add(bossesIdsKey, data);
        }

        private void listViewBosses_DoubleClick(object sender, EventArgs e)
        {
            var selected = listViewBosses.SelectedItems[0];
            int.TryParse(selected.Name, out int reservedId);
            new FormEditBossData(this, allBosses[reservedId], reservedId).Show();
        }

        private async void FormTwitchLogMessages_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            using (StreamWriter writer = new StreamWriter($@"{mainLink.LocalDir}\boss_data.txt"))
            {
                await writer.WriteLineAsync("## Edit the contents of this file at your own risk, use the application interface instead.");
                foreach (int key in allBosses.Keys)
                {
                    await writer.WriteLineAsync($"{allBosses[key].BossId}<;>{allBosses[key].Name}<;>{allBosses[key].SuccessMsg}<;>{allBosses[key].FailMsg}<;>{allBosses[key].Icon}<;>{(int)(allBosses[key].Type)}<;>{((allBosses[key].Event) ? "1" : "0")}");
                }
            }
        }

        private void ButtonResetSettings_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to reset all the bosses?\nThis will undo all Discord webhook icon and Twitch messages settings and reset them to their default state.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                listViewBosses.Items.Clear();
                allBosses.Clear();
                foreach (var keyPair in Bosses.GetDefaultSettingsForBossesAsDictionary())
                {
                    allBosses.Add(keyPair.Key, keyPair.Value);
                }
                bossesIdsKey = allBosses.Count;
                foreach (int key in allBosses.Keys)
                {
                    listViewBosses.Items.Add(new ListViewItem() { Name = key.ToString(), Text = allBosses[key].Name });
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
                    allBosses.Remove(reservedId);
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
