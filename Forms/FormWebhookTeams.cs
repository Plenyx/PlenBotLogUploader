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
        private int teamIdsKey;
        private readonly IDictionary<int, WebhookTeam> allTeams;
        private readonly IDictionary<int, DiscordWebhookData> allWebhooks = DiscordWebhooks.All;
        #endregion

        public FormWebhookTeams()
        {
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            allTeams = LoadWebhookTeams();

            teamIdsKey = allTeams.Values.Select(x => x.ID).OrderByDescending(x => x).First() + 1;

            foreach (var key in allTeams.Keys.Skip(1))
            {
                listBoxWebhookTeams.Items.Add(allTeams[key]);
            }
        }

        private IDictionary<int, WebhookTeam> LoadWebhookTeams()
        {
            IDictionary<int, WebhookTeam> webhookTeams = new Dictionary<int, WebhookTeam>();
            try
            {
                if (File.Exists(WebhookTeams.TxtFileLocation))
                {
                    webhookTeams = WebhookTeams.FromFile(WebhookTeams.TxtFileLocation);
                    WebhookTeams.SaveToJson(allTeams);
                    File.Move(WebhookTeams.TxtFileLocation, WebhookTeams.MigratedTxtFileLocation);
                }
                else if (File.Exists(WebhookTeams.JsonFileLocation))
                {
                    webhookTeams = WebhookTeams.FromJsonFile(WebhookTeams.JsonFileLocation);
                }
                else
                {
                    webhookTeams.Add(0, new WebhookTeam {Name = "No team selected"});
                }
            }
            catch
            {
                webhookTeams = new Dictionary<int, WebhookTeam>();
                webhookTeams.Add(0, new WebhookTeam {Name = "No team selected"});
            }
            return webhookTeams;
        }

        private void FormWebhookTeams_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            WebhookTeams.SaveToJson(allTeams);
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
            if (!(listBoxWebhookTeams.SelectedItem is null))
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