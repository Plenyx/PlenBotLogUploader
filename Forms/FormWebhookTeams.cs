using PlenBotLogUploader.AppSettings;
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
    public partial class FormWebhookTeams : Form
    {
        #region definitions
        // fields
        private int teamIdsKey = 0;
        private readonly Dictionary<int, WebhookTeam> allTeams = WebhookTeams.All;
        private readonly Dictionary<int, DiscordWebhookData> allWebhooks = DiscordWebhooks.All;
        #endregion

        public FormWebhookTeams()
        {
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            if (File.Exists($@"{ApplicationSettings.LocalDir}\webhook_teams.txt"))
            {
                try
                {
                    allTeams = WebhookTeams.FromFile($@"{ApplicationSettings.LocalDir}\webhook_teams.txt");
                    teamIdsKey = allTeams.Values.Select(x => x.ID).OrderByDescending(x => x).First() + 1;
                }
                catch
                {
                    WebhookTeams.ResetDictionary();
                    teamIdsKey = 1;
                }
            }
            else
            {
                WebhookTeams.ResetDictionary();
            }
            foreach (int key in allTeams.Keys.Skip(1))
            {
                listBoxWebhookTeams.Items.Add(allTeams[key]);
            }
        }

        private async void FormWebhookTeams_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            using (var writer = new StreamWriter($@"{ApplicationSettings.LocalDir}\webhook_teams.txt"))
            {
                await writer.WriteLineAsync("## Edit the contents of this file at your own risk, use the application interface instead.");
                foreach (int key in allTeams.Keys)
                {
                    await writer.WriteLineAsync(allTeams[key].ToString(true));
                }
            }
        }

        private void ContextMenuStripInteract_Opening(object sender, CancelEventArgs e)
        {
            var toggle = listBoxWebhookTeams.SelectedItems.Count > 0;
            toolStripMenuItemEdit.Enabled = toggle;
            toolStripMenuItemDelete.Enabled = toggle;
        }

        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            var item = (WebhookTeam)listBoxWebhookTeams.SelectedItem;
            foreach (var webhook in allWebhooks.Values)
            {
                if (webhook.Team.Equals(item))
                {
                    webhook.Team = allTeams.Values.First();
                }
            }
            allTeams.Remove(item.ID);
            listBoxWebhookTeams.Items.Remove(item);
        }

        private void ToolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            teamIdsKey++;
            new FormEditTeam(this, null, teamIdsKey).Show();
        }

        private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            var item = (WebhookTeam)listBoxWebhookTeams.SelectedItem;
            new FormEditTeam(this, item, item.ID).Show();
        }

        private void ListBoxWebhookTeams_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxWebhookTeams.SelectedItem != null)
            {
                var item = (WebhookTeam)listBoxWebhookTeams.SelectedItem;
                new FormEditTeam(this, item, item.ID).Show();
            }
        }

        private void ButtonAddTeam_Click(object sender, EventArgs e)
        {
            teamIdsKey++;
            new FormEditTeam(this, null, teamIdsKey).Show();
        }
    }
}
