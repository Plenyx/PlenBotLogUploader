using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.DpsReport;
using PlenBotLogUploader.Properties;
using PlenBotLogUploader.Tools;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PlenBotLogUploader;

public partial class FormEditBossData : Form
{
    // fields
    private readonly BossData data;
    private readonly FormBossData editLink;
    private BossType bossTypeSwitch = BossType.None;

    internal FormEditBossData(FormBossData editLink, BossData data)
    {
        this.editLink = editLink;
        InitializeComponent();
        this.data = data;
        Icon = Resources.AppIcon;
        Text = data is null ? "Add a new boss" : $"{data.Name} ({data.BossId})";
        textBoxBossID.Text = data?.BossId.ToString() ?? "";
        textBoxBossName.Text = data?.Name ?? "";
        textBoxInternalDescription.Text = data?.InternalDescription ?? "";
        textBoxSuccessMsg.Text = data?.SuccessMsg ?? ApplicationSettings.Current.BossTemplate.SuccessText;
        textBoxFailMsg.Text = data?.FailMsg ?? ApplicationSettings.Current.BossTemplate.FailText;
        textBoxIcon.Text = data?.Icon ?? "";
        BossTypeSwitch = data?.Type ?? BossType.None;
        checkBoxEvent.Checked = data?.Event ?? false;
    }
    // properties
    private BossType BossTypeSwitch
    {
        get => bossTypeSwitch;
        set
        {
            var eventEnabled = true;
            switch (value)
            {
                case BossType.RaidEncounter:
                    radioButtonTypeRaidEncounter.Checked = true;
                    break;
                case BossType.Fractal:
                    radioButtonTypeFractal.Checked = true;
                    break;
                case BossType.Golem:
                    radioButtonTypeGolem.Checked = true;
                    eventEnabled = false;
                    break;
                case BossType.WvW:
                    radioButtonTypeWvW.Checked = true;
                    eventEnabled = false;
                    break;
                default:
                    radioButtonTypeNone.Checked = true;
                    break;
            }
            checkBoxEvent.Enabled = eventEnabled;
            if (!eventEnabled)
            {
                checkBoxEvent.Checked = false;
            }
            bossTypeSwitch = value;
        }
    }

    private void FormEditBossData_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!int.TryParse(textBoxBossID.Text, out var bossId) && !string.IsNullOrWhiteSpace(textBoxBossName.Text.Trim()))
        {
            return;
        }
        if (data is null)
        {
            var existingBoss = Bosses.All.Find(x => x.BossId.Equals(bossId));
            if (existingBoss is not null)
            {
                var result = MessageBox.Show($"There is an already existing definition for this boss:\n\n{existingBoss.BossId}: {existingBoss.Name} ({existingBoss.Type})\n\nDo you wish to save this boss with the identical identification?", "Identical identification with an already existing boss", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            var boss = new BossData
            {
                BossId = bossId,
                Name = textBoxBossName.Text,
                InternalDescription = textBoxInternalDescription.Text,
                SuccessMsg = textBoxSuccessMsg.Text,
                FailMsg = textBoxFailMsg.Text,
                Icon = textBoxIcon.Text,
                Type = BossTypeSwitch,
                Event = checkBoxEvent.Checked,
            };
            Bosses.All.Add(boss);
            editLink.listViewBosses.Items.Add(new ListViewItemCustom<BossData> { Item = boss });
            return;
        }
        if (!data.BossId.Equals(bossId))
        {
            var existingBoss = Bosses.All.Find(x => x.BossId.Equals(bossId));
            if (existingBoss is not null)
            {
                var result = MessageBox.Show($"There is an already existing definition for this boss:\n\n{existingBoss.BossId}: {existingBoss.Name} ({existingBoss.Type})\n\nDo you wish to save this boss with the identical identification?", "Identical identification with an already existing boss", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
        data.BossId = bossId;
        data.Name = textBoxBossName.Text;
        data.InternalDescription = textBoxInternalDescription.Text;
        data.SuccessMsg = textBoxSuccessMsg.Text;
        data.FailMsg = textBoxFailMsg.Text;
        data.Icon = textBoxIcon.Text;
        data.Type = BossTypeSwitch;
        data.Event = checkBoxEvent.Checked;
        (data as IListViewItemInfo<BossData>)?.UpdateItems();
    }

    private void RadioButtonTypeNone_CheckedChanged(object sender, EventArgs e)
    {
        if (!radioButtonTypeNone.Checked)
        {
            return;
        }
        BossTypeSwitch = BossType.None;
    }

    private void RadioButtonTypeRaid_CheckedChanged(object sender, EventArgs e)
    {
        if (!radioButtonTypeRaidEncounter.Checked)
        {
            return;
        }
        BossTypeSwitch = BossType.RaidEncounter;
    }

    private void RadioButtonTypeFractal_CheckedChanged(object sender, EventArgs e)
    {
        if (!radioButtonTypeFractal.Checked)
        {
            return;
        }
        BossTypeSwitch = BossType.Fractal;
    }

    private void RadioButtonTypeGolem_CheckedChanged(object sender, EventArgs e)
    {
        if (!radioButtonTypeGolem.Checked)
        {
            return;
        }
        BossTypeSwitch = BossType.Golem;
    }

    private void RadioButtonTypeWvW_CheckedChanged(object sender, EventArgs e)
    {
        if (!radioButtonTypeWvW.Checked)
        {
            return;
        }
        BossTypeSwitch = BossType.WvW;
    }

    private void ButtonOpenIconLink_Click(object sender, EventArgs e) => Process.Start(new ProcessStartInfo { UseShellExecute = true, FileName = textBoxIcon.Text });
}
