using PlenBotLogUploader.DiscordAPI;
using PlenBotLogUploader.DPSReport;
using PlenBotLogUploader.Teams;
using PlenBotLogUploader.Tools;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormEditDiscordWebhook : Form
    {
        #region definitions
        // fields
        private readonly FormDiscordWebhooks discordPingLink;
        private readonly DiscordWebhookData data;
        private readonly int reservedId;
        private readonly Dictionary<int, DiscordWebhookData> allWebhooks = DiscordWebhooks.All;
        #endregion

        public FormEditDiscordWebhook(FormDiscordWebhooks discordPingLink, DiscordWebhookData data, int reservedId)
        {
            this.discordPingLink = discordPingLink;
            this.data = data;
            this.reservedId = reservedId;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            Text = (data == null) ? "Add a new webhook" : "Edit an existing webhook";
            textBoxName.Text = data?.Name ?? "";
            textBoxUrl.Text = data?.URL ?? "";
            switch(data?.SuccessFailToggle ?? DiscordWebhookDataSuccessToggle.OnSuccessAndFailure)
            {
                case DiscordWebhookDataSuccessToggle.OnSuccessOnly:
                    radioButtonOnlySuccess.Checked = true;
                    break;
                case DiscordWebhookDataSuccessToggle.OnFailOnly:
                    radioButtonOnlyFail.Checked = true;
                    break;
                default:
                    radioButtonOnlySuccessAndFail.Checked = true;
                    break;
            }
            checkBoxPlayers.Checked = data?.ShowPlayers ?? false;
            var bosses = Bosses.All;
            bosses = bosses
                .OrderBy(x => x.Value.Type)
                .ThenBy(x => x.Value.Name)
                .ToDictionary(x => x.Key, x => x.Value);
            var teams = WebhookTeams.All;
            foreach (var team in teams.Values)
            {
                comboBoxWebhookTeam.Items.Add(team);
            }
            comboBoxWebhookTeam.SelectedItem = (data == null || data.Team == null) ? teams[0] : data.Team;
            foreach (var bossNumber in bosses.Keys)
            {
                checkedListBoxBossesEnable.Items.Add(new BossesDisableHelperClass() { BossID = bosses[bossNumber].BossId, Text = $"{bosses[bossNumber].Type}: {bosses[bossNumber].Name} ({bosses[bossNumber].BossId})" }, data?.IsBossEnabled(bosses[bossNumber].BossId) ?? true);
            }
        }

        private void FormEditDiscordWebhook_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBoxName.Text.Trim() != "")
            {
                var successFailToggle = DiscordWebhookDataSuccessToggle.OnSuccessAndFailure;
                if (radioButtonOnlySuccess.Checked)
                {
                    successFailToggle = DiscordWebhookDataSuccessToggle.OnSuccessOnly;
                }
                else if (radioButtonOnlyFail.Checked)
                {
                    successFailToggle = DiscordWebhookDataSuccessToggle.OnFailOnly;
                }
                if (data == null)
                {
                    allWebhooks[reservedId] = new DiscordWebhookData() { Active = true, Name = textBoxName.Text, URL = textBoxUrl.Text, SuccessFailToggle = successFailToggle, ShowPlayers = checkBoxPlayers.Checked, BossesDisable = ConvertCheckboxListToList(), Team = (WebhookTeam)comboBoxWebhookTeam.SelectedItem };
                    discordPingLink.listViewDiscordWebhooks.Items.Add(new ListViewItem() { Name = reservedId.ToString(), Text = textBoxName.Text, Checked = true });
                }
                else
                {
                    var webhook = allWebhooks[reservedId];
                    webhook.Active = data.Active;
                    webhook.Name = textBoxName.Text;
                    webhook.URL = textBoxUrl.Text;
                    webhook.SuccessFailToggle = successFailToggle;
                    webhook.ShowPlayers = checkBoxPlayers.Checked;
                    webhook.BossesDisable = ConvertCheckboxListToList();
                    webhook.Team = (WebhookTeam)comboBoxWebhookTeam.SelectedItem;
                    discordPingLink.listViewDiscordWebhooks.Items[discordPingLink.listViewDiscordWebhooks.Items.IndexOfKey(reservedId.ToString())] = new ListViewItem() { Name = reservedId.ToString(), Text = textBoxName.Text, Checked = data.Active };
                }
            }
        }

        private List<int> ConvertCheckboxListToList()
        {
            var list = new List<int>();
            for (int i = 0; i < checkedListBoxBossesEnable.Items.Count; i++)
            {
                var item = checkedListBoxBossesEnable.Items[i];
                if (item.GetType().Equals(typeof(BossesDisableHelperClass)))
                {
                    var bossEnableHelper = (BossesDisableHelperClass)item;
                    var checkedState = checkedListBoxBossesEnable.GetItemChecked(i);
                    if (!checkedState)
                    {
                        list.Add(bossEnableHelper.BossID);
                    }
                }
            }
            return list;
        }
    }
}
