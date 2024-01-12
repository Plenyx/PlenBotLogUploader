using Hardstuck.GuildWars2.BuildCodes.V2;
using Hardstuck.GuildWars2.MumbleLink;
using Hardstuck.Http;
using Microsoft.Win32;
using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.DpsReport;
using PlenBotLogUploader.GitHub;
using PlenBotLogUploader.Gw2Api;
using PlenBotLogUploader.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitchIrcClient;

namespace PlenBotLogUploader
{
    public partial class FormMain : Form
    {
        #region definitions
        // properties
        internal List<DpsReportJson> SessionLogs { get; } = [];
        internal bool TwitchChannelJoined { get; set; } = false;
        internal HttpClientController HttpClientController { get; } = new();
        internal bool StartedMinimised { get; private set; } = false;
        internal MumbleReader MumbleReader { get; set; }
        internal bool UpdateFound
        {
            get => _updateFound;
            set
            {
                if (buttonUpdate.InvokeRequired)
                {
                    buttonUpdate.Invoke(() =>
                    {
                        buttonUpdate.Text = value ? "Update the uploader" : "Check for updates";
                        buttonUpdate.NotifyDefault(value);
                    });
                }
                else
                {
                    buttonUpdate.Text = value ? "Update the uploader" : "Check for updates";
                    buttonUpdate.NotifyDefault(value);
                }
                _updateFound = value;
            }
        }

        // fields
        private readonly FormTwitchNameSetup twitchNameLink;
        private readonly FormDpsReportSettings dpsReportSettingsLink;
        private readonly FormCustomName customNameLink;
        private readonly FormArcPluginManager arcPluginManagerLink;
        private readonly FormBossData bossDataLink;
        private readonly FormDiscordWebhooks discordWebhooksLink;
        private readonly FormPings pingsLink;
        private readonly FormTwitchCommands twitchCommandsLink;
        private readonly FormLogSession logSessionLink;
        private readonly FormGw2Api gw2APILink;
        private readonly FormAleevaIntegrations aleevaLink;
        private readonly FormGw2Bot gw2botLink;
        private readonly FormTeams teamsLink;
        private readonly List<string> allSessionLogs = [];
        private readonly Regex songSmartCommandRegex = songRegex();
        private readonly Regex buildSmartCommandRegex = buildRegex();
        private SemaphoreSlim semaphore;
        private TwitchChatClient chatConnect;
        private readonly ArcLogsChangeObserver watcher;
        private int reconnectedFailCounter = 0;
        private int recentUploadFailCounter = 0;
        private int logsCount = 0;
        private string lastLogMessage = "";
        private int lastLogBossId = 0;
        private int lastLogPullCounter = 0;
        private bool lastLogBossCM = false;
        private bool _updateFound = false;
        private GitHubReleaseLatest latestRelease = null;

        // constants
        private const int minFileSize = 8192;
        private const string plenbotVersionFileURL = "https://raw.githubusercontent.com/Plenyx/PlenBotLogUploader/master/VERSION";
        private const string plenbotDownloadName = "PlenBotLogUploader.exe";

        // partials
        [GeneratedRegex(@"(?:(?:build)){1}(?:(?:\?)|(?: is))+", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.CultureInvariant)]
        private static partial Regex buildRegex();
        [GeneratedRegex(@"(?:(?:song)|(?:music)){1}(?:(?:\?)|(?: is)|(?: name))+", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.CultureInvariant)]
        private static partial Regex songRegex();
        #endregion

        #region constructor
        internal FormMain()
        {
            ApplicationSettings.LocalDir = $"{Path.GetDirectoryName(Application.ExecutablePath.Replace('/', '\\'))}\\";
            ApplicationSettings.Load();
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            notifyIconTray.Icon = Properties.Resources.AppIcon;
            Text = $"{Text} r{ApplicationSettings.Version}";
            notifyIconTray.Text = $"{notifyIconTray.Text} r{ApplicationSettings.Version}";
            twitchNameLink = new FormTwitchNameSetup(this);
            dpsReportSettingsLink = new FormDpsReportSettings(this);
            customNameLink = new FormCustomName(this);
            pingsLink = new FormPings(this);
            arcPluginManagerLink = new FormArcPluginManager(this);
            bossDataLink = new FormBossData();
            discordWebhooksLink = new FormDiscordWebhooks(this);
            twitchCommandsLink = new FormTwitchCommands();
            logSessionLink = new FormLogSession(this);
            gw2APILink = new FormGw2Api(this);
            aleevaLink = new FormAleevaIntegrations(this);
            gw2botLink = new FormGw2Bot(this);
            teamsLink = new FormTeams();
            MumbleReader = new MumbleReader(false);
            watcher = new ArcLogsChangeObserver(OnLogCreated);
            #region tooltips
            toolTip.SetToolTip(checkBoxUploadLogs, "If checked, all created logs will be uploaded.");
            toolTip.SetToolTip(checkBoxPostToTwitch, "If checked, logs will be posted to connected Twitch channel.");
            toolTip.SetToolTip(checkBoxTwitchOnlySuccess, "If checked, only successful logs will be linked to Twitch channel.");
            toolTip.SetToolTip(checkBoxOnlyWhenStreamSoftwareRunning, "If checked, logs will be posted to connected Twitch channel only if a streaming software is running like OBS Studio, Twitch Studio or XSplit.");
            toolTip.SetToolTip(checkBoxAnonymiseReports, "If checked, the logs will be generated with fake names and accounts.");
            toolTip.SetToolTip(checkBoxDetailedWvW, "If checked, extended per-target log reports will be generated. (might cause some issues)");
            toolTip.SetToolTip(labelMaximumUploads, "Sets the maximum allowed uploads for drag & drop.");
            toolTip.SetToolTip(buttonCopyApplicationSession, "Copies all the logs uploaded during the application session into the clipboard.");
            toolTip.SetToolTip(checkBoxAutoUpdate, "Automatically downloads the newest version when it is available.\nOnly occurs during the start of the application.");
            toolTip.SetToolTip(twitchCommandsLink.checkBoxSongEnable, "If checked, the given command will output current song from Spotify to Twitch chat.");
            #endregion
            try
            {
                Size = ApplicationSettings.Current.MainFormSize;
                semaphore = new SemaphoreSlim(ApplicationSettings.Current.MaxConcurrentUploads, ApplicationSettings.Current.MaxConcurrentUploads);
                comboBoxMaxUploads.Text = ApplicationSettings.Current.MaxConcurrentUploads.ToString();
                if (ApplicationSettings.Current.FirstApplicationRun)
                {
                    MessageBox.Show("It looks like this is the first time you are running this program.\nIf you have any issues feel free to contact me directly via Twitch, Discord (@Plenyx#1029) or via GitHub!\n\nPlenyx", "Thank you for using PlenBotLogUploader", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var arcFolder = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Guild Wars 2\\addons\\arcdps\\arcdps.cbtlogs\\";
                    if (Directory.Exists(arcFolder))
                    {
                        ApplicationSettings.Current.LogsLocation = arcFolder;
                        MessageBox.Show($"arcdps log folder has been automatically set to\n{arcFolder}", "arcdps log folder automatically set", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    twitchNameLink.ShowDialog();
                    ApplicationSettings.Current.FirstApplicationRun = false;
                }
                if (ApplicationSettings.Current.LogsLocation.Equals("") || !Directory.Exists(ApplicationSettings.Current.LogsLocation))
                {
                    labelLocationInfo.Text = "!!! Select a directory with arc logs !!!";
                }
                else
                {
                    if (Directory.Exists(ApplicationSettings.Current.LogsLocation))
                    {
                        LogsScan(ApplicationSettings.Current.LogsLocation);
                        watcher.InitAndStart(ApplicationSettings.Current.LogsLocation, ApplicationSettings.Current.UsePollingForLogs ? ArcLogsChangeObserverMode.Polling : default);
                        buttonOpenLogs.Enabled = true;
                    }
                    else
                    {
                        ApplicationSettings.Current.LogsLocation = "";
                        labelLocationInfo.Text = "!!! Select a directory with arc logs !!!";
                    }
                }
                ApplicationSettings.Current.Twitch.ChannelName = ApplicationSettings.Current.Twitch.ChannelName.ToLower();
                if (ApplicationSettings.Current.Twitch.ChannelName != "")
                {
                    twitchNameLink.textBoxChannelUrl.Text = $"https://twitch.tv/{ApplicationSettings.Current.Twitch.ChannelName}/";
                }
                switch (ApplicationSettings.Current.Upload.DpsReportServer)
                {
                    case DpsReportServer.A:
                        dpsReportSettingsLink.radioButtonA.Checked = true;
                        break;
                    case DpsReportServer.B:
                        dpsReportSettingsLink.radioButtonB.Checked = true;
                        break;
                }
                if (ApplicationSettings.Current.Upload.Enabled)
                {
                    checkBoxUploadLogs.Checked = true;
                    checkBoxPostToTwitch.Enabled = true;
                    toolStripMenuItemUploadLogs.Checked = true;
                    toolStripMenuItemPostToTwitch.Enabled = true;
                }
                if (ApplicationSettings.Current.Upload.PostLogsToTwitch)
                {
                    checkBoxPostToTwitch.Checked = true;
                    checkBoxPostToTwitch.Enabled = true;
                    toolStripMenuItemPostToTwitch.Checked = true;
                    toolStripMenuItemPostToTwitch.Enabled = true;
                    checkBoxTwitchOnlySuccess.Enabled = true;
                    if (ApplicationSettings.Current.Upload.PostLogsToTwitchOnlySuccess)
                    {
                        checkBoxTwitchOnlySuccess.Checked = true;
                    }
                    if (ApplicationSettings.Current.Upload.PostLogsToTwitchOnlyWithStreamingSoftware)
                    {
                        checkBoxOnlyWhenStreamSoftwareRunning.Checked = true;
                    }
                }
                if (ApplicationSettings.Current.MinimiseToTray)
                {
                    checkBoxTrayMinimiseToIcon.Checked = true;
                }
                if (ApplicationSettings.Current.AutoUpdate)
                {
                    checkBoxAutoUpdate.Checked = true;
                }
                if (ApplicationSettings.Current.Upload.Anonymous)
                {
                    checkBoxAnonymiseReports.Checked = true;
                }
                if (ApplicationSettings.Current.Upload.DetailedWvw)
                {
                    checkBoxDetailedWvW.Checked = true;
                }
                if (ApplicationSettings.Current.Upload.SaveToCsvEnabled)
                {
                    checkBoxSaveLogsToCSV.Checked = true;
                }
                if (ApplicationSettings.Current.UsePollingForLogs)
                {
                    checkBoxUsePolling.Checked = true;
                }
                if (ApplicationSettings.Current.Twitch.Custom.Enabled)
                {
                    customNameLink.checkBoxCustomNameEnable.Checked = true;
                    ApplicationSettings.Current.Twitch.Custom.Name = ApplicationSettings.Current.Twitch.Custom.Name.ToLower();
                    customNameLink.textBoxCustomName.Text = ApplicationSettings.Current.Twitch.Custom.Name;
                    customNameLink.textBoxCustomOAuth.Text = ApplicationSettings.Current.Twitch.Custom.OauthPassword;
                }
                arcPluginManagerLink.checkBoxEnableNotifications.Checked = ApplicationSettings.Current.ArcUpdate.Notifications;
                if (!string.IsNullOrWhiteSpace(ApplicationSettings.Current.Gw2Location))
                {
                    if (File.Exists($@"{ApplicationSettings.Current.Gw2Location}\Gw2-64.exe") || File.Exists($@"{ApplicationSettings.Current.Gw2Location}\Gw2.exe") || File.Exists($@"{ApplicationSettings.Current.Gw2Location}\Guild Wars 2.exe"))
                    {
                        if (ApplicationSettings.Current.ArcUpdate.Enabled)
                        {
                            arcPluginManagerLink.checkBoxModuleEnabled.Checked = true;
                            _ = arcPluginManagerLink.StartTimerAsync(true, true);
                        }
                    }
                    else
                    {
                        ShowBalloon("arcdps plugin manager", "There has been an error locating the main Guild Wars 2 folder, try changing the directory again.", 6500);
                        ApplicationSettings.Current.Gw2Location = "";
                    }
                }
                twitchCommandsLink.checkBoxGW2BuildEnable.Checked = ApplicationSettings.Current.Twitch.Commands.BuildEnabled;
                twitchCommandsLink.textBoxGW2Build.Text = ApplicationSettings.Current.Twitch.Commands.BuildCommand;
                twitchCommandsLink.checkBoxUploaderEnable.Checked = ApplicationSettings.Current.Twitch.Commands.UploaderEnabled;
                twitchCommandsLink.textBoxUploaderCommand.Text = ApplicationSettings.Current.Twitch.Commands.UploaderCommand;
                twitchCommandsLink.checkBoxLastLogEnable.Checked = ApplicationSettings.Current.Twitch.Commands.LastLogEnabled;
                twitchCommandsLink.textBoxLastLogCommand.Text = ApplicationSettings.Current.Twitch.Commands.LastLogCommand;
                twitchCommandsLink.checkBoxSongEnable.Checked = ApplicationSettings.Current.Twitch.Commands.SongEnabled;
                twitchCommandsLink.textBoxSongCommand.Text = ApplicationSettings.Current.Twitch.Commands.SongCommand;
                twitchCommandsLink.checkBoxSongSmartRecognition.Checked = ApplicationSettings.Current.Twitch.Commands.SongSmartRecognition;
                twitchCommandsLink.checkBoxGW2IgnEnable.Checked = ApplicationSettings.Current.Twitch.Commands.IgnEnabled;
                twitchCommandsLink.textBoxGW2Ign.Text = ApplicationSettings.Current.Twitch.Commands.IgnCommand;
                twitchCommandsLink.checkBoxPullCounterEnable.Checked = ApplicationSettings.Current.Twitch.Commands.PullCounterEnabled;
                twitchCommandsLink.textBoxPullCounter.Text = ApplicationSettings.Current.Twitch.Commands.PullCounterCommand;
                logSessionLink.textBoxSessionName.Text = ApplicationSettings.Current.Session.Name;
                logSessionLink.checkBoxSupressWebhooks.Checked = ApplicationSettings.Current.Session.SupressWebhooks;
                logSessionLink.checkBoxOnlySuccess.Checked = ApplicationSettings.Current.Session.OnlySuccess;
                logSessionLink.textBoxSessionContent.Text = ApplicationSettings.Current.Session.Message;
                logSessionLink.radioButtonSortByUpload.Checked = ApplicationSettings.Current.Session.Sort == LogSessionSortBy.UploadTime;
                logSessionLink.checkBoxSaveToFile.Checked = ApplicationSettings.Current.Session.SaveToFile;
                logSessionLink.checkBoxMakeWvWSummary.Checked = ApplicationSettings.Current.Session.MakeWvwSummaryEmbed;
                discordWebhooksLink.checkBoxShortenThousands.Checked = ApplicationSettings.Current.ShortenThousands;
                if (!string.IsNullOrWhiteSpace(ApplicationSettings.Current.Aleeva.RefreshToken) && (DateTime.Now < ApplicationSettings.Current.Aleeva.RefreshTokenExpire))
                {
                    Task.Run(aleevaLink.GetAleevaTokenFromRefreshToken);
                }
                if (ApplicationSettings.Current.LogsLocation.Equals("") || !Directory.Exists(ApplicationSettings.Current.LogsLocation))
                {
                    MessageBox.Show("Path to arcdps logs is not set.\nDo not forget to set it up so the logs can be auto-uploaded.", "Just a reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (ApplicationSettings.Current.Twitch.ConnectToTwitch)
                {
                    if (ApplicationSettings.Current.Twitch.Custom.Enabled)
                    {
                        chatConnect = new TwitchChatClient(ApplicationSettings.Current.Twitch.Custom.Name, ApplicationSettings.Current.Twitch.Custom.OauthPassword);
                    }
                    else
                    {
                        chatConnect = new TwitchChatClient("gw2loguploader", "oauth:ycgqr3dyef7gp5r8uk7d5jz30nbrc6");
                    }
                    chatConnect.ReceivedMessage += ReadMessagesAsync;
                    chatConnect.StateChanged += OnIrcStateChanged;
                    chatConnect.BeginConnection();
                }
                else
                {
                    buttonDisConnectTwitch.Text = "Connect to Twitch";
                    buttonChangeTwitchChannel.Enabled = false;
                    toolStripMenuItemPostToTwitch.Enabled = false;
                    toolStripMenuItemOpenTwitchCommands.Enabled = false;
                    buttonReconnectBot.Enabled = false;
                    buttonTwitchCommands.Enabled = false;
                    checkBoxPostToTwitch.Enabled = false;
                }
                if (!File.Exists($"{ApplicationSettings.LocalDir}uploaded_logs.csv"))
                {
                    File.AppendAllText($"{ApplicationSettings.LocalDir}uploaded_logs.csv", "Boss;BossId;Success;Duration;RecordedBy;EliteInsightsVersion;arcdpsVersion;Permalink;UserToken\n");
                }
                // API keys check
                _ = ValidateGW2Tokens();
                // Windows startup check
                using (var registrySubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
                {
                    var registryValue = registrySubKey.GetValue("PlenBot Log Uploader");
                    if ((registryValue is not null) && ((string)registryValue).Contains(Application.ExecutablePath.Replace('/', '\\')))
                    {
                        checkBoxStartWhenWindowsStarts.Checked = true;
                    }
                }
                /* Subscribe to field changes events, otherwise they would trigger on load */
                checkBoxPostToTwitch.CheckedChanged += CheckBoxPostToTwitch_CheckedChanged;
                checkBoxUploadLogs.CheckedChanged += CheckBoxUploadAll_CheckedChanged;
                checkBoxTrayMinimiseToIcon.CheckedChanged += CheckBoxTrayMinimiseToIcon_CheckedChanged;
                checkBoxTwitchOnlySuccess.CheckedChanged += CheckBoxTwitchOnlySuccess_CheckedChanged;
                checkBoxOnlyWhenStreamSoftwareRunning.CheckedChanged += CheckBoxOnlyWhenStreamSoftwareRunning_CheckedChanged;
                checkBoxStartWhenWindowsStarts.CheckedChanged += CheckBoxStartWhenWindowsStarts_CheckedChanged;
                checkBoxAnonymiseReports.CheckedChanged += CheckBoxAnonymiseReports_CheckedChanged;
                checkBoxDetailedWvW.CheckedChanged += CheckBoxDetailedWvW_CheckedChanged;
                checkBoxSaveLogsToCSV.CheckedChanged += CheckBoxSaveLogsToCSV_CheckedChanged;
                checkBoxUsePolling.CheckedChanged += CheckBoxUsePolling_CheckedChanged;
                comboBoxMaxUploads.SelectedIndexChanged += ComboBoxMaxUploads_SelectedIndexChanged;
                checkBoxAutoUpdate.CheckedChanged += CheckBoxAutoUpdate_CheckedChanged;
                logSessionLink.checkBoxSupressWebhooks.CheckedChanged += logSessionLink.CheckBoxSupressWebhooks_CheckedChanged;
                logSessionLink.checkBoxOnlySuccess.CheckedChanged += logSessionLink.CheckBoxOnlySuccess_CheckedChanged;
                logSessionLink.checkBoxSaveToFile.CheckedChanged += logSessionLink.CheckBoxSaveToFile_CheckedChanged;
                discordWebhooksLink.checkBoxShortenThousands.CheckedChanged += discordWebhooksLink.CheckBoxShortenThousands_CheckedChanged;
                ApplicationSettings.Current.Save();
            }
            catch (Exception e)
            {
                MessageBox.Show($"An error has been encountered in the configuration.\n\n{e.Message}\n\nIf the problem persists, try deleting the configuration file and try again.", "An error has occurred");
                ExitApp();
            }
        }
        #endregion

        #region form events
        private async void FormMain_Load(object sender, EventArgs e)
        {
            Resize += FormMain_Resize;
            await StartUpAndCommandArgs();
            await NewReleaseCheckAsync(true, true);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ApplicationSettings.Current.Save();
            chatConnect?.Dispose();
            semaphore?.Dispose();
            HttpClientController?.Dispose();
            watcher?.Dispose();
            MumbleReader?.Dispose();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (WindowState.Equals(FormWindowState.Minimized) && checkBoxTrayMinimiseToIcon.Checked)
            {
                ShowInTaskbar = false;
                Hide();
                if (ApplicationSettings.Current.FirstTimeMinimised)
                {
                    ShowBalloon("Uploader minimised", "Double click the icon to bring back the uploader.\nYou can also right click for quick settings.", 6500);
                    ApplicationSettings.Current.FirstTimeMinimised = false;
                    ApplicationSettings.Current.Save();
                }
            }
            if (WindowState.Equals(FormWindowState.Normal))
            {
                ApplicationSettings.Current.MainFormSize = Size;
                ApplicationSettings.Current.MainFormState = WindowState;
            }
            if (WindowState.Equals(FormWindowState.Maximized))
            {
                ApplicationSettings.Current.MainFormState = WindowState;
            }
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            foreach (var file in ((string[])e.Data.GetData(DataFormats.FileDrop)).AsSpan())
            {
                Task.Run(async () =>
                {
                    semaphore.Wait();
                    await DoDragDropFile(file);
                    semaphore.Release();
                });
            }
        }

        protected async Task DoDragDropFile(string file)
        {
            var postData = new Dictionary<string, string>()
            {
                { "generator", "ei" },
                { "json", "1" }
            };
            if (File.Exists(file) && (file.EndsWith(".evtc") || file.EndsWith(".zevtc")))
            {
                var archived = false;
                var zipfilelocation = file;
                if (!file.EndsWith(".zevtc"))
                {
                    zipfilelocation = $"{ApplicationSettings.LocalDir}{Path.GetFileNameWithoutExtension(file)}.zevtc";
                    using var zipfile = ZipFile.Open(zipfilelocation, ZipArchiveMode.Create);
                    zipfile.CreateEntryFromFile(@file, Path.GetFileName(file));
                    archived = true;
                }
                try
                {
                    await HttpUploadLogAsync(zipfilelocation, postData, true);
                }
                catch
                {
                    AddToText($">:> Unknown error uploading a log: {zipfilelocation}");
                }
                finally
                {
                    if (archived)
                    {
                        File.Delete(zipfilelocation);
                    }
                }
            }
        }

        private void RichTextBoxUploadInfo_LinkClicked(object sender, LinkClickedEventArgs e) => Process.Start(new ProcessStartInfo() { UseShellExecute = true, FileName = e.LinkText });
        #endregion

        #region main program methods
        private async void OnLogCreated(FileInfo file)
        {
            logsCount++;
            if (!checkBoxUploadLogs.Checked)
            {
                return;
            }
            try
            {
                if (file.Length >= minFileSize)
                {
                    var zipfilelocation = file.FullName;
                    var archived = false;
                    // a workaround so arcdps can release the file for read access
                    Thread.Sleep(1000);
                    if (!file.FullName.EndsWith(".zevtc"))
                    {
                        zipfilelocation = $"{ApplicationSettings.LocalDir}{Path.GetFileNameWithoutExtension(file.FullName)}.zevtc";
                        using var zipfile = ZipFile.Open(zipfilelocation, ZipArchiveMode.Create);
                        zipfile.CreateEntryFromFile(file.FullName, file.Name);
                        archived = true;
                    }
                    try
                    {
                        var postData = new Dictionary<string, string>()
                        {
                            { "generator", "ei" },
                            { "json", "1" }
                        };
                        await HttpUploadLogAsync(zipfilelocation, postData);
                    }
                    finally
                    {
                        if (archived)
                        {
                            File.Delete(zipfilelocation);
                        }
                    }
                }
            }
            catch
            {
                logsCount--;
                AddToText($">:> Unable to upload the file: {file.FullName}");
            }
            UpdateLogCount();
        }

        internal void ShowBalloon(string title, string description, int ms)
        {
            MumbleReader?.Update();
            if (!MumbleReader?.Data.Context.UIState.HasFlag(UIState.IsInCombat) ?? true)
            {
                notifyIconTray.ShowBalloonTip(ms, title, description, ToolTipIcon.Info);
                return;
            }
            Task.Run(() =>
            {
                Task.Delay(30000);
                ShowBalloon(title, description, ms);
            });
        }

        private void LogsScan(string directory)
        {
            foreach (ReadOnlySpan<char> file in Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories).AsSpan())
            {
                if (file.EndsWith(".evtc") || file.EndsWith(".zevtc"))
                {
                    logsCount++;
                }
            }
            UpdateLogCount();
        }

        protected async Task NewReleaseCheckAsync(bool appStartup = false, bool quietFail = false)
        {
            try
            {
                if (buttonUpdate.InvokeRequired)
                {
                    buttonUpdate.Invoke((Action)(() => buttonUpdate.Enabled = false));
                }
                else
                {
                    buttonUpdate.Enabled = false;
                }
                var response = await HttpClientController.DownloadFileToStringAsync(plenbotVersionFileURL) ?? "0";
                if (!int.TryParse(response, out var currentVersion))
                {
                    if (!quietFail)
                    {
                        AddToText(">>> Could not verify the version release.");
                    }
                    timerCheckUpdate.Enabled = true;
                    timerCheckUpdate.Start();
                    return;
                }
                if (currentVersion <= ApplicationSettings.Version)
                {
                    if (!quietFail)
                    {
                        AddToText(">>> The uploader is up to date.");
                    }
                    timerCheckUpdate.Enabled = true;
                    timerCheckUpdate.Start();
                    return;
                }
                UpdateFound = true;
                latestRelease = await HttpClientController.GetGitHubLatestReleaseAsync("Plenyx/PlenBotLogUploader");
                if (appStartup && ApplicationSettings.Current.AutoUpdate && latestRelease is not null)
                {
                    await PerformUpdate(appStartup);
                    return;
                }
                AddToText($">>> New release available (r{response})");
                AddToText(">>> Read about all the changes here: https://github.com/Plenyx/PlenBotLogUploader/releases/latest");
                ShowBalloon("New release available for the uploader", $"If you want to update immediately, use the \"Update the uploader\" button.\nThe latest release is n. {response}.", 8500);
            }
            catch
            {
                if (!quietFail)
                {
                    AddToText(">>> Unable to check new release version.");
                }
            }
            finally
            {
                if (buttonUpdate.InvokeRequired)
                {
                    buttonUpdate.Invoke((Action)(() => buttonUpdate.Enabled = true));
                }
                else
                {
                    buttonUpdate.Enabled = true;
                }
            }
        }

        private void ExitApp()
        {
            if (InvokeRequired)
            {
                Invoke(ExitApp);
                return;
            }
            Close();
            Application.Exit();
        }

        protected async Task StartUpAndCommandArgs()
        {
            WindowState = ApplicationSettings.Current.MainFormState;
            var args = Environment.GetCommandLineArgs();
            if (args.Length <= 1)
            {
                return;
            }
            if (((args.Length == 2) || (args.Length == 3)) && args[1].Equals("-m"))
            {
                StartedMinimised = true;
                WindowState = FormWindowState.Minimized;
                if (checkBoxTrayMinimiseToIcon.Checked)
                {
                    ShowInTaskbar = false;
                    Hide();
                }
                return;
            }
            var postData = new Dictionary<string, string>()
            {
                { "generator", "ei" },
                { "json", "1" }
            };
            foreach (var arg in args)
            {
                if (arg.Equals(Application.ExecutablePath))
                {
                    continue;
                }
                if (File.Exists(arg) && (arg.EndsWith(".evtc") || arg.EndsWith(".zevtc")))
                {
                    var archived = false;
                    var zipfilelocation = arg;
                    if (!arg.EndsWith(".zevtc"))
                    {
                        zipfilelocation = $"{ApplicationSettings.LocalDir}{Path.GetFileNameWithoutExtension(arg)}.zevtc";
                        using var zipfile = ZipFile.Open(zipfilelocation, ZipArchiveMode.Create);
                        zipfile.CreateEntryFromFile(@arg, Path.GetFileName(arg));
                        archived = true;
                    }
                    try
                    {
                        await HttpUploadLogAsync(zipfilelocation, postData);
                    }
                    catch
                    {
                        AddToText($">>> Unknown error uploading a log: {zipfilelocation}");
                    }
                    finally
                    {
                        if (archived)
                        {
                            File.Delete(zipfilelocation);
                        }
                    }
                }
            }
            LogReuploader.ProcessLogs(HttpUploadLogAsync);
        }

        protected async Task ValidateGW2Tokens()
        {
            foreach (var apiKey in ApplicationSettings.Current.Gw2Apis)
            {
                await apiKey.ValidateToken(HttpClientController);
            }
            gw2APILink.RedrawList();
        }
        #endregion

        #region self-invocable functions
        internal void AddToText(string textToAdd)
        {
            if (richTextBoxMainConsole.InvokeRequired)
            {
                richTextBoxMainConsole.Invoke((string text) => AddToText(text), textToAdd);
                return;
            }
            var messagePre = textToAdd.IndexOf(' ');
            if (messagePre != -1)
            {
                richTextBoxMainConsole.SelectionColor = Color.Blue;
                richTextBoxMainConsole.AppendText(textToAdd[..(messagePre + 1)]);
                richTextBoxMainConsole.SelectionColor = Color.Black;
                richTextBoxMainConsole.AppendText(string.Concat(textToAdd.AsSpan(messagePre), Environment.NewLine));
            }
            else
            {
                richTextBoxMainConsole.AppendText(textToAdd + Environment.NewLine);
            }
            richTextBoxMainConsole.SelectionStart = richTextBoxMainConsole.TextLength;
            richTextBoxMainConsole.ScrollToCaret();
        }

        private void UpdateLogCount()
        {
            if (labelLocationInfo.InvokeRequired)
            {
                labelLocationInfo.Invoke(UpdateLogCount);
                return;
            }
            labelLocationInfo.Text = $"Logs in the directory: {logsCount}";
        }
        #endregion

        #region log upload and processing
        internal async Task SendLogToTwitchChatAsync(DpsReportJson reportJSON, bool bypassMessage = false)
        {
            if (!TwitchChannelJoined || !checkBoxPostToTwitch.Checked || bypassMessage || (ApplicationSettings.Current.Upload.PostLogsToTwitchOnlyWithStreamingSoftware && !IsStreamingSoftwareRunning()))
            {
                return;
            }
            var bossData = Bosses.GetBossDataFromId(reportJSON.ExtraJson?.TriggerId ?? reportJSON.Encounter.BossId);
            if (bossData is null)
            {
                lastLogMessage = $"Link to the last log: {reportJSON.ConfigAwarePermalink}";
                await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, lastLogMessage);
                return;
            }
            var format = bossData.TwitchMessageFormat(reportJSON, lastLogPullCounter);
            if (!string.IsNullOrWhiteSpace(format))
            {
                lastLogMessage = format;
                await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, lastLogMessage);
            }
        }

        internal async Task HttpUploadLogAsync(string file, Dictionary<string, string> postData, bool bypassMessage = false)
        {
            using var content = new MultipartFormDataContent();
            foreach (var key in postData.Keys)
            {
                content.Add(new StringContent(postData[key]), key);
            }
            AddToText($">:> Uploading {Path.GetFileName(file)}");
            var bossId = 1;
            try
            {
                using var inputStream = File.OpenRead(file);
                using var contentStream = new StreamContent(inputStream);
                content.Add(contentStream, "file", Path.GetFileName(file));
                try
                {
                    using var responseMessage = await HttpClientController.PostAsync(CreateDPSReportLink(), content);
                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        if ((int)responseMessage.StatusCode == 429)
                        {
                            AddToText($">:> Unable to upload file {Path.GetFileName(file)}, dps.report responded with Too-Many-Logs-Per-Minute error (429). Log will be reuploaded in 15 minutes.");
                            LogReuploader.FailedLogs.Add(file);
                            LogReuploader.SaveFailedLogs();
                            timerFailedLogsReupload.Enabled = true;
                            timerFailedLogsReupload.Stop();
                            timerFailedLogsReupload.Start();
                            return;
                        }
                        AddToText($">:> Unable to upload file {Path.GetFileName(file)}, dps.report responded with an non-ok status code ({(int)responseMessage.StatusCode})");
                        return;
                    }
                    var response = await responseMessage.Content.ReadAsStringAsync();
                    // workaround for deserialisation application crash if the player list is an empty array, in case the log being corrupted
                    response = response?.Replace("\"players\": []", "\"players\": {}");
                    try
                    {
                        var reportJson = JsonConvert.DeserializeObject<DpsReportJson>(response);
                        if (!string.IsNullOrEmpty(reportJson.Error))
                        {
                            AddToText($">:> Unable to process file {Path.GetFileName(file)}, dps.report responded with following error message: {reportJson.Error}");
                            return;
                        }
                        bossId = reportJson.Encounter.BossId;
                        var success = (reportJson.Encounter.Success ?? false) ? "true" : "false";
                        lastLogBossCM = reportJson.ChallengeMode;
                        // extra JSON from Elite Insights
                        if (reportJson.Encounter.JsonAvailable ?? false)
                        {
                            try
                            {
                                var jsonString = await HttpClientController.DownloadFileToStringAsync($"{ApplicationSettings.Current.Upload.DPSReportServerLink}/getJson?permalink={reportJson.ConfigAwarePermalink}");
                                var extraJson = JsonConvert.DeserializeObject<DpsReportJsonExtraJson>(jsonString);
                                if (extraJson?.Duration != null)
                                {
                                    reportJson.ExtraJson = extraJson;
                                    bossId = reportJson.ExtraJson.TriggerId;
                                    lastLogBossCM = reportJson.ChallengeMode;
                                }
                                else
                                {
                                    AddToText(">:> Extra JSON available but couldn't be obtained.");
                                }
                            }
                            catch
                            {
                                AddToText(">:> Extra JSON available but couldn't be obtained.");
                                reportJson.ExtraJson = null;
                                bossId = reportJson.Encounter.BossId;
                            }
                        }
                        if (ApplicationSettings.Current.Upload.SaveToCsvEnabled)
                        {
                            try
                            {
                                // log file
                                File.AppendAllText($"{ApplicationSettings.LocalDir}uploaded_logs.csv", $"{reportJson.ExtraJson?.FightName ?? reportJson.Encounter.Boss};{bossId};{success};{reportJson.ExtraJson?.Duration ?? ""};{reportJson.ExtraJson?.RecordedBy ?? ""};{reportJson.ExtraJson?.EliteInsightsVersion ?? ""};{reportJson.Evtc.Type}{reportJson.Evtc.Version};{reportJson.ConfigAwarePermalink};{reportJson.UserToken}\n");
                            }
                            catch (Exception e)
                            {
                                AddToText($">:> There has been an error saving file {Path.GetFileName(file)} to the main CSV: {e.Message}");
                            }
                        }
                        // save to clipboard list
                        allSessionLogs.Add(reportJson.ConfigAwarePermalink);
                        // Twitch chat
                        lastLogMessage = $"Link to the last log: {reportJson.ConfigAwarePermalink}";
                        if (lastLogBossId != bossId)
                        {
                            lastLogPullCounter = 0;
                        }
                        lastLogBossId = bossId;
                        lastLogPullCounter = (reportJson.Encounter.Success ?? false) ? 0 : lastLogPullCounter + 1;
                        AddToText($">:> {reportJson.ConfigAwarePermalink}");
                        if (checkBoxTwitchOnlySuccess.Checked && (reportJson.Encounter.Success ?? false))
                        {
                            await SendLogToTwitchChatAsync(reportJson, bypassMessage);
                        }
                        else if (checkBoxTwitchOnlySuccess.Checked)
                        {
                            await SendLogToTwitchChatAsync(reportJson, true);
                        }
                        else
                        {
                            await SendLogToTwitchChatAsync(reportJson, bypassMessage);
                        }
                        var players = reportJson.GetLogPlayers();
                        // Discord webhooks & log sessions
                        await ExecuteAllDiscordWebhooks(reportJson, players);
                        // remote server ping
                        await pingsLink.ExecuteAllPingsAsync(reportJson);
                        // aleeva integration
                        await aleevaLink.ExecuteAllActiveAleevaIntegrations(reportJson, players);
                        // gw2bot integration
                        await gw2botLink.PostLogToGW2Bot(reportJson, players);
                        // report success
                        AddToText($">:> {Path.GetFileName(file)} successfully uploaded.");
                        // remove from failed logs if present
                        var removed = LogReuploader.FailedLogs.Remove(file);
                        if (removed)
                        {
                            LogReuploader.SaveFailedLogs();
                        }
                    }
                    catch (Exception e)
                    {
                        AddToText($">:> There has been an error processing file {Path.GetFileName(file)}: {e.Message}");
                    }
                }
                catch
                {
                    AddToText($">:> Unable to upload file {Path.GetFileName(file)}, dps.report not responding");
                    Interlocked.Increment(ref recentUploadFailCounter);
                    if (recentUploadFailCounter > 3)
                    {
                        Interlocked.Exchange(ref recentUploadFailCounter, 0);
                        AddToText($">:> Upload retry failed 3 times for {Path.GetFileName(file)}, will try again in 15m.");
                        LogReuploader.FailedLogs.Add(file);
                        LogReuploader.SaveFailedLogs();
                        timerFailedLogsReupload.Enabled = true;
                        timerFailedLogsReupload.Stop();
                        timerFailedLogsReupload.Start();
                    }
                    else
                    {
                        var delay = recentUploadFailCounter switch
                        {
                            3 => 45000,
                            2 => 15000,
                            _ => 3000,
                        };
                        AddToText($">:> Retrying in {delay / 1000}s...");
                        await Task.Delay(delay);
                        await HttpUploadLogAsync(file, postData, bypassMessage);
                    }
                }
            }
            catch
            {
                Thread.Sleep(1000);
                await HttpUploadLogAsync(file, postData, bypassMessage);
            }
        }

        internal async Task ExecuteAllDiscordWebhooks(DpsReportJson reportJson, List<LogPlayer> players)
        {
            if (logSessionLink.SessionRunning)
            {
                if (logSessionLink.checkBoxOnlySuccess.Checked && (reportJson.Encounter.Success ?? false))
                {
                    SessionLogs.Add(reportJson);
                }
                else if (!logSessionLink.checkBoxOnlySuccess.Checked)
                {
                    SessionLogs.Add(reportJson);
                }
                if (!logSessionLink.checkBoxSupressWebhooks.Checked)
                {
                    await discordWebhooksLink.ExecuteAllActiveWebhooksAsync(reportJson, players);
                }
            }
            else
            {
                await discordWebhooksLink.ExecuteAllActiveWebhooksAsync(reportJson, players);
            }
        }

        internal async Task ExecuteSessionLogWebhooksAsync(LogSessionSettings logSessionSettings)
        {
            if (SessionLogs is null)
            {
                AddToText("There was an error processing log session logs. SessionLogs is null.");
                return;
            }
            var builder = new StringBuilder($">:> Session summary:{Environment.NewLine}");
            foreach (var log in SessionLogs)
            {
                builder.Append(log.ExtraJson?.FightName ?? log.Encounter.Boss).Append(": ").AppendLine(log.ConfigAwarePermalink);
            }
            AddToText(builder.ToString());
            await discordWebhooksLink.ExecuteSessionWebhooksAsync(SessionLogs, logSessionSettings);
        }

        private static string CreateDPSReportLink()
        {
            var builder = new StringBuilder();
            builder.Append(ApplicationSettings.Current.Upload.DPSReportServerLink).Append("/uploadContent");
            builder.Append("?json=1&generator=ei");
            if (ApplicationSettings.Current.Upload.DpsReportUserTokens.Count(x => x.Active) == 1)
            {
                builder.Append("&userToken=").Append(ApplicationSettings.Current.Upload.DpsReportUserTokens.Find(x => x.Active).UserToken);
            }
            if (ApplicationSettings.Current.Upload.Anonymous)
            {
                builder.Append("&anonymous=true");
            }
            if (ApplicationSettings.Current.Upload.DetailedWvw)
            {
                builder.Append("&detailedwvw=true");
            }
            return builder.ToString();
        }
        #endregion

        #region Twitch bot methods
        internal bool IsTwitchConnectionNull() => chatConnect is null;

        internal static bool IsStreamingSoftwareRunning()
        {
            Span<char> processNameLower = stackalloc char[50];
            foreach (var process in Process.GetProcesses().AsSpan())
            {
                ReadOnlySpan<char> processName = process.ProcessName;
                processName.ToLowerInvariant(processNameLower);
                if (processNameLower.StartsWith("obs")
                    || processNameLower.StartsWith("streamlabs obs")
                    || processNameLower.StartsWith("twitchstudio"))
                {
                    return true;
                }
            }
            return false;
        }

        internal async Task ConnectTwitchBot()
        {
            if (InvokeRequired)
            {
                Invoke(delegate { _ = ConnectTwitchBot(); });
                return;
            }
            buttonDisConnectTwitch.Text = "Disconnect from Twitch";
            buttonReconnectBot.Enabled = true;
            buttonChangeTwitchChannel.Enabled = true;
            toolStripMenuItemPostToTwitch.Enabled = true;
            toolStripMenuItemOpenTwitchCommands.Enabled = true;
            buttonCustomName.Enabled = true;
            buttonTwitchCommands.Enabled = true;
            checkBoxPostToTwitch.Enabled = true;
            if (ApplicationSettings.Current.Twitch.Custom.Enabled)
            {
                chatConnect = new TwitchChatClient(ApplicationSettings.Current.Twitch.Custom.Name, ApplicationSettings.Current.Twitch.Custom.OauthPassword);
            }
            else
            {
                chatConnect = new TwitchChatClient("gw2loguploader", "oauth:ycgqr3dyef7gp5r8uk7d5jz30nbrc6");
            }
            chatConnect.ReceivedMessage += ReadMessagesAsync;
            chatConnect.StateChanged += OnIrcStateChanged;
            await chatConnect.BeginConnectionAsync();
            ApplicationSettings.Current.Twitch.ConnectToTwitch = true;
            ApplicationSettings.Current.Save();
        }

        internal void DisconnectTwitchBot()
        {
            if (InvokeRequired)
            {
                Invoke(DisconnectTwitchBot);
                return;
            }
            chatConnect.ReceivedMessage -= ReadMessagesAsync;
            chatConnect.StateChanged -= OnIrcStateChanged;
            chatConnect.Dispose();
            chatConnect = null;
            AddToText("<-?-> CONNECTION CLOSED");
            buttonDisConnectTwitch.Text = "Connect to Twitch";
            buttonChangeTwitchChannel.Enabled = false;
            toolStripMenuItemPostToTwitch.Enabled = false;
            toolStripMenuItemOpenTwitchCommands.Enabled = false;
            buttonReconnectBot.Enabled = false;
            buttonTwitchCommands.Enabled = false;
            checkBoxPostToTwitch.Enabled = false;
            ApplicationSettings.Current.Twitch.ConnectToTwitch = false;
            ApplicationSettings.Current.Save();
        }

        internal async Task ReconnectTwitchBot()
        {
            if (InvokeRequired)
            {
                Invoke(delegate { _ = ReconnectTwitchBot(); });
                return;
            }
            chatConnect.ReceivedMessage -= ReadMessagesAsync;
            chatConnect.StateChanged -= OnIrcStateChanged;
            chatConnect.Dispose();
            chatConnect = null;
            if (ApplicationSettings.Current.Twitch.Custom.Enabled)
            {
                chatConnect = new TwitchChatClient(ApplicationSettings.Current.Twitch.Custom.Name, ApplicationSettings.Current.Twitch.Custom.OauthPassword);
            }
            else
            {
                chatConnect = new TwitchChatClient("gw2loguploader", "oauth:ycgqr3dyef7gp5r8uk7d5jz30nbrc6");
            }
            chatConnect.ReceivedMessage += ReadMessagesAsync;
            chatConnect.StateChanged += OnIrcStateChanged;
            await chatConnect.BeginConnectionAsync();
        }

        protected async void OnIrcStateChanged(object sender, IrcState newState, string channelName)
        {
            if (newState.Equals(IrcState.Disconnected))
            {
                TwitchChannelJoined = false;
                AddToText("<-?-> DISCONNECTED FROM TWITCH");
                if (InvokeRequired)
                {
                    Invoke((Action)(() => reconnectedFailCounter++));
                }
                else
                {
                    reconnectedFailCounter++;
                }
                if (reconnectedFailCounter <= 4)
                {
                    AddToText($"<-?-> TRYING TO RECONNECT TO TWITCH IN {reconnectedFailCounter * 15}s");
                    await Task.Delay(reconnectedFailCounter * 15000);
                    await ReconnectTwitchBot();
                }
                else
                {
                    AddToText("<-?-> FAILED TO RECONNECT TO TWITCH AFTER 4 ATTEMPTS, TRY TO CONNECT MANUALLY");
                    DisconnectTwitchBot();
                }
                return;
            }
            if (newState.Equals(IrcState.Connecting))
            {
                AddToText("<-?-> BOT CONNECTING TO TWITCH");
                return;
            }
            if (newState.Equals(IrcState.Connected))
            {
                AddToText("<-?-> CONNECTION ESTABILISHED");
                reconnectedFailCounter = 0;
                if (!string.IsNullOrWhiteSpace(ApplicationSettings.Current.Twitch.ChannelName))
                {
                    await chatConnect.JoinRoomAsync(ApplicationSettings.Current.Twitch.ChannelName);
                }
                return;
            }
            if (newState.Equals(IrcState.ChannelJoining))
            {
                AddToText($"<-?-> TRYING TO JOIN CHANNEL {channelName.ToUpper()}");
                return;
            }
            if (newState.Equals(IrcState.ChannelJoined))
            {
                AddToText("<-?-> CHANNEL JOINED");
                TwitchChannelJoined = true;
                return;
            }
            if (newState.Equals(IrcState.ChannelLeaving))
            {
                AddToText($"<-?-> LEAVING CHANNEL {channelName.ToUpper()}");
                return;
            }
            if (newState.Equals(IrcState.FailedConnection))
            {
                AddToText("<-?-> FAILED TO CONNECT TO TWITCH");
                DisconnectTwitchBot();
                return;
            }
            AddToText("<-?-> UNRECOGNISED IRC STATE RECEIVED");
        }

        protected async void ReadMessagesAsync(object sender, IrcMessage ircMessage)
        {
            if ((ircMessage is null) || (ircMessage?.IsChannelMessage != true))
            {
                return;
            }
            if (twitchCommandsLink.checkBoxSongEnable.Checked && twitchCommandsLink.checkBoxSongSmartRecognition.Checked && songSmartCommandRegex.IsMatch(ircMessage.ChannelMessage))
            {
                await SpotifySongCheck();
                return;
            }
            if (twitchCommandsLink.checkBoxGW2BuildEnable.Checked && twitchCommandsLink.checkBoxGW2BuildSmartRecognition.Checked && buildSmartCommandRegex.IsMatch(ircMessage.ChannelMessage))
            {
                await GenerateBuildCode();
                return;
            }
            var indexOfSpace = ircMessage.ChannelMessage.IndexOf(' ');
            var command = (indexOfSpace == -1) ? ircMessage.ChannelMessage.ToLower() : ircMessage.ChannelMessage[0..indexOfSpace].ToLower();
            if (command.Equals(twitchCommandsLink.textBoxUploaderCommand.Text.ToLower()) && twitchCommandsLink.checkBoxUploaderEnable.Checked)
            {
                AddToText("> UPLOADER COMMAND USED");
                await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, $"PlenBot Log Uploader r{ApplicationSettings.Version} | https://plenbot.net/uploader/ | https://github.com/Plenyx/PlenBotLogUploader/");
                return;
            }
            if (command.Equals(twitchCommandsLink.textBoxGW2Build.Text.ToLower()) && twitchCommandsLink.checkBoxGW2BuildEnable.Checked)
            {
                await GenerateBuildCode();
                return;
            }
            if (command.Equals(twitchCommandsLink.textBoxLastLogCommand.Text.ToLower()) && twitchCommandsLink.checkBoxLastLogEnable.Checked)
            {
                AddToText("> LAST LOG COMMAND USED");
                if (!string.IsNullOrWhiteSpace(lastLogMessage))
                {
                    await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, lastLogMessage);
                }
                return;
            }
            if (command.Equals(twitchCommandsLink.textBoxPullCounter.Text.ToLower()) && twitchCommandsLink.checkBoxPullCounterEnable.Checked)
            {
                AddToText("> PULLS COMMAND USED");
                if (lastLogBossId > 0)
                {
                    await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, $"{Bosses.GetBossDataFromId(lastLogBossId).Name}{(lastLogBossCM ? " CM" : "")} | Current pull: {lastLogPullCounter}");
                }
                return;
            }
            if (command.Equals(twitchCommandsLink.textBoxSongCommand.Text.ToLower()) && twitchCommandsLink.checkBoxSongEnable.Checked)
            {
                await SpotifySongCheck();
                return;
            }
            if (command.Equals(twitchCommandsLink.textBoxGW2Ign.Text.ToLower()) && twitchCommandsLink.checkBoxGW2IgnEnable.Checked)
            {
                AddToText("> (GW2) IGN COMMAND USED");
                MumbleReader?.Update();
                if (string.IsNullOrWhiteSpace(MumbleReader?.Data.Identity?.Name))
                {
                    AddToText("Read from Mumble Link has failed, is the game running?");
                    return;
                }
                _ = Task.Run(async () =>
                {
                    foreach (var apiKey in ApplicationSettings.Current.Gw2Apis.Where(x => x.Valid))
                    {
                        await apiKey.GetCharacters(HttpClientController);
                    }
                    var trueApiKey = ApplicationSettings.Current.Gw2Apis.Find(x => x.Characters.Contains(MumbleReader.Data.Identity.Name));
                    if (trueApiKey is null)
                    {
                        return;
                    }
                    using var gw2Api = new Gw2ApiHelper(trueApiKey.ApiKey);
                    var userInfo = await gw2Api.GetUserInfoAsync();
                    if ((userInfo is not null) && Gw2.AllServers.TryGetValue(userInfo.World, out var playerWorld))
                    {
                        await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, $"GW2 Account name: {userInfo.Name} | Server: {playerWorld.Name} ({playerWorld.Region})");
                    }
                    else
                    {
                        await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, "An error has occured while getting the user name from an API key.");
                    }
                });
                return;
            }
        }

        private async Task SpotifySongCheck()
        {
            AddToText("> (Spotify) SONG COMMAND USED");
            try
            {
                var spotifyProcess = Array.Find(Process.GetProcessesByName("Spotify"), x => !string.IsNullOrWhiteSpace(x.MainWindowTitle));
                if (spotifyProcess.MainWindowTitle.Contains("Spotify"))
                {
                    await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, "No song is being played.");
                    return;
                }
                await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, spotifyProcess.MainWindowTitle);
            }
            catch
            {
                await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, "Spotify is not running.");
            }
        }

        private async Task GenerateBuildCode()
        {
            AddToText("> (GW2) BUILD COMMAND USED");
            MumbleReader?.Update();
            if (string.IsNullOrWhiteSpace(MumbleReader?.Data.Identity?.Name))
            {
                AddToText("Read from Mumble Link has failed, is the game running?");
                return;
            }
            foreach (var apiKey in ApplicationSettings.Current.Gw2Apis.Where(x => x.Valid))
            {
                await apiKey.GetCharacters(HttpClientController);
            }
            var trueApiKey = ApplicationSettings.Current.Gw2Apis.Find(x => x.Characters.Contains(MumbleReader.Data.Identity.Name));
            if (trueApiKey == null)
            {
                AddToText($"No api key could be found for character '{MumbleReader.Data.Identity.Name}'");
                return;
            }

            try
            {
                var code = await APILoader.LoadBuildCodeFromCurrentCharacter(trueApiKey.ApiKey);
                if (ApplicationSettings.Current.BuildCodes.DemoteRunes)
                {
                    code.Rune = Static.LegendaryToSuperior(code.Rune);
                }
                if (ApplicationSettings.Current.BuildCodes.DemoteSigils)
                {
                    code.WeaponSet1.Sigil1 = Static.LegendaryToSuperior(code.WeaponSet1.Sigil1);
                    code.WeaponSet1.Sigil2 = Static.LegendaryToSuperior(code.WeaponSet1.Sigil2);
                    code.WeaponSet2.Sigil1 = Static.LegendaryToSuperior(code.WeaponSet2.Sigil1);
                    code.WeaponSet2.Sigil2 = Static.LegendaryToSuperior(code.WeaponSet2.Sigil2);
                }
                Static.Compress(code, ApplicationSettings.Current.BuildCodes.Compression);
                var message = $"Link to the build: https://hardstuck.gg/gw2/builds/?b={TextLoader.WriteBuildCode(code)}";
                await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, message);
            }
            catch (InvalidAccessTokenException)
            {
                AddToText("GW2 API access token is not valid.");
            }
            catch (MissingScopesException)
            {
                var missingScopes = APILoader.ValidateScopes(trueApiKey.ApiKey);
                AddToText($"GW2 API access token is missing the following required scopes: {string.Join(", ", missingScopes)}.");
            }
            catch (NotFoundException)
            {
                AddToText($"The currently logged in character ('{MumbleReader.Data.Identity.Name}') could be found using the GW2 API access token '{trueApiKey.Name}'");
            }
            catch (Exception ex)
            {
                AddToText($"A unexpected error occured. {ex.GetType()}: {ex.Message}");
            }
        }
        #endregion

        #region buttons & checks, events
        internal void RedrawUserTokenContext()
        {
            toolStripMenuItemDPSReportUserTokens.DropDownItems.Clear();
            if (ApplicationSettings.Current.Upload.DpsReportUserTokens.Count == 0)
            {
                toolStripMenuItemDPSReportUserTokens.DropDownItems.Add(new ToolStripMenuItem() { Enabled = false, Text = "No user tokens defined" });
                return;
            }
            foreach (var userToken in ApplicationSettings.Current.Upload.DpsReportUserTokens.OrderBy(x => x.Name).ToArray())
            {
                var index = toolStripMenuItemDPSReportUserTokens.DropDownItems.Add(new ToolStripMenuItemCustom<ApplicationSettingsUploadUserToken>() { Checked = userToken.Active, Text = userToken.Name, LinkedObject = userToken });
                toolStripMenuItemDPSReportUserTokens.DropDownItems[index].Click += UserTokenButtonClicked;
            }
        }

        private void UserTokenButtonClicked(object sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItemCustom<ApplicationSettingsUploadUserToken> pressedButton)
            {
                return;
            }
            foreach (var userToken in ApplicationSettings.Current.Upload.DpsReportUserTokens.AsSpan())
            {
                userToken.Active = false;
            }
            pressedButton.LinkedObject.Active = true;
            dpsReportSettingsLink.RedrawList();
            RedrawUserTokenContext();
        }

        private void CheckBoxUploadAll_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Upload.Enabled = checkBoxUploadLogs.Checked;
            ApplicationSettings.Current.Save();
            toolStripMenuItemUploadLogs.Checked = checkBoxUploadLogs.Checked;
            checkBoxPostToTwitch.Enabled = checkBoxUploadLogs.Checked;
            toolStripMenuItemPostToTwitch.Enabled = checkBoxUploadLogs.Checked;
            if (!checkBoxUploadLogs.Checked)
            {
                checkBoxPostToTwitch.Checked = false;
                toolStripMenuItemPostToTwitch.Checked = false;
            }
        }

        private async void ButtonReconnectBot_Click(object sender, EventArgs e)
        {
            reconnectedFailCounter = 0;
            await ReconnectTwitchBot();
        }

        private void ButtonLogsLocation_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog() { Description = "Select the arcdps folder containing the combat logs.\nThe default location is in \"My Documents\\Guild Wars 2\\addons\\arcdps\\arcdps.cbtlogs\\\"" };
            var result = dialog.ShowDialog();
            if (!result.Equals(DialogResult.OK) || string.IsNullOrWhiteSpace(dialog.SelectedPath))
            {
                return;
            }
            ApplicationSettings.Current.LogsLocation = dialog.SelectedPath;
            ApplicationSettings.Current.Save();
            logsCount = 0;
            LogsScan(ApplicationSettings.Current.LogsLocation);
            if (watcher.IsRunning)
            {
                watcher.ChangeRootPath(ApplicationSettings.Current.LogsLocation);
            }
            else
            {
                watcher.InitAndStart(ApplicationSettings.Current.LogsLocation, ApplicationSettings.Current.UsePollingForLogs ? ArcLogsChangeObserverMode.Polling : default);
            }
            buttonOpenLogs.Enabled = true;
        }

        private void CheckBoxUsePolling_CheckedChanged(object sender, System.EventArgs e)
        {
            watcher.ChangeMode(checkBoxUsePolling.Checked ? ArcLogsChangeObserverMode.Polling : default);

            ApplicationSettings.Current.UsePollingForLogs = checkBoxUsePolling.Checked;
            ApplicationSettings.Current.Save();
        }

        private void CheckBoxTrayMinimiseToIcon_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.MinimiseToTray = checkBoxTrayMinimiseToIcon.Checked;
            ApplicationSettings.Current.Save();
        }

        private void CheckBoxPostToTwitch_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Upload.PostLogsToTwitch = checkBoxPostToTwitch.Checked;
            ApplicationSettings.Current.Save();
            toolStripMenuItemPostToTwitch.Checked = checkBoxPostToTwitch.Checked;
            checkBoxTwitchOnlySuccess.Enabled = checkBoxPostToTwitch.Checked;
            if (!checkBoxPostToTwitch.Checked)
            {
                checkBoxTwitchOnlySuccess.Checked = false;
            }
        }

        private void CheckBoxTwitchOnlySuccess_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Upload.PostLogsToTwitchOnlySuccess = checkBoxTwitchOnlySuccess.Checked;
            ApplicationSettings.Current.Save();
        }

        private void CheckBoxAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.AutoUpdate = checkBoxAutoUpdate.Checked;
            ApplicationSettings.Current.Save();
        }

        private void NotifyIconTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ShowInTaskbar)
            {
                ShowInTaskbar = false;
                WindowState = FormWindowState.Minimized;
                Hide();
                return;
            }
            Show();
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        private void ButtonChangeTwitchChannel_Click(object sender, EventArgs e) => twitchNameLink.Show();

        private void ToolStripMenuItemUploadLogs_CheckedChanged(object sender, EventArgs e) => checkBoxUploadLogs.Checked = toolStripMenuItemUploadLogs.Checked;

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) => Close();

        private void ToolStripMenuItemPostToTwitch_CheckedChanged(object sender, EventArgs e) => checkBoxPostToTwitch.Checked = toolStripMenuItemPostToTwitch.Checked;

        private void ButtonOpenLogs_Click(object sender, EventArgs e) => Process.Start(new ProcessStartInfo() { UseShellExecute = true, FileName = ApplicationSettings.Current.LogsLocation });

        private void OpenDPSReportSettings()
        {
            dpsReportSettingsLink.Show();
            dpsReportSettingsLink.BringToFront();
        }

        private void OpenCustomNameSettings()
        {
            customNameLink.Show();
            customNameLink.BringToFront();
        }

        private void OpenRemotePingsSettings()
        {
            pingsLink.Show();
            pingsLink.BringToFront();
        }

        private void OpenArcDpsPluginManager()
        {
            arcPluginManagerLink.Show();
            arcPluginManagerLink.BringToFront();
        }

        private void OpenDiscordWebhooks()
        {
            discordWebhooksLink.Show();
            discordWebhooksLink.BringToFront();
        }

        private void OpenTwitchCommands()
        {
            twitchCommandsLink.Show();
            twitchCommandsLink.BringToFront();
        }

        private void ButtonDPSReportServer_Click(object sender, EventArgs e) => OpenDPSReportSettings();

        private void ButtonCustomName_Click(object sender, EventArgs e) => OpenCustomNameSettings();

        private void ButtonPingSettings_Click(object sender, EventArgs e) => OpenRemotePingsSettings();

        private void ButtonArcDpsPluginManager_Click(object sender, EventArgs e) => OpenArcDpsPluginManager();

        private void ButtonBossData_Click(object sender, EventArgs e)
        {
            bossDataLink.Show();
            bossDataLink.BringToFront();
        }

        private void ButtonDiscordWebhooks_Click(object sender, EventArgs e) => OpenDiscordWebhooks();

        private void ButtonTwitchCommands_Click(object sender, EventArgs e) => OpenTwitchCommands();

        private void ButtonGW2BotSettings_Click(object sender, EventArgs e)
        {
            gw2botLink.Show();
            gw2botLink.BringToFront();
        }

        private void ToolStripMenuItemOpenDPSReportServer_Click(object sender, EventArgs e) => OpenDPSReportSettings();

        private void ToolStripMenuItemOpenCustomName_Click(object sender, EventArgs e) => OpenCustomNameSettings();

        private void ToolStripMenuItemOpenPingSettings_Click(object sender, EventArgs e) => OpenRemotePingsSettings();

        private void ToolStripMenuItemOpenArcDpsPluginManager_Click(object sender, EventArgs e) => OpenArcDpsPluginManager();

        private void ToolStripMenuItemDiscordWebhooks_Click(object sender, EventArgs e) => OpenDiscordWebhooks();

        private void ToolStripMenuItemOpenTwitchCommands_Click(object sender, EventArgs e) => OpenTwitchCommands();

        private void ButtonSession_Click(object sender, EventArgs e)
        {
            logSessionLink.Show();
            logSessionLink.BringToFront();
        }

        private void ButtonGW2API_Click(object sender, EventArgs e)
        {
            gw2APILink.Show();
            gw2APILink.BringToFront();
        }

        private void ButtonAleevaSettings_Click(object sender, EventArgs e)
        {
            aleevaLink.Show();
            aleevaLink.BringToFront();
        }

        private void ButtonTeamsSettings_Click(object sender, EventArgs e)
        {
            teamsLink.Show();
            teamsLink.BringToFront();
        }

        private async void ButtonDisConnectTwitch_Click(object sender, EventArgs e)
        {
            reconnectedFailCounter = 0;
            if (chatConnect is null)
            {
                await ConnectTwitchBot();
                return;
            }
            DisconnectTwitchBot();
            checkBoxPostToTwitch.Checked = false;
        }

        private async void ButtonUpdateNow_Click(object sender, EventArgs e) => await PerformUpdate();

        internal async Task PerformUpdate(bool appStartup = false)
        {
            if (!UpdateFound)
            {
                await NewReleaseCheckAsync();
                return;
            }
            buttonUpdate.Enabled = false;
            AddToText(">>> Downloading the update...");
            var downloadUrl = Array.Find(latestRelease.Assets, x => x.Name.Equals(plenbotDownloadName))?.DownloadUrl;
            if (downloadUrl is null)
            {
                AddToText(">>> Something went wrong with the download. Please try again later.");
                buttonUpdate.Enabled = true;
                return;
            }
            var result = await HttpClientController.DownloadFileAsync(downloadUrl, $"{ApplicationSettings.LocalDir}PlenBotLogUploader_Update.exe");
            if (!result)
            {
                AddToText(">>> Something went wrong with the download. Please try again later.");
                buttonUpdate.Enabled = true;
                return;
            }
            Process.Start(new ProcessStartInfo() { UseShellExecute = true, FileName = $"{ApplicationSettings.LocalDir}PlenBotLogUploader_Update.exe", Arguments = $"-update {Path.GetFileName(Application.ExecutablePath.Replace('/', '\\'))}{((appStartup && StartedMinimised) ? " -m" : "")}" });
            ExitApp();
        }

        private void CheckBoxStartWhenWindowsStarts_CheckedChanged(object sender, EventArgs e)
        {
            using var registryRun = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (checkBoxStartWhenWindowsStarts.Checked)
            {
                registryRun.SetValue("PlenBot Log Uploader", $"\"{Application.ExecutablePath.Replace('/', '\\')}\" -m");
                return;
            }
            registryRun.DeleteValue("PlenBot Log Uploader");
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to do this?\nThis resets all your settings but not boss data, webhooks and ping configurations.\nIf you click yes the application will close itself.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (!result.Equals(DialogResult.Yes))
            {
                return;
            }
            Process.Start(new ProcessStartInfo() { UseShellExecute = true, FileName = ApplicationSettings.LocalDir });
            var reset = new ApplicationSettings();
            reset.Save();
            ExitApp();
        }

        private void TimerCheckUpdate_Tick(object sender, EventArgs e)
        {
            timerCheckUpdate.Stop();
            timerCheckUpdate.Enabled = false;
            _ = NewReleaseCheckAsync(false, true);
        }

        private void TimerFailedLogsReupload_Tick(object sender, EventArgs e)
        {
            timerFailedLogsReupload.Stop();
            timerFailedLogsReupload.Enabled = false;
            LogReuploader.ProcessLogs(HttpUploadLogAsync);
        }

        private void ComboBoxMaxUploads_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(comboBoxMaxUploads.Text, out var threads))
            {
                return;
            }
            ApplicationSettings.Current.MaxConcurrentUploads = threads;
            ApplicationSettings.Current.Save();
            semaphore?.Dispose();
            semaphore = new SemaphoreSlim(threads, threads);
        }

        private void ButtonCopyApplicationSession_Click(object sender, EventArgs e)
        {
            if (allSessionLogs.Count == 0)
            {
                return;
            }
            Clipboard.SetText(string.Join(Environment.NewLine, allSessionLogs));
        }

        private void CheckBoxAnonymiseReports_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Upload.Anonymous = checkBoxAnonymiseReports.Checked;
            ApplicationSettings.Current.Save();
        }

        private void CheckBoxDetailedWvW_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Upload.DetailedWvw = checkBoxDetailedWvW.Checked;
            ApplicationSettings.Current.Save();
        }

        private void CheckBoxSaveLogsToCSV_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Upload.SaveToCsvEnabled = checkBoxSaveLogsToCSV.Checked;
            ApplicationSettings.Current.Save();
        }

        private void CheckBoxOnlyWhenStreamSoftwareRunning_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Upload.PostLogsToTwitchOnlyWithStreamingSoftware = checkBoxOnlyWhenStreamSoftwareRunning.Checked;
            ApplicationSettings.Current.Save();
        }
        #endregion
    }
}
