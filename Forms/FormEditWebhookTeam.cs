using PlenBotLogUploader.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormEditTeam : Form
    {
        #region definitions
        // fields
        private readonly FormWebhookTeams teamsLink;
        private readonly WebhookTeam data;
        private readonly int reservedId;
        private readonly IDictionary<int, WebhookTeam> allTeams = WebhookTeams.All;
        #endregion

        public FormEditTeam(FormWebhookTeams teamsLink, WebhookTeam data, int reservedId)
        {
            this.teamsLink = teamsLink;
            this.data = data;
            this.reservedId = reservedId;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            Text = (data is null) ? "Add a new team" : "Edit an existing team";
            textBoxName.Text = data?.Name ?? "";
            switch (data?.Limiter)
            {
                case WebhookTeamLimiter.Exact:
                    radioButtonLimiterExact.Checked = true;
                    break;
                case WebhookTeamLimiter.Except:
                    radioButtonLimiterExcept.Checked = true;
                    break;
                default:
                    radioButtonLimiterMin.Checked = true;
                    break;
            }
            radioButtonLimiterMin.Checked = true;
            textBoxLimiterValue.Text = data?.LimiterValue.ToString() ?? "1";
            textBoxAccountNames.Clear();
            if (!(data is null))
            {
                textBoxAccountNames.Text = data.AccountNames.Aggregate((x, y) => $"{x}{Environment.NewLine}{y}");
            }
        }

        private void FormEditTeam_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxName.Text.Trim()))
            {
                var limiterToggle = WebhookTeamLimiter.Min;
                if (radioButtonLimiterExact.Checked)
                {
                    limiterToggle = WebhookTeamLimiter.Exact;
                }
                else if (radioButtonLimiterExcept.Checked)
                {
                    limiterToggle = WebhookTeamLimiter.Except;
                }
                int.TryParse(textBoxLimiterValue.Text, out int limiterValue);
                var accountNames = textBoxAccountNames.Lines.ToList();
                if (data is null)
                {
                    allTeams[reservedId] = new WebhookTeam() { ID = reservedId, Name = textBoxName.Text, Limiter = limiterToggle, LimiterValue = limiterValue, AccountNames = accountNames };
                    teamsLink.listBoxWebhookTeams.Items.Add(allTeams[reservedId]);
                }
                else
                {
                    var team = allTeams[reservedId];
                    team.Name = textBoxName.Text;
                    team.Limiter = limiterToggle;
                    team.LimiterValue = limiterValue;
                    team.AccountNames = accountNames;
                    teamsLink.listBoxWebhookTeams.DisplayMember = "";
                    teamsLink.listBoxWebhookTeams.DisplayMember = "Name";
                }
            }
        }

        private void RadioButtonLimiterMin_CheckedChanged(object sender, EventArgs e)
        {
            textBoxLimiterValue.Enabled = !radioButtonLimiterExcept.Checked;
        }

        private void RadioButtonLimiterExact_CheckedChanged(object sender, EventArgs e)
        {
            textBoxLimiterValue.Enabled = !radioButtonLimiterExcept.Checked;
        }

        private void RadioButtonLimiterExcept_CheckedChanged(object sender, EventArgs e)
        {
            textBoxLimiterValue.Enabled = !radioButtonLimiterExcept.Checked;
        }
    }
}
