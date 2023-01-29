namespace PlenBotLogUploader
{
    partial class FormEditAleevaIntegration
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
            this.groupBoxUploadSettings = new System.Windows.Forms.GroupBox();
            this.labelAleevaTeam = new System.Windows.Forms.Label();
            this.comboBoxSelectedTeam = new System.Windows.Forms.ComboBox();
            this.checkBoxOnlySuccessful = new System.Windows.Forms.CheckBox();
            this.checkBoxSendNotification = new System.Windows.Forms.CheckBox();
            this.groupBoxChannel = new System.Windows.Forms.GroupBox();
            this.comboBoxChannel = new System.Windows.Forms.ComboBox();
            this.groupBoxServer = new System.Windows.Forms.GroupBox();
            this.comboBoxServer = new System.Windows.Forms.ComboBox();
            this.groupBoxName = new System.Windows.Forms.GroupBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBoxUploadSettings.SuspendLayout();
            this.groupBoxChannel.SuspendLayout();
            this.groupBoxServer.SuspendLayout();
            this.groupBoxName.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUploadSettings
            // 
            this.groupBoxUploadSettings.Controls.Add(this.labelAleevaTeam);
            this.groupBoxUploadSettings.Controls.Add(this.comboBoxSelectedTeam);
            this.groupBoxUploadSettings.Controls.Add(this.checkBoxOnlySuccessful);
            this.groupBoxUploadSettings.Controls.Add(this.checkBoxSendNotification);
            this.groupBoxUploadSettings.Location = new System.Drawing.Point(15, 245);
            this.groupBoxUploadSettings.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxUploadSettings.Name = "groupBoxUploadSettings";
            this.groupBoxUploadSettings.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxUploadSettings.Size = new System.Drawing.Size(632, 128);
            this.groupBoxUploadSettings.TabIndex = 5;
            this.groupBoxUploadSettings.TabStop = false;
            this.groupBoxUploadSettings.Text = "Upload settings";
            // 
            // labelAleevaTeam
            // 
            this.labelAleevaTeam.AutoSize = true;
            this.labelAleevaTeam.Location = new System.Drawing.Point(5, 60);
            this.labelAleevaTeam.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelAleevaTeam.Name = "labelAleevaTeam";
            this.labelAleevaTeam.Size = new System.Drawing.Size(45, 20);
            this.labelAleevaTeam.TabIndex = 3;
            this.labelAleevaTeam.Text = "Team";
            // 
            // comboBoxSelectedTeam
            // 
            this.comboBoxSelectedTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectedTeam.FormattingEnabled = true;
            this.comboBoxSelectedTeam.Location = new System.Drawing.Point(8, 84);
            this.comboBoxSelectedTeam.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.comboBoxSelectedTeam.Name = "comboBoxSelectedTeam";
            this.comboBoxSelectedTeam.Size = new System.Drawing.Size(614, 28);
            this.comboBoxSelectedTeam.TabIndex = 2;
            this.comboBoxSelectedTeam.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectedTeam_SelectedIndexChanged);
            // 
            // checkBoxOnlySuccessful
            // 
            this.checkBoxOnlySuccessful.AutoSize = true;
            this.checkBoxOnlySuccessful.Location = new System.Drawing.Point(284, 29);
            this.checkBoxOnlySuccessful.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.checkBoxOnlySuccessful.Name = "checkBoxOnlySuccessful";
            this.checkBoxOnlySuccessful.Size = new System.Drawing.Size(213, 24);
            this.checkBoxOnlySuccessful.TabIndex = 1;
            this.checkBoxOnlySuccessful.Text = "Upload only successful logs";
            this.checkBoxOnlySuccessful.UseVisualStyleBackColor = true;
            // 
            // checkBoxSendNotification
            // 
            this.checkBoxSendNotification.AutoSize = true;
            this.checkBoxSendNotification.Location = new System.Drawing.Point(8, 29);
            this.checkBoxSendNotification.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.checkBoxSendNotification.Name = "checkBoxSendNotification";
            this.checkBoxSendNotification.Size = new System.Drawing.Size(266, 24);
            this.checkBoxSendNotification.TabIndex = 0;
            this.checkBoxSendNotification.Text = "Post the log to the selected channel";
            this.checkBoxSendNotification.UseVisualStyleBackColor = true;
            // 
            // groupBoxChannel
            // 
            this.groupBoxChannel.Controls.Add(this.comboBoxChannel);
            this.groupBoxChannel.Location = new System.Drawing.Point(15, 164);
            this.groupBoxChannel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxChannel.Name = "groupBoxChannel";
            this.groupBoxChannel.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxChannel.Size = new System.Drawing.Size(633, 73);
            this.groupBoxChannel.TabIndex = 4;
            this.groupBoxChannel.TabStop = false;
            this.groupBoxChannel.Text = "Notification channel";
            // 
            // comboBoxChannel
            // 
            this.comboBoxChannel.FormattingEnabled = true;
            this.comboBoxChannel.Location = new System.Drawing.Point(8, 29);
            this.comboBoxChannel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.comboBoxChannel.Name = "comboBoxChannel";
            this.comboBoxChannel.Size = new System.Drawing.Size(614, 28);
            this.comboBoxChannel.TabIndex = 2;
            // 
            // groupBoxServer
            // 
            this.groupBoxServer.Controls.Add(this.comboBoxServer);
            this.groupBoxServer.Location = new System.Drawing.Point(15, 83);
            this.groupBoxServer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxServer.Name = "groupBoxServer";
            this.groupBoxServer.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxServer.Size = new System.Drawing.Size(632, 73);
            this.groupBoxServer.TabIndex = 3;
            this.groupBoxServer.TabStop = false;
            this.groupBoxServer.Text = "Notification server";
            // 
            // comboBoxServer
            // 
            this.comboBoxServer.FormattingEnabled = true;
            this.comboBoxServer.Location = new System.Drawing.Point(8, 29);
            this.comboBoxServer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.comboBoxServer.Name = "comboBoxServer";
            this.comboBoxServer.Size = new System.Drawing.Size(614, 28);
            this.comboBoxServer.TabIndex = 1;
            this.comboBoxServer.DropDown += new System.EventHandler(this.ComboBoxServer_DropDown);
            // 
            // groupBoxName
            // 
            this.groupBoxName.Controls.Add(this.textBoxName);
            this.groupBoxName.Location = new System.Drawing.Point(15, 12);
            this.groupBoxName.Name = "groupBoxName";
            this.groupBoxName.Size = new System.Drawing.Size(633, 64);
            this.groupBoxName.TabIndex = 6;
            this.groupBoxName.TabStop = false;
            this.groupBoxName.Text = "Name (appears only in the uploader UI)";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(8, 26);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(614, 27);
            this.textBoxName.TabIndex = 0;
            // 
            // FormEditAleevaIntegration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(661, 386);
            this.Controls.Add(this.groupBoxName);
            this.Controls.Add(this.groupBoxServer);
            this.Controls.Add(this.groupBoxChannel);
            this.Controls.Add(this.groupBoxUploadSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditAleevaIntegration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aleeva integration";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.FormAleeva_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAleeva_FormClosing);
            this.Shown += new System.EventHandler(this.FormAleeva_Shown);
            this.groupBoxUploadSettings.ResumeLayout(false);
            this.groupBoxUploadSettings.PerformLayout();
            this.groupBoxChannel.ResumeLayout(false);
            this.groupBoxServer.ResumeLayout(false);
            this.groupBoxName.ResumeLayout(false);
            this.groupBoxName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxServer;
        private System.Windows.Forms.ComboBox comboBoxChannel;
        private System.Windows.Forms.GroupBox groupBoxChannel;
        private System.Windows.Forms.GroupBox groupBoxServer;
        private System.Windows.Forms.GroupBox groupBoxUploadSettings;
        private System.Windows.Forms.CheckBox checkBoxSendNotification;
        private System.Windows.Forms.CheckBox checkBoxOnlySuccessful;
        private System.Windows.Forms.Label labelAleevaTeam;
        private System.Windows.Forms.ComboBox comboBoxSelectedTeam;
        private System.Windows.Forms.GroupBox groupBoxName;
        private System.Windows.Forms.TextBox textBoxName;
    }
}