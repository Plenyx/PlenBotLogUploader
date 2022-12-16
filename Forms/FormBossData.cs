using PlenBotLogUploader.DpsReport;
using PlenBotLogUploader.Tools;
using System;
using System.IO;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormBossData : Form
    {
        #region definitions
        // fields
        private readonly FormTemplateBossData templateLink;
        #endregion

        internal FormBossData()
        {
            templateLink = new FormTemplateBossData();
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;

            LoadBossData();

            foreach (var boss in Bosses.All.AsSpan())
            {
                listViewBosses.Items.Add(new ListViewItemCustom<BossData>() { Item = boss });
            }
        }

        private void ListViewBosses_DoubleClick(object sender, EventArgs e)
        {
            if ((listViewBosses.SelectedItems.Count > 0) && (listViewBosses.SelectedItems[0] is ListViewItemCustom<BossData> item))
            {
                new FormEditBossData(this, item.Item).ShowDialog();
            }
        }

        private void FormBossData_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            Bosses.SaveToJson(Bosses.All);
        }

        private void ButtonResetSettings_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to reset all the bosses?\nThis will undo all Discord webhook icon and Twitch messages settings and reset them to their default state.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (!result.Equals(DialogResult.Yes))
            {
                return;
            }
            listViewBosses.Items.Clear();
            Bosses.All.Clear();
            Bosses.All.AddRange(Bosses.GetDefaultSettingsForBossesAsDictionary());
            foreach (var boss in Bosses.All.AsSpan())
            {
                listViewBosses.Items.Add(new ListViewItemCustom<BossData>() { Item = boss });
            }
        }

        private void AddNewClick() => new FormEditBossData(this, null).ShowDialog();

        private void ButtonAddNew_Click(object sender, EventArgs e) => AddNewClick();

        private void ToolStripMenuItemAddNew_Click(object sender, EventArgs e) => AddNewClick();

        private void ToolStripMenuItemEditBoss_Click(object sender, EventArgs e)
        {
            if ((listViewBosses.SelectedItems.Count == 0) || (listViewBosses.SelectedItems[0] is not ListViewItemCustom<BossData> item))
            {
                return;
            }
            new FormEditBossData(this, item.Item).ShowDialog();
        }

        private void ToolStripMenuItemDeleteBoss_Click(object sender, EventArgs e)
        {
            if ((listViewBosses.SelectedItems.Count == 0) || (listViewBosses.SelectedItems[0] is not ListViewItemCustom<BossData> item))
            {
                return;
            }
            var result = MessageBox.Show("Are you sure you want to delete this boss?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (!result.Equals(DialogResult.Yes))
            {
                return;
            }
            listViewBosses.Items.RemoveByKey(item.Name);
            Bosses.All.Remove(item.Item);
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

        private static void LoadBossData()
        {
            try
            {
                if (File.Exists(Bosses.JsonFileLocation))
                {
                    Bosses.FromJsonFile(Bosses.JsonFileLocation);
                }
                Bosses.GetDefaultSettingsForBossesAsDictionary();
            }
            catch
            {
                Bosses.GetDefaultSettingsForBossesAsDictionary();
            }
        }
    }
}
