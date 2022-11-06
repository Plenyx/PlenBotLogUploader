﻿using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.DPSReport;
using PlenBotLogUploader.Tools;
using System;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormEditBossData : Form
    {
        #region definitions
        // properties
        internal BossType BossTypeSwitch
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
        private BossType _bossTypeSwitch = BossType.None;
        #endregion

        internal FormEditBossData(FormBossData editLink, BossData data)
        {
            this.editLink = editLink;
            InitializeComponent();
            this.data = data;
            Icon = Properties.Resources.AppIcon;
            Text = (data is null) ? "Add a new boss" : $"{data.Name} ({data.BossId})";
            textBoxBossID.Text = data?.BossId.ToString() ?? string.Empty;
            textBoxBossName.Text = data?.Name ?? string.Empty;
            textBoxInternalDescription.Text = data?.InternalDescription ?? string.Empty;
            textBoxSuccessMsg.Text = data?.SuccessMsg ?? ApplicationSettings.Current.BossTemplate.SuccessText;
            textBoxFailMsg.Text = data?.FailMsg ?? ApplicationSettings.Current.BossTemplate.FailText;
            textBoxIcon.Text = data?.Icon ?? string.Empty;
            BossTypeSwitch = data?.Type ?? BossType.None;
            checkBoxEvent.Checked = data?.Event ?? false;
        }

        private void FormEditBossData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (int.TryParse(textBoxBossID.Text, out int bossId) && !string.IsNullOrWhiteSpace(textBoxBossName.Text.Trim()))
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
                    Bosses.All.Add(boss);
                    editLink.listViewBosses.Items.Add(new ListViewItemCustom<BossData>() { Item = boss });
                }
                else
                {
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
            }
        }

        private void RadioButtonTypeNone_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTypeNone.Checked)
            {
                BossTypeSwitch = BossType.None;
            }
        }

        private void RadioButtonTypeRaid_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTypeRaid.Checked)
            {
                BossTypeSwitch = BossType.Raid;
            }
        }

        private void RadioButtonTypeFractal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTypeFractal.Checked)
            {
                BossTypeSwitch = BossType.Fractal;
            }
        }

        private void RadioButtonTypeStrike_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTypeStrike.Checked)
            {
                BossTypeSwitch = BossType.Strike;
            }
        }

        private void RadioButtonTypeGolem_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTypeGolem.Checked)
            {
                BossTypeSwitch = BossType.Golem;
            }
        }

        private void RadioButtonTypeWvW_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTypeWvW.Checked)
            {
                BossTypeSwitch = BossType.WvW;
            }
        }
    }
}
