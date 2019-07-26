namespace PlenBotLogUploader
{
    partial class FormLogSession
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
            this.buttonSessionStarter = new System.Windows.Forms.Button();
            this.checkBoxSupressWebhooks = new System.Windows.Forms.CheckBox();
            this.checkBoxOnlySuccess = new System.Windows.Forms.CheckBox();
            this.buttonUnPauseSession = new System.Windows.Forms.Button();
            this.textBoxSessionName = new System.Windows.Forms.TextBox();
            this.labelSessionName = new System.Windows.Forms.Label();
            this.groupBoxSessionSettings = new System.Windows.Forms.GroupBox();
            this.groupBoxDiscordWebhooks = new System.Windows.Forms.GroupBox();
            this.radioButtonSortByUpload = new System.Windows.Forms.RadioButton();
            this.radioButtonSortByWing = new System.Windows.Forms.RadioButton();
            this.textBoxSessionContent = new System.Windows.Forms.TextBox();
            this.labelSessionContent = new System.Windows.Forms.Label();
            this.checkBoxSaveToFile = new System.Windows.Forms.CheckBox();
            this.groupBoxSessionSettings.SuspendLayout();
            this.groupBoxDiscordWebhooks.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSessionStarter
            // 
            this.buttonSessionStarter.Location = new System.Drawing.Point(12, 12);
            this.buttonSessionStarter.Name = "buttonSessionStarter";
            this.buttonSessionStarter.Size = new System.Drawing.Size(163, 23);
            this.buttonSessionStarter.TabIndex = 0;
            this.buttonSessionStarter.Text = "Start a log session";
            this.buttonSessionStarter.UseVisualStyleBackColor = true;
            this.buttonSessionStarter.Click += new System.EventHandler(this.ButtonSessionStarter_Click);
            // 
            // checkBoxSupressWebhooks
            // 
            this.checkBoxSupressWebhooks.AutoSize = true;
            this.checkBoxSupressWebhooks.Location = new System.Drawing.Point(6, 19);
            this.checkBoxSupressWebhooks.Name = "checkBoxSupressWebhooks";
            this.checkBoxSupressWebhooks.Size = new System.Drawing.Size(232, 17);
            this.checkBoxSupressWebhooks.TabIndex = 1;
            this.checkBoxSupressWebhooks.Text = "suppress webhooks until session concludes";
            this.checkBoxSupressWebhooks.UseVisualStyleBackColor = true;
            // 
            // checkBoxOnlySuccess
            // 
            this.checkBoxOnlySuccess.AutoSize = true;
            this.checkBoxOnlySuccess.Location = new System.Drawing.Point(9, 58);
            this.checkBoxOnlySuccess.Name = "checkBoxOnlySuccess";
            this.checkBoxOnlySuccess.Size = new System.Drawing.Size(167, 17);
            this.checkBoxOnlySuccess.TabIndex = 2;
            this.checkBoxOnlySuccess.Text = "save only successful attempts";
            this.checkBoxOnlySuccess.UseVisualStyleBackColor = true;
            // 
            // buttonUnPauseSession
            // 
            this.buttonUnPauseSession.Enabled = false;
            this.buttonUnPauseSession.Location = new System.Drawing.Point(181, 12);
            this.buttonUnPauseSession.Name = "buttonUnPauseSession";
            this.buttonUnPauseSession.Size = new System.Drawing.Size(116, 23);
            this.buttonUnPauseSession.TabIndex = 3;
            this.buttonUnPauseSession.Text = "Pause session";
            this.buttonUnPauseSession.UseVisualStyleBackColor = true;
            this.buttonUnPauseSession.Click += new System.EventHandler(this.ButtonUnPauseSession_Click);
            // 
            // textBoxSessionName
            // 
            this.textBoxSessionName.Location = new System.Drawing.Point(9, 32);
            this.textBoxSessionName.Name = "textBoxSessionName";
            this.textBoxSessionName.Size = new System.Drawing.Size(270, 20);
            this.textBoxSessionName.TabIndex = 4;
            // 
            // labelSessionName
            // 
            this.labelSessionName.AutoSize = true;
            this.labelSessionName.Location = new System.Drawing.Point(6, 16);
            this.labelSessionName.Name = "labelSessionName";
            this.labelSessionName.Size = new System.Drawing.Size(106, 13);
            this.labelSessionName.TabIndex = 5;
            this.labelSessionName.Text = "Name of the session:";
            // 
            // groupBoxSessionSettings
            // 
            this.groupBoxSessionSettings.Controls.Add(this.checkBoxSaveToFile);
            this.groupBoxSessionSettings.Controls.Add(this.groupBoxDiscordWebhooks);
            this.groupBoxSessionSettings.Controls.Add(this.textBoxSessionName);
            this.groupBoxSessionSettings.Controls.Add(this.labelSessionName);
            this.groupBoxSessionSettings.Controls.Add(this.checkBoxOnlySuccess);
            this.groupBoxSessionSettings.Location = new System.Drawing.Point(12, 41);
            this.groupBoxSessionSettings.Name = "groupBoxSessionSettings";
            this.groupBoxSessionSettings.Size = new System.Drawing.Size(285, 237);
            this.groupBoxSessionSettings.TabIndex = 6;
            this.groupBoxSessionSettings.TabStop = false;
            this.groupBoxSessionSettings.Text = "Session settings";
            // 
            // groupBoxDiscordWebhooks
            // 
            this.groupBoxDiscordWebhooks.Controls.Add(this.radioButtonSortByUpload);
            this.groupBoxDiscordWebhooks.Controls.Add(this.labelSessionContent);
            this.groupBoxDiscordWebhooks.Controls.Add(this.textBoxSessionContent);
            this.groupBoxDiscordWebhooks.Controls.Add(this.radioButtonSortByWing);
            this.groupBoxDiscordWebhooks.Controls.Add(this.checkBoxSupressWebhooks);
            this.groupBoxDiscordWebhooks.Location = new System.Drawing.Point(6, 104);
            this.groupBoxDiscordWebhooks.Name = "groupBoxDiscordWebhooks";
            this.groupBoxDiscordWebhooks.Size = new System.Drawing.Size(270, 127);
            this.groupBoxDiscordWebhooks.TabIndex = 8;
            this.groupBoxDiscordWebhooks.TabStop = false;
            this.groupBoxDiscordWebhooks.Text = "Discord webhook settings";
            // 
            // radioButtonSortByUpload
            // 
            this.radioButtonSortByUpload.AutoSize = true;
            this.radioButtonSortByUpload.Location = new System.Drawing.Point(6, 104);
            this.radioButtonSortByUpload.Name = "radioButtonSortByUpload";
            this.radioButtonSortByUpload.Size = new System.Drawing.Size(135, 17);
            this.radioButtonSortByUpload.TabIndex = 1;
            this.radioButtonSortByUpload.TabStop = true;
            this.radioButtonSortByUpload.Text = "sort logs by upload time";
            this.radioButtonSortByUpload.UseVisualStyleBackColor = true;
            this.radioButtonSortByUpload.CheckedChanged += new System.EventHandler(this.RadioButtonSortByUpload_CheckedChanged);
            // 
            // radioButtonSortByWing
            // 
            this.radioButtonSortByWing.AutoSize = true;
            this.radioButtonSortByWing.Checked = true;
            this.radioButtonSortByWing.Location = new System.Drawing.Point(6, 81);
            this.radioButtonSortByWing.Name = "radioButtonSortByWing";
            this.radioButtonSortByWing.Size = new System.Drawing.Size(176, 17);
            this.radioButtonSortByWing.TabIndex = 0;
            this.radioButtonSortByWing.TabStop = true;
            this.radioButtonSortByWing.Text = "sort logs by wing and boss order";
            this.radioButtonSortByWing.UseVisualStyleBackColor = true;
            this.radioButtonSortByWing.CheckedChanged += new System.EventHandler(this.RadioButtonSortByWing_CheckedChanged);
            // 
            // textBoxSessionContent
            // 
            this.textBoxSessionContent.Location = new System.Drawing.Point(6, 55);
            this.textBoxSessionContent.Name = "textBoxSessionContent";
            this.textBoxSessionContent.Size = new System.Drawing.Size(258, 20);
            this.textBoxSessionContent.TabIndex = 7;
            // 
            // labelSessionContent
            // 
            this.labelSessionContent.AutoSize = true;
            this.labelSessionContent.Location = new System.Drawing.Point(6, 39);
            this.labelSessionContent.Name = "labelSessionContent";
            this.labelSessionContent.Size = new System.Drawing.Size(91, 13);
            this.labelSessionContent.TabIndex = 6;
            this.labelSessionContent.Text = "Discord message:";
            // 
            // checkBoxSaveToFile
            // 
            this.checkBoxSaveToFile.AutoSize = true;
            this.checkBoxSaveToFile.Location = new System.Drawing.Point(9, 81);
            this.checkBoxSaveToFile.Name = "checkBoxSaveToFile";
            this.checkBoxSaveToFile.Size = new System.Drawing.Size(115, 17);
            this.checkBoxSaveToFile.TabIndex = 9;
            this.checkBoxSaveToFile.Text = "save session to file";
            this.checkBoxSaveToFile.UseVisualStyleBackColor = true;
            // 
            // FormLogSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 286);
            this.Controls.Add(this.groupBoxSessionSettings);
            this.Controls.Add(this.buttonUnPauseSession);
            this.Controls.Add(this.buttonSessionStarter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogSession";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log sessions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLogSession_FormClosing);
            this.groupBoxSessionSettings.ResumeLayout(false);
            this.groupBoxSessionSettings.PerformLayout();
            this.groupBoxDiscordWebhooks.ResumeLayout(false);
            this.groupBoxDiscordWebhooks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSessionStarter;
        public System.Windows.Forms.CheckBox checkBoxSupressWebhooks;
        public System.Windows.Forms.CheckBox checkBoxOnlySuccess;
        private System.Windows.Forms.Button buttonUnPauseSession;
        private System.Windows.Forms.Label labelSessionName;
        private System.Windows.Forms.GroupBox groupBoxSessionSettings;
        public System.Windows.Forms.TextBox textBoxSessionName;
        private System.Windows.Forms.Label labelSessionContent;
        public System.Windows.Forms.TextBox textBoxSessionContent;
        private System.Windows.Forms.GroupBox groupBoxDiscordWebhooks;
        public System.Windows.Forms.RadioButton radioButtonSortByUpload;
        public System.Windows.Forms.RadioButton radioButtonSortByWing;
        public System.Windows.Forms.CheckBox checkBoxSaveToFile;
    }
}