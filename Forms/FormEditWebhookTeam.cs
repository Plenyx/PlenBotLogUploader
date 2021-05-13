using PlenBotLogUploader.Teams;
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
        private readonly Dictionary<int, WebhookTeam> allTeams = WebhookTeams.All;
        #endregion

        public FormEditTeam(FormWebhookTeams teamsLink, WebhookTeam data, int reservedId)
        {
            this.teamsLink = teamsLink;
            this.data = data;
            this.reservedId = reservedId;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            Text = (data == null) ? "Add a new team" : "Edit an existing team";
            textBoxName.Text = data?.Name ?? "";
            radioButtonLimiterMin.Checked = true;
            textBoxLimiterValue.Text = data?.LimiterValue.ToString() ?? "1";
            textBoxAccountNames.Clear();
            if (data != null)
            {
                textBoxAccountNames.Text = data.AccountNames.Aggregate((x, y) => $"{x}{System.Environment.NewLine}{y}");
            }
        }

        private void FormEditTeam_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBoxName.Text.Trim() != "")
            {
                var limiterToggle = WebhookTeamLimiter.Min;
                int.TryParse(textBoxLimiterValue.Text, out int limiterValue);
                var accountNames = textBoxAccountNames.Lines.ToList();
                if (data == null)
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
                }
            }
        }
    }
}
