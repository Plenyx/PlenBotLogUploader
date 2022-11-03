﻿using PlenBotLogUploader.Teams;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormEditTeamCondition : Form
    {
        #region definitions
        internal Team Team { get; set; }
        internal TeamCondition Condition { get; set; }
        #endregion

        internal FormEditTeamCondition(Team teamData, TeamCondition data)
        {
            Team = teamData;
            Condition = data;
            InitializeComponent();
            ChangeFormText();
            Icon = Properties.Resources.AppIcon;
            if (Condition is not null)
            {
                textBoxConditionDescription.Text = Condition.Description;
                textBoxLimiterValue.Text = Condition.LimiterValue.ToString();
                switch (Condition.Limiter)
                {
                    case TeamLimiter.OR:
                        radioButtonLimiterOR.Checked = true;
                        textBoxLimiterValue.Enabled = false;
                        textBoxAccountNames.Enabled = false;
                        groupBoxAccountNames.Visible = false;
                        groupBoxSubConditions.Visible = true;
                        break;
                    case TeamLimiter.AND:
                        radioButtonLimiterAND.Checked = true;
                        textBoxLimiterValue.Enabled = false;
                        textBoxAccountNames.Enabled = false;
                        groupBoxAccountNames.Visible = false;
                        groupBoxSubConditions.Visible = true;
                        break;
                    case TeamLimiter.CommanderName:
                        radioButtonLimiterCommanderName.Checked = true;
                        textBoxLimiterValue.Enabled = false;
                        textBoxAccountNames.Enabled = true;
                        groupBoxAccountNames.Visible = true;
                        groupBoxSubConditions.Visible = false;
                        break;
                    case TeamLimiter.Except:
                        radioButtonLimiterExcept.Checked = true;
                        textBoxLimiterValue.Enabled = false;
                        textBoxAccountNames.Enabled = true;
                        groupBoxAccountNames.Visible = true;
                        groupBoxSubConditions.Visible = false;
                        break;
                    case TeamLimiter.Exact:
                        radioButtonLimiterExact.Checked = true;
                        textBoxLimiterValue.Enabled = true;
                        textBoxAccountNames.Enabled = true;
                        groupBoxAccountNames.Visible = true;
                        groupBoxSubConditions.Visible = false;
                        break;
                    default:
                        radioButtonLimiterAtLeast.Checked = true;
                        textBoxLimiterValue.Enabled = true;
                        textBoxAccountNames.Enabled = true;
                        groupBoxAccountNames.Visible = true;
                        groupBoxSubConditions.Visible = false;
                        break;
                }
                textBoxAccountNames.Text = ((Condition.AccountNames?.Count ?? 0) > 0) ? Condition.AccountNames.Aggregate((x, y) => x + Environment.NewLine + y) : string.Empty;
                textBoxConditionVisual.Text = Condition.Draw();
            }
            radioButtonLimiterOR.CheckedChanged += RadioButtonLimiterOR_CheckedChanged;
            radioButtonLimiterAND.CheckedChanged += RadioButtonLimiterAND_CheckedChanged;
            radioButtonLimiterCommanderName.CheckedChanged += RadioButtonLimiterCommanderName_CheckedChanged;
            radioButtonLimiterExcept.CheckedChanged += RadioButtonLimiterExcept_CheckedChanged;
            radioButtonLimiterExact.CheckedChanged += RadioButtonLimiterExact_CheckedChanged;
            radioButtonLimiterAtLeast.CheckedChanged += RadioButtonLimiterAtLeast_CheckedChanged;
            textBoxAccountNames.TextChanged += TextBoxAccountNames_TextChanged;
            Condition.ConditionChanged += HandleConditionChange;
        }

        private void RedrawCondition()
        {
            textBoxConditionVisual.Text = Condition.Draw() ?? string.Empty;
            ChangeFormText();
            listBoxSubConditions.Items.Clear();
            listBoxSubConditions.Items.AddRange(Condition.Subconditions.ToArray());
        }

        private void ChangeFormText()
        {
            Text = Team.Name + Condition.PathDescription;
        }

        protected void HandleConditionChange(object sender, EventArgs e)
        {
            RedrawCondition();
        }

        private void RadioButtonLimiterAtLeast_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonLimiterAtLeast.Checked)
            {
                return;
            }
            Condition.Limiter = TeamLimiter.AtLeast;
            textBoxLimiterValue.Enabled = true;
            textBoxAccountNames.Enabled = true;
            groupBoxAccountNames.Visible = true;
            groupBoxSubConditions.Visible = false;
            RedrawCondition();
        }

        private void RadioButtonLimiterExact_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonLimiterExact.Checked)
            {
                return;
            }
            Condition.Limiter = TeamLimiter.Exact;
            textBoxLimiterValue.Enabled = true;
            textBoxAccountNames.Enabled = true;
            groupBoxAccountNames.Visible = true;
            groupBoxSubConditions.Visible = false;
            RedrawCondition();
        }

        private void RadioButtonLimiterExcept_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonLimiterExcept.Checked)
            {
                return;
            }
            Condition.Limiter = TeamLimiter.Except;
            textBoxLimiterValue.Enabled = false;
            textBoxAccountNames.Enabled = true;
            groupBoxAccountNames.Visible = true;
            groupBoxSubConditions.Visible = false;
            RedrawCondition();
        }

        private void RadioButtonLimiterCommanderName_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonLimiterCommanderName.Checked)
            {
                return;
            }
            Condition.Limiter = TeamLimiter.CommanderName;
            textBoxLimiterValue.Enabled = false;
            textBoxAccountNames.Enabled = true;
            groupBoxAccountNames.Visible = true;
            groupBoxSubConditions.Visible = false;
            RedrawCondition();
        }

        private void RadioButtonLimiterAND_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonLimiterAND.Checked)
            {
                return;
            }
            Condition.Limiter = TeamLimiter.AND;
            textBoxLimiterValue.Enabled = false;
            textBoxAccountNames.Enabled = false;
            groupBoxAccountNames.Visible = false;
            groupBoxSubConditions.Visible = true;
            RedrawCondition();
        }

        private void RadioButtonLimiterOR_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonLimiterOR.Checked)
            {
                return;
            }
            Condition.Limiter = TeamLimiter.OR;
            textBoxLimiterValue.Enabled = false;
            textBoxAccountNames.Enabled = false;
            groupBoxAccountNames.Visible = false;
            groupBoxSubConditions.Visible = true;
            RedrawCondition();
        }

        private void TextBoxAccountNames_TextChanged(object sender, EventArgs e)
        {
            Condition.AccountNames = textBoxAccountNames.Lines.ToList();
            RedrawCondition();
        }

        private void TextBoxLimiterValue_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxLimiterValue.Text, out int limiterValue) && (limiterValue >= 0))
            {
                Condition.LimiterValue = limiterValue;
                RedrawCondition();
            }
        }

        private void TextBoxConditionDescription_TextChanged(object sender, EventArgs e)
        {
            Condition.Description = textBoxConditionDescription.Text;
            RedrawCondition();
        }

        private void AddNewSubCondition()
        {
            var newCondition = new TeamCondition() { ParentCondition = Condition };
            Condition.Subconditions.Add(newCondition);
            RedrawCondition();
            Condition.CallConditionChanged();
            listBoxSubConditions.SelectedItem = null;
            new FormEditTeamCondition(Team, newCondition).ShowDialog();
        }

        private void EditSubCondition()
        {
            if (listBoxSubConditions.SelectedItem is TeamCondition teamCondition)
            {
                listBoxSubConditions.SelectedItem = null;
                new FormEditTeamCondition(Team, teamCondition).ShowDialog();
            }
        }

        private void ButtonAddSubCondition_Click(object sender, EventArgs e) => AddNewSubCondition();

        private void FormEditTeamCondition_FormClosing(object sender, FormClosingEventArgs e) => Condition.ParentCondition?.CallConditionChanged();

        private void ContextMenuStripInteract_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var toggle = listBoxSubConditions.Items.Count > 0;
            toolStripMenuItemEdit.Enabled = toggle;
            toolStripMenuItemDelete.Enabled = toggle;
        }

        private void ToolStripMenuItemEdit_Click(object sender, EventArgs e) => EditSubCondition();

        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (listBoxSubConditions.SelectedItem is TeamCondition teamCondition)
            {
                listBoxSubConditions.SelectedItem = null;
                teamCondition.ParentCondition = null;
                Condition.Subconditions.Remove(teamCondition);
                RedrawCondition();
            }
        }

        private void ToolStripMenuItemAdd_Click(object sender, EventArgs e) => AddNewSubCondition();

        private void ListBoxSubConditions_DoubleClick(object sender, EventArgs e) => EditSubCondition();
    }
}
