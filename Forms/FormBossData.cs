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
        // fields
        private readonly FormMain mainLink;
        private readonly FormTemplateBossData templateLink;
        private int bossesIdsKey = 0;
        private readonly Dictionary<int, BossData> allBosses = Bosses.GetAllBosses();
        #endregion

        public FormBossData(FormMain mainLink)
        {
            this.mainLink = mainLink;
            templateLink = new FormTemplateBossData();
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            if (File.Exists($@"{mainLink.LocalDir}\boss_data.txt"))
            {
                try
                {
                    allBosses = Bosses.FromFile($@"{mainLink.LocalDir}\boss_data.txt");
                    bossesIdsKey = allBosses.Count;
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

        private void ListViewBosses_DoubleClick(object sender, EventArgs e)
        {
            var selected = listViewBosses.SelectedItems[0];
            int.TryParse(selected.Name, out int reservedId);
            new FormEditBossData(this, allBosses[reservedId], reservedId).Show();
        }

        private async void FormBossData_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            using (StreamWriter writer = new StreamWriter($@"{mainLink.LocalDir}\boss_data.txt"))
            {
                await writer.WriteLineAsync("## Edit the contents of this file at your own risk, use the application interface instead.");
                foreach (int key in allBosses.Keys)
                {
                    await writer.WriteLineAsync(allBosses[key].ToString(true));
                }
            }
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
