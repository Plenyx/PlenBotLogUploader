using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.DPSReport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormBossData : Form
    {
        #region definitions

        // fields
        private readonly FormTemplateBossData templateLink;
        private int bossesIdsKey = 0;
        private readonly IDictionary<int, BossData> allBosses;

        #endregion

        public FormBossData()
        {
            templateLink = new FormTemplateBossData();
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;

            if (File.Exists($@"{ApplicationSettings.LocalDir}\boss_data.txt"))
            {
                try
                {
                    allBosses = Bosses.FromTxtFile($@"{ApplicationSettings.LocalDir}\boss_data.txt");
                    Bosses.SaveToJson(allBosses, $@"{ApplicationSettings.LocalDir}\boss_data.json");
                    File.Move($@"{ApplicationSettings.LocalDir}\boss_data.txt",$@"{ApplicationSettings.LocalDir}\boss_data_migrated.txt");
                }
                catch
                {
                    allBosses = Bosses.GetDefaultSettingsForBossesAsDictionary();
                }
            }
            else if (File.Exists($@"{ApplicationSettings.LocalDir}\boss_data.json"))
            {
                try
                {
                    allBosses = Bosses.FromJsonFile($@"{ApplicationSettings.LocalDir}\boss_data.json");
                }
                catch
                {
                    allBosses = Bosses.GetDefaultSettingsForBossesAsDictionary();
                }
            } 
            else
            {
                allBosses = Bosses.GetDefaultSettingsForBossesAsDictionary();
            }

            bossesIdsKey = allBosses.Count;
            
            foreach (var key in allBosses.Keys)
            {
                listViewBosses.Items.Add(new ListViewItem { Name = key.ToString(), Text = allBosses[key].Name });
            }
        }

        private void ListViewBosses_DoubleClick(object sender, EventArgs e)
        {
            var selected = listViewBosses.SelectedItems[0];
            int.TryParse(selected.Name, out int reservedId);
            new FormEditBossData(this, allBosses[reservedId], reservedId).Show();
        }

        private void FormBossData_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            Bosses.SaveToJson(allBosses, $@"{ApplicationSettings.LocalDir}\boss_data.json");
        }

        private void ButtonResetSettings_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to reset all the bosses?\nThis will undo all Discord webhook icon and Twitch messages settings and reset them to their default state.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.Yes))
            {
                listViewBosses.Items.Clear();
                allBosses.Clear();
                foreach (var keyPair in Bosses.GetDefaultSettingsForBossesAsDictionary())
                {
                    allBosses.Add(keyPair.Key, keyPair.Value);
                }
                bossesIdsKey = allBosses.Count;
                foreach (var bossEntry in allBosses)
                {
                    listViewBosses.Items.Add(new ListViewItem() { Name = bossEntry.Key.ToString(), Text = bossEntry.Value.Name });
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

        private void ToolStripMenuItemEditBoss_Click(object sender, EventArgs e)
        {
            if (listViewBosses.SelectedItems.Count > 0)
            {
                var selected = listViewBosses.SelectedItems[0];
                int.TryParse(selected.Name, out int reservedId);
                new FormEditBossData(this, allBosses[reservedId], reservedId).Show();
            }
        }

        private void ToolStripMenuItemDeleteBoss_Click(object sender, EventArgs e)
        {
            if (listViewBosses.SelectedItems.Count > 0)
            {
                var selected = listViewBosses.SelectedItems[0];
                int.TryParse(selected.Name, out int reservedId);
                var result = MessageBox.Show("Are you sure you want to delete this boss?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result.Equals(DialogResult.Yes))
                {
                    listViewBosses.Items.RemoveByKey(reservedId.ToString());
                    allBosses.Remove(reservedId);
                }
            }
        }

        private void ContextMenuStripInteract_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            toolStripMenuItemEditBoss.Enabled = listViewBosses.SelectedItems.Count > 0;
            toolStripMenuItemDeleteBoss.Enabled = listViewBosses.SelectedItems.Count > 0;
        }

        private void ButtonOpenTemplate_Click(object sender, EventArgs e)
        {
            templateLink.Show();
            templateLink.BringToFront();
        }
    }
}