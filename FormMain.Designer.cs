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
            this.buttonCustomName = new System.Windows.Forms.Button();
            this.buttonChangeTwitchChannel = new System.Windows.Forms.Button();
            this.checkBoxFileSizeIgnore = new System.Windows.Forms.CheckBox();
            this.checkBoxPostToTwitch = new System.Windows.Forms.CheckBox();
            this.checkBoxWepSkill1 = new System.Windows.Forms.CheckBox();
            this.buttonReconnectBot = new System.Windows.Forms.Button();
            this.checkBoxUploadLogs = new System.Windows.Forms.CheckBox();
            this.groupBoxArcdpsLogs = new System.Windows.Forms.GroupBox();
            this.buttonOpenLogs = new System.Windows.Forms.Button();
            this.labelLocationInfo = new System.Windows.Forms.Label();
            this.buttonLogsLocation = new System.Windows.Forms.Button();
            this.groupBoxTrayIconSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxTrayMinimiseToIcon = new System.Windows.Forms.CheckBox();
            this.notifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemUploadLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPostToTwitch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorFirst = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxOtherSettings = new System.Windows.Forms.GroupBox();
            this.buttonRaidarSettings = new System.Windows.Forms.Button();
            this.buttonDPSReportServer = new System.Windows.Forms.Button();
            this.buttonPingSettings = new System.Windows.Forms.Button();
            this.toolStripSeparatorSecond = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemOpenDPSReportServer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenPingSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenCustomName = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxTwitchSettings.SuspendLayout();
            this.groupBoxArcdpsLogs.SuspendLayout();
            this.groupBoxTrayIconSettings.SuspendLayout();
            this.contextMenuStripIcon.SuspendLayout();
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
            this.textBoxUploadInfo.Size = new System.Drawing.Size(408, 435);
            this.textBoxUploadInfo.TabIndex = 0;
            // 
            // groupBoxTwitchSettings
            // 
            this.groupBoxTwitchSettings.Controls.Add(this.buttonCustomName);
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
            // buttonCustomName
            // 
            this.buttonCustomName.Location = new System.Drawing.Point(6, 137);
            this.buttonCustomName.Name = "buttonCustomName";
            this.buttonCustomName.Size = new System.Drawing.Size(91, 23);
            this.buttonCustomName.TabIndex = 9;
            this.buttonCustomName.Text = "Custom name";
            this.buttonCustomName.UseVisualStyleBackColor = true;
            this.buttonCustomName.Click += new System.EventHandler(this.buttonCustomName_Click);
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
            this.buttonReconnectBot.Location = new System.Drawing.Point(103, 137);
            this.buttonReconnectBot.Name = "buttonReconnectBot";
            this.buttonReconnectBot.Size = new System.Drawing.Size(91, 23);
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
            // groupBoxArcdpsLogs
            // 
            this.groupBoxArcdpsLogs.Controls.Add(this.buttonOpenLogs);
            this.groupBoxArcdpsLogs.Controls.Add(this.buttonDPSReportServer);
            this.groupBoxArcdpsLogs.Controls.Add(this.labelLocationInfo);
            this.groupBoxArcdpsLogs.Controls.Add(this.buttonLogsLocation);
            this.groupBoxArcdpsLogs.Location = new System.Drawing.Point(426, 187);
            this.groupBoxArcdpsLogs.Name = "groupBoxArcdpsLogs";
            this.groupBoxArcdpsLogs.Size = new System.Drawing.Size(200, 99);
            this.groupBoxArcdpsLogs.TabIndex = 5;
            this.groupBoxArcdpsLogs.TabStop = false;
            this.groupBoxArcdpsLogs.Text = "arcdps logs and DPS.report";
            // 
            // buttonOpenLogs
            // 
            this.buttonOpenLogs.Enabled = false;
            this.buttonOpenLogs.Location = new System.Drawing.Point(138, 19);
            this.buttonOpenLogs.Name = "buttonOpenLogs";
            this.buttonOpenLogs.Size = new System.Drawing.Size(56, 23);
            this.buttonOpenLogs.TabIndex = 2;
            this.buttonOpenLogs.Text = "Open";
            this.buttonOpenLogs.UseVisualStyleBackColor = true;
            this.buttonOpenLogs.Click += new System.EventHandler(this.buttonOpenLogs_Click);
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
            this.buttonLogsLocation.Size = new System.Drawing.Size(126, 23);
            this.buttonLogsLocation.TabIndex = 0;
            this.buttonLogsLocation.Text = "Change logs directory";
            this.buttonLogsLocation.UseVisualStyleBackColor = true;
            this.buttonLogsLocation.Click += new System.EventHandler(this.buttonLogsLocation_Click);
            // 
            // groupBoxTrayIconSettings
            // 
            this.groupBoxTrayIconSettings.Controls.Add(this.checkBoxTrayMinimiseToIcon);
            this.groupBoxTrayIconSettings.Location = new System.Drawing.Point(426, 292);
            this.groupBoxTrayIconSettings.Name = "groupBoxTrayIconSettings";
            this.groupBoxTrayIconSettings.Size = new System.Drawing.Size(200, 43);
            this.groupBoxTrayIconSettings.TabIndex = 6;
            this.groupBoxTrayIconSettings.TabStop = false;
            this.groupBoxTrayIconSettings.Text = "Tray icon settings";
            // 
            // checkBoxTrayMinimiseToIcon
            // 
            this.checkBoxTrayMinimiseToIcon.AutoSize = true;
            this.checkBoxTrayMinimiseToIcon.Location = new System.Drawing.Point(9, 20);
            this.checkBoxTrayMinimiseToIcon.Name = "checkBoxTrayMinimiseToIcon";
            this.checkBoxTrayMinimiseToIcon.Size = new System.Drawing.Size(100, 17);
            this.checkBoxTrayMinimiseToIcon.TabIndex = 0;
            this.checkBoxTrayMinimiseToIcon.Text = "minimise to icon";
            this.checkBoxTrayMinimiseToIcon.UseVisualStyleBackColor = true;
            // 
            // notifyIconTray
            // 
            this.notifyIconTray.ContextMenuStrip = this.contextMenuStripIcon;
            this.notifyIconTray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconTray.Icon")));
            this.notifyIconTray.Text = "PlenBot Log Uploader";
            this.notifyIconTray.Visible = true;
            this.notifyIconTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconTray_MouseDoubleClick);
            // 
            // contextMenuStripIcon
            // 
            this.contextMenuStripIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemUploadLogs,
            this.toolStripMenuItemPostToTwitch,
            this.toolStripSeparatorFirst,
            this.toolStripMenuItemOpenDPSReportServer,
            this.toolStripMenuItemOpenCustomName,
            this.toolStripMenuItemOpenPingSettings,
            this.toolStripSeparatorSecond,
            this.toolStripMenuItemExit});
            this.contextMenuStripIcon.Name = "contextMenuStripIcon";
            this.contextMenuStripIcon.Size = new System.Drawing.Size(250, 170);
            // 
            // toolStripMenuItemUploadLogs
            // 
            this.toolStripMenuItemUploadLogs.CheckOnClick = true;
            this.toolStripMenuItemUploadLogs.Name = "toolStripMenuItemUploadLogs";
            this.toolStripMenuItemUploadLogs.Size = new System.Drawing.Size(249, 22);
            this.toolStripMenuItemUploadLogs.Text = "upload logs";
            this.toolStripMenuItemUploadLogs.CheckedChanged += new System.EventHandler(this.toolStripMenuItemUploadLogs_CheckedChanged);
            // 
            // toolStripMenuItemPostToTwitch
            // 
            this.toolStripMenuItemPostToTwitch.CheckOnClick = true;
            this.toolStripMenuItemPostToTwitch.Name = "toolStripMenuItemPostToTwitch";
            this.toolStripMenuItemPostToTwitch.Size = new System.Drawing.Size(249, 22);
            this.toolStripMenuItemPostToTwitch.Text = "post links to Twitch chat";
            this.toolStripMenuItemPostToTwitch.CheckedChanged += new System.EventHandler(this.toolStripMenuItemPostToTwitch_CheckedChanged);
            // 
            // toolStripSeparatorFirst
            // 
            this.toolStripSeparatorFirst.Name = "toolStripSeparatorFirst";
            this.toolStripSeparatorFirst.Size = new System.Drawing.Size(246, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(249, 22);
            this.toolStripMenuItemExit.Text = "Shutdown";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // groupBoxOtherSettings
            // 
            this.groupBoxOtherSettings.Controls.Add(this.buttonRaidarSettings);
            this.groupBoxOtherSettings.Controls.Add(this.buttonPingSettings);
            this.groupBoxOtherSettings.Location = new System.Drawing.Point(426, 341);
            this.groupBoxOtherSettings.Name = "groupBoxOtherSettings";
            this.groupBoxOtherSettings.Size = new System.Drawing.Size(200, 106);
            this.groupBoxOtherSettings.TabIndex = 7;
            this.groupBoxOtherSettings.TabStop = false;
            this.groupBoxOtherSettings.Text = "Other settings";
            // 
            // buttonRaidarSettings
            // 
            this.buttonRaidarSettings.Enabled = false;
            this.buttonRaidarSettings.Location = new System.Drawing.Point(6, 48);
            this.buttonRaidarSettings.Name = "buttonRaidarSettings";
            this.buttonRaidarSettings.Size = new System.Drawing.Size(188, 23);
            this.buttonRaidarSettings.TabIndex = 2;
            this.buttonRaidarSettings.Text = "GW2Raidar settings";
            this.buttonRaidarSettings.UseVisualStyleBackColor = true;
            this.buttonRaidarSettings.Click += new System.EventHandler(this.buttonRaidarSettings_Click);
            // 
            // buttonDPSReportServer
            // 
            this.buttonDPSReportServer.Location = new System.Drawing.Point(6, 71);
            this.buttonDPSReportServer.Name = "buttonDPSReportServer";
            this.buttonDPSReportServer.Size = new System.Drawing.Size(188, 23);
            this.buttonDPSReportServer.TabIndex = 1;
            this.buttonDPSReportServer.Text = "DPS.report server";
            this.buttonDPSReportServer.UseVisualStyleBackColor = true;
            this.buttonDPSReportServer.Click += new System.EventHandler(this.buttonDPSReportServer_Click);
            // 
            // buttonPingSettings
            // 
            this.buttonPingSettings.Location = new System.Drawing.Point(6, 19);
            this.buttonPingSettings.Name = "buttonPingSettings";
            this.buttonPingSettings.Size = new System.Drawing.Size(188, 23);
            this.buttonPingSettings.TabIndex = 0;
            this.buttonPingSettings.Text = "Remote server ping";
            this.buttonPingSettings.UseVisualStyleBackColor = true;
            this.buttonPingSettings.Click += new System.EventHandler(this.buttonPingSettings_Click);
            // 
            // toolStripSeparatorSecond
            // 
            this.toolStripSeparatorSecond.Name = "toolStripSeparatorSecond";
            this.toolStripSeparatorSecond.Size = new System.Drawing.Size(246, 6);
            // 
            // toolStripMenuItemOpenDPSReportServer
            // 
            this.toolStripMenuItemOpenDPSReportServer.Name = "toolStripMenuItemOpenDPSReportServer";
            this.toolStripMenuItemOpenDPSReportServer.Size = new System.Drawing.Size(249, 22);
            this.toolStripMenuItemOpenDPSReportServer.Text = "Open DPS.report settings";
            this.toolStripMenuItemOpenDPSReportServer.Click += new System.EventHandler(this.toolStripMenuItemOpenDPSReportServer_Click);
            // 
            // toolStripMenuItemOpenPingSettings
            // 
            this.toolStripMenuItemOpenPingSettings.Name = "toolStripMenuItemOpenPingSettings";
            this.toolStripMenuItemOpenPingSettings.Size = new System.Drawing.Size(249, 22);
            this.toolStripMenuItemOpenPingSettings.Text = "Open remote server ping settings";
            this.toolStripMenuItemOpenPingSettings.Click += new System.EventHandler(this.toolStripMenuItemOpenPingSettings_Click);
            // 
            // toolStripMenuItemOpenCustomName
            // 
            this.toolStripMenuItemOpenCustomName.Name = "toolStripMenuItemOpenCustomName";
            this.toolStripMenuItemOpenCustomName.Size = new System.Drawing.Size(249, 22);
            this.toolStripMenuItemOpenCustomName.Text = "Open custom name settings";
            this.toolStripMenuItemOpenCustomName.Click += new System.EventHandler(this.toolStripMenuItemOpenCustomName_Click);
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 452);
            this.Controls.Add(this.groupBoxOtherSettings);
            this.Controls.Add(this.groupBoxTrayIconSettings);
            this.Controls.Add(this.groupBoxArcdpsLogs);
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
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.groupBoxTwitchSettings.ResumeLayout(false);
            this.groupBoxTwitchSettings.PerformLayout();
            this.groupBoxArcdpsLogs.ResumeLayout(false);
            this.groupBoxTrayIconSettings.ResumeLayout(false);
            this.groupBoxTrayIconSettings.PerformLayout();
            this.contextMenuStripIcon.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBoxArcdpsLogs;
        private System.Windows.Forms.Button buttonLogsLocation;
        private System.Windows.Forms.Label labelLocationInfo;
        private System.Windows.Forms.GroupBox groupBoxTrayIconSettings;
        private System.Windows.Forms.NotifyIcon notifyIconTray;
        private System.Windows.Forms.CheckBox checkBoxPostToTwitch;
        private System.Windows.Forms.GroupBox groupBoxOtherSettings;
        private System.Windows.Forms.Button buttonPingSettings;
        private System.Windows.Forms.CheckBox checkBoxFileSizeIgnore;
        private System.Windows.Forms.Button buttonChangeTwitchChannel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripIcon;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUploadLogs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorFirst;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPostToTwitch;
        private System.Windows.Forms.Button buttonOpenLogs;
        private System.Windows.Forms.Button buttonCustomName;
        private System.Windows.Forms.Button buttonDPSReportServer;
        private System.Windows.Forms.Button buttonRaidarSettings;
        private System.Windows.Forms.CheckBox checkBoxTrayMinimiseToIcon;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenDPSReportServer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenCustomName;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenPingSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorSecond;
    }
}

