using PlenBotLogUploader.DiscordAPI;
using PlenBotLogUploader.Teams;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormTeams : Form
    {
        #region definitions
        // fields
        private int teamIdsKey;
        private readonly IDictionary<int, Team> allTeams;
        private readonly IDictionary<int, DiscordWebhookData> allWebhooks = DiscordWebhooks.All;
        #endregion

        public FormTeams()
        {
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            allTeams = LoadTeams();

            teamIdsKey = allTeams.Values.Select(x => x.ID).OrderByDescending(x => x).First() + 1;

            foreach (var key in allTeams.Keys.Skip(1))
            {
                listBoxTeams.Items.Add(allTeams[key]);
            }
        }

        private IDictionary<int, Team> LoadTeams()
        {
            try
            {
                if (File.Exists(Teams.Teams.JsonFileLocation))
                {
                    return Teams.Teams.FromJsonFile(Teams.Teams.JsonFileLocation);
                }
                return Teams.Teams.ResetDictionary();
            }
            catch
            {
                return Teams.Teams.ResetDictionary();
            }
        }

        private void FormTeams_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            Teams.Teams.SaveToJson(allTeams);
        }

        private void ContextMenuStripInteract_Opening(object sender, CancelEventArgs e)
        {
            var toggle = listBoxTeams.SelectedItems.Count > 0;
            toolStripMenuItemEdit.Enabled = toggle;
            toolStripMenuItemDelete.Enabled = toggle;
        }

        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            var item = (Team)listBoxTeams.SelectedItem;
            foreach (var webhook in allWebhooks.Values)
            {
                if (webhook.Team.Equals(item))
                {
                    webhook.Team = allTeams.Values.First();
                }
            }
            listBoxTeams.SelectedItem = null;
            allTeams.Remove(item.ID);
            listBoxTeams.Items.Remove(item);
        }

        private void ToolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            teamIdsKey++;
            listBoxTeams.SelectedItem = null;
            new FormEditTeam(this, null, teamIdsKey).Show();
        }

        private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            var item = (Team)listBoxTeams.SelectedItem;
            listBoxTeams.SelectedItem = null;
            new FormEditTeam(this, item, item.ID).Show();
        }

        private void ListBoxTeams_DoubleClick(object sender, EventArgs e)
        {
            if (!(listBoxTeams.SelectedItem is null))
            {
                var item = (Team)listBoxTeams.SelectedItem;
                new FormEditTeam(this, item, item.ID).Show();
            }
            listBoxTeams.SelectedItem = null;
        }

        private void ButtonAddTeam_Click(object sender, EventArgs e)
        {
            teamIdsKey++;
            listBoxTeams.SelectedItem = null;
            new FormEditTeam(this, null, teamIdsKey).Show();
        }
    }
}
