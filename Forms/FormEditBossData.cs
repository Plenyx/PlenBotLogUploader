using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.DPSReport;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormEditBossData : Form
    {
        #region definitions
        // properties
        public BossType BossTypeSwitch
        {
            get => _bossTypeSwitch;
            set
            {
                var eventEnabled = true;
                switch (value)
                {
                    case BossType.Raid:
                        radioButtonTypeRaid.Checked = true;
                        break;
                    case BossType.Fractal:
                        radioButtonTypeFractal.Checked = true;
                        break;
                    case BossType.Strike:
                        radioButtonTypeStrike.Checked = true;
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
                _bossTypeSwitch = value;
            }
        }

        // fields
        private readonly FormBossData editLink;
        private readonly BossData data;
        private readonly int reservedId;
        private BossType _bossTypeSwitch = BossType.None;
        #endregion

        public FormEditBossData(FormBossData editLink, BossData data, int reservedId)
        {
            this.editLink = editLink;
            InitializeComponent();
            this.data = data;
            this.reservedId = reservedId;
            Icon = Properties.Resources.AppIcon;
            Text = (data is null) ? "Add a new boss" : $"{data.Name} ({data.BossId})";
            textBoxBossID.Text = data?.BossId.ToString() ?? "";
            textBoxBossName.Text = data?.Name ?? "";
            textBoxInternalDescription.Text = data?.InternalDescription ?? "";
            textBoxSuccessMsg.Text = data?.SuccessMsg ?? ApplicationSettings.Current.BossTemplate.SuccessText;
            textBoxFailMsg.Text = data?.FailMsg ?? ApplicationSettings.Current.BossTemplate.FailText;
            textBoxIcon.Text = data?.Icon ?? "";
            BossTypeSwitch = data?.Type ?? BossType.None;
            checkBoxEvent.Checked = data?.Event ?? false;
        }

        private void FormEditBossData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (int.TryParse(textBoxBossID.Text, out int bossId))
            {
                if (!string.IsNullOrWhiteSpace(textBoxBossName.Text.Trim()))
                {
                    if (data is null)
                    {
                        var boss = new BossData()
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
                        Bosses.All[reservedId] = boss;
                        editLink.listViewBosses.Items.Add(new ListViewItem() { Name = reservedId.ToString(), Text = boss.UIName });
                    }
                    else
                    {
                        var boss = Bosses.All[reservedId];
                        boss.BossId = bossId;
                        boss.Name = textBoxBossName.Text;
                        boss.InternalDescription = textBoxInternalDescription.Text;
                        boss.SuccessMsg = textBoxSuccessMsg.Text;
                        boss.FailMsg = textBoxFailMsg.Text;
                        boss.Icon = textBoxIcon.Text;
                        boss.Type = BossTypeSwitch;
                        boss.Event = checkBoxEvent.Checked;
                        editLink.listViewBosses.Items[editLink.listViewBosses.Items.IndexOfKey(reservedId.ToString())].Text = boss.UIName;
                    }
                }
            }
        }

        private void RadioButtonTypeNone_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButtonTypeNone.Checked)
            {
                BossTypeSwitch = BossType.None;
            }
        }

        private void RadioButtonTypeRaid_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButtonTypeRaid.Checked)
            {
                BossTypeSwitch = BossType.Raid;
            }
        }

        private void RadioButtonTypeFractal_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButtonTypeFractal.Checked)
            {
                BossTypeSwitch = BossType.Fractal;
            }
        }

        private void RadioButtonTypeStrike_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButtonTypeStrike.Checked)
            {
                BossTypeSwitch = BossType.Strike;
            }
        }

        private void RadioButtonTypeGolem_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButtonTypeGolem.Checked)
            {
                BossTypeSwitch = BossType.Golem;
            }
        }

        private void RadioButtonTypeWvW_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButtonTypeWvW.Checked)
            {
                BossTypeSwitch = BossType.WvW;
            }
        }
    }
}
