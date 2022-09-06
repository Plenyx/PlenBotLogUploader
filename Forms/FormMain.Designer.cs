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
            this.checkBoxUploadLogs = new System.Windows.Forms.CheckBox();
            this.groupBoxArcdpsLogs = new System.Windows.Forms.GroupBox();
            this.checkBoxSaveLogsToCSV = new System.Windows.Forms.CheckBox();
            this.checkBoxDetailedWvW = new System.Windows.Forms.CheckBox();
            this.checkBoxAnonymiseReports = new System.Windows.Forms.CheckBox();
            this.buttonCopyApplicationSession = new System.Windows.Forms.Button();
            this.buttonSession = new System.Windows.Forms.Button();
            this.buttonOpenLogs = new System.Windows.Forms.Button();
            this.buttonDPSReportServer = new System.Windows.Forms.Button();
            this.labelLocationInfo = new System.Windows.Forms.Label();
            this.buttonLogsLocation = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.checkBoxTrayMinimiseToIcon = new System.Windows.Forms.CheckBox();
            this.notifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemUploadLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPostToTwitch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorOne = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDPSReportUserTokens = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorTwo = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemOpenDPSReportServer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenCustomName = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenTwitchCommands = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenArcDpsPluginManager = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorThree = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDiscordWebhooks = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenPingSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorFour = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxOtherSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxAutoUpdate = new System.Windows.Forms.CheckBox();
            this.buttonTeamsSettings = new System.Windows.Forms.Button();
            this.buttonGW2BotSettings = new System.Windows.Forms.Button();
            this.buttonAleevaSettings = new System.Windows.Forms.Button();
            this.buttonGW2API = new System.Windows.Forms.Button();
            this.comboBoxMaxUploads = new System.Windows.Forms.ComboBox();
            this.labelMaximumUploads = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.checkBoxStartWhenWindowsStarts = new System.Windows.Forms.CheckBox();
            this.buttonDiscordWebhooks = new System.Windows.Forms.Button();
            this.buttonArcDpsPluginManager = new System.Windows.Forms.Button();
            this.buttonPingSettings = new System.Windows.Forms.Button();
            this.timerCheckUpdate = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.richTextBoxMainConsole = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanelMainForm = new System.Windows.Forms.TableLayoutPanel();
            this.timerResizeSave = new System.Windows.Forms.Timer(this.components);
            this.groupBoxTwitchSettings.SuspendLayout();
            this.groupBoxArcdpsLogs.SuspendLayout();
            this.contextMenuStripIcon.SuspendLayout();
            this.groupBoxOtherSettings.SuspendLayout();
            this.tableLayoutPanelMainForm.SuspendLayout();
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
            this.groupBoxTwitchSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTwitchSettings.Location = new System.Drawing.Point(573, 4);
            this.groupBoxTwitchSettings.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxTwitchSettings.Name = "groupBoxTwitchSettings";
            this.groupBoxTwitchSettings.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxTwitchSettings.Size = new System.Drawing.Size(267, 220);
            this.groupBoxTwitchSettings.TabIndex = 4;
            this.groupBoxTwitchSettings.TabStop = false;
            this.groupBoxTwitchSettings.Text = "Twitch settings";
            // 
            // buttonTwitchCommands
            // 
            this.buttonTwitchCommands.Location = new System.Drawing.Point(8, 148);
            this.buttonTwitchCommands.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTwitchCommands.Name = "buttonTwitchCommands";
            this.buttonTwitchCommands.Size = new System.Drawing.Size(251, 28);
            this.buttonTwitchCommands.TabIndex = 12;
            this.buttonTwitchCommands.Text = "Twitch commands";
            this.buttonTwitchCommands.UseVisualStyleBackColor = true;
            this.buttonTwitchCommands.Click += new System.EventHandler(this.ButtonTwitchCommands_Click);
            // 
            // checkBoxTwitchOnlySuccess
            // 
            this.checkBoxTwitchOnlySuccess.AutoSize = true;
            this.checkBoxTwitchOnlySuccess.Enabled = false;
            this.checkBoxTwitchOnlySuccess.Location = new System.Drawing.Point(8, 84);
            this.checkBoxTwitchOnlySuccess.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxTwitchOnlySuccess.Name = "checkBoxTwitchOnlySuccess";
            this.checkBoxTwitchOnlySuccess.Size = new System.Drawing.Size(178, 20);
            this.checkBoxTwitchOnlySuccess.TabIndex = 11;
            this.checkBoxTwitchOnlySuccess.Text = "post only successful logs";
            this.checkBoxTwitchOnlySuccess.UseVisualStyleBackColor = true;
            // 
            // buttonDisConnectTwitch
            // 
            this.buttonDisConnectTwitch.Location = new System.Drawing.Point(8, 183);
            this.buttonDisConnectTwitch.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDisConnectTwitch.Name = "buttonDisConnectTwitch";
            this.buttonDisConnectTwitch.Size = new System.Drawing.Size(251, 28);
            this.buttonDisConnectTwitch.TabIndex = 10;
            this.buttonDisConnectTwitch.Text = "Disconnect from Twitch";
            this.buttonDisConnectTwitch.UseVisualStyleBackColor = true;
            this.buttonDisConnectTwitch.Click += new System.EventHandler(this.ButtonDisConnectTwitch_Click);
            // 
            // buttonCustomName
            // 
            this.buttonCustomName.Location = new System.Drawing.Point(8, 112);
            this.buttonCustomName.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCustomName.Name = "buttonCustomName";
            this.buttonCustomName.Size = new System.Drawing.Size(121, 28);
            this.buttonCustomName.TabIndex = 9;
            this.buttonCustomName.Text = "Custom name";
            this.buttonCustomName.UseVisualStyleBackColor = true;
            this.buttonCustomName.Click += new System.EventHandler(this.ButtonCustomName_Click);
            // 
            // buttonChangeTwitchChannel
            // 
            this.buttonChangeTwitchChannel.Location = new System.Drawing.Point(8, 20);
            this.buttonChangeTwitchChannel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonChangeTwitchChannel.Name = "buttonChangeTwitchChannel";
            this.buttonChangeTwitchChannel.Size = new System.Drawing.Size(251, 28);
            this.buttonChangeTwitchChannel.TabIndex = 8;
            this.buttonChangeTwitchChannel.Text = "Change Twitch channel";
            this.buttonChangeTwitchChannel.UseVisualStyleBackColor = true;
            this.buttonChangeTwitchChannel.Click += new System.EventHandler(this.ButtonChangeTwitchChannel_Click);
            // 
            // checkBoxPostToTwitch
            // 
            this.checkBoxPostToTwitch.AutoSize = true;
            this.checkBoxPostToTwitch.Enabled = false;
            this.checkBoxPostToTwitch.Location = new System.Drawing.Point(8, 55);
            this.checkBoxPostToTwitch.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxPostToTwitch.Name = "checkBoxPostToTwitch";
            this.checkBoxPostToTwitch.Size = new System.Drawing.Size(189, 20);
            this.checkBoxPostToTwitch.TabIndex = 6;
            this.checkBoxPostToTwitch.Text = "post links to the Twitch chat";
            this.checkBoxPostToTwitch.UseVisualStyleBackColor = true;
            // 
            // buttonReconnectBot
            // 
            this.buttonReconnectBot.Location = new System.Drawing.Point(137, 112);
            this.buttonReconnectBot.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReconnectBot.Name = "buttonReconnectBot";
            this.buttonReconnectBot.Size = new System.Drawing.Size(121, 28);
            this.buttonReconnectBot.TabIndex = 4;
            this.buttonReconnectBot.Text = "Reconnect bot";
            this.buttonReconnectBot.UseVisualStyleBackColor = true;
            this.buttonReconnectBot.Click += new System.EventHandler(this.ButtonReconnectBot_Click);
            // 
            // buttonBossData
            // 
            this.buttonBossData.Location = new System.Drawing.Point(148, 137);
            this.buttonBossData.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBossData.Name = "buttonBossData";
            this.buttonBossData.Size = new System.Drawing.Size(111, 28);
            this.buttonBossData.TabIndex = 12;
            this.buttonBossData.Text = "Edit boss data";
            this.buttonBossData.UseVisualStyleBackColor = true;
            this.buttonBossData.Click += new System.EventHandler(this.ButtonBossData_Click);
            // 
            // checkBoxUploadLogs
            // 
            this.checkBoxUploadLogs.AutoSize = true;
            this.checkBoxUploadLogs.Location = new System.Drawing.Point(12, 23);
            this.checkBoxUploadLogs.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxUploadLogs.Name = "checkBoxUploadLogs";
            this.checkBoxUploadLogs.Size = new System.Drawing.Size(100, 20);
            this.checkBoxUploadLogs.TabIndex = 3;
            this.checkBoxUploadLogs.Text = "upload logs";
            this.checkBoxUploadLogs.UseVisualStyleBackColor = true;
            // 
            // groupBoxArcdpsLogs
            // 
            this.groupBoxArcdpsLogs.Controls.Add(this.checkBoxSaveLogsToCSV);
            this.groupBoxArcdpsLogs.Controls.Add(this.checkBoxDetailedWvW);
            this.groupBoxArcdpsLogs.Controls.Add(this.checkBoxAnonymiseReports);
            this.groupBoxArcdpsLogs.Controls.Add(this.buttonCopyApplicationSession);
            this.groupBoxArcdpsLogs.Controls.Add(this.buttonSession);
            this.groupBoxArcdpsLogs.Controls.Add(this.buttonBossData);
            this.groupBoxArcdpsLogs.Controls.Add(this.buttonOpenLogs);
            this.groupBoxArcdpsLogs.Controls.Add(this.buttonDPSReportServer);
            this.groupBoxArcdpsLogs.Controls.Add(this.labelLocationInfo);
            this.groupBoxArcdpsLogs.Controls.Add(this.buttonLogsLocation);
            this.groupBoxArcdpsLogs.Controls.Add(this.checkBoxUploadLogs);
            this.groupBoxArcdpsLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxArcdpsLogs.Location = new System.Drawing.Point(573, 232);
            this.groupBoxArcdpsLogs.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxArcdpsLogs.Name = "groupBoxArcdpsLogs";
            this.groupBoxArcdpsLogs.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxArcdpsLogs.Size = new System.Drawing.Size(267, 273);
            this.groupBoxArcdpsLogs.TabIndex = 5;
            this.groupBoxArcdpsLogs.TabStop = false;
            this.groupBoxArcdpsLogs.Text = "arcdps logs and DPS.report";
            // 
            // checkBoxSaveLogsToCSV
            // 
            this.checkBoxSaveLogsToCSV.AutoSize = true;
            this.checkBoxSaveLogsToCSV.Location = new System.Drawing.Point(12, 108);
            this.checkBoxSaveLogsToCSV.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxSaveLogsToCSV.Name = "checkBoxSaveLogsToCSV";
            this.checkBoxSaveLogsToCSV.Size = new System.Drawing.Size(163, 20);
            this.checkBoxSaveLogsToCSV.TabIndex = 17;
            this.checkBoxSaveLogsToCSV.Text = "save logs to a CSV file";
            this.checkBoxSaveLogsToCSV.UseVisualStyleBackColor = true;
            // 
            // checkBoxDetailedWvW
            // 
            this.checkBoxDetailedWvW.AutoSize = true;
            this.checkBoxDetailedWvW.Location = new System.Drawing.Point(12, 80);
            this.checkBoxDetailedWvW.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxDetailedWvW.Name = "checkBoxDetailedWvW";
            this.checkBoxDetailedWvW.Size = new System.Drawing.Size(159, 20);
            this.checkBoxDetailedWvW.TabIndex = 16;
            this.checkBoxDetailedWvW.Text = "detailed WvW reports";
            this.checkBoxDetailedWvW.UseVisualStyleBackColor = true;
            // 
            // checkBoxAnonymiseReports
            // 
            this.checkBoxAnonymiseReports.AutoSize = true;
            this.checkBoxAnonymiseReports.Location = new System.Drawing.Point(12, 52);
            this.checkBoxAnonymiseReports.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxAnonymiseReports.Name = "checkBoxAnonymiseReports";
            this.checkBoxAnonymiseReports.Size = new System.Drawing.Size(140, 20);
            this.checkBoxAnonymiseReports.TabIndex = 15;
            this.checkBoxAnonymiseReports.Text = "anonymise reports";
            this.checkBoxAnonymiseReports.UseVisualStyleBackColor = true;
            // 
            // buttonCopyApplicationSession
            // 
            this.buttonCopyApplicationSession.Location = new System.Drawing.Point(161, 172);
            this.buttonCopyApplicationSession.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCopyApplicationSession.Name = "buttonCopyApplicationSession";
            this.buttonCopyApplicationSession.Size = new System.Drawing.Size(97, 28);
            this.buttonCopyApplicationSession.TabIndex = 14;
            this.buttonCopyApplicationSession.Text = "Copy to clip.";
            this.buttonCopyApplicationSession.UseVisualStyleBackColor = true;
            this.buttonCopyApplicationSession.Click += new System.EventHandler(this.ButtonCopyApplicationSession_Click);
            // 
            // buttonSession
            // 
            this.buttonSession.Location = new System.Drawing.Point(8, 137);
            this.buttonSession.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSession.Name = "buttonSession";
            this.buttonSession.Size = new System.Drawing.Size(132, 28);
            this.buttonSession.TabIndex = 13;
            this.buttonSession.Text = "Log sessions";
            this.buttonSession.UseVisualStyleBackColor = true;
            this.buttonSession.Click += new System.EventHandler(this.ButtonSession_Click);
            // 
            // buttonOpenLogs
            // 
            this.buttonOpenLogs.Enabled = false;
            this.buttonOpenLogs.Location = new System.Drawing.Point(184, 208);
            this.buttonOpenLogs.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenLogs.Name = "buttonOpenLogs";
            this.buttonOpenLogs.Size = new System.Drawing.Size(75, 28);
            this.buttonOpenLogs.TabIndex = 2;
            this.buttonOpenLogs.Text = "Open";
            this.buttonOpenLogs.UseVisualStyleBackColor = true;
            this.buttonOpenLogs.Click += new System.EventHandler(this.ButtonOpenLogs_Click);
            // 
            // buttonDPSReportServer
            // 
            this.buttonDPSReportServer.Location = new System.Drawing.Point(8, 172);
            this.buttonDPSReportServer.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDPSReportServer.Name = "buttonDPSReportServer";
            this.buttonDPSReportServer.Size = new System.Drawing.Size(145, 28);
            this.buttonDPSReportServer.TabIndex = 1;
            this.buttonDPSReportServer.Text = "DPS.report settings";
            this.buttonDPSReportServer.UseVisualStyleBackColor = true;
            this.buttonDPSReportServer.Click += new System.EventHandler(this.ButtonDPSReportServer_Click);
            // 
            // labelLocationInfo
            // 
            this.labelLocationInfo.Location = new System.Drawing.Point(8, 240);
            this.labelLocationInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLocationInfo.Name = "labelLocationInfo";
            this.labelLocationInfo.Size = new System.Drawing.Size(251, 28);
            this.labelLocationInfo.TabIndex = 1;
            this.labelLocationInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonLogsLocation
            // 
            this.buttonLogsLocation.Location = new System.Drawing.Point(8, 208);
            this.buttonLogsLocation.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogsLocation.Name = "buttonLogsLocation";
            this.buttonLogsLocation.Size = new System.Drawing.Size(168, 28);
            this.buttonLogsLocation.TabIndex = 0;
            this.buttonLogsLocation.Text = "Change logs directory";
            this.buttonLogsLocation.UseVisualStyleBackColor = true;
            this.buttonLogsLocation.Click += new System.EventHandler(this.ButtonLogsLocation_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonUpdate.Location = new System.Drawing.Point(7, 419);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(251, 28);
            this.buttonUpdate.TabIndex = 8;
            this.buttonUpdate.Text = "Check for updates";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpdateNow_Click);
            // 
            // checkBoxTrayMinimiseToIcon
            // 
            this.checkBoxTrayMinimiseToIcon.AutoSize = true;
            this.checkBoxTrayMinimiseToIcon.Location = new System.Drawing.Point(12, 23);
            this.checkBoxTrayMinimiseToIcon.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxTrayMinimiseToIcon.Name = "checkBoxTrayMinimiseToIcon";
            this.checkBoxTrayMinimiseToIcon.Size = new System.Drawing.Size(149, 20);
            this.checkBoxTrayMinimiseToIcon.TabIndex = 0;
            this.checkBoxTrayMinimiseToIcon.Text = "minimise to tray icon";
            this.checkBoxTrayMinimiseToIcon.UseVisualStyleBackColor = true;
            // 
            // notifyIconTray
            // 
            this.notifyIconTray.ContextMenuStrip = this.contextMenuStripIcon;
            this.notifyIconTray.Text = "PlenBot Log Uploader";
            this.notifyIconTray.Visible = true;
            this.notifyIconTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIconTray_MouseDoubleClick);
            // 
            // contextMenuStripIcon
            // 
            this.contextMenuStripIcon.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemUploadLogs,
            this.toolStripMenuItemPostToTwitch,
            this.toolStripSeparatorOne,
            this.toolStripMenuItemDPSReportUserTokens,
            this.toolStripSeparatorTwo,
            this.toolStripMenuItemOpenDPSReportServer,
            this.toolStripMenuItemOpenCustomName,
            this.toolStripMenuItemOpenTwitchCommands,
            this.toolStripMenuItemOpenArcDpsPluginManager,
            this.toolStripSeparatorThree,
            this.toolStripMenuItemDiscordWebhooks,
            this.toolStripMenuItemOpenPingSettings,
            this.toolStripSeparatorFour,
            this.toolStripMenuItemExit});
            this.contextMenuStripIcon.Name = "contextMenuStripIcon";
            this.contextMenuStripIcon.Size = new System.Drawing.Size(272, 296);
            // 
            // toolStripMenuItemUploadLogs
            // 
            this.toolStripMenuItemUploadLogs.CheckOnClick = true;
            this.toolStripMenuItemUploadLogs.Name = "toolStripMenuItemUploadLogs";
            this.toolStripMenuItemUploadLogs.Size = new System.Drawing.Size(271, 24);
            this.toolStripMenuItemUploadLogs.Text = "upload logs";
            this.toolStripMenuItemUploadLogs.CheckedChanged += new System.EventHandler(this.ToolStripMenuItemUploadLogs_CheckedChanged);
            // 
            // toolStripMenuItemPostToTwitch
            // 
            this.toolStripMenuItemPostToTwitch.CheckOnClick = true;
            this.toolStripMenuItemPostToTwitch.Name = "toolStripMenuItemPostToTwitch";
            this.toolStripMenuItemPostToTwitch.Size = new System.Drawing.Size(271, 24);
            this.toolStripMenuItemPostToTwitch.Text = "post links to Twitch chat";
            this.toolStripMenuItemPostToTwitch.CheckedChanged += new System.EventHandler(this.ToolStripMenuItemPostToTwitch_CheckedChanged);
            // 
            // toolStripSeparatorOne
            // 
            this.toolStripSeparatorOne.Name = "toolStripSeparatorOne";
            this.toolStripSeparatorOne.Size = new System.Drawing.Size(268, 6);
            // 
            // toolStripMenuItemDPSReportUserTokens
            // 
            this.toolStripMenuItemDPSReportUserTokens.Name = "toolStripMenuItemDPSReportUserTokens";
            this.toolStripMenuItemDPSReportUserTokens.Size = new System.Drawing.Size(271, 24);
            this.toolStripMenuItemDPSReportUserTokens.Text = "DPS.report user token";
            // 
            // toolStripSeparatorTwo
            // 
            this.toolStripSeparatorTwo.Name = "toolStripSeparatorTwo";
            this.toolStripSeparatorTwo.Size = new System.Drawing.Size(268, 6);
            // 
            // toolStripMenuItemOpenDPSReportServer
            // 
            this.toolStripMenuItemOpenDPSReportServer.Name = "toolStripMenuItemOpenDPSReportServer";
            this.toolStripMenuItemOpenDPSReportServer.Size = new System.Drawing.Size(271, 24);
            this.toolStripMenuItemOpenDPSReportServer.Text = "Open DPS.report settings";
            this.toolStripMenuItemOpenDPSReportServer.Click += new System.EventHandler(this.ToolStripMenuItemOpenDPSReportServer_Click);
            // 
            // toolStripMenuItemOpenCustomName
            // 
            this.toolStripMenuItemOpenCustomName.Name = "toolStripMenuItemOpenCustomName";
            this.toolStripMenuItemOpenCustomName.Size = new System.Drawing.Size(271, 24);
            this.toolStripMenuItemOpenCustomName.Text = "Open custom name settings";
            this.toolStripMenuItemOpenCustomName.Click += new System.EventHandler(this.ToolStripMenuItemOpenCustomName_Click);
            // 
            // toolStripMenuItemOpenTwitchCommands
            // 
            this.toolStripMenuItemOpenTwitchCommands.Name = "toolStripMenuItemOpenTwitchCommands";
            this.toolStripMenuItemOpenTwitchCommands.Size = new System.Drawing.Size(271, 24);
            this.toolStripMenuItemOpenTwitchCommands.Text = "Open Twitch commands";
            this.toolStripMenuItemOpenTwitchCommands.Click += new System.EventHandler(this.ToolStripMenuItemOpenTwitchCommands_Click);
            // 
            // toolStripMenuItemOpenArcDpsPluginManager
            // 
            this.toolStripMenuItemOpenArcDpsPluginManager.Name = "toolStripMenuItemOpenArcDpsPluginManager";
            this.toolStripMenuItemOpenArcDpsPluginManager.Size = new System.Drawing.Size(271, 24);
            this.toolStripMenuItemOpenArcDpsPluginManager.Text = "Open arcdps plugin manager";
            this.toolStripMenuItemOpenArcDpsPluginManager.Click += new System.EventHandler(this.ToolStripMenuItemOpenArcDpsPluginManager_Click);
            // 
            // toolStripSeparatorThree
            // 
            this.toolStripSeparatorThree.Name = "toolStripSeparatorThree";
            this.toolStripSeparatorThree.Size = new System.Drawing.Size(268, 6);
            // 
            // toolStripMenuItemDiscordWebhooks
            // 
            this.toolStripMenuItemDiscordWebhooks.Name = "toolStripMenuItemDiscordWebhooks";
            this.toolStripMenuItemDiscordWebhooks.Size = new System.Drawing.Size(271, 24);
            this.toolStripMenuItemDiscordWebhooks.Text = "Discord webhooks";
            this.toolStripMenuItemDiscordWebhooks.Click += new System.EventHandler(this.ToolStripMenuItemDiscordWebhooks_Click);
            // 
            // toolStripMenuItemOpenPingSettings
            // 
            this.toolStripMenuItemOpenPingSettings.Name = "toolStripMenuItemOpenPingSettings";
            this.toolStripMenuItemOpenPingSettings.Size = new System.Drawing.Size(271, 24);
            this.toolStripMenuItemOpenPingSettings.Text = "Remote server pings";
            this.toolStripMenuItemOpenPingSettings.Click += new System.EventHandler(this.ToolStripMenuItemOpenPingSettings_Click);
            // 
            // toolStripSeparatorFour
            // 
            this.toolStripSeparatorFour.Name = "toolStripSeparatorFour";
            this.toolStripSeparatorFour.Size = new System.Drawing.Size(268, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(271, 24);
            this.toolStripMenuItemExit.Text = "Shutdown";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // groupBoxOtherSettings
            // 
            this.groupBoxOtherSettings.Controls.Add(this.checkBoxAutoUpdate);
            this.groupBoxOtherSettings.Controls.Add(this.buttonTeamsSettings);
            this.groupBoxOtherSettings.Controls.Add(this.buttonGW2BotSettings);
            this.groupBoxOtherSettings.Controls.Add(this.buttonAleevaSettings);
            this.groupBoxOtherSettings.Controls.Add(this.buttonGW2API);
            this.groupBoxOtherSettings.Controls.Add(this.buttonUpdate);
            this.groupBoxOtherSettings.Controls.Add(this.comboBoxMaxUploads);
            this.groupBoxOtherSettings.Controls.Add(this.labelMaximumUploads);
            this.groupBoxOtherSettings.Controls.Add(this.buttonReset);
            this.groupBoxOtherSettings.Controls.Add(this.checkBoxStartWhenWindowsStarts);
            this.groupBoxOtherSettings.Controls.Add(this.buttonDiscordWebhooks);
            this.groupBoxOtherSettings.Controls.Add(this.buttonArcDpsPluginManager);
            this.groupBoxOtherSettings.Controls.Add(this.checkBoxTrayMinimiseToIcon);
            this.groupBoxOtherSettings.Controls.Add(this.buttonPingSettings);
            this.groupBoxOtherSettings.Location = new System.Drawing.Point(573, 513);
            this.groupBoxOtherSettings.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxOtherSettings.Name = "groupBoxOtherSettings";
            this.groupBoxOtherSettings.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxOtherSettings.Size = new System.Drawing.Size(267, 455);
            this.groupBoxOtherSettings.TabIndex = 7;
            this.groupBoxOtherSettings.TabStop = false;
            this.groupBoxOtherSettings.Text = "Other settings";
            // 
            // checkBoxAutoUpdate
            // 
            this.checkBoxAutoUpdate.AutoSize = true;
            this.checkBoxAutoUpdate.Location = new System.Drawing.Point(7, 394);
            this.checkBoxAutoUpdate.Name = "checkBoxAutoUpdate";
            this.checkBoxAutoUpdate.Size = new System.Drawing.Size(231, 20);
            this.checkBoxAutoUpdate.TabIndex = 16;
            this.checkBoxAutoUpdate.Text = "automatically update the uploader";
            this.checkBoxAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonTeamsSettings
            // 
            this.buttonTeamsSettings.Location = new System.Drawing.Point(8, 221);
            this.buttonTeamsSettings.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTeamsSettings.Name = "buttonTeamsSettings";
            this.buttonTeamsSettings.Size = new System.Drawing.Size(251, 28);
            this.buttonTeamsSettings.TabIndex = 15;
            this.buttonTeamsSettings.Text = "Setup Teams";
            this.buttonTeamsSettings.UseVisualStyleBackColor = true;
            this.buttonTeamsSettings.Click += new System.EventHandler(this.ButtonTeamsSettings_Click);
            // 
            // buttonGW2BotSettings
            // 
            this.buttonGW2BotSettings.Image = global::PlenBotLogUploader.Properties.Resources.gw2bot_icon16;
            this.buttonGW2BotSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGW2BotSettings.Location = new System.Drawing.Point(8, 185);
            this.buttonGW2BotSettings.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGW2BotSettings.Name = "buttonGW2BotSettings";
            this.buttonGW2BotSettings.Size = new System.Drawing.Size(251, 28);
            this.buttonGW2BotSettings.TabIndex = 14;
            this.buttonGW2BotSettings.Text = "GW2Bot integration";
            this.buttonGW2BotSettings.UseVisualStyleBackColor = true;
            this.buttonGW2BotSettings.Click += new System.EventHandler(this.ButtonGW2BotSettings_Click);
            // 
            // buttonAleevaSettings
            // 
            this.buttonAleevaSettings.Image = global::PlenBotLogUploader.Properties.Resources.aleeva_icon16;
            this.buttonAleevaSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAleevaSettings.Location = new System.Drawing.Point(8, 149);
            this.buttonAleevaSettings.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAleevaSettings.Name = "buttonAleevaSettings";
            this.buttonAleevaSettings.Size = new System.Drawing.Size(251, 28);
            this.buttonAleevaSettings.TabIndex = 13;
            this.buttonAleevaSettings.Text = "Aleeva integration";
            this.buttonAleevaSettings.UseVisualStyleBackColor = true;
            this.buttonAleevaSettings.Click += new System.EventHandler(this.ButtonAleevaSettings_Click);
            // 
            // buttonGW2API
            // 
            this.buttonGW2API.Location = new System.Drawing.Point(8, 257);
            this.buttonGW2API.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGW2API.Name = "buttonGW2API";
            this.buttonGW2API.Size = new System.Drawing.Size(251, 28);
            this.buttonGW2API.TabIndex = 12;
            this.buttonGW2API.Text = "GW2 API keys and Hs build links";
            this.buttonGW2API.UseVisualStyleBackColor = true;
            this.buttonGW2API.Click += new System.EventHandler(this.ButtonGW2API_Click);
            // 
            // comboBoxMaxUploads
            // 
            this.comboBoxMaxUploads.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.comboBoxMaxUploads.Location = new System.Drawing.Point(177, 80);
            this.comboBoxMaxUploads.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxMaxUploads.Name = "comboBoxMaxUploads";
            this.comboBoxMaxUploads.Size = new System.Drawing.Size(80, 24);
            this.comboBoxMaxUploads.TabIndex = 11;
            // 
            // labelMaximumUploads
            // 
            this.labelMaximumUploads.AutoSize = true;
            this.labelMaximumUploads.Location = new System.Drawing.Point(8, 84);
            this.labelMaximumUploads.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMaximumUploads.Name = "labelMaximumUploads";
            this.labelMaximumUploads.Size = new System.Drawing.Size(149, 16);
            this.labelMaximumUploads.TabIndex = 10;
            this.labelMaximumUploads.Text = "Max concurrent uploads";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(8, 359);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(251, 28);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "Reset all settings";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // checkBoxStartWhenWindowsStarts
            // 
            this.checkBoxStartWhenWindowsStarts.AutoSize = true;
            this.checkBoxStartWhenWindowsStarts.Location = new System.Drawing.Point(12, 52);
            this.checkBoxStartWhenWindowsStarts.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxStartWhenWindowsStarts.Name = "checkBoxStartWhenWindowsStarts";
            this.checkBoxStartWhenWindowsStarts.Size = new System.Drawing.Size(218, 20);
            this.checkBoxStartWhenWindowsStarts.TabIndex = 5;
            this.checkBoxStartWhenWindowsStarts.Text = "start uploader on system startup";
            this.checkBoxStartWhenWindowsStarts.UseVisualStyleBackColor = true;
            // 
            // buttonDiscordWebhooks
            // 
            this.buttonDiscordWebhooks.Location = new System.Drawing.Point(8, 113);
            this.buttonDiscordWebhooks.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDiscordWebhooks.Name = "buttonDiscordWebhooks";
            this.buttonDiscordWebhooks.Size = new System.Drawing.Size(251, 28);
            this.buttonDiscordWebhooks.TabIndex = 4;
            this.buttonDiscordWebhooks.Text = "Discord webhooks";
            this.buttonDiscordWebhooks.UseVisualStyleBackColor = true;
            this.buttonDiscordWebhooks.Click += new System.EventHandler(this.ButtonDiscordWebhooks_Click);
            // 
            // buttonArcDpsPluginManager
            // 
            this.buttonArcDpsPluginManager.Location = new System.Drawing.Point(8, 293);
            this.buttonArcDpsPluginManager.Margin = new System.Windows.Forms.Padding(4);
            this.buttonArcDpsPluginManager.Name = "buttonArcDpsPluginManager";
            this.buttonArcDpsPluginManager.Size = new System.Drawing.Size(251, 28);
            this.buttonArcDpsPluginManager.TabIndex = 3;
            this.buttonArcDpsPluginManager.Text = "arcdps plugin manager";
            this.buttonArcDpsPluginManager.UseVisualStyleBackColor = true;
            this.buttonArcDpsPluginManager.Click += new System.EventHandler(this.ButtonArcDpsPluginManager_Click);
            // 
            // buttonPingSettings
            // 
            this.buttonPingSettings.Location = new System.Drawing.Point(8, 328);
            this.buttonPingSettings.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPingSettings.Name = "buttonPingSettings";
            this.buttonPingSettings.Size = new System.Drawing.Size(251, 28);
            this.buttonPingSettings.TabIndex = 0;
            this.buttonPingSettings.Text = "Remote server pings";
            this.buttonPingSettings.UseVisualStyleBackColor = true;
            this.buttonPingSettings.Click += new System.EventHandler(this.ButtonPingSettings_Click);
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
            // richTextBoxMainConsole
            // 
            this.richTextBoxMainConsole.BackColor = System.Drawing.Color.White;
            this.richTextBoxMainConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxMainConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxMainConsole.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBoxMainConsole.Location = new System.Drawing.Point(4, 4);
            this.richTextBoxMainConsole.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxMainConsole.Name = "richTextBoxMainConsole";
            this.richTextBoxMainConsole.ReadOnly = true;
            this.tableLayoutPanelMainForm.SetRowSpan(this.richTextBoxMainConsole, 4);
            this.richTextBoxMainConsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBoxMainConsole.Size = new System.Drawing.Size(561, 967);
            this.richTextBoxMainConsole.TabIndex = 9;
            this.richTextBoxMainConsole.Text = "";
            this.richTextBoxMainConsole.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RichTextBoxUploadInfo_LinkClicked);
            // 
            // tableLayoutPanelMainForm
            // 
            this.tableLayoutPanelMainForm.ColumnCount = 2;
            this.tableLayoutPanelMainForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMainForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMainForm.Controls.Add(this.richTextBoxMainConsole, 0, 0);
            this.tableLayoutPanelMainForm.Controls.Add(this.groupBoxTwitchSettings, 1, 0);
            this.tableLayoutPanelMainForm.Controls.Add(this.groupBoxArcdpsLogs, 1, 1);
            this.tableLayoutPanelMainForm.Controls.Add(this.groupBoxOtherSettings, 1, 2);
            this.tableLayoutPanelMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMainForm.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMainForm.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelMainForm.Name = "tableLayoutPanelMainForm";
            this.tableLayoutPanelMainForm.RowCount = 4;
            this.tableLayoutPanelMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanelMainForm.Size = new System.Drawing.Size(844, 975);
            this.tableLayoutPanelMainForm.TabIndex = 10;
            // 
            // timerResizeSave
            // 
            this.timerResizeSave.Interval = 1500;
            this.timerResizeSave.Tick += new System.EventHandler(this.TimerResizeSave_Tick);
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(844, 975);
            this.Controls.Add(this.tableLayoutPanelMainForm);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(726, 1018);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlenBot Log Uploader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.groupBoxTwitchSettings.ResumeLayout(false);
            this.groupBoxTwitchSettings.PerformLayout();
            this.groupBoxArcdpsLogs.ResumeLayout(false);
            this.groupBoxArcdpsLogs.PerformLayout();
            this.contextMenuStripIcon.ResumeLayout(false);
            this.groupBoxOtherSettings.ResumeLayout(false);
            this.groupBoxOtherSettings.PerformLayout();
            this.tableLayoutPanelMainForm.ResumeLayout(false);
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
        private System.Windows.Forms.Button buttonChangeTwitchChannel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripIcon;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUploadLogs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorTwo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPostToTwitch;
        private System.Windows.Forms.Button buttonOpenLogs;
        private System.Windows.Forms.Button buttonCustomName;
        private System.Windows.Forms.Button buttonDPSReportServer;
        private System.Windows.Forms.CheckBox checkBoxTrayMinimiseToIcon;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenDPSReportServer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenCustomName;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenPingSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorThree;
        private System.Windows.Forms.Button buttonDisConnectTwitch;
        internal System.Windows.Forms.CheckBox checkBoxPostToTwitch;
        private System.Windows.Forms.CheckBox checkBoxTwitchOnlySuccess;
        private System.Windows.Forms.Button buttonArcDpsPluginManager;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenArcDpsPluginManager;
        private System.Windows.Forms.Button buttonBossData;
        private System.Windows.Forms.Button buttonDiscordWebhooks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorFour;
        internal System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDiscordWebhooks;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.CheckBox checkBoxStartWhenWindowsStarts;
        private System.Windows.Forms.Timer timerCheckUpdate;
        private System.Windows.Forms.Button buttonTwitchCommands;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenTwitchCommands;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonSession;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.ComboBox comboBoxMaxUploads;
        private System.Windows.Forms.Label labelMaximumUploads;
        private System.Windows.Forms.RichTextBox richTextBoxMainConsole;
        private System.Windows.Forms.Button buttonGW2API;
        private System.Windows.Forms.Button buttonAleevaSettings;
        private System.Windows.Forms.Button buttonCopyApplicationSession;
        private System.Windows.Forms.CheckBox checkBoxDetailedWvW;
        private System.Windows.Forms.CheckBox checkBoxAnonymiseReports;
        private System.Windows.Forms.CheckBox checkBoxSaveLogsToCSV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMainForm;
        private System.Windows.Forms.Timer timerResizeSave;
        private System.Windows.Forms.Button buttonGW2BotSettings;
        private System.Windows.Forms.Button buttonTeamsSettings;
        private System.Windows.Forms.CheckBox checkBoxAutoUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorOne;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDPSReportUserTokens;
    }
}

