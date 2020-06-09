using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using PlenBotLogUploader.Tools;
using PlenBotLogUploader.DPSReport;
using PlenBotLogUploader.DiscordAPI;

namespace PlenBotLogUploader
{
    public partial class FormEditDiscordWebhook : Form
    {
        #region definitions
        // fields
        private readonly FormDiscordWebhooks discordPingLink;
        private readonly DiscordWebhookData data;
        private readonly int reservedId;
        private readonly Dictionary<int, DiscordWebhookData> allWebhooks = DiscordWebhooks.GetAllWebhooks();
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
            var bosses = Bosses.GetAllBosses();
            bosses = bosses
                .OrderBy(anon => anon.Value.Type)
                .ThenBy(anon => anon.Value.Name)
                .ToDictionary(anon => anon.Key, anon => anon.Value);
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
                    allWebhooks[reservedId] = new DiscordWebhookData() { Active = true, Name = textBoxName.Text, URL = textBoxUrl.Text, SuccessFailToggle = successFailToggle, ShowPlayers = checkBoxPlayers.Checked, BossesDisable = ConvertCheckboxListToList() };
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
                if (item.GetType() == typeof(BossesDisableHelperClass))
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
