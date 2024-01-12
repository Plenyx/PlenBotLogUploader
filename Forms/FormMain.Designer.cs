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
            components = new System.ComponentModel.Container();
            groupBoxTwitchSettings = new System.Windows.Forms.GroupBox();
            checkBoxOnlyWhenStreamSoftwareRunning = new System.Windows.Forms.CheckBox();
            buttonTwitchCommands = new System.Windows.Forms.Button();
            checkBoxTwitchOnlySuccess = new System.Windows.Forms.CheckBox();
            buttonDisConnectTwitch = new System.Windows.Forms.Button();
            buttonCustomName = new System.Windows.Forms.Button();
            buttonChangeTwitchChannel = new System.Windows.Forms.Button();
            checkBoxPostToTwitch = new System.Windows.Forms.CheckBox();
            buttonReconnectBot = new System.Windows.Forms.Button();
            buttonBossData = new System.Windows.Forms.Button();
            checkBoxUploadLogs = new System.Windows.Forms.CheckBox();
            groupBoxArcdpsLogs = new System.Windows.Forms.GroupBox();
            checkBoxUsePolling = new System.Windows.Forms.CheckBox();
            checkBoxSaveLogsToCSV = new System.Windows.Forms.CheckBox();
            checkBoxDetailedWvW = new System.Windows.Forms.CheckBox();
            checkBoxAnonymiseReports = new System.Windows.Forms.CheckBox();
            buttonCopyApplicationSession = new System.Windows.Forms.Button();
            buttonSession = new System.Windows.Forms.Button();
            buttonOpenLogs = new System.Windows.Forms.Button();
            buttonDPSReportServer = new System.Windows.Forms.Button();
            labelLocationInfo = new System.Windows.Forms.Label();
            buttonLogsLocation = new System.Windows.Forms.Button();
            buttonUpdate = new System.Windows.Forms.Button();
            checkBoxTrayMinimiseToIcon = new System.Windows.Forms.CheckBox();
            notifyIconTray = new System.Windows.Forms.NotifyIcon(components);
            contextMenuStripIcon = new System.Windows.Forms.ContextMenuStrip(components);
            toolStripMenuItemUploadLogs = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemPostToTwitch = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparatorOne = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItemDPSReportUserTokens = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparatorTwo = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItemOpenDPSReportServer = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemOpenCustomName = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemOpenTwitchCommands = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemOpenArcDpsPluginManager = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparatorThree = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItemDiscordWebhooks = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemOpenPingSettings = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparatorFour = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            groupBoxOtherSettings = new System.Windows.Forms.GroupBox();
            checkBoxAutoUpdate = new System.Windows.Forms.CheckBox();
            buttonTeamsSettings = new System.Windows.Forms.Button();
            buttonGW2BotSettings = new System.Windows.Forms.Button();
            buttonAleevaSettings = new System.Windows.Forms.Button();
            buttonGW2API = new System.Windows.Forms.Button();
            comboBoxMaxUploads = new System.Windows.Forms.ComboBox();
            labelMaximumUploads = new System.Windows.Forms.Label();
            buttonReset = new System.Windows.Forms.Button();
            checkBoxStartWhenWindowsStarts = new System.Windows.Forms.CheckBox();
            buttonDiscordWebhooks = new System.Windows.Forms.Button();
            buttonArcDpsPluginManager = new System.Windows.Forms.Button();
            buttonPingSettings = new System.Windows.Forms.Button();
            timerCheckUpdate = new System.Windows.Forms.Timer(components);
            toolTip = new System.Windows.Forms.ToolTip(components);
            richTextBoxMainConsole = new System.Windows.Forms.RichTextBox();
            tableLayoutPanelMainForm = new System.Windows.Forms.TableLayoutPanel();
            tabControlSettings = new System.Windows.Forms.TabControl();
            tabPageMainSettings = new System.Windows.Forms.TabPage();
            tabPageOtherSettings = new System.Windows.Forms.TabPage();
            timerFailedLogsReupload = new System.Windows.Forms.Timer(components);
            groupBoxTwitchSettings.SuspendLayout();
            groupBoxArcdpsLogs.SuspendLayout();
            contextMenuStripIcon.SuspendLayout();
            groupBoxOtherSettings.SuspendLayout();
            tableLayoutPanelMainForm.SuspendLayout();
            tabControlSettings.SuspendLayout();
            tabPageMainSettings.SuspendLayout();
            tabPageOtherSettings.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxTwitchSettings
            // 
            groupBoxTwitchSettings.Controls.Add(checkBoxOnlyWhenStreamSoftwareRunning);
            groupBoxTwitchSettings.Controls.Add(buttonTwitchCommands);
            groupBoxTwitchSettings.Controls.Add(checkBoxTwitchOnlySuccess);
            groupBoxTwitchSettings.Controls.Add(buttonDisConnectTwitch);
            groupBoxTwitchSettings.Controls.Add(buttonCustomName);
            groupBoxTwitchSettings.Controls.Add(buttonChangeTwitchChannel);
            groupBoxTwitchSettings.Controls.Add(checkBoxPostToTwitch);
            groupBoxTwitchSettings.Controls.Add(buttonReconnectBot);
            groupBoxTwitchSettings.Location = new System.Drawing.Point(7, 8);
            groupBoxTwitchSettings.Margin = new System.Windows.Forms.Padding(5);
            groupBoxTwitchSettings.Name = "groupBoxTwitchSettings";
            groupBoxTwitchSettings.Padding = new System.Windows.Forms.Padding(5);
            groupBoxTwitchSettings.Size = new System.Drawing.Size(309, 275);
            groupBoxTwitchSettings.TabIndex = 4;
            groupBoxTwitchSettings.TabStop = false;
            groupBoxTwitchSettings.Text = "Twitch settings";
            // 
            // checkBoxOnlyWhenStreamSoftwareRunning
            // 
            checkBoxOnlyWhenStreamSoftwareRunning.AutoSize = true;
            checkBoxOnlyWhenStreamSoftwareRunning.Location = new System.Drawing.Point(11, 113);
            checkBoxOnlyWhenStreamSoftwareRunning.Name = "checkBoxOnlyWhenStreamSoftwareRunning";
            checkBoxOnlyWhenStreamSoftwareRunning.Size = new System.Drawing.Size(273, 24);
            checkBoxOnlyWhenStreamSoftwareRunning.TabIndex = 13;
            checkBoxOnlyWhenStreamSoftwareRunning.Text = "post only if streaming app is running";
            checkBoxOnlyWhenStreamSoftwareRunning.UseVisualStyleBackColor = true;
            // 
            // buttonTwitchCommands
            // 
            buttonTwitchCommands.Location = new System.Drawing.Point(8, 185);
            buttonTwitchCommands.Margin = new System.Windows.Forms.Padding(5);
            buttonTwitchCommands.Name = "buttonTwitchCommands";
            buttonTwitchCommands.Size = new System.Drawing.Size(291, 35);
            buttonTwitchCommands.TabIndex = 12;
            buttonTwitchCommands.Text = "Twitch commands";
            buttonTwitchCommands.UseVisualStyleBackColor = true;
            buttonTwitchCommands.Click += ButtonTwitchCommands_Click;
            // 
            // checkBoxTwitchOnlySuccess
            // 
            checkBoxTwitchOnlySuccess.AutoSize = true;
            checkBoxTwitchOnlySuccess.Enabled = false;
            checkBoxTwitchOnlySuccess.Location = new System.Drawing.Point(11, 90);
            checkBoxTwitchOnlySuccess.Margin = new System.Windows.Forms.Padding(5);
            checkBoxTwitchOnlySuccess.Name = "checkBoxTwitchOnlySuccess";
            checkBoxTwitchOnlySuccess.Size = new System.Drawing.Size(193, 24);
            checkBoxTwitchOnlySuccess.TabIndex = 11;
            checkBoxTwitchOnlySuccess.Text = "post only successful logs";
            checkBoxTwitchOnlySuccess.UseVisualStyleBackColor = true;
            // 
            // buttonDisConnectTwitch
            // 
            buttonDisConnectTwitch.Location = new System.Drawing.Point(8, 229);
            buttonDisConnectTwitch.Margin = new System.Windows.Forms.Padding(5);
            buttonDisConnectTwitch.Name = "buttonDisConnectTwitch";
            buttonDisConnectTwitch.Size = new System.Drawing.Size(291, 35);
            buttonDisConnectTwitch.TabIndex = 10;
            buttonDisConnectTwitch.Text = "Disconnect from Twitch";
            buttonDisConnectTwitch.UseVisualStyleBackColor = true;
            buttonDisConnectTwitch.Click += ButtonDisConnectTwitch_Click;
            // 
            // buttonCustomName
            // 
            buttonCustomName.Location = new System.Drawing.Point(8, 140);
            buttonCustomName.Margin = new System.Windows.Forms.Padding(5);
            buttonCustomName.Name = "buttonCustomName";
            buttonCustomName.Size = new System.Drawing.Size(139, 35);
            buttonCustomName.TabIndex = 9;
            buttonCustomName.Text = "Custom name";
            buttonCustomName.UseVisualStyleBackColor = true;
            buttonCustomName.Click += ButtonCustomName_Click;
            // 
            // buttonChangeTwitchChannel
            // 
            buttonChangeTwitchChannel.Location = new System.Drawing.Point(8, 25);
            buttonChangeTwitchChannel.Margin = new System.Windows.Forms.Padding(5);
            buttonChangeTwitchChannel.Name = "buttonChangeTwitchChannel";
            buttonChangeTwitchChannel.Size = new System.Drawing.Size(291, 35);
            buttonChangeTwitchChannel.TabIndex = 8;
            buttonChangeTwitchChannel.Text = "Change Twitch channel";
            buttonChangeTwitchChannel.UseVisualStyleBackColor = true;
            buttonChangeTwitchChannel.Click += ButtonChangeTwitchChannel_Click;
            // 
            // checkBoxPostToTwitch
            // 
            checkBoxPostToTwitch.AutoSize = true;
            checkBoxPostToTwitch.Enabled = false;
            checkBoxPostToTwitch.Location = new System.Drawing.Point(11, 66);
            checkBoxPostToTwitch.Margin = new System.Windows.Forms.Padding(5);
            checkBoxPostToTwitch.Name = "checkBoxPostToTwitch";
            checkBoxPostToTwitch.Size = new System.Drawing.Size(214, 24);
            checkBoxPostToTwitch.TabIndex = 6;
            checkBoxPostToTwitch.Text = "post links to the Twitch chat";
            checkBoxPostToTwitch.UseVisualStyleBackColor = true;
            // 
            // buttonReconnectBot
            // 
            buttonReconnectBot.Location = new System.Drawing.Point(155, 140);
            buttonReconnectBot.Margin = new System.Windows.Forms.Padding(5);
            buttonReconnectBot.Name = "buttonReconnectBot";
            buttonReconnectBot.Size = new System.Drawing.Size(144, 35);
            buttonReconnectBot.TabIndex = 4;
            buttonReconnectBot.Text = "Reconnect bot";
            buttonReconnectBot.UseVisualStyleBackColor = true;
            buttonReconnectBot.Click += ButtonReconnectBot_Click;
            // 
            // buttonBossData
            // 
            buttonBossData.Location = new System.Drawing.Point(173, 158);
            buttonBossData.Margin = new System.Windows.Forms.Padding(5);
            buttonBossData.Name = "buttonBossData";
            buttonBossData.Size = new System.Drawing.Size(126, 35);
            buttonBossData.TabIndex = 12;
            buttonBossData.Text = "Edit boss data";
            buttonBossData.UseVisualStyleBackColor = true;
            buttonBossData.Click += ButtonBossData_Click;
            // 
            // checkBoxUploadLogs
            // 
            checkBoxUploadLogs.AutoSize = true;
            checkBoxUploadLogs.Location = new System.Drawing.Point(10, 30);
            checkBoxUploadLogs.Margin = new System.Windows.Forms.Padding(5);
            checkBoxUploadLogs.Name = "checkBoxUploadLogs";
            checkBoxUploadLogs.Size = new System.Drawing.Size(110, 24);
            checkBoxUploadLogs.TabIndex = 3;
            checkBoxUploadLogs.Text = "upload logs";
            checkBoxUploadLogs.UseVisualStyleBackColor = true;
            // 
            // groupBoxArcdpsLogs
            // 
            groupBoxArcdpsLogs.Controls.Add(checkBoxUsePolling);
            groupBoxArcdpsLogs.Controls.Add(checkBoxSaveLogsToCSV);
            groupBoxArcdpsLogs.Controls.Add(checkBoxDetailedWvW);
            groupBoxArcdpsLogs.Controls.Add(checkBoxAnonymiseReports);
            groupBoxArcdpsLogs.Controls.Add(buttonCopyApplicationSession);
            groupBoxArcdpsLogs.Controls.Add(buttonSession);
            groupBoxArcdpsLogs.Controls.Add(buttonBossData);
            groupBoxArcdpsLogs.Controls.Add(buttonOpenLogs);
            groupBoxArcdpsLogs.Controls.Add(buttonDPSReportServer);
            groupBoxArcdpsLogs.Controls.Add(labelLocationInfo);
            groupBoxArcdpsLogs.Controls.Add(buttonLogsLocation);
            groupBoxArcdpsLogs.Controls.Add(checkBoxUploadLogs);
            groupBoxArcdpsLogs.Location = new System.Drawing.Point(7, 293);
            groupBoxArcdpsLogs.Margin = new System.Windows.Forms.Padding(5);
            groupBoxArcdpsLogs.Name = "groupBoxArcdpsLogs";
            groupBoxArcdpsLogs.Padding = new System.Windows.Forms.Padding(5);
            groupBoxArcdpsLogs.Size = new System.Drawing.Size(309, 334);
            groupBoxArcdpsLogs.TabIndex = 5;
            groupBoxArcdpsLogs.TabStop = false;
            groupBoxArcdpsLogs.Text = "arcdps logs and DPS.report";
            // 
            // checkBoxUsePolling
            // 
            checkBoxUsePolling.AutoSize = true;
            checkBoxUsePolling.Location = new System.Drawing.Point(10, 125);
            checkBoxUsePolling.Margin = new System.Windows.Forms.Padding(4);
            checkBoxUsePolling.Name = "checkBoxUsePolling";
            checkBoxUsePolling.Size = new System.Drawing.Size(264, 24);
            checkBoxUsePolling.TabIndex = 4;
            checkBoxUsePolling.Text = "use Linux compatible log detection";
            checkBoxUsePolling.UseVisualStyleBackColor = true;
            // 
            // checkBoxSaveLogsToCSV
            // 
            checkBoxSaveLogsToCSV.AutoSize = true;
            checkBoxSaveLogsToCSV.Location = new System.Drawing.Point(10, 101);
            checkBoxSaveLogsToCSV.Margin = new System.Windows.Forms.Padding(5);
            checkBoxSaveLogsToCSV.Name = "checkBoxSaveLogsToCSV";
            checkBoxSaveLogsToCSV.Size = new System.Drawing.Size(177, 24);
            checkBoxSaveLogsToCSV.TabIndex = 17;
            checkBoxSaveLogsToCSV.Text = "save logs to a CSV file";
            checkBoxSaveLogsToCSV.UseVisualStyleBackColor = true;
            // 
            // checkBoxDetailedWvW
            // 
            checkBoxDetailedWvW.AutoSize = true;
            checkBoxDetailedWvW.Location = new System.Drawing.Point(10, 77);
            checkBoxDetailedWvW.Margin = new System.Windows.Forms.Padding(5);
            checkBoxDetailedWvW.Name = "checkBoxDetailedWvW";
            checkBoxDetailedWvW.Size = new System.Drawing.Size(176, 24);
            checkBoxDetailedWvW.TabIndex = 16;
            checkBoxDetailedWvW.Text = "detailed WvW reports";
            checkBoxDetailedWvW.UseVisualStyleBackColor = true;
            // 
            // checkBoxAnonymiseReports
            // 
            checkBoxAnonymiseReports.AutoSize = true;
            checkBoxAnonymiseReports.Location = new System.Drawing.Point(10, 53);
            checkBoxAnonymiseReports.Margin = new System.Windows.Forms.Padding(5);
            checkBoxAnonymiseReports.Name = "checkBoxAnonymiseReports";
            checkBoxAnonymiseReports.Size = new System.Drawing.Size(153, 24);
            checkBoxAnonymiseReports.TabIndex = 15;
            checkBoxAnonymiseReports.Text = "anonymise reports";
            checkBoxAnonymiseReports.UseVisualStyleBackColor = true;
            // 
            // buttonCopyApplicationSession
            // 
            buttonCopyApplicationSession.Location = new System.Drawing.Point(161, 202);
            buttonCopyApplicationSession.Margin = new System.Windows.Forms.Padding(5);
            buttonCopyApplicationSession.Name = "buttonCopyApplicationSession";
            buttonCopyApplicationSession.Size = new System.Drawing.Size(138, 35);
            buttonCopyApplicationSession.TabIndex = 14;
            buttonCopyApplicationSession.Text = "Copy to clipboard";
            buttonCopyApplicationSession.UseVisualStyleBackColor = true;
            buttonCopyApplicationSession.Click += ButtonCopyApplicationSession_Click;
            // 
            // buttonSession
            // 
            buttonSession.Location = new System.Drawing.Point(8, 158);
            buttonSession.Margin = new System.Windows.Forms.Padding(5);
            buttonSession.Name = "buttonSession";
            buttonSession.Size = new System.Drawing.Size(157, 35);
            buttonSession.TabIndex = 13;
            buttonSession.Text = "Log sessions";
            buttonSession.UseVisualStyleBackColor = true;
            buttonSession.Click += ButtonSession_Click;
            // 
            // buttonOpenLogs
            // 
            buttonOpenLogs.Enabled = false;
            buttonOpenLogs.Location = new System.Drawing.Point(213, 247);
            buttonOpenLogs.Margin = new System.Windows.Forms.Padding(5);
            buttonOpenLogs.Name = "buttonOpenLogs";
            buttonOpenLogs.Size = new System.Drawing.Size(86, 35);
            buttonOpenLogs.TabIndex = 2;
            buttonOpenLogs.Text = "Open";
            buttonOpenLogs.UseVisualStyleBackColor = true;
            buttonOpenLogs.Click += ButtonOpenLogs_Click;
            // 
            // buttonDPSReportServer
            // 
            buttonDPSReportServer.Location = new System.Drawing.Point(8, 202);
            buttonDPSReportServer.Margin = new System.Windows.Forms.Padding(5);
            buttonDPSReportServer.Name = "buttonDPSReportServer";
            buttonDPSReportServer.Size = new System.Drawing.Size(145, 35);
            buttonDPSReportServer.TabIndex = 1;
            buttonDPSReportServer.Text = "DPS.report settings";
            buttonDPSReportServer.UseVisualStyleBackColor = true;
            buttonDPSReportServer.Click += ButtonDPSReportServer_Click;
            // 
            // labelLocationInfo
            // 
            labelLocationInfo.Location = new System.Drawing.Point(8, 287);
            labelLocationInfo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            labelLocationInfo.Name = "labelLocationInfo";
            labelLocationInfo.Size = new System.Drawing.Size(291, 35);
            labelLocationInfo.TabIndex = 1;
            labelLocationInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonLogsLocation
            // 
            buttonLogsLocation.Location = new System.Drawing.Point(8, 247);
            buttonLogsLocation.Margin = new System.Windows.Forms.Padding(5);
            buttonLogsLocation.Name = "buttonLogsLocation";
            buttonLogsLocation.Size = new System.Drawing.Size(197, 35);
            buttonLogsLocation.TabIndex = 0;
            buttonLogsLocation.Text = "Change logs directory";
            buttonLogsLocation.UseVisualStyleBackColor = true;
            buttonLogsLocation.Click += ButtonLogsLocation_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new System.Drawing.Point(6, 524);
            buttonUpdate.Margin = new System.Windows.Forms.Padding(5);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new System.Drawing.Size(295, 35);
            buttonUpdate.TabIndex = 8;
            buttonUpdate.Text = "Check for updates";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += ButtonUpdateNow_Click;
            // 
            // checkBoxTrayMinimiseToIcon
            // 
            checkBoxTrayMinimiseToIcon.AutoSize = true;
            checkBoxTrayMinimiseToIcon.Location = new System.Drawing.Point(11, 29);
            checkBoxTrayMinimiseToIcon.Margin = new System.Windows.Forms.Padding(5);
            checkBoxTrayMinimiseToIcon.Name = "checkBoxTrayMinimiseToIcon";
            checkBoxTrayMinimiseToIcon.Size = new System.Drawing.Size(170, 24);
            checkBoxTrayMinimiseToIcon.TabIndex = 0;
            checkBoxTrayMinimiseToIcon.Text = "minimise to tray icon";
            checkBoxTrayMinimiseToIcon.UseVisualStyleBackColor = true;
            // 
            // notifyIconTray
            // 
            notifyIconTray.ContextMenuStrip = contextMenuStripIcon;
            notifyIconTray.Text = "PlenBot Log Uploader";
            notifyIconTray.Visible = true;
            notifyIconTray.MouseDoubleClick += NotifyIconTray_MouseDoubleClick;
            // 
            // contextMenuStripIcon
            // 
            contextMenuStripIcon.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuStripIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemUploadLogs, toolStripMenuItemPostToTwitch, toolStripSeparatorOne, toolStripMenuItemDPSReportUserTokens, toolStripSeparatorTwo, toolStripMenuItemOpenDPSReportServer, toolStripMenuItemOpenCustomName, toolStripMenuItemOpenTwitchCommands, toolStripMenuItemOpenArcDpsPluginManager, toolStripSeparatorThree, toolStripMenuItemDiscordWebhooks, toolStripMenuItemOpenPingSettings, toolStripSeparatorFour, toolStripMenuItemExit });
            contextMenuStripIcon.Name = "contextMenuStripIcon";
            contextMenuStripIcon.Size = new System.Drawing.Size(272, 268);
            // 
            // toolStripMenuItemUploadLogs
            // 
            toolStripMenuItemUploadLogs.CheckOnClick = true;
            toolStripMenuItemUploadLogs.Name = "toolStripMenuItemUploadLogs";
            toolStripMenuItemUploadLogs.Size = new System.Drawing.Size(271, 24);
            toolStripMenuItemUploadLogs.Text = "upload logs";
            toolStripMenuItemUploadLogs.CheckedChanged += ToolStripMenuItemUploadLogs_CheckedChanged;
            // 
            // toolStripMenuItemPostToTwitch
            // 
            toolStripMenuItemPostToTwitch.CheckOnClick = true;
            toolStripMenuItemPostToTwitch.Name = "toolStripMenuItemPostToTwitch";
            toolStripMenuItemPostToTwitch.Size = new System.Drawing.Size(271, 24);
            toolStripMenuItemPostToTwitch.Text = "post links to Twitch chat";
            toolStripMenuItemPostToTwitch.CheckedChanged += ToolStripMenuItemPostToTwitch_CheckedChanged;
            // 
            // toolStripSeparatorOne
            // 
            toolStripSeparatorOne.Name = "toolStripSeparatorOne";
            toolStripSeparatorOne.Size = new System.Drawing.Size(268, 6);
            // 
            // toolStripMenuItemDPSReportUserTokens
            // 
            toolStripMenuItemDPSReportUserTokens.Name = "toolStripMenuItemDPSReportUserTokens";
            toolStripMenuItemDPSReportUserTokens.Size = new System.Drawing.Size(271, 24);
            toolStripMenuItemDPSReportUserTokens.Text = "DPS.report user token";
            // 
            // toolStripSeparatorTwo
            // 
            toolStripSeparatorTwo.Name = "toolStripSeparatorTwo";
            toolStripSeparatorTwo.Size = new System.Drawing.Size(268, 6);
            // 
            // toolStripMenuItemOpenDPSReportServer
            // 
            toolStripMenuItemOpenDPSReportServer.Name = "toolStripMenuItemOpenDPSReportServer";
            toolStripMenuItemOpenDPSReportServer.Size = new System.Drawing.Size(271, 24);
            toolStripMenuItemOpenDPSReportServer.Text = "Open DPS.report settings";
            toolStripMenuItemOpenDPSReportServer.Click += ToolStripMenuItemOpenDPSReportServer_Click;
            // 
            // toolStripMenuItemOpenCustomName
            // 
            toolStripMenuItemOpenCustomName.Name = "toolStripMenuItemOpenCustomName";
            toolStripMenuItemOpenCustomName.Size = new System.Drawing.Size(271, 24);
            toolStripMenuItemOpenCustomName.Text = "Open custom name settings";
            toolStripMenuItemOpenCustomName.Click += ToolStripMenuItemOpenCustomName_Click;
            // 
            // toolStripMenuItemOpenTwitchCommands
            // 
            toolStripMenuItemOpenTwitchCommands.Name = "toolStripMenuItemOpenTwitchCommands";
            toolStripMenuItemOpenTwitchCommands.Size = new System.Drawing.Size(271, 24);
            toolStripMenuItemOpenTwitchCommands.Text = "Open Twitch commands";
            toolStripMenuItemOpenTwitchCommands.Click += ToolStripMenuItemOpenTwitchCommands_Click;
            // 
            // toolStripMenuItemOpenArcDpsPluginManager
            // 
            toolStripMenuItemOpenArcDpsPluginManager.Name = "toolStripMenuItemOpenArcDpsPluginManager";
            toolStripMenuItemOpenArcDpsPluginManager.Size = new System.Drawing.Size(271, 24);
            toolStripMenuItemOpenArcDpsPluginManager.Text = "Open arcdps plugin manager";
            toolStripMenuItemOpenArcDpsPluginManager.Click += ToolStripMenuItemOpenArcDpsPluginManager_Click;
            // 
            // toolStripSeparatorThree
            // 
            toolStripSeparatorThree.Name = "toolStripSeparatorThree";
            toolStripSeparatorThree.Size = new System.Drawing.Size(268, 6);
            // 
            // toolStripMenuItemDiscordWebhooks
            // 
            toolStripMenuItemDiscordWebhooks.Name = "toolStripMenuItemDiscordWebhooks";
            toolStripMenuItemDiscordWebhooks.Size = new System.Drawing.Size(271, 24);
            toolStripMenuItemDiscordWebhooks.Text = "Discord webhooks";
            toolStripMenuItemDiscordWebhooks.Click += ToolStripMenuItemDiscordWebhooks_Click;
            // 
            // toolStripMenuItemOpenPingSettings
            // 
            toolStripMenuItemOpenPingSettings.Name = "toolStripMenuItemOpenPingSettings";
            toolStripMenuItemOpenPingSettings.Size = new System.Drawing.Size(271, 24);
            toolStripMenuItemOpenPingSettings.Text = "Remote server pings";
            toolStripMenuItemOpenPingSettings.Click += ToolStripMenuItemOpenPingSettings_Click;
            // 
            // toolStripSeparatorFour
            // 
            toolStripSeparatorFour.Name = "toolStripSeparatorFour";
            toolStripSeparatorFour.Size = new System.Drawing.Size(268, 6);
            // 
            // toolStripMenuItemExit
            // 
            toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            toolStripMenuItemExit.Size = new System.Drawing.Size(271, 24);
            toolStripMenuItemExit.Text = "Shutdown";
            toolStripMenuItemExit.Click += ToolStripMenuItemExit_Click;
            // 
            // groupBoxOtherSettings
            // 
            groupBoxOtherSettings.Controls.Add(checkBoxAutoUpdate);
            groupBoxOtherSettings.Controls.Add(buttonTeamsSettings);
            groupBoxOtherSettings.Controls.Add(buttonGW2BotSettings);
            groupBoxOtherSettings.Controls.Add(buttonAleevaSettings);
            groupBoxOtherSettings.Controls.Add(buttonGW2API);
            groupBoxOtherSettings.Controls.Add(buttonUpdate);
            groupBoxOtherSettings.Controls.Add(comboBoxMaxUploads);
            groupBoxOtherSettings.Controls.Add(labelMaximumUploads);
            groupBoxOtherSettings.Controls.Add(buttonReset);
            groupBoxOtherSettings.Controls.Add(checkBoxStartWhenWindowsStarts);
            groupBoxOtherSettings.Controls.Add(buttonDiscordWebhooks);
            groupBoxOtherSettings.Controls.Add(buttonArcDpsPluginManager);
            groupBoxOtherSettings.Controls.Add(checkBoxTrayMinimiseToIcon);
            groupBoxOtherSettings.Controls.Add(buttonPingSettings);
            groupBoxOtherSettings.Location = new System.Drawing.Point(7, 8);
            groupBoxOtherSettings.Margin = new System.Windows.Forms.Padding(5);
            groupBoxOtherSettings.Name = "groupBoxOtherSettings";
            groupBoxOtherSettings.Padding = new System.Windows.Forms.Padding(5);
            groupBoxOtherSettings.Size = new System.Drawing.Size(309, 569);
            groupBoxOtherSettings.TabIndex = 7;
            groupBoxOtherSettings.TabStop = false;
            groupBoxOtherSettings.Text = "Other settings";
            // 
            // checkBoxAutoUpdate
            // 
            checkBoxAutoUpdate.AutoSize = true;
            checkBoxAutoUpdate.Location = new System.Drawing.Point(7, 494);
            checkBoxAutoUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            checkBoxAutoUpdate.Name = "checkBoxAutoUpdate";
            checkBoxAutoUpdate.Size = new System.Drawing.Size(261, 24);
            checkBoxAutoUpdate.TabIndex = 16;
            checkBoxAutoUpdate.Text = "automatically update the uploader";
            checkBoxAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonTeamsSettings
            // 
            buttonTeamsSettings.Location = new System.Drawing.Point(6, 272);
            buttonTeamsSettings.Margin = new System.Windows.Forms.Padding(5);
            buttonTeamsSettings.Name = "buttonTeamsSettings";
            buttonTeamsSettings.Size = new System.Drawing.Size(295, 35);
            buttonTeamsSettings.TabIndex = 15;
            buttonTeamsSettings.Text = "Setup Teams";
            buttonTeamsSettings.UseVisualStyleBackColor = true;
            buttonTeamsSettings.Click += ButtonTeamsSettings_Click;
            // 
            // buttonGW2BotSettings
            // 
            buttonGW2BotSettings.Image = Properties.Resources.gw2bot_icon16;
            buttonGW2BotSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            buttonGW2BotSettings.Location = new System.Drawing.Point(6, 227);
            buttonGW2BotSettings.Margin = new System.Windows.Forms.Padding(5);
            buttonGW2BotSettings.Name = "buttonGW2BotSettings";
            buttonGW2BotSettings.Size = new System.Drawing.Size(295, 35);
            buttonGW2BotSettings.TabIndex = 14;
            buttonGW2BotSettings.Text = "GW2Bot integration";
            buttonGW2BotSettings.UseVisualStyleBackColor = true;
            buttonGW2BotSettings.Click += ButtonGW2BotSettings_Click;
            // 
            // buttonAleevaSettings
            // 
            buttonAleevaSettings.Image = Properties.Resources.aleeva_icon16;
            buttonAleevaSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            buttonAleevaSettings.Location = new System.Drawing.Point(6, 182);
            buttonAleevaSettings.Margin = new System.Windows.Forms.Padding(5);
            buttonAleevaSettings.Name = "buttonAleevaSettings";
            buttonAleevaSettings.Size = new System.Drawing.Size(295, 35);
            buttonAleevaSettings.TabIndex = 13;
            buttonAleevaSettings.Text = "Aleeva integrations";
            buttonAleevaSettings.UseVisualStyleBackColor = true;
            buttonAleevaSettings.Click += ButtonAleevaSettings_Click;
            // 
            // buttonGW2API
            // 
            buttonGW2API.Location = new System.Drawing.Point(6, 317);
            buttonGW2API.Margin = new System.Windows.Forms.Padding(5);
            buttonGW2API.Name = "buttonGW2API";
            buttonGW2API.Size = new System.Drawing.Size(295, 35);
            buttonGW2API.TabIndex = 12;
            buttonGW2API.Text = "GW2 API keys and Hardstuck build links";
            buttonGW2API.UseVisualStyleBackColor = true;
            buttonGW2API.Click += ButtonGW2API_Click;
            // 
            // comboBoxMaxUploads
            // 
            comboBoxMaxUploads.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxMaxUploads.FormattingEnabled = true;
            comboBoxMaxUploads.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            comboBoxMaxUploads.Location = new System.Drawing.Point(177, 100);
            comboBoxMaxUploads.Margin = new System.Windows.Forms.Padding(5);
            comboBoxMaxUploads.Name = "comboBoxMaxUploads";
            comboBoxMaxUploads.Size = new System.Drawing.Size(123, 28);
            comboBoxMaxUploads.TabIndex = 11;
            // 
            // labelMaximumUploads
            // 
            labelMaximumUploads.AutoSize = true;
            labelMaximumUploads.Location = new System.Drawing.Point(8, 105);
            labelMaximumUploads.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            labelMaximumUploads.Name = "labelMaximumUploads";
            labelMaximumUploads.Size = new System.Drawing.Size(168, 20);
            labelMaximumUploads.TabIndex = 10;
            labelMaximumUploads.Text = "Max concurrent uploads";
            // 
            // buttonReset
            // 
            buttonReset.Location = new System.Drawing.Point(6, 452);
            buttonReset.Margin = new System.Windows.Forms.Padding(5);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new System.Drawing.Size(295, 35);
            buttonReset.TabIndex = 9;
            buttonReset.Text = "Reset all settings";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += ButtonReset_Click;
            // 
            // checkBoxStartWhenWindowsStarts
            // 
            checkBoxStartWhenWindowsStarts.AutoSize = true;
            checkBoxStartWhenWindowsStarts.Location = new System.Drawing.Point(11, 65);
            checkBoxStartWhenWindowsStarts.Margin = new System.Windows.Forms.Padding(5);
            checkBoxStartWhenWindowsStarts.Name = "checkBoxStartWhenWindowsStarts";
            checkBoxStartWhenWindowsStarts.Size = new System.Drawing.Size(244, 24);
            checkBoxStartWhenWindowsStarts.TabIndex = 5;
            checkBoxStartWhenWindowsStarts.Text = "start uploader on system startup";
            checkBoxStartWhenWindowsStarts.UseVisualStyleBackColor = true;
            // 
            // buttonDiscordWebhooks
            // 
            buttonDiscordWebhooks.Location = new System.Drawing.Point(6, 137);
            buttonDiscordWebhooks.Margin = new System.Windows.Forms.Padding(5);
            buttonDiscordWebhooks.Name = "buttonDiscordWebhooks";
            buttonDiscordWebhooks.Size = new System.Drawing.Size(295, 35);
            buttonDiscordWebhooks.TabIndex = 4;
            buttonDiscordWebhooks.Text = "Discord webhooks";
            buttonDiscordWebhooks.UseVisualStyleBackColor = true;
            buttonDiscordWebhooks.Click += ButtonDiscordWebhooks_Click;
            // 
            // buttonArcDpsPluginManager
            // 
            buttonArcDpsPluginManager.Location = new System.Drawing.Point(6, 362);
            buttonArcDpsPluginManager.Margin = new System.Windows.Forms.Padding(5);
            buttonArcDpsPluginManager.Name = "buttonArcDpsPluginManager";
            buttonArcDpsPluginManager.Size = new System.Drawing.Size(295, 35);
            buttonArcDpsPluginManager.TabIndex = 3;
            buttonArcDpsPluginManager.Text = "arcdps plugin manager";
            buttonArcDpsPluginManager.UseVisualStyleBackColor = true;
            buttonArcDpsPluginManager.Click += ButtonArcDpsPluginManager_Click;
            // 
            // buttonPingSettings
            // 
            buttonPingSettings.Location = new System.Drawing.Point(6, 407);
            buttonPingSettings.Margin = new System.Windows.Forms.Padding(5);
            buttonPingSettings.Name = "buttonPingSettings";
            buttonPingSettings.Size = new System.Drawing.Size(295, 35);
            buttonPingSettings.TabIndex = 0;
            buttonPingSettings.Text = "Remote server pings";
            buttonPingSettings.UseVisualStyleBackColor = true;
            buttonPingSettings.Click += ButtonPingSettings_Click;
            // 
            // timerCheckUpdate
            // 
            timerCheckUpdate.Interval = 5400000;
            timerCheckUpdate.Tick += TimerCheckUpdate_Tick;
            // 
            // toolTip
            // 
            toolTip.ShowAlways = true;
            // 
            // richTextBoxMainConsole
            // 
            richTextBoxMainConsole.BackColor = System.Drawing.Color.White;
            richTextBoxMainConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            richTextBoxMainConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            richTextBoxMainConsole.Font = new System.Drawing.Font("Segoe UI", 12F);
            richTextBoxMainConsole.Location = new System.Drawing.Point(5, 5);
            richTextBoxMainConsole.Margin = new System.Windows.Forms.Padding(5);
            richTextBoxMainConsole.Name = "richTextBoxMainConsole";
            richTextBoxMainConsole.ReadOnly = true;
            tableLayoutPanelMainForm.SetRowSpan(richTextBoxMainConsole, 2);
            richTextBoxMainConsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            richTextBoxMainConsole.Size = new System.Drawing.Size(472, 683);
            richTextBoxMainConsole.TabIndex = 9;
            richTextBoxMainConsole.Text = "";
            richTextBoxMainConsole.LinkClicked += RichTextBoxUploadInfo_LinkClicked;
            // 
            // tableLayoutPanelMainForm
            // 
            tableLayoutPanelMainForm.ColumnCount = 2;
            tableLayoutPanelMainForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelMainForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelMainForm.Controls.Add(richTextBoxMainConsole, 0, 0);
            tableLayoutPanelMainForm.Controls.Add(tabControlSettings, 1, 0);
            tableLayoutPanelMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelMainForm.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelMainForm.Margin = new System.Windows.Forms.Padding(5);
            tableLayoutPanelMainForm.Name = "tableLayoutPanelMainForm";
            tableLayoutPanelMainForm.RowCount = 2;
            tableLayoutPanelMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            tableLayoutPanelMainForm.Size = new System.Drawing.Size(816, 693);
            tableLayoutPanelMainForm.TabIndex = 10;
            // 
            // tabControlSettings
            // 
            tabControlSettings.Controls.Add(tabPageMainSettings);
            tabControlSettings.Controls.Add(tabPageOtherSettings);
            tabControlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlSettings.Location = new System.Drawing.Point(485, 3);
            tabControlSettings.Name = "tabControlSettings";
            tabControlSettings.SelectedIndex = 0;
            tabControlSettings.Size = new System.Drawing.Size(328, 687);
            tabControlSettings.TabIndex = 10;
            // 
            // tabPageMainSettings
            // 
            tabPageMainSettings.BackColor = System.Drawing.Color.White;
            tabPageMainSettings.Controls.Add(groupBoxTwitchSettings);
            tabPageMainSettings.Controls.Add(groupBoxArcdpsLogs);
            tabPageMainSettings.Location = new System.Drawing.Point(4, 29);
            tabPageMainSettings.Name = "tabPageMainSettings";
            tabPageMainSettings.Padding = new System.Windows.Forms.Padding(3);
            tabPageMainSettings.Size = new System.Drawing.Size(320, 654);
            tabPageMainSettings.TabIndex = 0;
            tabPageMainSettings.Text = "Main settings";
            // 
            // tabPageOtherSettings
            // 
            tabPageOtherSettings.BackColor = System.Drawing.Color.White;
            tabPageOtherSettings.Controls.Add(groupBoxOtherSettings);
            tabPageOtherSettings.Location = new System.Drawing.Point(4, 29);
            tabPageOtherSettings.Name = "tabPageOtherSettings";
            tabPageOtherSettings.Padding = new System.Windows.Forms.Padding(3);
            tabPageOtherSettings.Size = new System.Drawing.Size(320, 654);
            tabPageOtherSettings.TabIndex = 1;
            tabPageOtherSettings.Text = "Other settings";
            // 
            // timerFailedLogsReupload
            // 
            timerFailedLogsReupload.Interval = 900000;
            timerFailedLogsReupload.Tick += TimerFailedLogsReupload_Tick;
            // 
            // FormMain
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(816, 693);
            Controls.Add(tableLayoutPanelMainForm);
            Margin = new System.Windows.Forms.Padding(5);
            MinimumSize = new System.Drawing.Size(832, 730);
            Name = "FormMain";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "PlenBot Log Uploader";
            FormClosed += FormMain_FormClosed;
            Load += FormMain_Load;
            DragDrop += FormMain_DragDrop;
            DragEnter += FormMain_DragEnter;
            groupBoxTwitchSettings.ResumeLayout(false);
            groupBoxTwitchSettings.PerformLayout();
            groupBoxArcdpsLogs.ResumeLayout(false);
            groupBoxArcdpsLogs.PerformLayout();
            contextMenuStripIcon.ResumeLayout(false);
            groupBoxOtherSettings.ResumeLayout(false);
            groupBoxOtherSettings.PerformLayout();
            tableLayoutPanelMainForm.ResumeLayout(false);
            tabControlSettings.ResumeLayout(false);
            tabPageMainSettings.ResumeLayout(false);
            tabPageOtherSettings.ResumeLayout(false);
            ResumeLayout(false);
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
        private System.Windows.Forms.Button buttonGW2BotSettings;
        private System.Windows.Forms.Button buttonTeamsSettings;
        private System.Windows.Forms.CheckBox checkBoxAutoUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorOne;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDPSReportUserTokens;
        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.TabPage tabPageMainSettings;
        private System.Windows.Forms.TabPage tabPageOtherSettings;
        private System.Windows.Forms.Timer timerFailedLogsReupload;
        private System.Windows.Forms.CheckBox checkBoxUsePolling;
        private System.Windows.Forms.CheckBox checkBoxOnlyWhenStreamSoftwareRunning;
    }
}

