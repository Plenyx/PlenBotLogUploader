﻿using Hardstuck.GuildWars2.Builds;
using Hardstuck.GuildWars2.MumbleLink;
using Microsoft.Win32;
using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.DPSReport;
using PlenBotLogUploader.GitHub;
using PlenBotLogUploader.GW2API;
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
using TwitchIRCClient;

namespace PlenBotLogUploader
{
    public partial class FormMain : Form
    {
        #region definitions
        // properties
        internal List<DPSReportJSON> SessionLogs { get; } = new List<DPSReportJSON>();
        internal bool ChannelJoined { get; set; } = false;
        internal HttpClientController HttpClientController { get; } = new HttpClientController();
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
        private readonly FormDPSReportSettings dpsReportSettingsLink;
        private readonly FormCustomName customNameLink;
        private readonly FormArcPluginManager arcPluginManagerLink;
        private readonly FormBossData bossDataLink;
        private readonly FormDiscordWebhooks discordWebhooksLink;
        private readonly FormPings pingsLink;
        private readonly FormTwitchCommands twitchCommandsLink;
        private readonly FormLogSession logSessionLink;
        private readonly FormGW2API gw2APILink;
        private readonly FormAleeva aleevaLink;
        private readonly FormGW2Bot gw2botLink;
        private readonly FormTeams teamsLink;
        private readonly List<string> allSessionLogs = new();
        private readonly Regex songCommandRegex = new(@"(?:(?:song)|(?:music)){1}(?:(?:\?)|(?: is)|(?: name))+", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline);
        private SemaphoreSlim semaphore;
        private TwitchIrcClient chatConnect;
        private FileSystemWatcher watcher = new() { Filter = "*.*", IncludeSubdirectories = true, NotifyFilter = NotifyFilters.FileName };
        private int reconnectedFailCounter = 0;
        private int recentUploadFailCounter = 0;
        private int logsCount = 0;
        private string lastLogMessage = string.Empty;
        private int lastLogBossId = 0;
        private int lastLogPullCounter = 0;
        private bool lastLogBossCM = false;
        private bool _updateFound = false;
        private GitHubReleaseLatest latestRelease = null;

        // constants
        private const int minFileSize = 8192;
        private const string plenbotVersionFileURL = "https://raw.githubusercontent.com/HardstuckGuild/PlenBotLogUploader/master/VERSION";
        private const string netv6DownloadName = "PlenBotLogUploader.netv6.exe";
        private const string standaloneDownloadName = "PlenBotLogUploader.exe";
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
            dpsReportSettingsLink = new FormDPSReportSettings(this);
            customNameLink = new FormCustomName(this);
            pingsLink = new FormPings(this);
            arcPluginManagerLink = new FormArcPluginManager(this);
            bossDataLink = new FormBossData();
            discordWebhooksLink = new FormDiscordWebhooks(this);
            twitchCommandsLink = new FormTwitchCommands();
            logSessionLink = new FormLogSession(this);
            gw2APILink = new FormGW2API(this);
            aleevaLink = new FormAleeva(this);
            gw2botLink = new FormGW2Bot(this);
            teamsLink = new FormTeams();
            MumbleReader = new MumbleReader(false);
            #region tooltips
            toolTip.SetToolTip(checkBoxUploadLogs, "If checked, all created logs will be uploaded.");
            toolTip.SetToolTip(checkBoxPostToTwitch, "If checked, logs will be posted to Twitch channel if properly connected to it and OBS is running.");
            toolTip.SetToolTip(checkBoxTwitchOnlySuccess, "If checked, only successful logs will be linked to Twitch channel if properly connected to it.");
            toolTip.SetToolTip(checkBoxAnonymiseReports, "If checked, the log will be generated with fake names and accounts.");
            toolTip.SetToolTip(checkBoxDetailedWvW, "If checked, extended per-target reports will be generated. (might cause some issues)");
            toolTip.SetToolTip(labelMaximumUploads, "Sets the maximum allowed uploads for drag & drop.");
            toolTip.SetToolTip(buttonCopyApplicationSession, "Copies all the logs uploaded during the application session into the clipboard.");
            toolTip.SetToolTip(checkBoxAutoUpdate, "Automatically downloads the newest version when it is available.\nOnly occurs during the start of the app.");
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
                if (ApplicationSettings.Current.LogsLocation.Equals(string.Empty) || !Directory.Exists(ApplicationSettings.Current.LogsLocation))
                {
                    labelLocationInfo.Text = "!!! Select a directory with arc logs !!!";
                }
                else
                {
                    if (Directory.Exists(ApplicationSettings.Current.LogsLocation))
                    {
                        LogsScan(ApplicationSettings.Current.LogsLocation);
                        watcher.Path = ApplicationSettings.Current.LogsLocation;
                        watcher.Renamed += OnLogCreated;
                        watcher.EnableRaisingEvents = true;
                        buttonOpenLogs.Enabled = true;
                    }
                    else
                    {
                        ApplicationSettings.Current.LogsLocation = string.Empty;
                        labelLocationInfo.Text = "!!! Select a directory with arc logs !!!";
                    }
                }
                ApplicationSettings.Current.Twitch.ChannelName = ApplicationSettings.Current.Twitch.ChannelName.ToLower();
                if (ApplicationSettings.Current.Twitch.ChannelName != string.Empty)
                {
                    twitchNameLink.textBoxChannelUrl.Text = $"https://twitch.tv/{ApplicationSettings.Current.Twitch.ChannelName}/";
                }
                switch (ApplicationSettings.Current.Upload.DPSReportServer)
                {
                    case DPSReportServer.A:
                        dpsReportSettingsLink.radioButtonA.Checked = true;
                        break;
                    case DPSReportServer.B:
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
                if (ApplicationSettings.Current.Upload.DetailedWvW)
                {
                    checkBoxDetailedWvW.Checked = true;
                }
                if (ApplicationSettings.Current.Upload.SaveToCSVEnabled)
                {
                    checkBoxSaveLogsToCSV.Checked = true;
                }
                if (ApplicationSettings.Current.Twitch.Custom.Enabled)
                {
                    customNameLink.checkBoxCustomNameEnable.Checked = true;
                    ApplicationSettings.Current.Twitch.Custom.Name = ApplicationSettings.Current.Twitch.Custom.Name.ToLower();
                    customNameLink.textBoxCustomName.Text = ApplicationSettings.Current.Twitch.Custom.Name;
                    customNameLink.textBoxCustomOAuth.Text = ApplicationSettings.Current.Twitch.Custom.OAuthPassword;
                }
                arcPluginManagerLink.checkBoxEnableNotifications.Checked = ApplicationSettings.Current.ArcUpdate.Notifications;
                if (!string.IsNullOrWhiteSpace(ApplicationSettings.Current.GW2Location))
                {
                    if (File.Exists($@"{ApplicationSettings.Current.GW2Location}\Gw2-64.exe") || File.Exists($@"{ApplicationSettings.Current.GW2Location}\Gw2.exe") || File.Exists($@"{ApplicationSettings.Current.GW2Location}\Guild Wars 2.exe"))
                    {
                        if (ApplicationSettings.Current.ArcUpdate.UseAL)
                        {
                            arcPluginManagerLink.checkBoxUseAL.Checked = true;
                        }
                        if (ApplicationSettings.Current.ArcUpdate.Enabled)
                        {
                            arcPluginManagerLink.checkBoxModuleEnabled.Checked = true;
                            _ = arcPluginManagerLink.StartTimerAsync(true, true);
                        }
                    }
                    else
                    {
                        ShowBalloon("arcdps plugin manager", "There has been an error locating the main Guild Wars 2 folder, try changing the directory again.", 6500);
                        ApplicationSettings.Current.GW2Location = string.Empty;
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
                twitchCommandsLink.checkBoxSongSmartRecognition.Checked = ApplicationSettings.Current.Twitch.Commands.SmartRecognition;
                twitchCommandsLink.checkBoxGW2IgnEnable.Checked = ApplicationSettings.Current.Twitch.Commands.IGNEnabled;
                twitchCommandsLink.textBoxGW2Ign.Text = ApplicationSettings.Current.Twitch.Commands.IGNCommand;
                twitchCommandsLink.checkBoxPullCounterEnable.Checked = ApplicationSettings.Current.Twitch.Commands.PullCounterEnabled;
                twitchCommandsLink.textBoxPullCounter.Text = ApplicationSettings.Current.Twitch.Commands.PullCounterCommand;
                logSessionLink.textBoxSessionName.Text = ApplicationSettings.Current.Session.Name;
                logSessionLink.checkBoxSupressWebhooks.Checked = ApplicationSettings.Current.Session.SupressWebhooks;
                logSessionLink.checkBoxOnlySuccess.Checked = ApplicationSettings.Current.Session.OnlySuccess;
                logSessionLink.textBoxSessionContent.Text = ApplicationSettings.Current.Session.Message;
                logSessionLink.radioButtonSortByUpload.Checked = ApplicationSettings.Current.Session.Sort == LogSessionSortBy.UploadTime;
                logSessionLink.checkBoxSaveToFile.Checked = ApplicationSettings.Current.Session.SaveToFile;
                logSessionLink.checkBoxMakeWvWSummary.Checked = ApplicationSettings.Current.Session.MakeWvWSummaryEmbed;
                discordWebhooksLink.checkBoxShortenThousands.Checked = ApplicationSettings.Current.ShortenThousands;
                if (!string.IsNullOrWhiteSpace(ApplicationSettings.Current.Aleeva.RefreshToken) && (DateTime.Now < ApplicationSettings.Current.Aleeva.RefreshTokenExpire))
                {
                    Task.Run(() => aleevaLink.GetAleevaTokenFromRefreshToken());
                }
                if (ApplicationSettings.Current.LogsLocation.Equals(string.Empty) || !Directory.Exists(ApplicationSettings.Current.LogsLocation))
                {
                    MessageBox.Show("Path to arcdps logs is not set.\nDo not forget to set it up so the logs can be auto-uploaded.", "Just a reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (ApplicationSettings.Current.Twitch.ConnectToTwitch)
                {
                    if (ApplicationSettings.Current.Twitch.Custom.Enabled)
                    {
                        chatConnect = new TwitchIrcClient(ApplicationSettings.Current.Twitch.Custom.Name, ApplicationSettings.Current.Twitch.Custom.OAuthPassword);
                    }
                    else
                    {
                        chatConnect = new TwitchIrcClient("gw2loguploader", "oauth:ycgqr3dyef7gp5r8uk7d5jz30nbrc6");
                    }
                    chatConnect.ReceiveMessage += ReadMessagesAsync;
                    chatConnect.StateChange += OnIrcStateChanged;
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
                checkBoxStartWhenWindowsStarts.CheckedChanged += CheckBoxStartWhenWindowsStarts_CheckedChanged;
                checkBoxAnonymiseReports.CheckedChanged += CheckBoxAnonymiseReports_CheckedChanged;
                checkBoxDetailedWvW.CheckedChanged += CheckBoxDetailedWvW_CheckedChanged;
                checkBoxSaveLogsToCSV.CheckedChanged += CheckBoxSaveLogsToCSV_CheckedChanged;
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
        private void FormMain_Load(object sender, EventArgs e)
        {
            _ = Task.Run(async () =>
            {
                await StartUpAndCommandArgs();
                await NewReleaseCheckAsync(true);
            });
            Resize += FormMain_Resize;
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

        private void RichTextBoxUploadInfo_LinkClicked(object sender, LinkClickedEventArgs e) => Process.Start(e.LinkText);
        #endregion

        #region main program methods
        // triggeres when a file is renamed within the folder, renaming is the last process done by arcdps to create evtc or zevtc files
        private async void OnLogCreated(object sender, FileSystemEventArgs e)
        {
            if (e.FullPath.EndsWith(".evtc") || e.FullPath.EndsWith(".zevtc"))
            {
                logsCount++;
                if (checkBoxUploadLogs.Checked)
                {
                    try
                    {
                        if (new FileInfo(e.FullPath).Length >= minFileSize)
                        {
                            var zipfilelocation = e.FullPath;
                            var archived = false;
                            // a workaround so arcdps can release the file for read access
                            Thread.Sleep(1000);
                            if (!e.FullPath.EndsWith(".zevtc"))
                            {
                                zipfilelocation = $"{ApplicationSettings.LocalDir}{Path.GetFileNameWithoutExtension(e.FullPath)}.zevtc";
                                using var zipfile = ZipFile.Open(zipfilelocation, ZipArchiveMode.Create);
                                zipfile.CreateEntryFromFile(@e.FullPath, Path.GetFileName(e.FullPath));
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
                        AddToText($">:> Unable to upload the file: {e.FullPath}");
                    }
                }
                UpdateLogCount();
            }
        }

        internal void ShowBalloon(string title, string description, int ms)
        {
            MumbleReader?.Update();
            if (!MumbleReader?.Data.Context.UIState.HasFlag(UIState.IsInCombat) ?? true)
            {
                notifyIconTray.ShowBalloonTip(ms, title, description, ToolTipIcon.Info);
            }
            else
            {
                Task.Run(() =>
                {
                    Task.Delay(30000);
                    ShowBalloon(title, description, ms);
                });
            }
        }

        private void LogsScan(string directory)
        {
            foreach (var file in Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories).AsSpan())
            {
                if (file.EndsWith(".evtc") || file.EndsWith(".zevtc"))
                {
                    logsCount++;
                }
            }
            UpdateLogCount();
        }

        protected async Task NewReleaseCheckAsync(bool appStartup = false)
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
                if (int.TryParse(response, out int currentVersion))
                {
                    if (currentVersion >= ApplicationSettings.Version)
                    {
                        UpdateFound = true;
                        latestRelease = await HttpClientController.GetGitHubLatestReleaseAsync("HardstuckGuild/PlenBotLogUploader");
                        if (appStartup && ApplicationSettings.Current.AutoUpdate)
                        {
                            await PerformUpdate(appStartup);
                        }
                        else
                        {
                            AddToText($">>> New release available (r{response})");
                            AddToText(">>> Read about all the changes here: https://github.com/HardstuckGuild/PlenBotLogUploader/releases/latest");
                            ShowBalloon("New release available for the uploader", $"If you want to update immediately, use the \"Update the uploader\" button.\nThe latest release is n. {response}.", 8500);
                        }
                    }
                    else
                    {
                        AddToText(">>> The uploader is up to date.");
                        timerCheckUpdate.Enabled = true;
                        timerCheckUpdate.Start();
                    }
                }
                else
                {
                    AddToText(">>> Could not verify the version release.");
                    timerCheckUpdate.Enabled = true;
                    timerCheckUpdate.Start();
                }
            }
            catch
            {
                AddToText(">>> Unable to check new release version.");
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
            Close();
            Application.Exit();
        }

        protected async Task StartUpAndCommandArgs()
        {
            WindowState = ApplicationSettings.Current.MainFormState;
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                if (((args.Length == 2) || (args.Length == 3)) && args[1].Equals("-m"))
                {
                    StartedMinimised = true;
                    WindowState = FormWindowState.Minimized;
                    if (checkBoxTrayMinimiseToIcon.Checked)
                    {
                        ShowInTaskbar = false;
                        Hide();
                    }
                }
                else
                {
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
                }
            }
        }

        protected async Task ValidateGW2Tokens()
        {
            foreach (var apiKey in ApplicationSettings.Current.GW2APIs)
            {
                await apiKey.ValidateToken(HttpClientController);
            }
            gw2APILink.RedrawList();
        }
        #endregion

        #region self-invocable functions
        internal void AddToText(string s)
        {
            if (richTextBoxMainConsole.InvokeRequired)
            {
                richTextBoxMainConsole.Invoke((string text) => AddToText(text), s);
                return;
            }
            var messagePre = s.IndexOf(' ');
            if (messagePre != -1)
            {
                richTextBoxMainConsole.SelectionColor = Color.Blue;
                richTextBoxMainConsole.AppendText(s[..(messagePre + 1)]);
                richTextBoxMainConsole.SelectionColor = Color.Black;
                richTextBoxMainConsole.AppendText(string.Concat(s.AsSpan(messagePre), Environment.NewLine));
            }
            else
            {
                richTextBoxMainConsole.AppendText(s + Environment.NewLine);
            }
            richTextBoxMainConsole.SelectionStart = richTextBoxMainConsole.TextLength;
            richTextBoxMainConsole.ScrollToCaret();
        }

        private void UpdateLogCount()
        {
            if (labelLocationInfo.InvokeRequired)
            {
                labelLocationInfo.Invoke(() => UpdateLogCount());
                return;
            }
            labelLocationInfo.Text = $"Logs in the directory: {logsCount}";
        }
        #endregion

        #region log upload and processing
        internal async Task SendLogToTwitchChatAsync(DPSReportJSON reportJSON, bool bypassMessage = false)
        {
            if (ChannelJoined && checkBoxPostToTwitch.Checked && !bypassMessage && IsStreamingSoftwareRunning())
            {
                var bossData = Bosses.GetBossDataFromId(reportJSON.ExtraJSON?.TriggerID ?? reportJSON.Encounter.BossId);
                if (bossData is not null)
                {
                    var format = bossData.TwitchMessageFormat(reportJSON, lastLogPullCounter);
                    if (!string.IsNullOrWhiteSpace(format))
                    {
                        lastLogMessage = format;
                        await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, lastLogMessage);
                    }
                }
                else
                {
                    lastLogMessage = $"Link to the last log: {reportJSON.ConfigAwarePermalink}";
                    await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, lastLogMessage);
                }
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
                    var uri = new Uri(CreateDPSReportLink());
                    using var responseMessage = await HttpClientController.PostAsync(uri, content);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var response = await responseMessage.Content.ReadAsStringAsync();
                        // workaround for deserialisation application crash if the player list is an empty array, in case the log being corrupted
                        response = response?.Replace("\"players\": []", "\"players\": {}");
                        try
                        {
                            var reportJSON = JsonConvert.DeserializeObject<DPSReportJSON>(response);
                            if (string.IsNullOrEmpty(reportJSON.Error))
                            {
                                bossId = reportJSON.Encounter.BossId;
                                var success = (reportJSON.Encounter.Success ?? false) ? "true" : "false";
                                lastLogBossCM = reportJSON.ChallengeMode;
                                // extra JSON from Elite Insights
                                if (reportJSON.Encounter.JsonAvailable ?? false)
                                {
                                    try
                                    {
                                        var jsonString = await HttpClientController.DownloadFileToStringAsync($"{ApplicationSettings.Current.Upload.DPSReportServerLink}/getJson?permalink={reportJSON.ConfigAwarePermalink}");
                                        var extraJSON = JsonConvert.DeserializeObject<DPSReportJSONExtraJSON>(jsonString);
                                        if (extraJSON is not null)
                                        {
                                            reportJSON.ExtraJSON = extraJSON;
                                            bossId = reportJSON.ExtraJSON.TriggerID;
                                            lastLogBossCM = reportJSON.ChallengeMode;
                                        }
                                        else
                                        {
                                            AddToText(">:> Extra JSON available but couldn't be obtained.");
                                        }
                                    }
                                    catch
                                    {
                                        AddToText(">:> Extra JSON available but couldn't be obtained.");
                                    }
                                }
                                if (ApplicationSettings.Current.Upload.SaveToCSVEnabled)
                                {
                                    try
                                    {
                                        // log file
                                        File.AppendAllText($"{ApplicationSettings.LocalDir}uploaded_logs.csv", $"{reportJSON.ExtraJSON?.FightName ?? reportJSON.Encounter.Boss};{bossId};{success};{reportJSON.ExtraJSON?.Duration ?? string.Empty};{reportJSON.ExtraJSON?.RecordedBy ?? string.Empty};{reportJSON.ExtraJSON?.EliteInsightsVersion ?? string.Empty};{reportJSON.EVTC.Type}{reportJSON.EVTC.Version};{reportJSON.ConfigAwarePermalink};{reportJSON.UserToken}\n");
                                    }
                                    catch (Exception e)
                                    {
                                        AddToText($">:> There has been an error saving file {Path.GetFileName(file)} to the main CSV: {e.Message}");
                                    }
                                }
                                // save to clipboard list
                                allSessionLogs.Add(reportJSON.ConfigAwarePermalink);
                                // Twitch chat
                                lastLogMessage = $"Link to the last log: {reportJSON.ConfigAwarePermalink}";
                                if (lastLogBossId != bossId)
                                {
                                    lastLogPullCounter = 0;
                                }
                                lastLogBossId = bossId;
                                lastLogPullCounter = (reportJSON.Encounter.Success ?? false) ? 0 : lastLogPullCounter + 1;
                                AddToText($">:> {reportJSON.ConfigAwarePermalink}");
                                if (checkBoxTwitchOnlySuccess.Checked && (reportJSON.Encounter.Success ?? false))
                                {
                                    await SendLogToTwitchChatAsync(reportJSON, bypassMessage);
                                }
                                else if (checkBoxTwitchOnlySuccess.Checked)
                                {
                                    await SendLogToTwitchChatAsync(reportJSON, true);
                                }
                                else
                                {
                                    await SendLogToTwitchChatAsync(reportJSON, bypassMessage);
                                }
                                // Discord webhooks & log sessions
                                if (logSessionLink.SessionRunning)
                                {
                                    if (logSessionLink.checkBoxOnlySuccess.Checked && (reportJSON.Encounter.Success ?? false))
                                    {
                                        SessionLogs.Add(reportJSON);
                                    }
                                    else if (!logSessionLink.checkBoxOnlySuccess.Checked)
                                    {
                                        SessionLogs.Add(reportJSON);
                                    }
                                    if (!logSessionLink.checkBoxSupressWebhooks.Checked)
                                    {
                                        await discordWebhooksLink.ExecuteAllActiveWebhooksAsync(reportJSON);
                                    }
                                }
                                else
                                {
                                    await discordWebhooksLink.ExecuteAllActiveWebhooksAsync(reportJSON);
                                }
                                // remote server ping
                                await pingsLink.ExecuteAllPingsAsync(reportJSON);
                                // aleeva pings
                                await aleevaLink.PostLogToAleeva(reportJSON);
                                // gw2bot pings
                                await gw2botLink.PostLogToGW2Bot(reportJSON);
                                // report success
                                AddToText($">:> {Path.GetFileName(file)} successfully uploaded.");
                            }
                            else if (reportJSON.Error.Length > 0)
                            {
                                AddToText($">:> Unable to process file {Path.GetFileName(file)}, dps.report responded with following error message: {reportJSON.Error}");
                            }
                            else
                            {
                                AddToText($">:> Unable to process file {Path.GetFileName(file)}, error while deserilising the response.");
                            }
                        }
                        catch (Exception e)
                        {
                            AddToText($">:> There has been an error processing file {Path.GetFileName(file)}: {e.Message}");
                        }
                    }
                    else
                    {
                        AddToText($">:> Unable to upload file {Path.GetFileName(file)}, dps.report responded with an non-ok status code ({(int)responseMessage.StatusCode})");
                    }
                }
                catch
                {
                    AddToText($">:> Unable to upload file {Path.GetFileName(file)}, dps.report not responding");
                    Interlocked.Increment(ref recentUploadFailCounter);
                    if (recentUploadFailCounter > 3)
                    {
                        Interlocked.Exchange(ref recentUploadFailCounter, 0);
                        AddToText($">:> Upload retry failed 3 times for {Path.GetFileName(file)}, aborting.");
                    }
                    else
                    {
                        await Task.Run(async () =>
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
                        });
                    }
                }
            }
            catch
            {
                Thread.Sleep(1000);
                await HttpUploadLogAsync(file, postData, bypassMessage);
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
                builder.Append(log.ExtraJSON?.FightName ?? log.Encounter.Boss).Append(": ").AppendLine(log.ConfigAwarePermalink);
            }
            AddToText(builder.ToString());
            await discordWebhooksLink.ExecuteSessionWebhooksAsync(SessionLogs, logSessionSettings);
        }

        private static string CreateDPSReportLink()
        {
            var baseUrl = $"{ApplicationSettings.Current.Upload.DPSReportServerLink}/uploadContent";
            var urlParameters = new List<string>()
            {
                "json=1",
                "generator=ei"
            };
            if (ApplicationSettings.Current.Upload.DPSReportUserTokens.Count(x => x.Active) == 1)
            {
                urlParameters.Add($"userToken={ApplicationSettings.Current.Upload.DPSReportUserTokens.Find(x => x.Active).UserToken}");
            }
            if (ApplicationSettings.Current.Upload.Anonymous)
            {
                urlParameters.Add("anonymous=true");
            }
            if (ApplicationSettings.Current.Upload.DetailedWvW)
            {
                urlParameters.Add("detailedwvw=true");
            }
            return $"{baseUrl}?{urlParameters.Aggregate((x, y) => $"{x}&{y}")}";
        }
        #endregion

        #region Twitch bot methods
        internal bool IsTwitchConnectionNull() => chatConnect is null;

        internal static bool IsStreamingSoftwareRunning()
        {
            foreach (var process in Process.GetProcesses().AsSpan())
            {
                var processLower = process.ProcessName.ToLower();
                if ((processLower.StartsWith("obs"))
                    || (processLower.StartsWith("streamlabs obs"))
                    || (processLower.Equals("twitchstudio")))
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
                Invoke((Action)async delegate { await ConnectTwitchBot(); });
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
                chatConnect = new TwitchIrcClient(ApplicationSettings.Current.Twitch.Custom.Name, ApplicationSettings.Current.Twitch.Custom.OAuthPassword);
            }
            else
            {
                chatConnect = new TwitchIrcClient("gw2loguploader", "oauth:ycgqr3dyef7gp5r8uk7d5jz30nbrc6");
            }
            chatConnect.ReceiveMessage += ReadMessagesAsync;
            chatConnect.StateChange += OnIrcStateChanged;
            await chatConnect.BeginConnectionAsync();
            ApplicationSettings.Current.Twitch.ConnectToTwitch = true;
            ApplicationSettings.Current.Save();
        }

        internal void DisconnectTwitchBot()
        {
            if (InvokeRequired)
            {
                Invoke(delegate { DisconnectTwitchBot(); });
                return;
            }
            chatConnect.ReceiveMessage -= ReadMessagesAsync;
            chatConnect.StateChange -= OnIrcStateChanged;
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
                Invoke((Action)async delegate { await ReconnectTwitchBot(); });
                return;
            }
            chatConnect.ReceiveMessage -= ReadMessagesAsync;
            chatConnect.StateChange -= OnIrcStateChanged;
            chatConnect.Dispose();
            chatConnect = null;
            if (ApplicationSettings.Current.Twitch.Custom.Enabled)
            {
                chatConnect = new TwitchIrcClient(ApplicationSettings.Current.Twitch.Custom.Name, ApplicationSettings.Current.Twitch.Custom.OAuthPassword);
            }
            else
            {
                chatConnect = new TwitchIrcClient("gw2loguploader", "oauth:ycgqr3dyef7gp5r8uk7d5jz30nbrc6");
            }
            chatConnect.ReceiveMessage += ReadMessagesAsync;
            chatConnect.StateChange += OnIrcStateChanged;
            await chatConnect.BeginConnectionAsync();
        }

        protected async void OnIrcStateChanged(object sender, IrcChangedEventArgs e)
        {
            switch (e.NewState)
            {
                case IrcStates.Disconnected:
                    ChannelJoined = false;
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
                        await Task.Run(async () =>
                        {
                            await Task.Delay(reconnectedFailCounter * 15000);
                            await ReconnectTwitchBot();
                        });
                    }
                    else
                    {
                        AddToText("<-?-> FAILED TO RECONNECT TO TWITCH AFTER 4 ATTEMPTS, TRY TO CONNECT MANUALLY");
                        DisconnectTwitchBot();
                    }
                    break;
                case IrcStates.Connecting:
                    AddToText("<-?-> BOT CONNECTING TO TWITCH");
                    break;
                case IrcStates.Connected:
                    AddToText("<-?-> CONNECTION ESTABILISHED");
                    reconnectedFailCounter = 0;
                    if (!string.IsNullOrWhiteSpace(ApplicationSettings.Current.Twitch.ChannelName))
                    {
                        await chatConnect.JoinRoomAsync(ApplicationSettings.Current.Twitch.ChannelName);
                    }
                    break;
                case IrcStates.ChannelJoining:
                    AddToText($"<-?-> TRYING TO JOIN CHANNEL {e.Channel.ToUpper()}");
                    break;
                case IrcStates.ChannelJoined:
                    AddToText("<-?-> CHANNEL JOINED");
                    ChannelJoined = true;
                    break;
                case IrcStates.ChannelLeaving:
                    AddToText($"<-?-> LEAVING CHANNEL {e.Channel.ToUpper()}");
                    break;
                case IrcStates.FailedConnection:
                    AddToText("<-?-> FAILED TO CONNECT TO TWITCH");
                    DisconnectTwitchBot();
                    break;
                default:
                    AddToText("<-?-> UNRECOGNISED IRC STATE RECEIVED");
                    break;
            }
        }

        protected async void ReadMessagesAsync(object sender, IrcMessageEventArgs e)
        {
            if ((e is null) || (e.Message is null))
            {
                return;
            }
            if (e.Message.IsChannelMessage)
            {
                if (twitchCommandsLink.checkBoxSongEnable.Checked && twitchCommandsLink.checkBoxSongSmartRecognition.Checked && songCommandRegex.IsMatch(e.Message.ChannelMessage))
                {
                    await SpotifySongCheck();
                }
                var command = e.Message.ChannelMessage.Split(' ')[0].ToLower();
                if (command.Equals(twitchCommandsLink.textBoxUploaderCommand.Text.ToLower()) && twitchCommandsLink.checkBoxUploaderEnable.Checked)
                {
                    AddToText("> UPLOADER COMMAND USED");
                    await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, $"PlenBot Log Uploader r{ApplicationSettings.Version} | https://plenbot.net/uploader/ | https://github.com/HardstuckGuild/PlenBotLogUploader/");
                }
                else if (command.Equals(twitchCommandsLink.textBoxGW2Build.Text.ToLower()) && twitchCommandsLink.checkBoxGW2BuildEnable.Checked)
                {
                    AddToText("> (GW2) BUILD COMMAND USED");
                    MumbleReader?.Update();
                    if (!string.IsNullOrWhiteSpace(MumbleReader?.Data.Identity?.Name))
                    {
                        _ = Task.Run(async () =>
                        {
                            foreach (var apiKey in ApplicationSettings.Current.GW2APIs.Where(x => x.Valid))
                            {
                                await apiKey.GetCharacters(HttpClientController);
                            }
                            var trueApiKey = ApplicationSettings.Current.GW2APIs.Find(x => x.Characters.Contains(MumbleReader.Data.Identity.Name));
                            try
                            {
                                using var parser = new GW2BuildParser(trueApiKey?.APIKey ?? "");
                                var build = await parser.GetAPIBuildAsync(MumbleReader.Data.Identity.Name, MumbleReader.Data.Context.GameMode);
                                var buildLink = build.GetBuildLink();
                                await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, $"Link to the build: {buildLink}");
                            }
                            catch (NotEnoughPermissionsException ex)
                            {
                                var response = new StringBuilder("The API request failed due to low API key permissions, main reason: ");
                                switch (ex.MissingPermission)
                                {
                                    case NotEnoughPermissionsReason.Characters:
                                        response.Append("the API key is missing \"characters\" permission");
                                        break;
                                    case NotEnoughPermissionsReason.Builds:
                                        response.Append("the API key is missing \"builds\" permission");
                                        break;
                                    default:
                                        response.Append("the API key is invalid");
                                        break;
                                }
                                AddToText(response.ToString());
                            }
                        });
                    }
                    else
                    {
                        AddToText("Read from Mumble Link has failed, is the game running?");
                    }
                }
                else if (command.Equals(twitchCommandsLink.textBoxLastLogCommand.Text.ToLower()) && twitchCommandsLink.checkBoxLastLogEnable.Checked)
                {
                    AddToText("> LAST LOG COMMAND USED");
                    if (!string.IsNullOrWhiteSpace(lastLogMessage))
                    {
                        await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, lastLogMessage);
                    }
                }
                else if (command.Equals(twitchCommandsLink.textBoxPullCounter.Text.ToLower()) && twitchCommandsLink.checkBoxPullCounterEnable.Checked)
                {
                    AddToText("> PULLS COMMAND USED");
                    if (lastLogBossId > 0)
                    {
                        await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, $"{Bosses.GetBossDataFromId(lastLogBossId).Name}{((lastLogBossCM) ? " CM" : string.Empty)} | Current pull: {lastLogPullCounter}");
                    }
                }
                else if (command.Equals(twitchCommandsLink.textBoxSongCommand.Text.ToLower()) && twitchCommandsLink.checkBoxSongEnable.Checked)
                {
                    await SpotifySongCheck();
                }
                else if (command.Equals(twitchCommandsLink.textBoxGW2Ign.Text.ToLower()) && twitchCommandsLink.checkBoxGW2IgnEnable.Checked)
                {
                    AddToText("> (GW2) IGN COMMAND USED");
                    MumbleReader?.Update();
                    if (!string.IsNullOrWhiteSpace(MumbleReader?.Data.Identity?.Name))
                    {
                        _ = Task.Run(async () =>
                        {
                            foreach (var apiKey in ApplicationSettings.Current.GW2APIs.Where(x => x.Valid))
                            {
                                await apiKey.GetCharacters(HttpClientController);
                            }
                            var trueApiKey = ApplicationSettings.Current.GW2APIs.Find(x => x.Characters.Contains(MumbleReader.Data.Identity.Name));
                            if (trueApiKey is null)
                            {
                                return;
                            }
                            using var gw2Api = new Gw2APIHelper(trueApiKey.APIKey);
                            var userInfo = await gw2Api.GetUserInfoAsync();
                            if (userInfo is not null)
                            {
                                var playerWorld = GW2.AllServers[userInfo.World];
                                await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, $"GW2 Account name: {userInfo.Name} | Server: {playerWorld.Name} ({playerWorld.Region})");
                            }
                            else
                            {
                                await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, "An error has occured while getting the user name from an API key.");
                            }
                        });
                    }
                }
            }
        }

        private async Task SpotifySongCheck()
        {
            AddToText("> (Spotify) SONG COMMAND USED");
            try
            {
                var process = Array.Find(Process.GetProcessesByName("Spotify"), x => !string.IsNullOrWhiteSpace(x.MainWindowTitle));
                if (process.MainWindowTitle.Contains("Spotify"))
                {
                    await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, "No song is being played.");
                }
                else
                {
                    await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, process.MainWindowTitle);
                }
            }
            catch
            {
                await chatConnect.SendChatMessageAsync(ApplicationSettings.Current.Twitch.ChannelName, "Spotify is not running.");
            }
        }
        #endregion

        #region buttons & checks, events
        internal void RedrawUserTokenContext()
        {
            toolStripMenuItemDPSReportUserTokens.DropDownItems.Clear();
            if (ApplicationSettings.Current.Upload.DPSReportUserTokens.Count == 0)
            {
                toolStripMenuItemDPSReportUserTokens.DropDownItems.Add(new ToolStripMenuItem() { Enabled = false, Text = "No user tokens defined" });
                return;
            }
            foreach (var userToken in ApplicationSettings.Current.Upload.DPSReportUserTokens.OrderBy(x => x.Name))
            {
                var index = toolStripMenuItemDPSReportUserTokens.DropDownItems.Add(new ToolStripMenuItemCustom<ApplicationSettingsUploadUserToken>() { Checked = userToken.Active, Text = userToken.Name, LinkedObject = userToken });
                toolStripMenuItemDPSReportUserTokens.DropDownItems[index].Click += UserTokenButtonClicked;
            }
        }

        private void UserTokenButtonClicked(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItemCustom<ApplicationSettingsUploadUserToken> pressedButton)
            {
                foreach (var userToken in ApplicationSettings.Current.Upload.DPSReportUserTokens.AsSpan())
                {
                    userToken.Active = false;
                }
                pressedButton.LinkedObject.Active = true;
                dpsReportSettingsLink.RedrawList();
                RedrawUserTokenContext();
            }
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
            if (result.Equals(DialogResult.OK) && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
            {
                ApplicationSettings.Current.LogsLocation = dialog.SelectedPath;
                ApplicationSettings.Current.Save();
                logsCount = 0;
                LogsScan(ApplicationSettings.Current.LogsLocation);
                watcher.Renamed -= OnLogCreated;
                watcher.Dispose();
                watcher = null;
                watcher = new FileSystemWatcher()
                {
                    Path = ApplicationSettings.Current.LogsLocation,
                    Filter = "*.*",
                    IncludeSubdirectories = true,
                    NotifyFilter = NotifyFilters.FileName
                };
                watcher.Renamed += OnLogCreated;
                watcher.EnableRaisingEvents = true;
                buttonOpenLogs.Enabled = true;
            }
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
            }
            else
            {
                Show();
                ShowInTaskbar = true;
                WindowState = FormWindowState.Normal;
                BringToFront();
            }
        }

        private void ButtonChangeTwitchChannel_Click(object sender, EventArgs e) => twitchNameLink.Show();

        private void ToolStripMenuItemUploadLogs_CheckedChanged(object sender, EventArgs e) => checkBoxUploadLogs.Checked = toolStripMenuItemUploadLogs.Checked;

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) => Close();

        private void ToolStripMenuItemPostToTwitch_CheckedChanged(object sender, EventArgs e) => checkBoxPostToTwitch.Checked = toolStripMenuItemPostToTwitch.Checked;

        private void ButtonOpenLogs_Click(object sender, EventArgs e) => Process.Start(ApplicationSettings.Current.LogsLocation);

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
            }
            else
            {
                DisconnectTwitchBot();
                checkBoxPostToTwitch.Checked = false;
            }
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
            var downloadUrl = Array.Find(latestRelease.Assets, x => x.Name.Equals(Process.GetCurrentProcess().ProcessName.Contains("netv6") ? netv6DownloadName : standaloneDownloadName)).DownloadURL;
            if (downloadUrl is null)
            {
                var result = await HttpClientController.DownloadFileAsync(downloadUrl, $"{ApplicationSettings.LocalDir}PlenBotLogUploader_Update.exe");
                if (result)
                {
                    Process.Start(new ProcessStartInfo() { UseShellExecute = true, FileName = $"{ApplicationSettings.LocalDir}PlenBotLogUploader_Update.exe", Arguments = $"-update {Path.GetFileName(Application.ExecutablePath.Replace('/', '\\'))}{((appStartup && StartedMinimised) ? " -m" : string.Empty)}" });
                    if (InvokeRequired)
                    {
                        Invoke(() => ExitApp());
                    }
                    else
                    {
                        ExitApp();
                    }
                }
                else
                {
                    AddToText(">>> Something went wrong with the download. Please try again later.");
                    buttonUpdate.Enabled = true;
                }
            }
            else
            {
                AddToText(">>> Something went wrong with the download. Please try again later.");
                buttonUpdate.Enabled = true;
            }
        }

        private void CheckBoxStartWhenWindowsStarts_CheckedChanged(object sender, EventArgs e)
        {
            using var registryRun = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (checkBoxStartWhenWindowsStarts.Checked)
            {
                registryRun.SetValue("PlenBot Log Uploader", $"\"{Application.ExecutablePath.Replace('/', '\\')}\" -m");
            }
            else
            {
                registryRun.DeleteValue("PlenBot Log Uploader");
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to do this?\nThis resets all your settings but not boss data, webhooks and ping configurations.\nIf you click yes the application will close itself.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result.Equals(DialogResult.Yes))
            {
                Process.Start(ApplicationSettings.LocalDir);
                var reset = new ApplicationSettings();
                reset.Save();
                ExitApp();
            }
        }

        private void TimerCheckUpdate_Tick(object sender, EventArgs e)
        {
            timerCheckUpdate.Stop();
            timerCheckUpdate.Enabled = false;
            Task.Run(() => NewReleaseCheckAsync());
        }

        private void ComboBoxMaxUploads_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(comboBoxMaxUploads.Text, out int threads))
            {
                ApplicationSettings.Current.MaxConcurrentUploads = threads;
                ApplicationSettings.Current.Save();
                semaphore?.Dispose();
                semaphore = new SemaphoreSlim(threads, threads);
            }
        }

        private void ButtonCopyApplicationSession_Click(object sender, EventArgs e)
        {
            if (allSessionLogs.Count > 0)
            {
                Clipboard.SetText(allSessionLogs.Aggregate((a, b) => $"{a}\n{b}"));
            }
        }

        private void CheckBoxAnonymiseReports_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Upload.Anonymous = checkBoxAnonymiseReports.Checked;
            ApplicationSettings.Current.Save();
        }

        private void CheckBoxDetailedWvW_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Upload.DetailedWvW = checkBoxDetailedWvW.Checked;
            ApplicationSettings.Current.Save();
        }

        private void CheckBoxSaveLogsToCSV_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Upload.SaveToCSVEnabled = checkBoxSaveLogsToCSV.Checked;
            ApplicationSettings.Current.Save();
        }
        #endregion
    }
}
