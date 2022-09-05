namespace PlenBotLogUploader
{
    partial class FormEditBossData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSuccessMsg = new System.Windows.Forms.Label();
            this.labelFailMsg = new System.Windows.Forms.Label();
            this.textBoxSuccessMsg = new System.Windows.Forms.TextBox();
            this.textBoxFailMsg = new System.Windows.Forms.TextBox();
            this.textBoxIcon = new System.Windows.Forms.TextBox();
            this.labelIcon = new System.Windows.Forms.Label();
            this.textBoxBossID = new System.Windows.Forms.TextBox();
            this.textBoxBossName = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.labelBossName = new System.Windows.Forms.Label();
            this.groupBoxCrucial = new System.Windows.Forms.GroupBox();
            this.textBoxInternalDescription = new System.Windows.Forms.TextBox();
            this.labelBossInternalDescription = new System.Windows.Forms.Label();
            this.groupBoxOtherSettings = new System.Windows.Forms.GroupBox();
            this.labelWPulls = new System.Windows.Forms.Label();
            this.labelWLog = new System.Windows.Forms.Label();
            this.labelWBoss = new System.Windows.Forms.Label();
            this.labelAvailableWildcards = new System.Windows.Forms.Label();
            this.groupBoxBossType = new System.Windows.Forms.GroupBox();
            this.checkBoxEvent = new System.Windows.Forms.CheckBox();
            this.radioButtonTypeGolem = new System.Windows.Forms.RadioButton();
            this.radioButtonTypeWvW = new System.Windows.Forms.RadioButton();
            this.radioButtonTypeStrike = new System.Windows.Forms.RadioButton();
            this.radioButtonTypeFractal = new System.Windows.Forms.RadioButton();
            this.radioButtonTypeRaid = new System.Windows.Forms.RadioButton();
            this.radioButtonTypeNone = new System.Windows.Forms.RadioButton();
            this.groupBoxCrucial.SuspendLayout();
            this.groupBoxOtherSettings.SuspendLayout();
            this.groupBoxBossType.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSuccessMsg
            // 
            this.labelSuccessMsg.AutoSize = true;
            this.labelSuccessMsg.Location = new System.Drawing.Point(4, 22);
            this.labelSuccessMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSuccessMsg.Name = "labelSuccessMsg";
            this.labelSuccessMsg.Size = new System.Drawing.Size(179, 16);
            this.labelSuccessMsg.TabIndex = 0;
            this.labelSuccessMsg.Text = "Twitch message on success:";
            // 
            // labelFailMsg
            // 
            this.labelFailMsg.AutoSize = true;
            this.labelFailMsg.Location = new System.Drawing.Point(4, 70);
            this.labelFailMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFailMsg.Name = "labelFailMsg";
            this.labelFailMsg.Size = new System.Drawing.Size(146, 16);
            this.labelFailMsg.TabIndex = 1;
            this.labelFailMsg.Text = "Twitch message on fail:";
            // 
            // textBoxSuccessMsg
            // 
            this.textBoxSuccessMsg.Location = new System.Drawing.Point(8, 42);
            this.textBoxSuccessMsg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSuccessMsg.Name = "textBoxSuccessMsg";
            this.textBoxSuccessMsg.Size = new System.Drawing.Size(484, 22);
            this.textBoxSuccessMsg.TabIndex = 2;
            // 
            // textBoxFailMsg
            // 
            this.textBoxFailMsg.Location = new System.Drawing.Point(8, 90);
            this.textBoxFailMsg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFailMsg.Name = "textBoxFailMsg";
            this.textBoxFailMsg.Size = new System.Drawing.Size(484, 22);
            this.textBoxFailMsg.TabIndex = 3;
            // 
            // textBoxIcon
            // 
            this.textBoxIcon.Location = new System.Drawing.Point(8, 197);
            this.textBoxIcon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxIcon.Name = "textBoxIcon";
            this.textBoxIcon.Size = new System.Drawing.Size(484, 22);
            this.textBoxIcon.TabIndex = 4;
            // 
            // labelIcon
            // 
            this.labelIcon.AutoSize = true;
            this.labelIcon.Location = new System.Drawing.Point(4, 177);
            this.labelIcon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIcon.Name = "labelIcon";
            this.labelIcon.Size = new System.Drawing.Size(198, 16);
            this.labelIcon.TabIndex = 5;
            this.labelIcon.Text = "Icon URL for Discord webhooks:";
            // 
            // textBoxBossID
            // 
            this.textBoxBossID.Location = new System.Drawing.Point(8, 43);
            this.textBoxBossID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxBossID.Name = "textBoxBossID";
            this.textBoxBossID.Size = new System.Drawing.Size(487, 22);
            this.textBoxBossID.TabIndex = 6;
            // 
            // textBoxBossName
            // 
            this.textBoxBossName.Location = new System.Drawing.Point(8, 91);
            this.textBoxBossName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxBossName.Name = "textBoxBossName";
            this.textBoxBossName.Size = new System.Drawing.Size(487, 22);
            this.textBoxBossName.TabIndex = 7;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(4, 23);
            this.labelId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(290, 16);
            this.labelId.TabIndex = 8;
            this.labelId.Text = "Boss ID (settings will not save if this is left blank):";
            // 
            // labelBossName
            // 
            this.labelBossName.AutoSize = true;
            this.labelBossName.Location = new System.Drawing.Point(4, 71);
            this.labelBossName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBossName.Name = "labelBossName";
            this.labelBossName.Size = new System.Drawing.Size(311, 16);
            this.labelBossName.TabIndex = 9;
            this.labelBossName.Text = "Boss name (settings will not save if this is left blank):";
            // 
            // groupBoxCrucial
            // 
            this.groupBoxCrucial.Controls.Add(this.textBoxInternalDescription);
            this.groupBoxCrucial.Controls.Add(this.labelBossInternalDescription);
            this.groupBoxCrucial.Controls.Add(this.textBoxBossName);
            this.groupBoxCrucial.Controls.Add(this.labelBossName);
            this.groupBoxCrucial.Controls.Add(this.textBoxBossID);
            this.groupBoxCrucial.Controls.Add(this.labelId);
            this.groupBoxCrucial.Location = new System.Drawing.Point(16, 15);
            this.groupBoxCrucial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxCrucial.Name = "groupBoxCrucial";
            this.groupBoxCrucial.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxCrucial.Size = new System.Drawing.Size(507, 172);
            this.groupBoxCrucial.TabIndex = 10;
            this.groupBoxCrucial.TabStop = false;
            this.groupBoxCrucial.Text = "Boss data (beware of changing these)";
            // 
            // textBoxInternalDescription
            // 
            this.textBoxInternalDescription.Location = new System.Drawing.Point(8, 139);
            this.textBoxInternalDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxInternalDescription.Name = "textBoxInternalDescription";
            this.textBoxInternalDescription.Size = new System.Drawing.Size(487, 22);
            this.textBoxInternalDescription.TabIndex = 11;
            // 
            // labelBossInternalDescription
            // 
            this.labelBossInternalDescription.AutoSize = true;
            this.labelBossInternalDescription.Location = new System.Drawing.Point(4, 119);
            this.labelBossInternalDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBossInternalDescription.Name = "labelBossInternalDescription";
            this.labelBossInternalDescription.Size = new System.Drawing.Size(369, 16);
            this.labelBossInternalDescription.TabIndex = 10;
            this.labelBossInternalDescription.Text = "Uploader UI only description (will appear in [ ] in the boss list):";
            // 
            // groupBoxOtherSettings
            // 
            this.groupBoxOtherSettings.Controls.Add(this.labelWPulls);
            this.groupBoxOtherSettings.Controls.Add(this.labelWLog);
            this.groupBoxOtherSettings.Controls.Add(this.labelWBoss);
            this.groupBoxOtherSettings.Controls.Add(this.labelAvailableWildcards);
            this.groupBoxOtherSettings.Controls.Add(this.textBoxSuccessMsg);
            this.groupBoxOtherSettings.Controls.Add(this.labelSuccessMsg);
            this.groupBoxOtherSettings.Controls.Add(this.labelIcon);
            this.groupBoxOtherSettings.Controls.Add(this.labelFailMsg);
            this.groupBoxOtherSettings.Controls.Add(this.textBoxIcon);
            this.groupBoxOtherSettings.Controls.Add(this.textBoxFailMsg);
            this.groupBoxOtherSettings.Location = new System.Drawing.Point(17, 279);
            this.groupBoxOtherSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxOtherSettings.Name = "groupBoxOtherSettings";
            this.groupBoxOtherSettings.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxOtherSettings.Size = new System.Drawing.Size(505, 229);
            this.groupBoxOtherSettings.TabIndex = 11;
            this.groupBoxOtherSettings.TabStop = false;
            this.groupBoxOtherSettings.Text = "Uploader specific settings for the boss (empty messages are not sent)";
            // 
            // labelWPulls
            // 
            this.labelWPulls.AutoSize = true;
            this.labelWPulls.Location = new System.Drawing.Point(184, 150);
            this.labelWPulls.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWPulls.Name = "labelWPulls";
            this.labelWPulls.Size = new System.Drawing.Size(198, 16);
            this.labelWPulls.TabIndex = 9;
            this.labelWPulls.Text = "<pulls> - the current wipe counter";
            // 
            // labelWLog
            // 
            this.labelWLog.AutoSize = true;
            this.labelWLog.Location = new System.Drawing.Point(184, 134);
            this.labelWLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWLog.Name = "labelWLog";
            this.labelWLog.Size = new System.Drawing.Size(191, 16);
            this.labelWLog.TabIndex = 8;
            this.labelWLog.Text = "<log> - link to the dps.report log";
            // 
            // labelWBoss
            // 
            this.labelWBoss.AutoSize = true;
            this.labelWBoss.Location = new System.Drawing.Point(184, 118);
            this.labelWBoss.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWBoss.Name = "labelWBoss";
            this.labelWBoss.Size = new System.Drawing.Size(157, 16);
            this.labelWBoss.TabIndex = 7;
            this.labelWBoss.Text = "<boss> - encounter name";
            // 
            // labelAvailableWildcards
            // 
            this.labelAvailableWildcards.AutoSize = true;
            this.labelAvailableWildcards.Location = new System.Drawing.Point(4, 118);
            this.labelAvailableWildcards.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAvailableWildcards.Name = "labelAvailableWildcards";
            this.labelAvailableWildcards.Size = new System.Drawing.Size(174, 16);
            this.labelAvailableWildcards.TabIndex = 6;
            this.labelAvailableWildcards.Text = "Available variables for texts:";
            // 
            // groupBoxBossType
            // 
            this.groupBoxBossType.Controls.Add(this.checkBoxEvent);
            this.groupBoxBossType.Controls.Add(this.radioButtonTypeGolem);
            this.groupBoxBossType.Controls.Add(this.radioButtonTypeWvW);
            this.groupBoxBossType.Controls.Add(this.radioButtonTypeStrike);
            this.groupBoxBossType.Controls.Add(this.radioButtonTypeFractal);
            this.groupBoxBossType.Controls.Add(this.radioButtonTypeRaid);
            this.groupBoxBossType.Controls.Add(this.radioButtonTypeNone);
            this.groupBoxBossType.Location = new System.Drawing.Point(17, 194);
            this.groupBoxBossType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxBossType.Name = "groupBoxBossType";
            this.groupBoxBossType.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxBossType.Size = new System.Drawing.Size(505, 78);
            this.groupBoxBossType.TabIndex = 12;
            this.groupBoxBossType.TabStop = false;
            this.groupBoxBossType.Text = "Boss type";
            // 
            // checkBoxEvent
            // 
            this.checkBoxEvent.AutoSize = true;
            this.checkBoxEvent.Location = new System.Drawing.Point(9, 53);
            this.checkBoxEvent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxEvent.Name = "checkBoxEvent";
            this.checkBoxEvent.Size = new System.Drawing.Size(63, 20);
            this.checkBoxEvent.TabIndex = 6;
            this.checkBoxEvent.Text = "Event";
            this.checkBoxEvent.UseVisualStyleBackColor = true;
            // 
            // radioButtonTypeGolem
            // 
            this.radioButtonTypeGolem.AutoSize = true;
            this.radioButtonTypeGolem.Location = new System.Drawing.Point(317, 23);
            this.radioButtonTypeGolem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonTypeGolem.Name = "radioButtonTypeGolem";
            this.radioButtonTypeGolem.Size = new System.Drawing.Size(68, 20);
            this.radioButtonTypeGolem.TabIndex = 5;
            this.radioButtonTypeGolem.TabStop = true;
            this.radioButtonTypeGolem.Text = "Golem";
            this.radioButtonTypeGolem.UseVisualStyleBackColor = true;
            this.radioButtonTypeGolem.CheckedChanged += new System.EventHandler(this.RadioButtonTypeGolem_CheckedChanged);
            // 
            // radioButtonTypeWvW
            // 
            this.radioButtonTypeWvW.AutoSize = true;
            this.radioButtonTypeWvW.Location = new System.Drawing.Point(399, 23);
            this.radioButtonTypeWvW.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonTypeWvW.Name = "radioButtonTypeWvW";
            this.radioButtonTypeWvW.Size = new System.Drawing.Size(61, 20);
            this.radioButtonTypeWvW.TabIndex = 4;
            this.radioButtonTypeWvW.TabStop = true;
            this.radioButtonTypeWvW.Text = "WvW";
            this.radioButtonTypeWvW.UseVisualStyleBackColor = true;
            this.radioButtonTypeWvW.CheckedChanged += new System.EventHandler(this.RadioButtonTypeWvW_CheckedChanged);
            // 
            // radioButtonTypeStrike
            // 
            this.radioButtonTypeStrike.AutoSize = true;
            this.radioButtonTypeStrike.Location = new System.Drawing.Point(240, 23);
            this.radioButtonTypeStrike.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonTypeStrike.Name = "radioButtonTypeStrike";
            this.radioButtonTypeStrike.Size = new System.Drawing.Size(62, 20);
            this.radioButtonTypeStrike.TabIndex = 3;
            this.radioButtonTypeStrike.Text = "Strike";
            this.radioButtonTypeStrike.UseVisualStyleBackColor = true;
            this.radioButtonTypeStrike.CheckedChanged += new System.EventHandler(this.RadioButtonTypeStrike_CheckedChanged);
            // 
            // radioButtonTypeFractal
            // 
            this.radioButtonTypeFractal.AutoSize = true;
            this.radioButtonTypeFractal.Location = new System.Drawing.Point(156, 23);
            this.radioButtonTypeFractal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonTypeFractal.Name = "radioButtonTypeFractal";
            this.radioButtonTypeFractal.Size = new System.Drawing.Size(69, 20);
            this.radioButtonTypeFractal.TabIndex = 2;
            this.radioButtonTypeFractal.Text = "Fractal";
            this.radioButtonTypeFractal.UseVisualStyleBackColor = true;
            this.radioButtonTypeFractal.CheckedChanged += new System.EventHandler(this.RadioButtonTypeFractal_CheckedChanged);
            // 
            // radioButtonTypeRaid
            // 
            this.radioButtonTypeRaid.AutoSize = true;
            this.radioButtonTypeRaid.Location = new System.Drawing.Point(85, 23);
            this.radioButtonTypeRaid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonTypeRaid.Name = "radioButtonTypeRaid";
            this.radioButtonTypeRaid.Size = new System.Drawing.Size(57, 20);
            this.radioButtonTypeRaid.TabIndex = 1;
            this.radioButtonTypeRaid.Text = "Raid";
            this.radioButtonTypeRaid.UseVisualStyleBackColor = true;
            this.radioButtonTypeRaid.CheckedChanged += new System.EventHandler(this.RadioButtonTypeRaid_CheckedChanged);
            // 
            // radioButtonTypeNone
            // 
            this.radioButtonTypeNone.AutoSize = true;
            this.radioButtonTypeNone.Checked = true;
            this.radioButtonTypeNone.Location = new System.Drawing.Point(9, 23);
            this.radioButtonTypeNone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonTypeNone.Name = "radioButtonTypeNone";
            this.radioButtonTypeNone.Size = new System.Drawing.Size(61, 20);
            this.radioButtonTypeNone.TabIndex = 0;
            this.radioButtonTypeNone.TabStop = true;
            this.radioButtonTypeNone.Text = "None";
            this.radioButtonTypeNone.UseVisualStyleBackColor = true;
            this.radioButtonTypeNone.CheckedChanged += new System.EventHandler(this.RadioButtonTypeNone_CheckedChanged);
            // 
            // FormEditBossData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(537, 517);
            this.Controls.Add(this.groupBoxBossType);
            this.Controls.Add(this.groupBoxOtherSettings);
            this.Controls.Add(this.groupBoxCrucial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditBossData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEditBossData";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditBossData_FormClosing);
            this.groupBoxCrucial.ResumeLayout(false);
            this.groupBoxCrucial.PerformLayout();
            this.groupBoxOtherSettings.ResumeLayout(false);
            this.groupBoxOtherSettings.PerformLayout();
            this.groupBoxBossType.ResumeLayout(false);
            this.groupBoxBossType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelSuccessMsg;
        private System.Windows.Forms.Label labelFailMsg;
        private System.Windows.Forms.TextBox textBoxSuccessMsg;
        private System.Windows.Forms.TextBox textBoxFailMsg;
        private System.Windows.Forms.TextBox textBoxIcon;
        private System.Windows.Forms.Label labelIcon;
        private System.Windows.Forms.TextBox textBoxBossID;
        private System.Windows.Forms.TextBox textBoxBossName;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelBossName;
        private System.Windows.Forms.GroupBox groupBoxCrucial;
        private System.Windows.Forms.GroupBox groupBoxOtherSettings;
        private System.Windows.Forms.GroupBox groupBoxBossType;
        private System.Windows.Forms.RadioButton radioButtonTypeWvW;
        private System.Windows.Forms.RadioButton radioButtonTypeStrike;
        private System.Windows.Forms.RadioButton radioButtonTypeFractal;
        private System.Windows.Forms.RadioButton radioButtonTypeRaid;
        private System.Windows.Forms.RadioButton radioButtonTypeNone;
        private System.Windows.Forms.CheckBox checkBoxEvent;
        private System.Windows.Forms.RadioButton radioButtonTypeGolem;
        private System.Windows.Forms.Label labelWPulls;
        private System.Windows.Forms.Label labelWLog;
        private System.Windows.Forms.Label labelWBoss;
        private System.Windows.Forms.Label labelAvailableWildcards;
        private System.Windows.Forms.Label labelBossInternalDescription;
        private System.Windows.Forms.TextBox textBoxInternalDescription;
    }
}