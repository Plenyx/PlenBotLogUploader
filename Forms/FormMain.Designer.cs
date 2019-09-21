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
            this.groupBoxTwitchSettings = new System.Windows.Forms.GroupBox();
            this.buttonTwitchCommands = new System.Windows.Forms.Button();
            this.checkBoxTwitchOnlySuccess = new System.Windows.Forms.CheckBox();
            this.buttonDisConnectTwitch = new System.Windows.Forms.Button();
            this.buttonCustomName = new System.Windows.Forms.Button();
            this.buttonChangeTwitchChannel = new System.Windows.Forms.Button();
            this.checkBoxPostToTwitch = new System.Windows.Forms.CheckBox();
            this.buttonReconnectBot = new System.Windows.Forms.Button();
            this.buttonBossData = new System.Windows.Forms.Button();
            this.checkBoxFileSizeIgnore = new System.Windows.Forms.CheckBox();
            this.checkBoxUploadLogs = new System.Windows.Forms.CheckBox();
            this.groupBoxArcdpsLogs = new System.Windows.Forms.GroupBox();
            this.buttonSession = new System.Windows.Forms.Button();
            this.buttonOpenLogs = new System.Windows.Forms.Button();
            this.buttonDPSReportServer = new System.Windows.Forms.Button();
            this.labelLocationInfo = new System.Windows.Forms.Label();
            this.buttonLogsLocation = new System.Windows.Forms.Button();
            this.checkBoxTrayMinimiseToIcon = new System.Windows.Forms.CheckBox();
            this.notifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemUploadLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPostToTwitch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorFirst = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemOpenDPSReportServer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenCustomName = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenTwitchCommands = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenRaidarSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenArcVersionsSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorSecond = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDiscordWebhooks = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenPingSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorThird = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxOtherSettings = new System.Windows.Forms.GroupBox();
            this.comboBoxMaxUploads = new System.Windows.Forms.ComboBox();
            this.labelMaximumUploads = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.checkBoxStartWhenWindowsStarts = new System.Windows.Forms.CheckBox();
            this.buttonDiscordWebhooks = new System.Windows.Forms.Button();
            this.buttonArcVersionChecking = new System.Windows.Forms.Button();
            this.buttonRaidarSettings = new System.Windows.Forms.Button();
            this.buttonPingSettings = new System.Windows.Forms.Button();
            this.buttonUpdateNow = new System.Windows.Forms.Button();
            this.timerCheckUpdate = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.richTextBoxUploadInfo = new System.Windows.Forms.RichTextBox();
            this.groupBoxTwitchSettings.SuspendLayout();
            this.groupBoxArcdpsLogs.SuspendLayout();
            this.contextMenuStripIcon.SuspendLayout();
            this.groupBoxOtherSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTwitchSettings
            // 
            this.groupBoxTwitchSettings.Controls.Add(this.buttonTwitchCommands);
            this.groupBoxTwitchSettings.Controls.Add(this.checkBoxTwitchOnlySuccess);
            this.groupBoxTwitchSettings.Controls.Add(this.buttonDisConnectTwitch);
            this.groupBoxTwitchSettings.Controls.Add(this.buttonCustomName);
            this.groupBoxTwitchSettings.Controls.Add(this.buttonChangeTwitchChannel);
            this.groupBoxTwitchSettings.Controls.Add(this.checkBoxPostToTwitch);
            this.groupBoxTwitchSettings.Controls.Add(this.buttonReconnectBot);
            this.groupBoxTwitchSettings.Location = new System.Drawing.Point(426, 12);
            this.groupBoxTwitchSettings.Name = "groupBoxTwitchSettings";
            this.groupBoxTwitchSettings.Size = new System.Drawing.Size(200, 179);
            this.groupBoxTwitchSettings.TabIndex = 4;
            this.groupBoxTwitchSettings.TabStop = false;
            this.groupBoxTwitchSettings.Text = "Twitch settings";
            // 
            // buttonTwitchCommands
            // 
            this.buttonTwitchCommands.Location = new System.Drawing.Point(6, 120);
            this.buttonTwitchCommands.Name = "buttonTwitchCommands";
            this.buttonTwitchCommands.Size = new System.Drawing.Size(188, 23);
            this.buttonTwitchCommands.TabIndex = 12;
            this.buttonTwitchCommands.Text = "Twitch commands";
            this.buttonTwitchCommands.UseVisualStyleBackColor = true;
            this.buttonTwitchCommands.Click += new System.EventHandler(this.ButtonTwitchCommands_Click);
            // 
            // checkBoxTwitchOnlySuccess
            // 
            this.checkBoxTwitchOnlySuccess.AutoSize = true;
            this.checkBoxTwitchOnlySuccess.Enabled = false;
            this.checkBoxTwitchOnlySuccess.Location = new System.Drawing.Point(6, 68);
            this.checkBoxTwitchOnlySuccess.Name = "checkBoxTwitchOnlySuccess";
            this.checkBoxTwitchOnlySuccess.Size = new System.Drawing.Size(143, 17);
            this.checkBoxTwitchOnlySuccess.TabIndex = 11;
            this.checkBoxTwitchOnlySuccess.Text = "post only successful logs";
            this.checkBoxTwitchOnlySuccess.UseVisualStyleBackColor = true;
            // 
            // buttonDisConnectTwitch
            // 
            this.buttonDisConnectTwitch.Location = new System.Drawing.Point(6, 149);
            this.buttonDisConnectTwitch.Name = "buttonDisConnectTwitch";
            this.buttonDisConnectTwitch.Size = new System.Drawing.Size(188, 23);
            this.buttonDisConnectTwitch.TabIndex = 10;
            this.buttonDisConnectTwitch.Text = "Disconnect from Twitch";
            this.buttonDisConnectTwitch.UseVisualStyleBackColor = true;
            this.buttonDisConnectTwitch.Click += new System.EventHandler(this.buttonDisConnectTwitch_Click);
            // 
            // buttonCustomName
            // 
            this.buttonCustomName.Location = new System.Drawing.Point(6, 91);
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
            // checkBoxPostToTwitch
            // 
            this.checkBoxPostToTwitch.AutoSize = true;
            this.checkBoxPostToTwitch.Enabled = false;
            this.checkBoxPostToTwitch.Location = new System.Drawing.Point(6, 45);
            this.checkBoxPostToTwitch.Name = "checkBoxPostToTwitch";
            this.checkBoxPostToTwitch.Size = new System.Drawing.Size(159, 17);
            this.checkBoxPostToTwitch.TabIndex = 6;
            this.checkBoxPostToTwitch.Text = "post links to the Twitch chat";
            this.checkBoxPostToTwitch.UseVisualStyleBackColor = true;
            // 
            // buttonReconnectBot
            // 
            this.buttonReconnectBot.Location = new System.Drawing.Point(103, 91);
            this.buttonReconnectBot.Name = "buttonReconnectBot";
            this.buttonReconnectBot.Size = new System.Drawing.Size(91, 23);
            this.buttonReconnectBot.TabIndex = 4;
            this.buttonReconnectBot.Text = "Reconnect bot";
            this.buttonReconnectBot.UseVisualStyleBackColor = true;
            this.buttonReconnectBot.Click += new System.EventHandler(this.buttonReconnectBot_Click);
            // 
            // buttonBossData
            // 
            this.buttonBossData.Location = new System.Drawing.Point(111, 94);
            this.buttonBossData.Name = "buttonBossData";
            this.buttonBossData.Size = new System.Drawing.Size(83, 23);
            this.buttonBossData.TabIndex = 12;
            this.buttonBossData.Text = "Edit boss data";
            this.buttonBossData.UseVisualStyleBackColor = true;
            this.buttonBossData.Click += new System.EventHandler(this.buttonBossData_Click);
            // 
            // checkBoxFileSizeIgnore
            // 
            this.checkBoxFileSizeIgnore.AutoSize = true;
            this.checkBoxFileSizeIgnore.Location = new System.Drawing.Point(9, 42);
            this.checkBoxFileSizeIgnore.Name = "checkBoxFileSizeIgnore";
            this.checkBoxFileSizeIgnore.Size = new System.Drawing.Size(155, 17);
            this.checkBoxFileSizeIgnore.TabIndex = 7;
            this.checkBoxFileSizeIgnore.Text = "ignore file size limit of 12 kB";
            this.checkBoxFileSizeIgnore.UseVisualStyleBackColor = true;
            // 
            // checkBoxUploadLogs
            // 
            this.checkBoxUploadLogs.AutoSize = true;
            this.checkBoxUploadLogs.Location = new System.Drawing.Point(9, 19);
            this.checkBoxUploadLogs.Name = "checkBoxUploadLogs";
            this.checkBoxUploadLogs.Size = new System.Drawing.Size(80, 17);
            this.checkBoxUploadLogs.TabIndex = 3;
            this.checkBoxUploadLogs.Text = "upload logs";
            this.checkBoxUploadLogs.UseVisualStyleBackColor = true;
            // 
            // groupBoxArcdpsLogs
            // 
            this.groupBoxArcdpsLogs.Controls.Add(this.buttonSession);
            this.groupBoxArcdpsLogs.Controls.Add(this.buttonBossData);
            this.groupBoxArcdpsLogs.Controls.Add(this.buttonOpenLogs);
            this.groupBoxArcdpsLogs.Controls.Add(this.buttonDPSReportServer);
            this.groupBoxArcdpsLogs.Controls.Add(this.checkBoxFileSizeIgnore);
            this.groupBoxArcdpsLogs.Controls.Add(this.labelLocationInfo);
            this.groupBoxArcdpsLogs.Controls.Add(this.buttonLogsLocation);
            this.groupBoxArcdpsLogs.Controls.Add(this.checkBoxUploadLogs);
            this.groupBoxArcdpsLogs.Location = new System.Drawing.Point(426, 197);
            this.groupBoxArcdpsLogs.Name = "groupBoxArcdpsLogs";
            this.groupBoxArcdpsLogs.Size = new System.Drawing.Size(200, 179);
            this.groupBoxArcdpsLogs.TabIndex = 5;
            this.groupBoxArcdpsLogs.TabStop = false;
            this.groupBoxArcdpsLogs.Text = "arcdps logs and DPS.report";
            // 
            // buttonSession
            // 
            this.buttonSession.Location = new System.Drawing.Point(6, 65);
            this.buttonSession.Name = "buttonSession";
            this.buttonSession.Size = new System.Drawing.Size(188, 23);
            this.buttonSession.TabIndex = 13;
            this.buttonSession.Text = "Log sessions";
            this.buttonSession.UseVisualStyleBackColor = true;
            this.buttonSession.Click += new System.EventHandler(this.ButtonSession_Click);
            // 
            // buttonOpenLogs
            // 
            this.buttonOpenLogs.Enabled = false;
            this.buttonOpenLogs.Location = new System.Drawing.Point(138, 123);
            this.buttonOpenLogs.Name = "buttonOpenLogs";
            this.buttonOpenLogs.Size = new System.Drawing.Size(56, 23);
            this.buttonOpenLogs.TabIndex = 2;
            this.buttonOpenLogs.Text = "Open";
            this.buttonOpenLogs.UseVisualStyleBackColor = true;
            this.buttonOpenLogs.Click += new System.EventHandler(this.buttonOpenLogs_Click);
            // 
            // buttonDPSReportServer
            // 
            this.buttonDPSReportServer.Location = new System.Drawing.Point(6, 94);
            this.buttonDPSReportServer.Name = "buttonDPSReportServer";
            this.buttonDPSReportServer.Size = new System.Drawing.Size(99, 23);
            this.buttonDPSReportServer.TabIndex = 1;
            this.buttonDPSReportServer.Text = "DPS.report server";
            this.buttonDPSReportServer.UseVisualStyleBackColor = true;
            this.buttonDPSReportServer.Click += new System.EventHandler(this.buttonDPSReportServer_Click);
            // 
            // labelLocationInfo
            // 
            this.labelLocationInfo.Location = new System.Drawing.Point(6, 149);
            this.labelLocationInfo.Name = "labelLocationInfo";
            this.labelLocationInfo.Size = new System.Drawing.Size(188, 23);
            this.labelLocationInfo.TabIndex = 1;
            this.labelLocationInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonLogsLocation
            // 
            this.buttonLogsLocation.Location = new System.Drawing.Point(6, 123);
            this.buttonLogsLocation.Name = "buttonLogsLocation";
            this.buttonLogsLocation.Size = new System.Drawing.Size(126, 23);
            this.buttonLogsLocation.TabIndex = 0;
            this.buttonLogsLocation.Text = "Change logs directory";
            this.buttonLogsLocation.UseVisualStyleBackColor = true;
            this.buttonLogsLocation.Click += new System.EventHandler(this.buttonLogsLocation_Click);
            // 
            // checkBoxTrayMinimiseToIcon
            // 
            this.checkBoxTrayMinimiseToIcon.AutoSize = true;
            this.checkBoxTrayMinimiseToIcon.Location = new System.Drawing.Point(9, 19);
            this.checkBoxTrayMinimiseToIcon.Name = "checkBoxTrayMinimiseToIcon";
            this.checkBoxTrayMinimiseToIcon.Size = new System.Drawing.Size(120, 17);
            this.checkBoxTrayMinimiseToIcon.TabIndex = 0;
            this.checkBoxTrayMinimiseToIcon.Text = "minimise to tray icon";
            this.checkBoxTrayMinimiseToIcon.UseVisualStyleBackColor = true;
            // 
            // notifyIconTray
            // 
            this.notifyIconTray.ContextMenuStrip = this.contextMenuStripIcon;
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
            this.toolStripMenuItemOpenTwitchCommands,
            this.toolStripMenuItemOpenRaidarSettings,
            this.toolStripMenuItemOpenArcVersionsSettings,
            this.toolStripSeparatorSecond,
            this.toolStripMenuItemDiscordWebhooks,
            this.toolStripMenuItemOpenPingSettings,
            this.toolStripSeparatorThird,
            this.toolStripMenuItemExit});
            this.contextMenuStripIcon.Name = "contextMenuStripIcon";
            this.contextMenuStripIcon.Size = new System.Drawing.Size(278, 242);
            // 
            // toolStripMenuItemUploadLogs
            // 
            this.toolStripMenuItemUploadLogs.CheckOnClick = true;
            this.toolStripMenuItemUploadLogs.Name = "toolStripMenuItemUploadLogs";
            this.toolStripMenuItemUploadLogs.Size = new System.Drawing.Size(277, 22);
            this.toolStripMenuItemUploadLogs.Text = "upload logs";
            this.toolStripMenuItemUploadLogs.CheckedChanged += new System.EventHandler(this.toolStripMenuItemUploadLogs_CheckedChanged);
            // 
            // toolStripMenuItemPostToTwitch
            // 
            this.toolStripMenuItemPostToTwitch.CheckOnClick = true;
            this.toolStripMenuItemPostToTwitch.Name = "toolStripMenuItemPostToTwitch";
            this.toolStripMenuItemPostToTwitch.Size = new System.Drawing.Size(277, 22);
            this.toolStripMenuItemPostToTwitch.Text = "post links to Twitch chat";
            this.toolStripMenuItemPostToTwitch.CheckedChanged += new System.EventHandler(this.toolStripMenuItemPostToTwitch_CheckedChanged);
            // 
            // toolStripSeparatorFirst
            // 
            this.toolStripSeparatorFirst.Name = "toolStripSeparatorFirst";
            this.toolStripSeparatorFirst.Size = new System.Drawing.Size(274, 6);
            // 
            // toolStripMenuItemOpenDPSReportServer
            // 
            this.toolStripMenuItemOpenDPSReportServer.Name = "toolStripMenuItemOpenDPSReportServer";
            this.toolStripMenuItemOpenDPSReportServer.Size = new System.Drawing.Size(277, 22);
            this.toolStripMenuItemOpenDPSReportServer.Text = "Open DPS.report settings";
            this.toolStripMenuItemOpenDPSReportServer.Click += new System.EventHandler(this.toolStripMenuItemOpenDPSReportServer_Click);
            // 
            // toolStripMenuItemOpenCustomName
            // 
            this.toolStripMenuItemOpenCustomName.Name = "toolStripMenuItemOpenCustomName";
            this.toolStripMenuItemOpenCustomName.Size = new System.Drawing.Size(277, 22);
            this.toolStripMenuItemOpenCustomName.Text = "Open custom name settings";
            this.toolStripMenuItemOpenCustomName.Click += new System.EventHandler(this.toolStripMenuItemOpenCustomName_Click);
            // 
            // toolStripMenuItemOpenTwitchCommands
            // 
            this.toolStripMenuItemOpenTwitchCommands.Name = "toolStripMenuItemOpenTwitchCommands";
            this.toolStripMenuItemOpenTwitchCommands.Size = new System.Drawing.Size(277, 22);
            this.toolStripMenuItemOpenTwitchCommands.Text = "Open Twitch commands";
            this.toolStripMenuItemOpenTwitchCommands.Click += new System.EventHandler(this.ToolStripMenuItemOpenTwitchCommands_Click);
            // 
            // toolStripMenuItemOpenRaidarSettings
            // 
            this.toolStripMenuItemOpenRaidarSettings.Name = "toolStripMenuItemOpenRaidarSettings";
            this.toolStripMenuItemOpenRaidarSettings.Size = new System.Drawing.Size(277, 22);
            this.toolStripMenuItemOpenRaidarSettings.Text = "Open GW2Raidar settings";
            this.toolStripMenuItemOpenRaidarSettings.Click += new System.EventHandler(this.toolStripMenuItemOpenRaidarSettings_Click);
            // 
            // toolStripMenuItemOpenArcVersionsSettings
            // 
            this.toolStripMenuItemOpenArcVersionsSettings.Name = "toolStripMenuItemOpenArcVersionsSettings";
            this.toolStripMenuItemOpenArcVersionsSettings.Size = new System.Drawing.Size(277, 22);
            this.toolStripMenuItemOpenArcVersionsSettings.Text = "Open arcdps version checking settings";
            this.toolStripMenuItemOpenArcVersionsSettings.Click += new System.EventHandler(this.toolStripMenuItemOpenArcVersionsSettings_Click);
            // 
            // toolStripSeparatorSecond
            // 
            this.toolStripSeparatorSecond.Name = "toolStripSeparatorSecond";
            this.toolStripSeparatorSecond.Size = new System.Drawing.Size(274, 6);
            // 
            // toolStripMenuItemDiscordWebhooks
            // 
            this.toolStripMenuItemDiscordWebhooks.Name = "toolStripMenuItemDiscordWebhooks";
            this.toolStripMenuItemDiscordWebhooks.Size = new System.Drawing.Size(277, 22);
            this.toolStripMenuItemDiscordWebhooks.Text = "Discord webhooks";
            this.toolStripMenuItemDiscordWebhooks.Click += new System.EventHandler(this.toolStripMenuItemDiscordWebhooks_Click);
            // 
            // toolStripMenuItemOpenPingSettings
            // 
            this.toolStripMenuItemOpenPingSettings.Name = "toolStripMenuItemOpenPingSettings";
            this.toolStripMenuItemOpenPingSettings.Size = new System.Drawing.Size(277, 22);
            this.toolStripMenuItemOpenPingSettings.Text = "Remote server pings";
            this.toolStripMenuItemOpenPingSettings.Click += new System.EventHandler(this.toolStripMenuItemOpenPingSettings_Click);
            // 
            // toolStripSeparatorThird
            // 
            this.toolStripSeparatorThird.Name = "toolStripSeparatorThird";
            this.toolStripSeparatorThird.Size = new System.Drawing.Size(274, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(277, 22);
            this.toolStripMenuItemExit.Text = "Shutdown";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // groupBoxOtherSettings
            // 
            this.groupBoxOtherSettings.Controls.Add(this.comboBoxMaxUploads);
            this.groupBoxOtherSettings.Controls.Add(this.labelMaximumUploads);
            this.groupBoxOtherSettings.Controls.Add(this.buttonReset);
            this.groupBoxOtherSettings.Controls.Add(this.checkBoxStartWhenWindowsStarts);
            this.groupBoxOtherSettings.Controls.Add(this.buttonDiscordWebhooks);
            this.groupBoxOtherSettings.Controls.Add(this.buttonArcVersionChecking);
            this.groupBoxOtherSettings.Controls.Add(this.checkBoxTrayMinimiseToIcon);
            this.groupBoxOtherSettings.Controls.Add(this.buttonRaidarSettings);
            this.groupBoxOtherSettings.Controls.Add(this.buttonPingSettings);
            this.groupBoxOtherSettings.Location = new System.Drawing.Point(426, 382);
            this.groupBoxOtherSettings.Name = "groupBoxOtherSettings";
            this.groupBoxOtherSettings.Size = new System.Drawing.Size(200, 239);
            this.groupBoxOtherSettings.TabIndex = 7;
            this.groupBoxOtherSettings.TabStop = false;
            this.groupBoxOtherSettings.Text = "Other settings";
            // 
            // comboBoxMaxUploads
            // 
            this.comboBoxMaxUploads.FormattingEnabled = true;
            this.comboBoxMaxUploads.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBoxMaxUploads.Location = new System.Drawing.Point(133, 65);
            this.comboBoxMaxUploads.Name = "comboBoxMaxUploads";
            this.comboBoxMaxUploads.Size = new System.Drawing.Size(61, 21);
            this.comboBoxMaxUploads.TabIndex = 11;
            // 
            // labelMaximumUploads
            // 
            this.labelMaximumUploads.AutoSize = true;
            this.labelMaximumUploads.Location = new System.Drawing.Point(6, 68);
            this.labelMaximumUploads.Name = "labelMaximumUploads";
            this.labelMaximumUploads.Size = new System.Drawing.Size(121, 13);
            this.labelMaximumUploads.TabIndex = 10;
            this.labelMaximumUploads.Text = "Max concurrent uploads";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(6, 208);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(188, 23);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "Reset all settings";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // checkBoxStartWhenWindowsStarts
            // 
            this.checkBoxStartWhenWindowsStarts.AutoSize = true;
            this.checkBoxStartWhenWindowsStarts.Location = new System.Drawing.Point(9, 42);
            this.checkBoxStartWhenWindowsStarts.Name = "checkBoxStartWhenWindowsStarts";
            this.checkBoxStartWhenWindowsStarts.Size = new System.Drawing.Size(175, 17);
            this.checkBoxStartWhenWindowsStarts.TabIndex = 5;
            this.checkBoxStartWhenWindowsStarts.Text = "start uploader on system startup";
            this.checkBoxStartWhenWindowsStarts.UseVisualStyleBackColor = true;
            // 
            // buttonDiscordWebhooks
            // 
            this.buttonDiscordWebhooks.Location = new System.Drawing.Point(6, 92);
            this.buttonDiscordWebhooks.Name = "buttonDiscordWebhooks";
            this.buttonDiscordWebhooks.Size = new System.Drawing.Size(188, 23);
            this.buttonDiscordWebhooks.TabIndex = 4;
            this.buttonDiscordWebhooks.Text = "Discord webhooks";
            this.buttonDiscordWebhooks.UseVisualStyleBackColor = true;
            this.buttonDiscordWebhooks.Click += new System.EventHandler(this.buttonDiscordWebhooks_Click);
            // 
            // buttonArcVersionChecking
            // 
            this.buttonArcVersionChecking.Location = new System.Drawing.Point(6, 150);
            this.buttonArcVersionChecking.Name = "buttonArcVersionChecking";
            this.buttonArcVersionChecking.Size = new System.Drawing.Size(188, 23);
            this.buttonArcVersionChecking.TabIndex = 3;
            this.buttonArcVersionChecking.Text = "arcdps version checking settings";
            this.buttonArcVersionChecking.UseVisualStyleBackColor = true;
            this.buttonArcVersionChecking.Click += new System.EventHandler(this.buttonArcVersionChecking_Click);
            // 
            // buttonRaidarSettings
            // 
            this.buttonRaidarSettings.Location = new System.Drawing.Point(6, 121);
            this.buttonRaidarSettings.Name = "buttonRaidarSettings";
            this.buttonRaidarSettings.Size = new System.Drawing.Size(188, 23);
            this.buttonRaidarSettings.TabIndex = 2;
            this.buttonRaidarSettings.Text = "GW2Raidar settings";
            this.buttonRaidarSettings.UseVisualStyleBackColor = true;
            this.buttonRaidarSettings.Click += new System.EventHandler(this.buttonRaidarSettings_Click);
            // 
            // buttonPingSettings
            // 
            this.buttonPingSettings.Location = new System.Drawing.Point(6, 179);
            this.buttonPingSettings.Name = "buttonPingSettings";
            this.buttonPingSettings.Size = new System.Drawing.Size(188, 23);
            this.buttonPingSettings.TabIndex = 0;
            this.buttonPingSettings.Text = "Remote server pings";
            this.buttonPingSettings.UseVisualStyleBackColor = true;
            this.buttonPingSettings.Click += new System.EventHandler(this.buttonPingSettings_Click);
            // 
            // buttonUpdateNow
            // 
            this.buttonUpdateNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonUpdateNow.Location = new System.Drawing.Point(24, 572);
            this.buttonUpdateNow.Name = "buttonUpdateNow";
            this.buttonUpdateNow.Size = new System.Drawing.Size(112, 40);
            this.buttonUpdateNow.TabIndex = 8;
            this.buttonUpdateNow.Text = "Update the uploader";
            this.buttonUpdateNow.UseVisualStyleBackColor = true;
            this.buttonUpdateNow.Visible = false;
            this.buttonUpdateNow.Click += new System.EventHandler(this.buttonUpdateNow_Click);
            // 
            // timerCheckUpdate
            // 
            this.timerCheckUpdate.Interval = 5400000;
            this.timerCheckUpdate.Tick += new System.EventHandler(this.TimerCheckUpdate_Tick);
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            // 
            // richTextBoxUploadInfo
            // 
            this.richTextBoxUploadInfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBoxUploadInfo.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxUploadInfo.Name = "richTextBoxUploadInfo";
            this.richTextBoxUploadInfo.ReadOnly = true;
            this.richTextBoxUploadInfo.Size = new System.Drawing.Size(408, 609);
            this.richTextBoxUploadInfo.TabIndex = 9;
            this.richTextBoxUploadInfo.Text = "";
            this.richTextBoxUploadInfo.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RichTextBoxUploadInfo_LinkClicked);
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 629);
            this.Controls.Add(this.buttonUpdateNow);
            this.Controls.Add(this.groupBoxOtherSettings);
            this.Controls.Add(this.groupBoxArcdpsLogs);
            this.Controls.Add(this.groupBoxTwitchSettings);
            this.Controls.Add(this.richTextBoxUploadInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlenBot Log Uploader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.groupBoxTwitchSettings.ResumeLayout(false);
            this.groupBoxTwitchSettings.PerformLayout();
            this.groupBoxArcdpsLogs.ResumeLayout(false);
            this.groupBoxArcdpsLogs.PerformLayout();
            this.contextMenuStripIcon.ResumeLayout(false);
            this.groupBoxOtherSettings.ResumeLayout(false);
            this.groupBoxOtherSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxTwitchSettings;
        private System.Windows.Forms.CheckBox checkBoxUploadLogs;
        private System.Windows.Forms.Button buttonReconnectBot;
        private System.Windows.Forms.GroupBox groupBoxArcdpsLogs;
        private System.Windows.Forms.Button buttonLogsLocation;
        private System.Windows.Forms.Label labelLocationInfo;
        private System.Windows.Forms.NotifyIcon notifyIconTray;
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
        private System.Windows.Forms.Button buttonDisConnectTwitch;
        public System.Windows.Forms.CheckBox checkBoxPostToTwitch;
        private System.Windows.Forms.CheckBox checkBoxTwitchOnlySuccess;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenRaidarSettings;
        private System.Windows.Forms.Button buttonArcVersionChecking;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenArcVersionsSettings;
        private System.Windows.Forms.Button buttonBossData;
        private System.Windows.Forms.Button buttonDiscordWebhooks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorThird;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDiscordWebhooks;
        private System.Windows.Forms.Button buttonUpdateNow;
        private System.Windows.Forms.CheckBox checkBoxStartWhenWindowsStarts;
        private System.Windows.Forms.Timer timerCheckUpdate;
        private System.Windows.Forms.Button buttonTwitchCommands;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenTwitchCommands;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonSession;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.ComboBox comboBoxMaxUploads;
        private System.Windows.Forms.Label labelMaximumUploads;
        private System.Windows.Forms.RichTextBox richTextBoxUploadInfo;
    }
}

