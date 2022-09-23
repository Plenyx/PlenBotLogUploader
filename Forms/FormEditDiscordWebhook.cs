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
        private readonly IDictionary<int, DiscordWebhookData> allWebhooks = DiscordWebhooks.All;
        #endregion

        internal FormEditDiscordWebhook(FormDiscordWebhooks discordPingLink, DiscordWebhookData data, int reservedId)
        {
            this.discordPingLink = discordPingLink;
            this.data = data;
            this.reservedId = reservedId;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            Text = (data is null) ? "Add a new webhook" : "Edit an existing webhook";
            textBoxName.Text = data?.Name ?? string.Empty;
            textBoxUrl.Text = data?.URL ?? string.Empty;
            switch (data?.SuccessFailToggle ?? DiscordWebhookDataSuccessToggle.OnSuccessAndFailure)
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
            checkBoxPlayers.Checked = data?.ShowPlayers ?? true;
            var bosses = Bosses.All;
            bosses = bosses
                .OrderBy(x => x.Value.Type)
                .ThenBy(x => x.Value.Name)
                .ToDictionary(x => x.Key, x => x.Value);
            var teams = Teams.Teams.All;
            foreach (var team in teams.Values)
            {
                comboBoxTeam.Items.Add(team);
            }
            comboBoxTeam.SelectedItem = data?.Team ?? teams[0];
            foreach (var bossNumber in bosses.Keys)
            {
                checkedListBoxBossesEnable.Items.Add(new BossesDisableHelperClass() { BossID = bosses[bossNumber].BossId, Text = $"{bosses[bossNumber].Type}: {bosses[bossNumber].Name} ({bosses[bossNumber].BossId})" }, data?.IsBossEnabled(bosses[bossNumber].BossId) ?? true);
            }
        }

        private void FormEditDiscordWebhook_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxName.Text.Trim()))
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
                if (data is null)
                {
                    allWebhooks[reservedId] = new DiscordWebhookData() { Active = true, Name = textBoxName.Text, URL = textBoxUrl.Text, SuccessFailToggle = successFailToggle, ShowPlayers = checkBoxPlayers.Checked, BossesDisable = ConvertCheckboxListToList(), Team = (Team)comboBoxTeam.SelectedItem };
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
                    webhook.Team = (Team)comboBoxTeam.SelectedItem;
                    discordPingLink.listViewDiscordWebhooks.Items[discordPingLink.listViewDiscordWebhooks.Items.IndexOfKey(reservedId.ToString())] = new ListViewItem() { Name = reservedId.ToString(), Text = textBoxName.Text, Checked = data.Active };
                }
            }
        }

        private List<int> ConvertCheckboxListToList()
        {
            var list = new List<int>();
            for (var i = 0; i < checkedListBoxBossesEnable.Items.Count; i++)
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

        private void ButtonUnSelectAll_Click(object sender, System.EventArgs e)
        {
            var allSelected = true;
            for (var i = 0; i < checkedListBoxBossesEnable.Items.Count; i++)
            {
                var checkedState = checkedListBoxBossesEnable.GetItemChecked(i);
                if (!checkedState)
                {
                    allSelected = false;
                    break;
                }
            }
            if (!allSelected)
            {
                for (var i = 0; i < checkedListBoxBossesEnable.Items.Count; i++)
                {
                    checkedListBoxBossesEnable.SetItemChecked(i, true);
                }
            }
            else
            {
                for (var i = 0; i < checkedListBoxBossesEnable.Items.Count; i++)
                {
                    checkedListBoxBossesEnable.SetItemChecked(i, false);
                }
            }
        }

        private void ButtonUnSelectAllRaids_Click(object sender, System.EventArgs e)
        {
            var allSelected = true;
            for (var i = 0; i < checkedListBoxBossesEnable.Items.Count; i++)
            {
                var item = (BossesDisableHelperClass)checkedListBoxBossesEnable.Items[i];
                if (Bosses.All.Values.Where(x => x.BossId.Equals(item.BossID)).FirstOrDefault()?.Type.Equals(BossType.Raid) ?? false)
                {
                    var checkedState = checkedListBoxBossesEnable.GetItemChecked(i);
                    if (!checkedState)
                    {
                        allSelected = false;
                        break;
                    }
                }
            }
            if (!allSelected)
            {
                for (var i = 0; i < checkedListBoxBossesEnable.Items.Count; i++)
                {
                    var item = (BossesDisableHelperClass)checkedListBoxBossesEnable.Items[i];
                    if (Bosses.All.Values.Where(x => x.BossId.Equals(item.BossID)).FirstOrDefault()?.Type.Equals(BossType.Raid) ?? false)
                    {
                        checkedListBoxBossesEnable.SetItemChecked(i, true);
                    }
                }
            }
            else
            {
                for (var i = 0; i < checkedListBoxBossesEnable.Items.Count; i++)
                {
                    var item = (BossesDisableHelperClass)checkedListBoxBossesEnable.Items[i];
                    if (Bosses.All.Values.Where(x => x.BossId.Equals(item.BossID)).FirstOrDefault()?.Type.Equals(BossType.Raid) ?? false)
                    {
                        checkedListBoxBossesEnable.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void ButtonUnSelectAllFractals_Click(object sender, System.EventArgs e)
        {
            var allSelected = true;
            for (var i = 0; i < checkedListBoxBossesEnable.Items.Count; i++)
            {
                var item = (BossesDisableHelperClass)checkedListBoxBossesEnable.Items[i];
                if (Bosses.All.Values.Where(x => x.BossId.Equals(item.BossID)).FirstOrDefault()?.Type.Equals(BossType.Fractal) ?? false)
                {
                    var checkedState = checkedListBoxBossesEnable.GetItemChecked(i);
                    if (!checkedState)
                    {
                        allSelected = false;
                        break;
                    }
                }
            }
            if (!allSelected)
            {
                for (var i = 0; i < checkedListBoxBossesEnable.Items.Count; i++)
                {
                    var item = (BossesDisableHelperClass)checkedListBoxBossesEnable.Items[i];
                    if (Bosses.All.Values.Where(x => x.BossId.Equals(item.BossID)).FirstOrDefault()?.Type.Equals(BossType.Fractal) ?? false)
                    {
                        checkedListBoxBossesEnable.SetItemChecked(i, true);
                    }
                }
            }
            else
            {
                for (var i = 0; i < checkedListBoxBossesEnable.Items.Count; i++)
                {
                    var item = (BossesDisableHelperClass)checkedListBoxBossesEnable.Items[i];
                    if (Bosses.All.Values.Where(x => x.BossId.Equals(item.BossID)).FirstOrDefault()?.Type.Equals(BossType.Fractal) ?? false)
                    {
                        checkedListBoxBossesEnable.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void ButtonUnSelectAllStrikes_Click(object sender, System.EventArgs e)
        {
            var allSelected = true;
            for (var i = 0; i < checkedListBoxBossesEnable.Items.Count; i++)
            {
                var item = (BossesDisableHelperClass)checkedListBoxBossesEnable.Items[i];
                if (Bosses.All.Values.Where(x => x.BossId.Equals(item.BossID)).FirstOrDefault()?.Type.Equals(BossType.Strike) ?? false)
                {
                    var checkedState = checkedListBoxBossesEnable.GetItemChecked(i);
                    if (!checkedState)
                    {
                        allSelected = false;
                        break;
                    }
                }
            }
            if (!allSelected)
            {
                for (var i = 0; i < checkedListBoxBossesEnable.Items.Count; i++)
                {
                    var item = (BossesDisableHelperClass)checkedListBoxBossesEnable.Items[i];
                    if (Bosses.All.Values.Where(x => x.BossId.Equals(item.BossID)).FirstOrDefault()?.Type.Equals(BossType.Strike) ?? false)
                    {
                        checkedListBoxBossesEnable.SetItemChecked(i, true);
                    }
                }
            }
            else
            {
                for (var i = 0; i < checkedListBoxBossesEnable.Items.Count; i++)
                {
                    var item = (BossesDisableHelperClass)checkedListBoxBossesEnable.Items[i];
                    if (Bosses.All.Values.Where(x => x.BossId.Equals(item.BossID)).FirstOrDefault()?.Type.Equals(BossType.Strike) ?? false)
                    {
                        checkedListBoxBossesEnable.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void ButtonUnSelectAllGolems_Click(object sender, System.EventArgs e)
        {
            var allSelected = true;
            for (var i = 0; i < checkedListBoxBossesEnable.Items.Count; i++)
            {
                var item = (BossesDisableHelperClass)checkedListBoxBossesEnable.Items[i];
                if (Bosses.All.Values.Where(x => x.BossId.Equals(item.BossID)).FirstOrDefault()?.Type.Equals(BossType.Golem) ?? false)
                {
                    var checkedState = checkedListBoxBossesEnable.GetItemChecked(i);
                    if (!checkedState)
                    {
                        allSelected = false;
                        break;
                    }
                }
            }
            if (!allSelected)
            {
                for (var i = 0; i < checkedListBoxBossesEnable.Items.Count; i++)
                {
                    var item = (BossesDisableHelperClass)checkedListBoxBossesEnable.Items[i];
                    if (Bosses.All.Values.Where(x => x.BossId.Equals(item.BossID)).FirstOrDefault()?.Type.Equals(BossType.Golem) ?? false)
                    {
                        checkedListBoxBossesEnable.SetItemChecked(i, true);
                    }
                }
            }
            else
            {
                for (var i = 0; i < checkedListBoxBossesEnable.Items.Count; i++)
                {
                    var item = (BossesDisableHelperClass)checkedListBoxBossesEnable.Items[i];
                    if (Bosses.All.Values.Where(x => x.BossId.Equals(item.BossID)).FirstOrDefault()?.Type.Equals(BossType.Golem) ?? false)
                    {
                        checkedListBoxBossesEnable.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void ButtonUnSelectWvW_Click(object sender, System.EventArgs e)
        {
            for (var i = 0; i < checkedListBoxBossesEnable.Items.Count; i++)
            {
                var item = (BossesDisableHelperClass)checkedListBoxBossesEnable.Items[i];
                if (item.BossID.Equals(1))
                {
                    checkedListBoxBossesEnable.SetItemChecked(i, !checkedListBoxBossesEnable.GetItemChecked(i));
                    break;
                }
            }
        }
    }
}
