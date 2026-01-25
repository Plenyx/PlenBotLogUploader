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
            labelSuccessMsg = new System.Windows.Forms.Label();
            labelFailMsg = new System.Windows.Forms.Label();
            textBoxSuccessMsg = new System.Windows.Forms.TextBox();
            textBoxFailMsg = new System.Windows.Forms.TextBox();
            textBoxIcon = new System.Windows.Forms.TextBox();
            labelIcon = new System.Windows.Forms.Label();
            textBoxBossID = new System.Windows.Forms.TextBox();
            textBoxBossName = new System.Windows.Forms.TextBox();
            labelId = new System.Windows.Forms.Label();
            labelBossName = new System.Windows.Forms.Label();
            groupBoxCrucial = new System.Windows.Forms.GroupBox();
            textBoxInternalDescription = new System.Windows.Forms.TextBox();
            labelBossInternalDescription = new System.Windows.Forms.Label();
            groupBoxOtherSettings = new System.Windows.Forms.GroupBox();
            labelPhase = new System.Windows.Forms.Label();
            buttonOpenIconLink = new System.Windows.Forms.Button();
            labelWPercent = new System.Windows.Forms.Label();
            labelWPulls = new System.Windows.Forms.Label();
            labelWLog = new System.Windows.Forms.Label();
            labelWBoss = new System.Windows.Forms.Label();
            labelAvailableWildcards = new System.Windows.Forms.Label();
            groupBoxBossType = new System.Windows.Forms.GroupBox();
            checkBoxEvent = new System.Windows.Forms.CheckBox();
            radioButtonTypeGolem = new System.Windows.Forms.RadioButton();
            radioButtonTypeWvW = new System.Windows.Forms.RadioButton();
            radioButtonTypeFractal = new System.Windows.Forms.RadioButton();
            radioButtonTypeRaidEncounter = new System.Windows.Forms.RadioButton();
            radioButtonTypeNone = new System.Windows.Forms.RadioButton();
            groupBoxCrucial.SuspendLayout();
            groupBoxOtherSettings.SuspendLayout();
            groupBoxBossType.SuspendLayout();
            SuspendLayout();
            // 
            // labelSuccessMsg
            // 
            labelSuccessMsg.AutoSize = true;
            labelSuccessMsg.Location = new System.Drawing.Point(4, 28);
            labelSuccessMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelSuccessMsg.Name = "labelSuccessMsg";
            labelSuccessMsg.Size = new System.Drawing.Size(189, 20);
            labelSuccessMsg.TabIndex = 0;
            labelSuccessMsg.Text = "Twitch message on success:";
            // 
            // labelFailMsg
            // 
            labelFailMsg.AutoSize = true;
            labelFailMsg.Location = new System.Drawing.Point(4, 88);
            labelFailMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelFailMsg.Name = "labelFailMsg";
            labelFailMsg.Size = new System.Drawing.Size(162, 20);
            labelFailMsg.TabIndex = 1;
            labelFailMsg.Text = "Twitch message on fail:";
            // 
            // textBoxSuccessMsg
            // 
            textBoxSuccessMsg.Location = new System.Drawing.Point(8, 52);
            textBoxSuccessMsg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBoxSuccessMsg.Name = "textBoxSuccessMsg";
            textBoxSuccessMsg.Size = new System.Drawing.Size(516, 27);
            textBoxSuccessMsg.TabIndex = 2;
            // 
            // textBoxFailMsg
            // 
            textBoxFailMsg.Location = new System.Drawing.Point(8, 112);
            textBoxFailMsg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBoxFailMsg.Name = "textBoxFailMsg";
            textBoxFailMsg.Size = new System.Drawing.Size(516, 27);
            textBoxFailMsg.TabIndex = 3;
            // 
            // textBoxIcon
            // 
            textBoxIcon.Location = new System.Drawing.Point(9, 272);
            textBoxIcon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBoxIcon.Name = "textBoxIcon";
            textBoxIcon.Size = new System.Drawing.Size(423, 27);
            textBoxIcon.TabIndex = 4;
            // 
            // labelIcon
            // 
            labelIcon.AutoSize = true;
            labelIcon.Location = new System.Drawing.Point(5, 248);
            labelIcon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelIcon.Name = "labelIcon";
            labelIcon.Size = new System.Drawing.Size(219, 20);
            labelIcon.TabIndex = 5;
            labelIcon.Text = "Icon URL for Discord webhooks:";
            // 
            // textBoxBossID
            // 
            textBoxBossID.Location = new System.Drawing.Point(8, 54);
            textBoxBossID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBoxBossID.Name = "textBoxBossID";
            textBoxBossID.Size = new System.Drawing.Size(517, 27);
            textBoxBossID.TabIndex = 6;
            // 
            // textBoxBossName
            // 
            textBoxBossName.Location = new System.Drawing.Point(8, 114);
            textBoxBossName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBoxBossName.Name = "textBoxBossName";
            textBoxBossName.Size = new System.Drawing.Size(517, 27);
            textBoxBossName.TabIndex = 7;
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Location = new System.Drawing.Point(4, 29);
            labelId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelId.Name = "labelId";
            labelId.Size = new System.Drawing.Size(332, 20);
            labelId.TabIndex = 8;
            labelId.Text = "Boss ID (settings will not save if this is left blank):";
            // 
            // labelBossName
            // 
            labelBossName.AutoSize = true;
            labelBossName.Location = new System.Drawing.Point(4, 89);
            labelBossName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelBossName.Name = "labelBossName";
            labelBossName.Size = new System.Drawing.Size(354, 20);
            labelBossName.TabIndex = 9;
            labelBossName.Text = "Boss name (settings will not save if this is left blank):";
            // 
            // groupBoxCrucial
            // 
            groupBoxCrucial.Controls.Add(textBoxInternalDescription);
            groupBoxCrucial.Controls.Add(labelBossInternalDescription);
            groupBoxCrucial.Controls.Add(textBoxBossName);
            groupBoxCrucial.Controls.Add(labelBossName);
            groupBoxCrucial.Controls.Add(textBoxBossID);
            groupBoxCrucial.Controls.Add(labelId);
            groupBoxCrucial.Location = new System.Drawing.Point(16, 19);
            groupBoxCrucial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxCrucial.Name = "groupBoxCrucial";
            groupBoxCrucial.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxCrucial.Size = new System.Drawing.Size(533, 215);
            groupBoxCrucial.TabIndex = 10;
            groupBoxCrucial.TabStop = false;
            groupBoxCrucial.Text = "Boss data (beware of changing these)";
            // 
            // textBoxInternalDescription
            // 
            textBoxInternalDescription.Location = new System.Drawing.Point(8, 174);
            textBoxInternalDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBoxInternalDescription.Name = "textBoxInternalDescription";
            textBoxInternalDescription.Size = new System.Drawing.Size(517, 27);
            textBoxInternalDescription.TabIndex = 11;
            // 
            // labelBossInternalDescription
            // 
            labelBossInternalDescription.AutoSize = true;
            labelBossInternalDescription.Location = new System.Drawing.Point(4, 149);
            labelBossInternalDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelBossInternalDescription.Name = "labelBossInternalDescription";
            labelBossInternalDescription.Size = new System.Drawing.Size(422, 20);
            labelBossInternalDescription.TabIndex = 10;
            labelBossInternalDescription.Text = "Uploader UI only description (will appear in [ ] in the boss list):";
            // 
            // groupBoxOtherSettings
            // 
            groupBoxOtherSettings.Controls.Add(labelPhase);
            groupBoxOtherSettings.Controls.Add(buttonOpenIconLink);
            groupBoxOtherSettings.Controls.Add(labelWPercent);
            groupBoxOtherSettings.Controls.Add(labelWPulls);
            groupBoxOtherSettings.Controls.Add(labelWLog);
            groupBoxOtherSettings.Controls.Add(labelWBoss);
            groupBoxOtherSettings.Controls.Add(labelAvailableWildcards);
            groupBoxOtherSettings.Controls.Add(textBoxSuccessMsg);
            groupBoxOtherSettings.Controls.Add(labelSuccessMsg);
            groupBoxOtherSettings.Controls.Add(labelIcon);
            groupBoxOtherSettings.Controls.Add(labelFailMsg);
            groupBoxOtherSettings.Controls.Add(textBoxIcon);
            groupBoxOtherSettings.Controls.Add(textBoxFailMsg);
            groupBoxOtherSettings.Location = new System.Drawing.Point(17, 349);
            groupBoxOtherSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxOtherSettings.Name = "groupBoxOtherSettings";
            groupBoxOtherSettings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxOtherSettings.Size = new System.Drawing.Size(532, 309);
            groupBoxOtherSettings.TabIndex = 11;
            groupBoxOtherSettings.TabStop = false;
            groupBoxOtherSettings.Text = "Uploader specific settings for the boss (empty messages are not sent)";
            // 
            // labelPhase
            // 
            labelPhase.AutoSize = true;
            labelPhase.Location = new System.Drawing.Point(184, 208);
            labelPhase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelPhase.Name = "labelPhase";
            labelPhase.Size = new System.Drawing.Size(259, 20);
            labelPhase.TabIndex = 12;
            labelPhase.Text = "<phase> - the phase of the encounter";
            // 
            // buttonOpenIconLink
            // 
            buttonOpenIconLink.Location = new System.Drawing.Point(439, 272);
            buttonOpenIconLink.Name = "buttonOpenIconLink";
            buttonOpenIconLink.Size = new System.Drawing.Size(81, 29);
            buttonOpenIconLink.TabIndex = 11;
            buttonOpenIconLink.Text = "Open link";
            buttonOpenIconLink.UseVisualStyleBackColor = true;
            buttonOpenIconLink.Click += ButtonOpenIconLink_Click;
            // 
            // labelWPercent
            // 
            labelWPercent.AutoSize = true;
            labelWPercent.Location = new System.Drawing.Point(184, 227);
            labelWPercent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelWPercent.Name = "labelWPercent";
            labelWPercent.Size = new System.Drawing.Size(311, 20);
            labelWPercent.TabIndex = 10;
            labelWPercent.Text = "<percent> - the % of targets of the encounter";
            // 
            // labelWPulls
            // 
            labelWPulls.AutoSize = true;
            labelWPulls.Location = new System.Drawing.Point(184, 188);
            labelWPulls.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelWPulls.Name = "labelWPulls";
            labelWPulls.Size = new System.Drawing.Size(235, 20);
            labelWPulls.TabIndex = 9;
            labelWPulls.Text = "<pulls> - the current wipe counter";
            // 
            // labelWLog
            // 
            labelWLog.AutoSize = true;
            labelWLog.Location = new System.Drawing.Point(184, 168);
            labelWLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelWLog.Name = "labelWLog";
            labelWLog.Size = new System.Drawing.Size(229, 20);
            labelWLog.TabIndex = 8;
            labelWLog.Text = "<log> - link to the dps.report log";
            // 
            // labelWBoss
            // 
            labelWBoss.AutoSize = true;
            labelWBoss.Location = new System.Drawing.Point(184, 148);
            labelWBoss.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelWBoss.Name = "labelWBoss";
            labelWBoss.Size = new System.Drawing.Size(180, 20);
            labelWBoss.TabIndex = 7;
            labelWBoss.Text = "<boss> - encounter name";
            // 
            // labelAvailableWildcards
            // 
            labelAvailableWildcards.AutoSize = true;
            labelAvailableWildcards.Location = new System.Drawing.Point(4, 148);
            labelAvailableWildcards.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelAvailableWildcards.Name = "labelAvailableWildcards";
            labelAvailableWildcards.Size = new System.Drawing.Size(195, 20);
            labelAvailableWildcards.TabIndex = 6;
            labelAvailableWildcards.Text = "Available variables for texts:";
            // 
            // groupBoxBossType
            // 
            groupBoxBossType.Controls.Add(checkBoxEvent);
            groupBoxBossType.Controls.Add(radioButtonTypeGolem);
            groupBoxBossType.Controls.Add(radioButtonTypeWvW);
            groupBoxBossType.Controls.Add(radioButtonTypeFractal);
            groupBoxBossType.Controls.Add(radioButtonTypeRaidEncounter);
            groupBoxBossType.Controls.Add(radioButtonTypeNone);
            groupBoxBossType.Location = new System.Drawing.Point(17, 242);
            groupBoxBossType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxBossType.Name = "groupBoxBossType";
            groupBoxBossType.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxBossType.Size = new System.Drawing.Size(532, 98);
            groupBoxBossType.TabIndex = 12;
            groupBoxBossType.TabStop = false;
            groupBoxBossType.Text = "Boss type";
            // 
            // checkBoxEvent
            // 
            checkBoxEvent.AutoSize = true;
            checkBoxEvent.Location = new System.Drawing.Point(9, 66);
            checkBoxEvent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            checkBoxEvent.Name = "checkBoxEvent";
            checkBoxEvent.Size = new System.Drawing.Size(67, 24);
            checkBoxEvent.TabIndex = 6;
            checkBoxEvent.Text = "Event";
            checkBoxEvent.UseVisualStyleBackColor = true;
            // 
            // radioButtonTypeGolem
            // 
            radioButtonTypeGolem.AutoSize = true;
            radioButtonTypeGolem.Location = new System.Drawing.Point(305, 29);
            radioButtonTypeGolem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioButtonTypeGolem.Name = "radioButtonTypeGolem";
            radioButtonTypeGolem.Size = new System.Drawing.Size(74, 24);
            radioButtonTypeGolem.TabIndex = 5;
            radioButtonTypeGolem.TabStop = true;
            radioButtonTypeGolem.Text = "Golem";
            radioButtonTypeGolem.UseVisualStyleBackColor = true;
            radioButtonTypeGolem.CheckedChanged += RadioButtonTypeGolem_CheckedChanged;
            // 
            // radioButtonTypeWvW
            // 
            radioButtonTypeWvW.AutoSize = true;
            radioButtonTypeWvW.Location = new System.Drawing.Point(387, 29);
            radioButtonTypeWvW.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioButtonTypeWvW.Name = "radioButtonTypeWvW";
            radioButtonTypeWvW.Size = new System.Drawing.Size(65, 24);
            radioButtonTypeWvW.TabIndex = 4;
            radioButtonTypeWvW.TabStop = true;
            radioButtonTypeWvW.Text = "WvW";
            radioButtonTypeWvW.UseVisualStyleBackColor = true;
            radioButtonTypeWvW.CheckedChanged += RadioButtonTypeWvW_CheckedChanged;
            // 
            // radioButtonTypeFractal
            // 
            radioButtonTypeFractal.AutoSize = true;
            radioButtonTypeFractal.Location = new System.Drawing.Point(223, 29);
            radioButtonTypeFractal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioButtonTypeFractal.Name = "radioButtonTypeFractal";
            radioButtonTypeFractal.Size = new System.Drawing.Size(74, 24);
            radioButtonTypeFractal.TabIndex = 2;
            radioButtonTypeFractal.Text = "Fractal";
            radioButtonTypeFractal.UseVisualStyleBackColor = true;
            radioButtonTypeFractal.CheckedChanged += RadioButtonTypeFractal_CheckedChanged;
            // 
            // radioButtonTypeRaidEncounter
            // 
            radioButtonTypeRaidEncounter.AutoSize = true;
            radioButtonTypeRaidEncounter.Location = new System.Drawing.Point(85, 29);
            radioButtonTypeRaidEncounter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioButtonTypeRaidEncounter.Name = "radioButtonTypeRaidEncounter";
            radioButtonTypeRaidEncounter.Size = new System.Drawing.Size(130, 24);
            radioButtonTypeRaidEncounter.TabIndex = 1;
            radioButtonTypeRaidEncounter.Text = "Raid encounter";
            radioButtonTypeRaidEncounter.UseVisualStyleBackColor = true;
            radioButtonTypeRaidEncounter.CheckedChanged += RadioButtonTypeRaid_CheckedChanged;
            // 
            // radioButtonTypeNone
            // 
            radioButtonTypeNone.AutoSize = true;
            radioButtonTypeNone.Checked = true;
            radioButtonTypeNone.Location = new System.Drawing.Point(9, 29);
            radioButtonTypeNone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioButtonTypeNone.Name = "radioButtonTypeNone";
            radioButtonTypeNone.Size = new System.Drawing.Size(66, 24);
            radioButtonTypeNone.TabIndex = 0;
            radioButtonTypeNone.TabStop = true;
            radioButtonTypeNone.Text = "None";
            radioButtonTypeNone.UseVisualStyleBackColor = true;
            radioButtonTypeNone.CheckedChanged += RadioButtonTypeNone_CheckedChanged;
            // 
            // FormEditBossData
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(562, 668);
            Controls.Add(groupBoxBossType);
            Controls.Add(groupBoxOtherSettings);
            Controls.Add(groupBoxCrucial);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "FormEditBossData";
            FormClosing += FormEditBossData_FormClosing;
            groupBoxCrucial.ResumeLayout(false);
            groupBoxCrucial.PerformLayout();
            groupBoxOtherSettings.ResumeLayout(false);
            groupBoxOtherSettings.PerformLayout();
            groupBoxBossType.ResumeLayout(false);
            groupBoxBossType.PerformLayout();
            ResumeLayout(false);
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
        private System.Windows.Forms.RadioButton radioButtonTypeFractal;
        private System.Windows.Forms.RadioButton radioButtonTypeRaidEncounter;
        private System.Windows.Forms.RadioButton radioButtonTypeNone;
        private System.Windows.Forms.CheckBox checkBoxEvent;
        private System.Windows.Forms.RadioButton radioButtonTypeGolem;
        private System.Windows.Forms.Label labelWPulls;
        private System.Windows.Forms.Label labelWLog;
        private System.Windows.Forms.Label labelWBoss;
        private System.Windows.Forms.Label labelAvailableWildcards;
        private System.Windows.Forms.Label labelBossInternalDescription;
        private System.Windows.Forms.TextBox textBoxInternalDescription;
        private System.Windows.Forms.Label labelWPercent;
        private System.Windows.Forms.Button buttonOpenIconLink;
        private System.Windows.Forms.Label labelPhase;
    }
}