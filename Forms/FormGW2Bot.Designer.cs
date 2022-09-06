namespace PlenBotLogUploader
{
    partial class FormGW2Bot
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
            this.checkBoxOnlySuccessful = new System.Windows.Forms.CheckBox();
            this.groupBoxUploadSettings = new System.Windows.Forms.GroupBox();
            this.labelSelectedTeam = new System.Windows.Forms.Label();
            this.comboBoxSelectedTeam = new System.Windows.Forms.ComboBox();
            this.groupBoxModuleEnabled = new System.Windows.Forms.GroupBox();
            this.checkBoxModuleEnabled = new System.Windows.Forms.CheckBox();
            this.groupBoxAPIKey = new System.Windows.Forms.GroupBox();
            this.textBoxAPIKey = new System.Windows.Forms.TextBox();
            this.groupBoxUploadSettings.SuspendLayout();
            this.groupBoxModuleEnabled.SuspendLayout();
            this.groupBoxAPIKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxOnlySuccessful
            // 
            this.checkBoxOnlySuccessful.AutoSize = true;
            this.checkBoxOnlySuccessful.Location = new System.Drawing.Point(6, 19);
            this.checkBoxOnlySuccessful.Name = "checkBoxOnlySuccessful";
            this.checkBoxOnlySuccessful.Size = new System.Drawing.Size(157, 17);
            this.checkBoxOnlySuccessful.TabIndex = 1;
            this.checkBoxOnlySuccessful.Text = "Upload only successful logs";
            this.checkBoxOnlySuccessful.UseVisualStyleBackColor = true;
            // 
            // groupBoxUploadSettings
            // 
            this.groupBoxUploadSettings.Controls.Add(this.labelSelectedTeam);
            this.groupBoxUploadSettings.Controls.Add(this.comboBoxSelectedTeam);
            this.groupBoxUploadSettings.Controls.Add(this.checkBoxOnlySuccessful);
            this.groupBoxUploadSettings.Enabled = false;
            this.groupBoxUploadSettings.Location = new System.Drawing.Point(12, 115);
            this.groupBoxUploadSettings.Name = "groupBoxUploadSettings";
            this.groupBoxUploadSettings.Size = new System.Drawing.Size(265, 88);
            this.groupBoxUploadSettings.TabIndex = 6;
            this.groupBoxUploadSettings.TabStop = false;
            this.groupBoxUploadSettings.Text = "Upload settings";
            // 
            // labelSelectedTeam
            // 
            this.labelSelectedTeam.AutoSize = true;
            this.labelSelectedTeam.Location = new System.Drawing.Point(6, 42);
            this.labelSelectedTeam.Name = "labelSelectedTeam";
            this.labelSelectedTeam.Size = new System.Drawing.Size(34, 13);
            this.labelSelectedTeam.TabIndex = 3;
            this.labelSelectedTeam.Text = "Team";
            // 
            // comboBoxSelectedTeam
            // 
            this.comboBoxSelectedTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectedTeam.FormattingEnabled = true;
            this.comboBoxSelectedTeam.Location = new System.Drawing.Point(6, 58);
            this.comboBoxSelectedTeam.Name = "comboBoxSelectedTeam";
            this.comboBoxSelectedTeam.Size = new System.Drawing.Size(253, 21);
            this.comboBoxSelectedTeam.TabIndex = 2;
            // 
            // groupBoxModuleEnabled
            // 
            this.groupBoxModuleEnabled.Controls.Add(this.checkBoxModuleEnabled);
            this.groupBoxModuleEnabled.Location = new System.Drawing.Point(12, 12);
            this.groupBoxModuleEnabled.Name = "groupBoxModuleEnabled";
            this.groupBoxModuleEnabled.Size = new System.Drawing.Size(265, 44);
            this.groupBoxModuleEnabled.TabIndex = 7;
            this.groupBoxModuleEnabled.TabStop = false;
            this.groupBoxModuleEnabled.Text = "GW2Bot integration";
            // 
            // checkBoxModuleEnabled
            // 
            this.checkBoxModuleEnabled.AutoSize = true;
            this.checkBoxModuleEnabled.Location = new System.Drawing.Point(6, 19);
            this.checkBoxModuleEnabled.Name = "checkBoxModuleEnabled";
            this.checkBoxModuleEnabled.Size = new System.Drawing.Size(95, 17);
            this.checkBoxModuleEnabled.TabIndex = 3;
            this.checkBoxModuleEnabled.Text = "enable module";
            this.checkBoxModuleEnabled.UseVisualStyleBackColor = true;
            this.checkBoxModuleEnabled.CheckedChanged += new System.EventHandler(this.CheckBoxModuleEnabled_CheckedChanged);
            // 
            // groupBoxAPIKey
            // 
            this.groupBoxAPIKey.Controls.Add(this.textBoxAPIKey);
            this.groupBoxAPIKey.Enabled = false;
            this.groupBoxAPIKey.Location = new System.Drawing.Point(12, 62);
            this.groupBoxAPIKey.Name = "groupBoxAPIKey";
            this.groupBoxAPIKey.Size = new System.Drawing.Size(265, 47);
            this.groupBoxAPIKey.TabIndex = 8;
            this.groupBoxAPIKey.TabStop = false;
            this.groupBoxAPIKey.Text = "API key";
            // 
            // textBoxAPIKey
            // 
            this.textBoxAPIKey.Location = new System.Drawing.Point(6, 19);
            this.textBoxAPIKey.Name = "textBoxAPIKey";
            this.textBoxAPIKey.Size = new System.Drawing.Size(253, 20);
            this.textBoxAPIKey.TabIndex = 0;
            // 
            // FormGW2Bot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(289, 212);
            this.Controls.Add(this.groupBoxAPIKey);
            this.Controls.Add(this.groupBoxModuleEnabled);
            this.Controls.Add(this.groupBoxUploadSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGW2Bot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GW2Bot integration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGW2Bot_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGW2Bot_FormClosed);
            this.Shown += new System.EventHandler(this.FormGW2Bot_Shown);
            this.groupBoxUploadSettings.ResumeLayout(false);
            this.groupBoxUploadSettings.PerformLayout();
            this.groupBoxModuleEnabled.ResumeLayout(false);
            this.groupBoxModuleEnabled.PerformLayout();
            this.groupBoxAPIKey.ResumeLayout(false);
            this.groupBoxAPIKey.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxUploadSettings;
        private System.Windows.Forms.GroupBox groupBoxModuleEnabled;
        internal System.Windows.Forms.CheckBox checkBoxModuleEnabled;
        private System.Windows.Forms.GroupBox groupBoxAPIKey;
        internal System.Windows.Forms.TextBox textBoxAPIKey;
        internal System.Windows.Forms.CheckBox checkBoxOnlySuccessful;
        private System.Windows.Forms.Label labelSelectedTeam;
        private System.Windows.Forms.ComboBox comboBoxSelectedTeam;
    }
}