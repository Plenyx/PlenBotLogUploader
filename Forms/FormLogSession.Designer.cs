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
            this.checkBoxSaveToFile = new System.Windows.Forms.CheckBox();
            this.groupBoxDiscordWebhooks = new System.Windows.Forms.GroupBox();
            this.radioButtonSortByUpload = new System.Windows.Forms.RadioButton();
            this.labelSessionContent = new System.Windows.Forms.Label();
            this.textBoxSessionContent = new System.Windows.Forms.TextBox();
            this.radioButtonSortByWing = new System.Windows.Forms.RadioButton();
            this.groupBoxWebhookTypeSelection = new System.Windows.Forms.GroupBox();
            this.groupBoxSelectedWebhooks = new System.Windows.Forms.GroupBox();
            this.buttonReloadWebhooks = new System.Windows.Forms.Button();
            this.checkedListBoxSelectedWebhooks = new System.Windows.Forms.CheckedListBox();
            this.radioButtonOnlySelectedWebhooks = new System.Windows.Forms.RadioButton();
            this.radioButtonAllActive = new System.Windows.Forms.RadioButton();
            this.groupBoxSessionSettings.SuspendLayout();
            this.groupBoxDiscordWebhooks.SuspendLayout();
            this.groupBoxWebhookTypeSelection.SuspendLayout();
            this.groupBoxSelectedWebhooks.SuspendLayout();
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
            // checkBoxSaveToFile
            // 
            this.checkBoxSaveToFile.AutoSize = true;
            this.checkBoxSaveToFile.Location = new System.Drawing.Point(9, 81);
            this.checkBoxSaveToFile.Name = "checkBoxSaveToFile";
            this.checkBoxSaveToFile.Size = new System.Drawing.Size(124, 17);
            this.checkBoxSaveToFile.TabIndex = 9;
            this.checkBoxSaveToFile.Text = "save session to a file";
            this.checkBoxSaveToFile.UseVisualStyleBackColor = true;
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
            // labelSessionContent
            // 
            this.labelSessionContent.AutoSize = true;
            this.labelSessionContent.Location = new System.Drawing.Point(6, 39);
            this.labelSessionContent.Name = "labelSessionContent";
            this.labelSessionContent.Size = new System.Drawing.Size(91, 13);
            this.labelSessionContent.TabIndex = 6;
            this.labelSessionContent.Text = "Discord message:";
            // 
            // textBoxSessionContent
            // 
            this.textBoxSessionContent.Location = new System.Drawing.Point(6, 55);
            this.textBoxSessionContent.Name = "textBoxSessionContent";
            this.textBoxSessionContent.Size = new System.Drawing.Size(258, 20);
            this.textBoxSessionContent.TabIndex = 7;
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
            // groupBoxWebhookTypeSelection
            // 
            this.groupBoxWebhookTypeSelection.Controls.Add(this.groupBoxSelectedWebhooks);
            this.groupBoxWebhookTypeSelection.Controls.Add(this.radioButtonOnlySelectedWebhooks);
            this.groupBoxWebhookTypeSelection.Controls.Add(this.radioButtonAllActive);
            this.groupBoxWebhookTypeSelection.Location = new System.Drawing.Point(303, 12);
            this.groupBoxWebhookTypeSelection.Name = "groupBoxWebhookTypeSelection";
            this.groupBoxWebhookTypeSelection.Size = new System.Drawing.Size(246, 266);
            this.groupBoxWebhookTypeSelection.TabIndex = 7;
            this.groupBoxWebhookTypeSelection.TabStop = false;
            this.groupBoxWebhookTypeSelection.Text = "Select which Webhooks to execute for session";
            // 
            // groupBoxSelectedWebhooks
            // 
            this.groupBoxSelectedWebhooks.Controls.Add(this.buttonReloadWebhooks);
            this.groupBoxSelectedWebhooks.Controls.Add(this.checkedListBoxSelectedWebhooks);
            this.groupBoxSelectedWebhooks.Enabled = false;
            this.groupBoxSelectedWebhooks.Location = new System.Drawing.Point(7, 69);
            this.groupBoxSelectedWebhooks.Name = "groupBoxSelectedWebhooks";
            this.groupBoxSelectedWebhooks.Size = new System.Drawing.Size(233, 191);
            this.groupBoxSelectedWebhooks.TabIndex = 3;
            this.groupBoxSelectedWebhooks.TabStop = false;
            this.groupBoxSelectedWebhooks.Text = "Selected Webhooks";
            // 
            // buttonReloadWebhooks
            // 
            this.buttonReloadWebhooks.Location = new System.Drawing.Point(6, 18);
            this.buttonReloadWebhooks.Name = "buttonReloadWebhooks";
            this.buttonReloadWebhooks.Size = new System.Drawing.Size(221, 23);
            this.buttonReloadWebhooks.TabIndex = 3;
            this.buttonReloadWebhooks.Text = "Reload possible Webhooks";
            this.buttonReloadWebhooks.UseVisualStyleBackColor = true;
            this.buttonReloadWebhooks.Click += new System.EventHandler(this.ButtonReloadWebhooks_Click);
            // 
            // checkedListBoxSelectedWebhooks
            // 
            this.checkedListBoxSelectedWebhooks.FormattingEnabled = true;
            this.checkedListBoxSelectedWebhooks.Location = new System.Drawing.Point(6, 47);
            this.checkedListBoxSelectedWebhooks.Name = "checkedListBoxSelectedWebhooks";
            this.checkedListBoxSelectedWebhooks.Size = new System.Drawing.Size(221, 139);
            this.checkedListBoxSelectedWebhooks.TabIndex = 2;
            // 
            // radioButtonOnlySelectedWebhooks
            // 
            this.radioButtonOnlySelectedWebhooks.AutoSize = true;
            this.radioButtonOnlySelectedWebhooks.Location = new System.Drawing.Point(7, 41);
            this.radioButtonOnlySelectedWebhooks.Name = "radioButtonOnlySelectedWebhooks";
            this.radioButtonOnlySelectedWebhooks.Size = new System.Drawing.Size(200, 17);
            this.radioButtonOnlySelectedWebhooks.TabIndex = 1;
            this.radioButtonOnlySelectedWebhooks.Text = "Only selected Webhooks from the list";
            this.radioButtonOnlySelectedWebhooks.UseVisualStyleBackColor = true;
            this.radioButtonOnlySelectedWebhooks.CheckedChanged += new System.EventHandler(this.RadioButtonOnlySelectedWebhooks_CheckedChanged);
            // 
            // radioButtonAllActive
            // 
            this.radioButtonAllActive.AutoSize = true;
            this.radioButtonAllActive.Checked = true;
            this.radioButtonAllActive.Location = new System.Drawing.Point(7, 20);
            this.radioButtonAllActive.Name = "radioButtonAllActive";
            this.radioButtonAllActive.Size = new System.Drawing.Size(166, 17);
            this.radioButtonAllActive.TabIndex = 0;
            this.radioButtonAllActive.TabStop = true;
            this.radioButtonAllActive.Text = "All currently active Webhooks";
            this.radioButtonAllActive.UseVisualStyleBackColor = true;
            // 
            // FormLogSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 287);
            this.Controls.Add(this.groupBoxWebhookTypeSelection);
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
            this.groupBoxWebhookTypeSelection.ResumeLayout(false);
            this.groupBoxWebhookTypeSelection.PerformLayout();
            this.groupBoxSelectedWebhooks.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBoxWebhookTypeSelection;
        private System.Windows.Forms.GroupBox groupBoxSelectedWebhooks;
        private System.Windows.Forms.Button buttonReloadWebhooks;
        private System.Windows.Forms.CheckedListBox checkedListBoxSelectedWebhooks;
        private System.Windows.Forms.RadioButton radioButtonOnlySelectedWebhooks;
        private System.Windows.Forms.RadioButton radioButtonAllActive;
    }
}