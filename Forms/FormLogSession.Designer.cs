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
            buttonSessionStarter = new System.Windows.Forms.Button();
            checkBoxSupressWebhooks = new System.Windows.Forms.CheckBox();
            checkBoxOnlySuccess = new System.Windows.Forms.CheckBox();
            buttonUnPauseSession = new System.Windows.Forms.Button();
            textBoxSessionName = new System.Windows.Forms.TextBox();
            labelSessionName = new System.Windows.Forms.Label();
            groupBoxSessionSettings = new System.Windows.Forms.GroupBox();
            checkBoxSaveToFile = new System.Windows.Forms.CheckBox();
            groupBoxDiscordWebhooks = new System.Windows.Forms.GroupBox();
            checkBoxMakeWvWSummary = new System.Windows.Forms.CheckBox();
            radioButtonSortByUpload = new System.Windows.Forms.RadioButton();
            labelSessionContent = new System.Windows.Forms.Label();
            textBoxSessionContent = new System.Windows.Forms.TextBox();
            radioButtonSortByWing = new System.Windows.Forms.RadioButton();
            groupBoxWebhookTypeSelection = new System.Windows.Forms.GroupBox();
            groupBoxSelectedWebhooks = new System.Windows.Forms.GroupBox();
            buttonReloadWebhooks = new System.Windows.Forms.Button();
            checkedListBoxSelectedWebhooks = new System.Windows.Forms.CheckedListBox();
            radioButtonOnlySelectedWebhooks = new System.Windows.Forms.RadioButton();
            radioButtonAllActive = new System.Windows.Forms.RadioButton();
            checkBoxEnableWvWLogList = new System.Windows.Forms.CheckBox();
            groupBoxSessionSettings.SuspendLayout();
            groupBoxDiscordWebhooks.SuspendLayout();
            groupBoxWebhookTypeSelection.SuspendLayout();
            groupBoxSelectedWebhooks.SuspendLayout();
            SuspendLayout();
            // 
            // buttonSessionStarter
            // 
            buttonSessionStarter.Location = new System.Drawing.Point(16, 19);
            buttonSessionStarter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonSessionStarter.Name = "buttonSessionStarter";
            buttonSessionStarter.Size = new System.Drawing.Size(217, 35);
            buttonSessionStarter.TabIndex = 0;
            buttonSessionStarter.Text = "Start a log session";
            buttonSessionStarter.UseVisualStyleBackColor = true;
            buttonSessionStarter.Click += ButtonSessionStarter_Click;
            // 
            // checkBoxSupressWebhooks
            // 
            checkBoxSupressWebhooks.AutoSize = true;
            checkBoxSupressWebhooks.Location = new System.Drawing.Point(8, 29);
            checkBoxSupressWebhooks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            checkBoxSupressWebhooks.Name = "checkBoxSupressWebhooks";
            checkBoxSupressWebhooks.Size = new System.Drawing.Size(313, 24);
            checkBoxSupressWebhooks.TabIndex = 1;
            checkBoxSupressWebhooks.Text = "suppress webhooks until session concludes";
            checkBoxSupressWebhooks.UseVisualStyleBackColor = true;
            // 
            // checkBoxOnlySuccess
            // 
            checkBoxOnlySuccess.AutoSize = true;
            checkBoxOnlySuccess.Location = new System.Drawing.Point(12, 89);
            checkBoxOnlySuccess.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            checkBoxOnlySuccess.Name = "checkBoxOnlySuccess";
            checkBoxOnlySuccess.Size = new System.Drawing.Size(224, 24);
            checkBoxOnlySuccess.TabIndex = 2;
            checkBoxOnlySuccess.Text = "save only successful attempts";
            checkBoxOnlySuccess.UseVisualStyleBackColor = true;
            // 
            // buttonUnPauseSession
            // 
            buttonUnPauseSession.Enabled = false;
            buttonUnPauseSession.Location = new System.Drawing.Point(241, 19);
            buttonUnPauseSession.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonUnPauseSession.Name = "buttonUnPauseSession";
            buttonUnPauseSession.Size = new System.Drawing.Size(155, 35);
            buttonUnPauseSession.TabIndex = 3;
            buttonUnPauseSession.Text = "Pause session";
            buttonUnPauseSession.UseVisualStyleBackColor = true;
            buttonUnPauseSession.Click += ButtonUnPauseSession_Click;
            // 
            // textBoxSessionName
            // 
            textBoxSessionName.Location = new System.Drawing.Point(12, 49);
            textBoxSessionName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBoxSessionName.Name = "textBoxSessionName";
            textBoxSessionName.Size = new System.Drawing.Size(359, 27);
            textBoxSessionName.TabIndex = 4;
            // 
            // labelSessionName
            // 
            labelSessionName.AutoSize = true;
            labelSessionName.Location = new System.Drawing.Point(8, 25);
            labelSessionName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelSessionName.Name = "labelSessionName";
            labelSessionName.Size = new System.Drawing.Size(146, 20);
            labelSessionName.TabIndex = 5;
            labelSessionName.Text = "Name of the session:";
            // 
            // groupBoxSessionSettings
            // 
            groupBoxSessionSettings.Controls.Add(checkBoxSaveToFile);
            groupBoxSessionSettings.Controls.Add(groupBoxDiscordWebhooks);
            groupBoxSessionSettings.Controls.Add(textBoxSessionName);
            groupBoxSessionSettings.Controls.Add(labelSessionName);
            groupBoxSessionSettings.Controls.Add(checkBoxOnlySuccess);
            groupBoxSessionSettings.Location = new System.Drawing.Point(16, 62);
            groupBoxSessionSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxSessionSettings.Name = "groupBoxSessionSettings";
            groupBoxSessionSettings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxSessionSettings.Size = new System.Drawing.Size(380, 412);
            groupBoxSessionSettings.TabIndex = 6;
            groupBoxSessionSettings.TabStop = false;
            groupBoxSessionSettings.Text = "Session settings";
            // 
            // checkBoxSaveToFile
            // 
            checkBoxSaveToFile.AutoSize = true;
            checkBoxSaveToFile.Location = new System.Drawing.Point(12, 125);
            checkBoxSaveToFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            checkBoxSaveToFile.Name = "checkBoxSaveToFile";
            checkBoxSaveToFile.Size = new System.Drawing.Size(166, 24);
            checkBoxSaveToFile.TabIndex = 9;
            checkBoxSaveToFile.Text = "save session to a file";
            checkBoxSaveToFile.UseVisualStyleBackColor = true;
            // 
            // groupBoxDiscordWebhooks
            // 
            groupBoxDiscordWebhooks.Controls.Add(checkBoxEnableWvWLogList);
            groupBoxDiscordWebhooks.Controls.Add(checkBoxMakeWvWSummary);
            groupBoxDiscordWebhooks.Controls.Add(radioButtonSortByUpload);
            groupBoxDiscordWebhooks.Controls.Add(labelSessionContent);
            groupBoxDiscordWebhooks.Controls.Add(textBoxSessionContent);
            groupBoxDiscordWebhooks.Controls.Add(radioButtonSortByWing);
            groupBoxDiscordWebhooks.Controls.Add(checkBoxSupressWebhooks);
            groupBoxDiscordWebhooks.Location = new System.Drawing.Point(8, 160);
            groupBoxDiscordWebhooks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxDiscordWebhooks.Name = "groupBoxDiscordWebhooks";
            groupBoxDiscordWebhooks.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxDiscordWebhooks.Size = new System.Drawing.Size(360, 243);
            groupBoxDiscordWebhooks.TabIndex = 8;
            groupBoxDiscordWebhooks.TabStop = false;
            groupBoxDiscordWebhooks.Text = "Discord webhook settings";
            // 
            // checkBoxMakeWvWSummary
            // 
            checkBoxMakeWvWSummary.AutoSize = true;
            checkBoxMakeWvWSummary.Location = new System.Drawing.Point(8, 182);
            checkBoxMakeWvWSummary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            checkBoxMakeWvWSummary.Name = "checkBoxMakeWvWSummary";
            checkBoxMakeWvWSummary.Size = new System.Drawing.Size(242, 24);
            checkBoxMakeWvWSummary.TabIndex = 8;
            checkBoxMakeWvWSummary.Text = "create a summary for WvW logs";
            checkBoxMakeWvWSummary.UseVisualStyleBackColor = true;
            // 
            // radioButtonSortByUpload
            // 
            radioButtonSortByUpload.AutoSize = true;
            radioButtonSortByUpload.Location = new System.Drawing.Point(8, 153);
            radioButtonSortByUpload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioButtonSortByUpload.Name = "radioButtonSortByUpload";
            radioButtonSortByUpload.Size = new System.Drawing.Size(192, 24);
            radioButtonSortByUpload.TabIndex = 1;
            radioButtonSortByUpload.TabStop = true;
            radioButtonSortByUpload.Text = "sort logs by upload time";
            radioButtonSortByUpload.UseVisualStyleBackColor = true;
            radioButtonSortByUpload.CheckedChanged += RadioButtonSortByUpload_CheckedChanged;
            // 
            // labelSessionContent
            // 
            labelSessionContent.AutoSize = true;
            labelSessionContent.Location = new System.Drawing.Point(8, 60);
            labelSessionContent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelSessionContent.Name = "labelSessionContent";
            labelSessionContent.Size = new System.Drawing.Size(125, 20);
            labelSessionContent.TabIndex = 6;
            labelSessionContent.Text = "Discord message:";
            // 
            // textBoxSessionContent
            // 
            textBoxSessionContent.Location = new System.Drawing.Point(8, 85);
            textBoxSessionContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBoxSessionContent.Name = "textBoxSessionContent";
            textBoxSessionContent.Size = new System.Drawing.Size(343, 27);
            textBoxSessionContent.TabIndex = 7;
            // 
            // radioButtonSortByWing
            // 
            radioButtonSortByWing.AutoSize = true;
            radioButtonSortByWing.Checked = true;
            radioButtonSortByWing.Location = new System.Drawing.Point(8, 126);
            radioButtonSortByWing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioButtonSortByWing.Name = "radioButtonSortByWing";
            radioButtonSortByWing.Size = new System.Drawing.Size(246, 24);
            radioButtonSortByWing.TabIndex = 0;
            radioButtonSortByWing.TabStop = true;
            radioButtonSortByWing.Text = "sort logs by wing and boss order";
            radioButtonSortByWing.UseVisualStyleBackColor = true;
            radioButtonSortByWing.CheckedChanged += RadioButtonSortByWing_CheckedChanged;
            // 
            // groupBoxWebhookTypeSelection
            // 
            groupBoxWebhookTypeSelection.Controls.Add(groupBoxSelectedWebhooks);
            groupBoxWebhookTypeSelection.Controls.Add(radioButtonOnlySelectedWebhooks);
            groupBoxWebhookTypeSelection.Controls.Add(radioButtonAllActive);
            groupBoxWebhookTypeSelection.Location = new System.Drawing.Point(404, 19);
            groupBoxWebhookTypeSelection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxWebhookTypeSelection.Name = "groupBoxWebhookTypeSelection";
            groupBoxWebhookTypeSelection.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxWebhookTypeSelection.Size = new System.Drawing.Size(328, 455);
            groupBoxWebhookTypeSelection.TabIndex = 7;
            groupBoxWebhookTypeSelection.TabStop = false;
            groupBoxWebhookTypeSelection.Text = "Select which Webhooks to execute for session";
            // 
            // groupBoxSelectedWebhooks
            // 
            groupBoxSelectedWebhooks.Controls.Add(buttonReloadWebhooks);
            groupBoxSelectedWebhooks.Controls.Add(checkedListBoxSelectedWebhooks);
            groupBoxSelectedWebhooks.Enabled = false;
            groupBoxSelectedWebhooks.Location = new System.Drawing.Point(9, 106);
            groupBoxSelectedWebhooks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxSelectedWebhooks.Name = "groupBoxSelectedWebhooks";
            groupBoxSelectedWebhooks.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxSelectedWebhooks.Size = new System.Drawing.Size(311, 340);
            groupBoxSelectedWebhooks.TabIndex = 3;
            groupBoxSelectedWebhooks.TabStop = false;
            groupBoxSelectedWebhooks.Text = "Selected Webhooks";
            // 
            // buttonReloadWebhooks
            // 
            buttonReloadWebhooks.Location = new System.Drawing.Point(8, 28);
            buttonReloadWebhooks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonReloadWebhooks.Name = "buttonReloadWebhooks";
            buttonReloadWebhooks.Size = new System.Drawing.Size(295, 35);
            buttonReloadWebhooks.TabIndex = 3;
            buttonReloadWebhooks.Text = "Reload possible Webhooks";
            buttonReloadWebhooks.UseVisualStyleBackColor = true;
            buttonReloadWebhooks.Click += ButtonReloadWebhooks_Click;
            // 
            // checkedListBoxSelectedWebhooks
            // 
            checkedListBoxSelectedWebhooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            checkedListBoxSelectedWebhooks.FormattingEnabled = true;
            checkedListBoxSelectedWebhooks.Location = new System.Drawing.Point(8, 72);
            checkedListBoxSelectedWebhooks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            checkedListBoxSelectedWebhooks.Name = "checkedListBoxSelectedWebhooks";
            checkedListBoxSelectedWebhooks.Size = new System.Drawing.Size(293, 242);
            checkedListBoxSelectedWebhooks.TabIndex = 2;
            // 
            // radioButtonOnlySelectedWebhooks
            // 
            radioButtonOnlySelectedWebhooks.AutoSize = true;
            radioButtonOnlySelectedWebhooks.Location = new System.Drawing.Point(9, 62);
            radioButtonOnlySelectedWebhooks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioButtonOnlySelectedWebhooks.Name = "radioButtonOnlySelectedWebhooks";
            radioButtonOnlySelectedWebhooks.Size = new System.Drawing.Size(276, 24);
            radioButtonOnlySelectedWebhooks.TabIndex = 1;
            radioButtonOnlySelectedWebhooks.Text = "Only selected Webhooks from the list";
            radioButtonOnlySelectedWebhooks.UseVisualStyleBackColor = true;
            radioButtonOnlySelectedWebhooks.CheckedChanged += RadioButtonOnlySelectedWebhooks_CheckedChanged;
            // 
            // radioButtonAllActive
            // 
            radioButtonAllActive.AutoSize = true;
            radioButtonAllActive.Checked = true;
            radioButtonAllActive.Location = new System.Drawing.Point(9, 31);
            radioButtonAllActive.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioButtonAllActive.Name = "radioButtonAllActive";
            radioButtonAllActive.Size = new System.Drawing.Size(225, 24);
            radioButtonAllActive.TabIndex = 0;
            radioButtonAllActive.TabStop = true;
            radioButtonAllActive.Text = "All currently active Webhooks";
            radioButtonAllActive.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableWvWLogList
            // 
            checkBoxEnableWvWLogList.AutoSize = true;
            checkBoxEnableWvWLogList.Location = new System.Drawing.Point(8, 209);
            checkBoxEnableWvWLogList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            checkBoxEnableWvWLogList.Name = "checkBoxEnableWvWLogList";
            checkBoxEnableWvWLogList.Size = new System.Drawing.Size(222, 24);
            checkBoxEnableWvWLogList.TabIndex = 9;
            checkBoxEnableWvWLogList.Text = "post the list for all WvW logs";
            checkBoxEnableWvWLogList.UseVisualStyleBackColor = true;
            // 
            // FormLogSession
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(744, 506);
            Controls.Add(groupBoxWebhookTypeSelection);
            Controls.Add(groupBoxSessionSettings);
            Controls.Add(buttonUnPauseSession);
            Controls.Add(buttonSessionStarter);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogSession";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Log sessions";
            FormClosing += FormLogSession_FormClosing;
            groupBoxSessionSettings.ResumeLayout(false);
            groupBoxSessionSettings.PerformLayout();
            groupBoxDiscordWebhooks.ResumeLayout(false);
            groupBoxDiscordWebhooks.PerformLayout();
            groupBoxWebhookTypeSelection.ResumeLayout(false);
            groupBoxWebhookTypeSelection.PerformLayout();
            groupBoxSelectedWebhooks.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button buttonSessionStarter;
        private System.Windows.Forms.Button buttonUnPauseSession;
        private System.Windows.Forms.Label labelSessionName;
        private System.Windows.Forms.GroupBox groupBoxSessionSettings;
        private System.Windows.Forms.Label labelSessionContent;
        private System.Windows.Forms.GroupBox groupBoxDiscordWebhooks;
        private System.Windows.Forms.GroupBox groupBoxWebhookTypeSelection;
        private System.Windows.Forms.GroupBox groupBoxSelectedWebhooks;
        private System.Windows.Forms.Button buttonReloadWebhooks;
        private System.Windows.Forms.CheckedListBox checkedListBoxSelectedWebhooks;
        private System.Windows.Forms.RadioButton radioButtonOnlySelectedWebhooks;
        private System.Windows.Forms.RadioButton radioButtonAllActive;
        internal System.Windows.Forms.CheckBox checkBoxMakeWvWSummary;
        internal System.Windows.Forms.CheckBox checkBoxOnlySuccess;
        internal System.Windows.Forms.TextBox textBoxSessionName;
        internal System.Windows.Forms.CheckBox checkBoxSupressWebhooks;
        internal System.Windows.Forms.TextBox textBoxSessionContent;
        internal System.Windows.Forms.RadioButton radioButtonSortByUpload;
        internal System.Windows.Forms.RadioButton radioButtonSortByWing;
        internal System.Windows.Forms.CheckBox checkBoxSaveToFile;
        internal System.Windows.Forms.CheckBox checkBoxEnableWvWLogList;
    }
}