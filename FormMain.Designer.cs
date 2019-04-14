namespace PlenBotLogUploader
{
    partial class FormMain
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
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.textBoxUploadInfo = new System.Windows.Forms.TextBox();
            this.groupBoxTwitchSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxFileSizeIgnore = new System.Windows.Forms.CheckBox();
            this.checkBoxPostToTwitch = new System.Windows.Forms.CheckBox();
            this.checkBoxWepSkill1 = new System.Windows.Forms.CheckBox();
            this.buttonReconnectBot = new System.Windows.Forms.Button();
            this.checkBoxUploadLogs = new System.Windows.Forms.CheckBox();
            this.groupBoxLogsDirectory = new System.Windows.Forms.GroupBox();
            this.labelLocationInfo = new System.Windows.Forms.Label();
            this.buttonLogsLocation = new System.Windows.Forms.Button();
            this.groupBoxTrayIconSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxTrayNotification = new System.Windows.Forms.CheckBox();
            this.checkBoxTrayMinimiseToIcon = new System.Windows.Forms.CheckBox();
            this.checkBoxTrayEnable = new System.Windows.Forms.CheckBox();
            this.notifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBoxOtherSettings = new System.Windows.Forms.GroupBox();
            this.buttonPingSettings = new System.Windows.Forms.Button();
            this.buttonChangeTwitchChannel = new System.Windows.Forms.Button();
            this.groupBoxTwitchSettings.SuspendLayout();
            this.groupBoxLogsDirectory.SuspendLayout();
            this.groupBoxTrayIconSettings.SuspendLayout();
            this.groupBoxOtherSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxUploadInfo
            // 
            this.textBoxUploadInfo.Location = new System.Drawing.Point(12, 12);
            this.textBoxUploadInfo.MaxLength = 9999999;
            this.textBoxUploadInfo.Multiline = true;
            this.textBoxUploadInfo.Name = "textBoxUploadInfo";
            this.textBoxUploadInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxUploadInfo.Size = new System.Drawing.Size(408, 400);
            this.textBoxUploadInfo.TabIndex = 0;
            // 
            // groupBoxTwitchSettings
            // 
            this.groupBoxTwitchSettings.Controls.Add(this.buttonChangeTwitchChannel);
            this.groupBoxTwitchSettings.Controls.Add(this.checkBoxFileSizeIgnore);
            this.groupBoxTwitchSettings.Controls.Add(this.checkBoxPostToTwitch);
            this.groupBoxTwitchSettings.Controls.Add(this.checkBoxWepSkill1);
            this.groupBoxTwitchSettings.Controls.Add(this.buttonReconnectBot);
            this.groupBoxTwitchSettings.Controls.Add(this.checkBoxUploadLogs);
            this.groupBoxTwitchSettings.Location = new System.Drawing.Point(426, 12);
            this.groupBoxTwitchSettings.Name = "groupBoxTwitchSettings";
            this.groupBoxTwitchSettings.Size = new System.Drawing.Size(200, 169);
            this.groupBoxTwitchSettings.TabIndex = 4;
            this.groupBoxTwitchSettings.TabStop = false;
            this.groupBoxTwitchSettings.Text = "Twitch settings";
            // 
            // checkBoxFileSizeIgnore
            // 
            this.checkBoxFileSizeIgnore.AutoSize = true;
            this.checkBoxFileSizeIgnore.Location = new System.Drawing.Point(6, 114);
            this.checkBoxFileSizeIgnore.Name = "checkBoxFileSizeIgnore";
            this.checkBoxFileSizeIgnore.Size = new System.Drawing.Size(147, 17);
            this.checkBoxFileSizeIgnore.TabIndex = 7;
            this.checkBoxFileSizeIgnore.Text = "ignore file size for uploads";
            this.checkBoxFileSizeIgnore.UseVisualStyleBackColor = true;
            // 
            // checkBoxPostToTwitch
            // 
            this.checkBoxPostToTwitch.AutoSize = true;
            this.checkBoxPostToTwitch.Enabled = false;
            this.checkBoxPostToTwitch.Location = new System.Drawing.Point(6, 68);
            this.checkBoxPostToTwitch.Name = "checkBoxPostToTwitch";
            this.checkBoxPostToTwitch.Size = new System.Drawing.Size(159, 17);
            this.checkBoxPostToTwitch.TabIndex = 6;
            this.checkBoxPostToTwitch.Text = "post links to the Twitch chat";
            this.checkBoxPostToTwitch.UseVisualStyleBackColor = true;
            // 
            // checkBoxWepSkill1
            // 
            this.checkBoxWepSkill1.AutoSize = true;
            this.checkBoxWepSkill1.Location = new System.Drawing.Point(6, 91);
            this.checkBoxWepSkill1.Name = "checkBoxWepSkill1";
            this.checkBoxWepSkill1.Size = new System.Drawing.Size(126, 17);
            this.checkBoxWepSkill1.TabIndex = 5;
            this.checkBoxWepSkill1.Text = "render weapon skill 1";
            this.checkBoxWepSkill1.UseVisualStyleBackColor = true;
            // 
            // buttonReconnectBot
            // 
            this.buttonReconnectBot.Location = new System.Drawing.Point(6, 137);
            this.buttonReconnectBot.Name = "buttonReconnectBot";
            this.buttonReconnectBot.Size = new System.Drawing.Size(188, 23);
            this.buttonReconnectBot.TabIndex = 4;
            this.buttonReconnectBot.Text = "Reconnect bot";
            this.buttonReconnectBot.UseVisualStyleBackColor = true;
            this.buttonReconnectBot.Click += new System.EventHandler(this.buttonReconnectBot_Click);
            // 
            // checkBoxUploadLogs
            // 
            this.checkBoxUploadLogs.AutoSize = true;
            this.checkBoxUploadLogs.Location = new System.Drawing.Point(6, 45);
            this.checkBoxUploadLogs.Name = "checkBoxUploadLogs";
            this.checkBoxUploadLogs.Size = new System.Drawing.Size(80, 17);
            this.checkBoxUploadLogs.TabIndex = 3;
            this.checkBoxUploadLogs.Text = "upload logs";
            this.checkBoxUploadLogs.UseVisualStyleBackColor = true;
            // 
            // groupBoxLogsDirectory
            // 
            this.groupBoxLogsDirectory.Controls.Add(this.labelLocationInfo);
            this.groupBoxLogsDirectory.Controls.Add(this.buttonLogsLocation);
            this.groupBoxLogsDirectory.Location = new System.Drawing.Point(426, 187);
            this.groupBoxLogsDirectory.Name = "groupBoxLogsDirectory";
            this.groupBoxLogsDirectory.Size = new System.Drawing.Size(200, 75);
            this.groupBoxLogsDirectory.TabIndex = 5;
            this.groupBoxLogsDirectory.TabStop = false;
            this.groupBoxLogsDirectory.Text = "Logs directory";
            // 
            // labelLocationInfo
            // 
            this.labelLocationInfo.Location = new System.Drawing.Point(6, 45);
            this.labelLocationInfo.Name = "labelLocationInfo";
            this.labelLocationInfo.Size = new System.Drawing.Size(188, 23);
            this.labelLocationInfo.TabIndex = 1;
            this.labelLocationInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonLogsLocation
            // 
            this.buttonLogsLocation.Location = new System.Drawing.Point(6, 19);
            this.buttonLogsLocation.Name = "buttonLogsLocation";
            this.buttonLogsLocation.Size = new System.Drawing.Size(188, 23);
            this.buttonLogsLocation.TabIndex = 0;
            this.buttonLogsLocation.Text = "Change logs directory";
            this.buttonLogsLocation.UseVisualStyleBackColor = true;
            this.buttonLogsLocation.Click += new System.EventHandler(this.buttonLogsLocation_Click);
            // 
            // groupBoxTrayIconSettings
            // 
            this.groupBoxTrayIconSettings.Controls.Add(this.checkBoxTrayNotification);
            this.groupBoxTrayIconSettings.Controls.Add(this.checkBoxTrayMinimiseToIcon);
            this.groupBoxTrayIconSettings.Controls.Add(this.checkBoxTrayEnable);
            this.groupBoxTrayIconSettings.Location = new System.Drawing.Point(426, 268);
            this.groupBoxTrayIconSettings.Name = "groupBoxTrayIconSettings";
            this.groupBoxTrayIconSettings.Size = new System.Drawing.Size(200, 89);
            this.groupBoxTrayIconSettings.TabIndex = 6;
            this.groupBoxTrayIconSettings.TabStop = false;
            this.groupBoxTrayIconSettings.Text = "Tray Icon settings";
            // 
            // checkBoxTrayNotification
            // 
            this.checkBoxTrayNotification.AutoSize = true;
            this.checkBoxTrayNotification.Enabled = false;
            this.checkBoxTrayNotification.Location = new System.Drawing.Point(6, 65);
            this.checkBoxTrayNotification.Name = "checkBoxTrayNotification";
            this.checkBoxTrayNotification.Size = new System.Drawing.Size(110, 17);
            this.checkBoxTrayNotification.TabIndex = 2;
            this.checkBoxTrayNotification.Text = "show notifications";
            this.checkBoxTrayNotification.UseVisualStyleBackColor = true;
            // 
            // checkBoxTrayMinimiseToIcon
            // 
            this.checkBoxTrayMinimiseToIcon.AutoSize = true;
            this.checkBoxTrayMinimiseToIcon.Enabled = false;
            this.checkBoxTrayMinimiseToIcon.Location = new System.Drawing.Point(6, 42);
            this.checkBoxTrayMinimiseToIcon.Name = "checkBoxTrayMinimiseToIcon";
            this.checkBoxTrayMinimiseToIcon.Size = new System.Drawing.Size(100, 17);
            this.checkBoxTrayMinimiseToIcon.TabIndex = 1;
            this.checkBoxTrayMinimiseToIcon.Text = "minimise to icon";
            this.checkBoxTrayMinimiseToIcon.UseVisualStyleBackColor = true;
            // 
            // checkBoxTrayEnable
            // 
            this.checkBoxTrayEnable.AutoSize = true;
            this.checkBoxTrayEnable.Location = new System.Drawing.Point(6, 19);
            this.checkBoxTrayEnable.Name = "checkBoxTrayEnable";
            this.checkBoxTrayEnable.Size = new System.Drawing.Size(148, 17);
            this.checkBoxTrayEnable.TabIndex = 0;
            this.checkBoxTrayEnable.Text = "enable icon in the taskbar";
            this.checkBoxTrayEnable.UseVisualStyleBackColor = true;
            // 
            // notifyIconTray
            // 
            this.notifyIconTray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconTray.Icon")));
            this.notifyIconTray.Text = "PlenBot Log Uploader";
            this.notifyIconTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconTray_MouseDoubleClick);
            // 
            // groupBoxOtherSettings
            // 
            this.groupBoxOtherSettings.Controls.Add(this.buttonPingSettings);
            this.groupBoxOtherSettings.Location = new System.Drawing.Point(426, 363);
            this.groupBoxOtherSettings.Name = "groupBoxOtherSettings";
            this.groupBoxOtherSettings.Size = new System.Drawing.Size(200, 49);
            this.groupBoxOtherSettings.TabIndex = 7;
            this.groupBoxOtherSettings.TabStop = false;
            this.groupBoxOtherSettings.Text = "Other settings";
            // 
            // buttonPingSettings
            // 
            this.buttonPingSettings.Location = new System.Drawing.Point(9, 19);
            this.buttonPingSettings.Name = "buttonPingSettings";
            this.buttonPingSettings.Size = new System.Drawing.Size(107, 23);
            this.buttonPingSettings.TabIndex = 0;
            this.buttonPingSettings.Text = "Remote server ping";
            this.buttonPingSettings.UseVisualStyleBackColor = true;
            this.buttonPingSettings.Click += new System.EventHandler(this.buttonPingSettings_Click);
            // 
            // buttonChangeTwitchChannel
            // 
            this.buttonChangeTwitchChannel.Location = new System.Drawing.Point(6, 16);
            this.buttonChangeTwitchChannel.Name = "buttonChangeTwitchChannel";
            this.buttonChangeTwitchChannel.Size = new System.Drawing.Size(188, 23);
            this.buttonChangeTwitchChannel.TabIndex = 8;
            this.buttonChangeTwitchChannel.Text = "Change Twitch channel";
            this.buttonChangeTwitchChannel.UseVisualStyleBackColor = true;
            this.buttonChangeTwitchChannel.Click += new System.EventHandler(this.buttonChangeTwitchChannel_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 418);
            this.Controls.Add(this.groupBoxOtherSettings);
            this.Controls.Add(this.groupBoxTrayIconSettings);
            this.Controls.Add(this.groupBoxLogsDirectory);
            this.Controls.Add(this.groupBoxTwitchSettings);
            this.Controls.Add(this.textBoxUploadInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlenBot Log Uploader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.groupBoxTwitchSettings.ResumeLayout(false);
            this.groupBoxTwitchSettings.PerformLayout();
            this.groupBoxLogsDirectory.ResumeLayout(false);
            this.groupBoxTrayIconSettings.ResumeLayout(false);
            this.groupBoxTrayIconSettings.PerformLayout();
            this.groupBoxOtherSettings.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxUploadInfo;
        private System.Windows.Forms.GroupBox groupBoxTwitchSettings;
        private System.Windows.Forms.CheckBox checkBoxUploadLogs;
        private System.Windows.Forms.Button buttonReconnectBot;
        private System.Windows.Forms.CheckBox checkBoxWepSkill1;
        private System.Windows.Forms.GroupBox groupBoxLogsDirectory;
        private System.Windows.Forms.Button buttonLogsLocation;
        private System.Windows.Forms.Label labelLocationInfo;
        private System.Windows.Forms.GroupBox groupBoxTrayIconSettings;
        private System.Windows.Forms.CheckBox checkBoxTrayNotification;
        private System.Windows.Forms.CheckBox checkBoxTrayMinimiseToIcon;
        private System.Windows.Forms.CheckBox checkBoxTrayEnable;
        private System.Windows.Forms.NotifyIcon notifyIconTray;
        private System.Windows.Forms.CheckBox checkBoxPostToTwitch;
        private System.Windows.Forms.GroupBox groupBoxOtherSettings;
        private System.Windows.Forms.Button buttonPingSettings;
        private System.Windows.Forms.CheckBox checkBoxFileSizeIgnore;
        private System.Windows.Forms.Button buttonChangeTwitchChannel;
    }
}

