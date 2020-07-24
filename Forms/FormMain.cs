using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Net.Http;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Win32;
using PlenBotLogUploader.Tools;
using PlenBotLogUploader.GW2API;
using PlenBotLogUploader.DPSReport;
using PlenBotLogUploader.TwitchIRCClient;
using Newtonsoft.Json;

namespace PlenBotLogUploader
{
    public partial class FormMain : Form
    {
        #region definitions
        // properties
        public string LastLogLocation { get; set; } = "";
        public List<DPSReportJSON> SessionLogs { get; } = new List<DPSReportJSON>();
        public bool ChannelJoined { get; set; } = false;
        public string DPSReportServer { get; set; } = "";
        public string LocalDir { get; } = $"{Path.GetDirectoryName(Application.ExecutablePath.Replace('/', '\\'))}\\";
        public HttpClientController HttpClientController { get; } = new HttpClientController();
        public bool StartedMinimised { get; private set; } = false;

        // fields
        private readonly FormTwitchNameSetup twitchNameLink;
        private readonly FormDPSReportSettings dpsReportSettingsLink;
        private readonly FormCustomName customNameLink;
        private readonly FormArcVersions arcVersionsLink;
        private readonly FormBossData bossDataLink;
        private readonly FormDiscordWebhooks discordWebhooksLink;
        private readonly FormPings pingsLink;
        private readonly FormTwitchCommands twitchCommandsLink;
        private readonly FormLogSession logSessionLink;
        private readonly FormGW2API gw2APILink;
        private readonly Dictionary<int, BossData> allBosses = Bosses.GetAllBosses();
        private SemaphoreSlim semaphore;
        private TwitchIrcClient chatConnect;
        private FileSystemWatcher watcher = new FileSystemWatcher() { Filter = "*.*", IncludeSubdirectories = true, NotifyFilter = NotifyFilters.FileName };
        private int reconnectedFailCounter = 0;
        private int recentUploadFailCounter = 0;
        private int logsCount = 0;
        private int lastBossId = 0;
        private int pullCounter = 0;
        private bool lastBossCM = false;

        // constants
        private const int minFileSize = 8192;
        #endregion

        #region constructor
        public FormMain()
        {
            CompatibilityUpdate.SetLocalDir(LocalDir);
            CompatibilityUpdate.DoUpdate();
            InitializeComponent();
            Properties.Settings.Default.PropertyChanged += delegate { Properties.Settings.Default.Save(); };
            Icon = Properties.Resources.AppIcon;
            notifyIconTray.Icon = Properties.Resources.AppIcon;
            Text = $"{Text} r{Properties.Settings.Default.ReleaseVersion}";
            notifyIconTray.Text = $"{notifyIconTray.Text} r{Properties.Settings.Default.ReleaseVersion}";
            semaphore = new SemaphoreSlim(Properties.Settings.Default.MaxConcurrentUploads, Properties.Settings.Default.MaxConcurrentUploads);
            comboBoxMaxUploads.Text = Properties.Settings.Default.MaxConcurrentUploads.ToString();
            twitchNameLink = new FormTwitchNameSetup(this);
            dpsReportSettingsLink = new FormDPSReportSettings(this);
            customNameLink = new FormCustomName(this);
            pingsLink = new FormPings(this);
            arcVersionsLink = new FormArcVersions(this);
            bossDataLink = new FormBossData(this);
            discordWebhooksLink = new FormDiscordWebhooks(this);
            twitchCommandsLink = new FormTwitchCommands();
            logSessionLink = new FormLogSession(this);
            gw2APILink = new FormGW2API();
            #region tooltips
            toolTip.SetToolTip(checkBoxUploadLogs, "If checked, all created logs will be uploaded.");
            toolTip.SetToolTip(checkBoxFileSizeIgnore, "If checked, logs with less than 8 kB filesize will not be uploaded.");
            toolTip.SetToolTip(checkBoxPostToTwitch, "If checked, logs will be posted to Twitch channel if properly connected to it and OBS is running.");
            toolTip.SetToolTip(checkBoxTwitchOnlySuccess, "If checked, only successful logs will be linked to Twitch channel if properly connected to it.");
            toolTip.SetToolTip(labelMaximumUploads, "Sets the maximum allowed uploads for drag & drop.");
            toolTip.SetToolTip(twitchCommandsLink.checkBoxSongEnable, "If checked, the given command will output current song from Spotify to Twitch chat.");
            #endregion
            try
            {
                if (Properties.Settings.Default.FirstRun)
                {
                    MessageBox.Show("It looks like this is the first time you are running this program.\nIf you have any issues feel free to contact me directly via Twitch, Discord (@Plenyx#1029) or via GitHub!\n\nPlenyx", "Thank you for using PlenBotLogUploader", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var arcFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Guild Wars 2\\addons\\arcdps\\arcdps.cbtlogs\\";
                    if (Directory.Exists(arcFolder))
                    {
                        Properties.Settings.Default.LogsLocation = arcFolder;
                        MessageBox.Show($"arcdps log folder has been automatically set to\n{arcFolder}", "arcdps log folder automatically set", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    twitchNameLink.Show();
                    Properties.Settings.Default.FirstRun = false;
                }
                if ((Properties.Settings.Default.LogsLocation == "") || !Directory.Exists(Properties.Settings.Default.LogsLocation))
                {
                    labelLocationInfo.Text = "!!! Select a directory with arc logs !!!";
                }
                else
                {
                    if (Directory.Exists(Properties.Settings.Default.LogsLocation))
                    {
                        LogsScan(Properties.Settings.Default.LogsLocation);
                        watcher.Path = Properties.Settings.Default.LogsLocation;
                        watcher.Renamed += OnLogCreated;
                        watcher.EnableRaisingEvents = true;
                        buttonOpenLogs.Enabled = true;
                    }
                    else
                    {
                        Properties.Settings.Default.LogsLocation = "";
                        labelLocationInfo.Text = "!!! Select a directory with arc logs !!!";
                    }
                }
                Properties.Settings.Default.TwitchChannelName = Properties.Settings.Default.TwitchChannelName.ToLower();
                if (Properties.Settings.Default.TwitchChannelName != "")
                {
                    twitchNameLink.textBoxChannelUrl.Text = $"https://twitch.tv/{Properties.Settings.Default.TwitchChannelName}/";
                }
                switch (Properties.Settings.Default.DPSReportServer)
                {
                    case 0:
                        DPSReportServer = "https://dps.report";
                        break;
                    case 1:
                        DPSReportServer = "http://a.dps.report";
                        dpsReportSettingsLink.radioButtonA.Checked = true;
                        break;
                    default:
                        DPSReportServer = "https://b.dps.report";
                        dpsReportSettingsLink.radioButtonB.Checked = true;
                        break;
                }
                if (Properties.Settings.Default.DPSReportUsertokenEnabled)
                {
                    dpsReportSettingsLink.checkBoxDPSReportEnableUsertoken.Checked = true;
                }
                dpsReportSettingsLink.textBoxDPSReportUsertoken.Text = Properties.Settings.Default.DPSReportUsertoken;
                if (Properties.Settings.Default.UploadLogs)
                {
                    checkBoxUploadLogs.Checked = true;
                    checkBoxPostToTwitch.Enabled = true;
                    toolStripMenuItemUploadLogs.Checked = true;
                    toolStripMenuItemPostToTwitch.Enabled = true;
                }
                if (Properties.Settings.Default.UploadToTwitch)
                {
                    checkBoxPostToTwitch.Checked = true;
                    checkBoxPostToTwitch.Enabled = true;
                    toolStripMenuItemPostToTwitch.Checked = true;
                    toolStripMenuItemPostToTwitch.Enabled = true;
                    checkBoxTwitchOnlySuccess.Enabled = true;
                    if (Properties.Settings.Default.UploadToTwitchOnlySuccess)
                    {
                        checkBoxTwitchOnlySuccess.Checked = true;
                    }
                }
                if (Properties.Settings.Default.UploadIgnoreFileSize)
                {
                    checkBoxFileSizeIgnore.Checked = true;
                }
                if (Properties.Settings.Default.TrayMinimise)
                {
                    checkBoxTrayMinimiseToIcon.Checked = true;
                }
                if (Properties.Settings.Default.CustomTwitchNameEnabled)
                {
                    customNameLink.checkBoxCustomNameEnable.Checked = true;
                    Properties.Settings.Default.CustomTwitchName = Properties.Settings.Default.CustomTwitchName.ToLower();
                    customNameLink.textBoxCustomName.Text = Properties.Settings.Default.CustomTwitchName;
                    customNameLink.textBoxCustomOAuth.Text = Properties.Settings.Default.CustomTwitchOAuthPassword;
                }
                arcVersionsLink.GW2Location = Properties.Settings.Default.GW2Location;
                if (arcVersionsLink.GW2Location != "")
                {
                    if (File.Exists($@"{arcVersionsLink.GW2Location}\Gw2-64.exe") || File.Exists($@"{arcVersionsLink.GW2Location}\Gw2.exe"))
                    {
                        Task.Run(() => { arcVersionsLink.StartTimerAsync(true); });
                        arcVersionsLink.buttonEnabler.Enabled = true;
                        arcVersionsLink.buttonCheckNow.Enabled = true;
                    }
                    else
                    {
                        ShowBalloon("arcdps version checking", "There has been an error locating the main Guild Wars 2 folder, try changing the directory again.", 6500);
                        arcVersionsLink.GW2Location = "";
                        Properties.Settings.Default.GW2Location = "";
                    }
                }
                twitchCommandsLink.checkBoxUploaderEnable.Checked = Properties.Settings.Default.TwitchCommandUploaderEnabled;
                twitchCommandsLink.textBoxUploaderCommand.Text = Properties.Settings.Default.TwitchCommandUploader;
                twitchCommandsLink.checkBoxLastLogEnable.Checked = Properties.Settings.Default.TwitchCommandLastLogEnabled;
                twitchCommandsLink.textBoxLastLogCommand.Text = Properties.Settings.Default.TwitchCommandLastLog;
                twitchCommandsLink.checkBoxSongEnable.Checked = Properties.Settings.Default.TwitchCommandSongEnabled;
                twitchCommandsLink.textBoxSongCommand.Text = Properties.Settings.Default.TwitchCommandSong;
                twitchCommandsLink.checkBoxGW2IgnEnable.Checked = Properties.Settings.Default.TwitchCommandGW2IgnEnabled;
                twitchCommandsLink.textBoxGW2Ign.Text = Properties.Settings.Default.TwitchCommandGW2Ign;
                twitchCommandsLink.checkBoxPullCounterEnable.Checked = Properties.Settings.Default.TwitchCommandPullCounterEnabled;
                twitchCommandsLink.textBoxPullCounter.Text = Properties.Settings.Default.TwitchCommandPullCounter;
                logSessionLink.textBoxSessionName.Text = Properties.Settings.Default.SessionName;
                logSessionLink.checkBoxSupressWebhooks.Checked = Properties.Settings.Default.SessionSuppressWebhooks;
                logSessionLink.checkBoxOnlySuccess.Checked = Properties.Settings.Default.SessionOnlySuccess;
                logSessionLink.textBoxSessionContent.Text = Properties.Settings.Default.SessionMessage;
                logSessionLink.radioButtonSortByUpload.Checked = Properties.Settings.Default.SessionSort == 1;
                logSessionLink.checkBoxSaveToFile.Checked = Properties.Settings.Default.SessionSaveToFile;
                arcVersionsLink.checkBoxAutoUpdateArc.Checked = Properties.Settings.Default.ArcAutoUpdate;
                gw2APILink.textBoxAPIKey.Text = Properties.Settings.Default.GW2APIKey;
                if ((Properties.Settings.Default.LogsLocation == "") || !Directory.Exists(Properties.Settings.Default.LogsLocation))
                {
                    MessageBox.Show("Path to arcdps logs is not set.\nDo not forget to set it up so the logs can be auto-uploaded.", "Just a reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Properties.Settings.Default.ConnectToTwitch)
                {
                    if (Properties.Settings.Default.CustomTwitchNameEnabled)
                    {
                        chatConnect = new TwitchIrcClient(Properties.Settings.Default.CustomTwitchName, Properties.Settings.Default.CustomTwitchOAuthPassword);
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
                if (!File.Exists($"{LocalDir}uploaded_logs.csv"))
                {
                    File.AppendAllText($"{LocalDir}uploaded_logs.csv", "Boss;BossId;Success;Duration;RecordedBy;EliteInsightsVersion;arcdpsVersion;Permalink\n");
                }
                // startup check
                using (RegistryKey registryRun = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
                {
                    if (registryRun.GetValue("PlenBot Log Uploader") != null)
                    {
                        checkBoxStartWhenWindowsStarts.Checked = true;
                    }
                }
                /* Subscribe to field changes events, otherwise they would trigger on load */
                checkBoxPostToTwitch.CheckedChanged += new EventHandler(CheckBoxPostToTwitch_CheckedChanged);
                checkBoxUploadLogs.CheckedChanged += new EventHandler(CheckBoxUploadAll_CheckedChanged);
                checkBoxFileSizeIgnore.CheckedChanged += new EventHandler(CheckBoxFileSizeIgnore_CheckedChanged);
                checkBoxTrayMinimiseToIcon.CheckedChanged += new EventHandler(CheckBoxTrayMinimiseToIcon_CheckedChanged);
                checkBoxTwitchOnlySuccess.CheckedChanged += new EventHandler(CheckBoxTwitchOnlySuccess_CheckedChanged);
                checkBoxStartWhenWindowsStarts.CheckedChanged += new EventHandler(CheckBoxStartWhenWindowsStarts_CheckedChanged);
                comboBoxMaxUploads.SelectedIndexChanged += new EventHandler(ComboBoxMaxUploads_SelectedIndexChanged);
                logSessionLink.checkBoxSupressWebhooks.CheckedChanged += new EventHandler(logSessionLink.CheckBoxSupressWebhooks_CheckedChanged);
                logSessionLink.checkBoxOnlySuccess.CheckedChanged += new EventHandler(logSessionLink.CheckBoxOnlySuccess_CheckedChanged);
                logSessionLink.checkBoxSaveToFile.CheckedChanged += new EventHandler(logSessionLink.CheckBoxSaveToFile_CheckedChanged);
                arcVersionsLink.checkBoxAutoUpdateArc.CheckedChanged += new EventHandler(arcVersionsLink.CheckBoxAutoUpdateArc_CheckedChanged);
            }
            catch
            {
                MessageBox.Show("An error has been encountered in the configuration file.\nTry deleting the configuration file and try again.", "An error has occurred");
                ExitApp();
            }
        }
        #endregion

        #region form events
        private void FormMain_Load(object sender, EventArgs e)
        {
            DoCommandArgs();
            Task.Run(() => NewReleaseCheckAsync());
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            chatConnect?.Dispose();
            semaphore?.Dispose();
            HttpClientController?.Dispose();
            watcher?.Dispose();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if ((WindowState == FormWindowState.Minimized) && checkBoxTrayMinimiseToIcon.Checked)
            {
                ShowInTaskbar = false;
                Hide();
                if (Properties.Settings.Default.FirstTimeMinimise)
                {
                    ShowBalloon("Uploader minimised", "Double click the icon to bring back the uploader.\nYou can also right click for quick settings.", 6500);
                    Properties.Settings.Default.FirstTimeMinimise = false;
                }
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
            var files = ((string[])e.Data.GetData(DataFormats.FileDrop)).ToList();
            foreach (var file in files)
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
            Dictionary<string, string> postData = new Dictionary<string, string>
            {
                { "generator", "ei" },
                { "json", "1" }
            };
            if (File.Exists(file) && (file.EndsWith(".evtc") || file.EndsWith(".zevtc")))
            {
                bool archived = false;
                string zipfilelocation = file;
                if (!file.EndsWith(".zevtc"))
                {
                    zipfilelocation = $"{LocalDir}{Path.GetFileName(file)}.zevtc";
                    using (ZipArchive zipfile = ZipFile.Open(zipfilelocation, ZipArchiveMode.Create)) { zipfile.CreateEntryFromFile(@file, Path.GetFileName(file)); }
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
                        File.Delete($"{LocalDir}{Path.GetFileName(zipfilelocation)}.zevtc");
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
                Interlocked.Increment(ref logsCount);
                if (checkBoxUploadLogs.Checked)
                {
                    try
                    {
                        if (checkBoxFileSizeIgnore.Checked || new FileInfo(e.FullPath).Length >= minFileSize)
                        {
                            string zipfilelocation = e.FullPath;
                            bool archived = false;
                            // a workaround so arcdps can release the file for read access
                            Thread.Sleep(650);
                            if (!e.FullPath.EndsWith(".zevtc"))
                            {
                                zipfilelocation = $"{LocalDir}{Path.GetFileName(e.FullPath)}.zevtc";
                                using (ZipArchive zipfile = ZipFile.Open(zipfilelocation, ZipArchiveMode.Create)) { zipfile.CreateEntryFromFile(@e.FullPath, Path.GetFileName(e.FullPath)); }
                                archived = true;
                            }
                            try
                            {
                                Dictionary<string, string> postData = new Dictionary<string, string>
                                {
                                    { "generator", "ei" },
                                    { "json", "1" }
                                };
                                await HttpUploadLogAsync(zipfilelocation, postData);
                            }
                            catch
                            {
                                throw;
                            }
                            finally
                            {
                                if (archived)
                                {
                                    File.Delete($"{LocalDir}{Path.GetFileName(e.FullPath)}.zevtc");
                                }
                            }
                        }
                    }
                    catch
                    {
                        Interlocked.Decrement(ref logsCount);
                        AddToText($">:> Unable to upload the file: {e.FullPath}");
                    }
                }
                UpdateLogCount();
            }
        }

        public void ShowBalloon(string title, string description, int ms) => notifyIconTray.ShowBalloonTip(ms, title, description, ToolTipIcon.None);

        private void LogsScan(string directory)
        {
            Parallel.ForEach(Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories), f => {
                if (f.EndsWith(".evtc") || f.EndsWith(".zevtc"))
                {
                    Interlocked.Increment(ref logsCount);
                }
            });
            UpdateLogCount();
        }

        protected async void NewReleaseCheckAsync()
        {
            try
            {
                string response = await HttpClientController.DownloadFileToStringAsync("https://raw.githubusercontent.com/DelusionalElitists/PlenBotLogUploader/master/VERSION");
                if (int.TryParse(response, out int currentversion))
                {
                    if (currentversion > Properties.Settings.Default.ReleaseVersion)
                    {
                        if (buttonUpdateNow.InvokeRequired)
                        {
                            buttonUpdateNow.Invoke((Action)delegate () { buttonUpdateNow.Visible = true; });
                        }
                        else
                        {
                            buttonUpdateNow.Visible = true;
                        }
                        var notes = await HttpClientController.DownloadFileToStringAsync("https://plenbot.net/uploader/release-info/");
                        AddToText($">>> New release available (r{response})");
                        AddToText(">>> https://github.com/DelusionalElitists/PlenBotLogUploader/releases/");
                        AddToText(notes);
                        ShowBalloon("New release available for the uploader", $"If you want to update immediately, use the \"Update uploader\" button.\nThe latest release is n. {response}.", 8500);
                        Properties.Settings.Default.SavedVersion = Properties.Settings.Default.SavedVersion;
                    }
                    else
                    {
                        timerCheckUpdate.Enabled = true;
                        timerCheckUpdate.Start();
                    }
                }
            }
            catch
            {
                AddToText(">>> Unable to check new release version.");
            }
        }

        private void ExitApp()
        {
            Close();
            Application.Exit();
        }

        protected async void DoCommandArgs()
        {
            var args = Environment.GetCommandLineArgs().ToList();
            if (args.Count > 1)
            {
                if ((args.Count == 2) && (args[1].Equals("-m")))
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
                    Dictionary<string, string> postData = new Dictionary<string, string>
                    {
                        { "generator", "ei" },
                        { "json", "1" }
                    };
                    foreach (string arg in args)
                    {
                        if (arg == Application.ExecutablePath)
                        {
                            continue;
                        }
                        if (File.Exists(arg) && (arg.EndsWith(".evtc") || arg.EndsWith(".zevtc")))
                        {
                            bool archived = false;
                            string zipfilelocation = arg;
                            if (!arg.EndsWith(".zevtc"))
                            {
                                zipfilelocation = $"{LocalDir}{Path.GetFileName(arg)}.zevtc";
                                using (ZipArchive zipfile = ZipFile.Open(zipfilelocation, ZipArchiveMode.Create)) { zipfile.CreateEntryFromFile(@arg, Path.GetFileName(arg)); }
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
                                    File.Delete($"{LocalDir}{Path.GetFileName(zipfilelocation)}.zevtc");
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region self-invocable functions
        public void AddToText(string s)
        {
            if (richTextBoxUploadInfo.InvokeRequired)
            {
                // invokes the same function on the main thread
                richTextBoxUploadInfo.Invoke((Action<string>)delegate (string text) { AddToText(text); }, s);
            }
            else
            {
                var messagePre = s.IndexOf(' ');
                if (messagePre != -1)
                {
                    richTextBoxUploadInfo.SelectionColor = Color.Blue;
                    richTextBoxUploadInfo.AppendText(s.Substring(0, messagePre + 1));
                    richTextBoxUploadInfo.SelectionColor = Color.Black;
                    richTextBoxUploadInfo.AppendText($"{s.Substring(messagePre)}{Environment.NewLine}");
                }
                else
                {
                    richTextBoxUploadInfo.AppendText($"{s}{Environment.NewLine}");
                }
                richTextBoxUploadInfo.SelectionStart = richTextBoxUploadInfo.TextLength;
                richTextBoxUploadInfo.ScrollToCaret();
            }
            
        }

        private void UpdateLogCount()
        {
            if (labelLocationInfo.InvokeRequired)
            {
                // invokes the same function on the main thread
                labelLocationInfo.Invoke((Action)delegate () { UpdateLogCount(); });
            }
            else
            {
                labelLocationInfo.Text = $"Logs in the directory: {logsCount}";
            }
        }
        #endregion

        #region log upload and processing
        public async Task SendLogToTwitchChatAsync(DPSReportJSON reportJSON, bool bypassMessage = false)
        {
            if (ChannelJoined && checkBoxPostToTwitch.Checked && !bypassMessage && IsOBSRunning())
            {
                AddToText($">:> {reportJSON.Permalink}");
                var bossDataRef = allBosses
                    .Where(anon => anon.Value.BossId.Equals(reportJSON.ExtraJSON?.TriggerID ?? reportJSON.Encounter.BossId))
                    .Select(anon => anon.Value);
                if (bossDataRef.Count() == 1)
                {
                    var format = bossDataRef.First().TwitchMessageFormat(reportJSON, pullCounter);
                    if (!string.IsNullOrWhiteSpace(format))
                    {
                        await chatConnect.SendChatMessageAsync(Properties.Settings.Default.TwitchChannelName, format);
                    }
                }
                else
                {
                    await chatConnect.SendChatMessageAsync(Properties.Settings.Default.TwitchChannelName, $"Link to the log: {reportJSON.Permalink}");
                }
            }
            else
            {
                AddToText($">:> {reportJSON.Permalink}");
            }
        }

        public async Task HttpUploadLogAsync(string file, Dictionary<string, string> postData, bool bypassMessage = false)
        {
            using (var content = new MultipartFormDataContent())
            {
                foreach (string key in postData.Keys)
                {
                    content.Add(new StringContent(postData[key]), key);
                }
                AddToText($">:> Uploading {Path.GetFileName(file)}");
                int bossId = 1;
                try
                {
                    using (FileStream inputStream = File.OpenRead(file))
                    {
                        using (StreamContent contentStream = new StreamContent(inputStream))
                        {
                            content.Add(contentStream, "file", Path.GetFileName(file));
                            try
                            {
                                var uri = new Uri($"{DPSReportServer}/uploadContent{((Properties.Settings.Default.DPSReportUsertokenEnabled) ? $"?userToken={Properties.Settings.Default.DPSReportUsertoken}" : "")}");
                                using (var responseMessage = await HttpClientController.PostAsync(uri, content))
                                {
                                    string response = await responseMessage.Content.ReadAsStringAsync();
                                    try
                                    {
                                        var reportJSON = JsonConvert.DeserializeObject<DPSReportJSON>(response);
                                        if (string.IsNullOrEmpty(reportJSON.Error))
                                        {
                                            bossId = reportJSON.Encounter.BossId;
                                            string success = (reportJSON.Encounter.Success ?? false) ? "true" : "false";
                                            // extra JSON from Elite Insights
                                            if (reportJSON.Encounter.JsonAvailable ?? false)
                                            {
                                                try
                                                {
                                                    string jsonString = await HttpClientController.DownloadFileToStringAsync($"https://dps.report/getJson?permalink={reportJSON.Permalink}");
                                                    var extraJSON = JsonConvert.DeserializeObject<DPSReportJSONExtraJSON>(jsonString);
                                                    reportJSON.ExtraJSON = extraJSON;
                                                    bossId = reportJSON.ExtraJSON.TriggerID;
                                                    lastBossCM = reportJSON.ExtraJSON.IsCM;
                                                }
                                                catch
                                                {
                                                    AddToText(">:> Extra JSON available but couldn't be obtained.");
                                                }
                                            }
                                            // log file
                                            File.AppendAllText($"{LocalDir}uploaded_logs.csv",
                                                $"{reportJSON.ExtraJSON?.FightName ?? reportJSON.Encounter.Boss};{bossId};{success};{reportJSON.ExtraJSON?.Duration ?? ""};{reportJSON.ExtraJSON?.RecordedBy ?? ""};{reportJSON.ExtraJSON?.EliteInsightsVersion ?? ""};{reportJSON.EVTC.Type}{reportJSON.EVTC.Version};{reportJSON.Permalink}\n");
                                            // Twitch chat
                                            LastLogLocation = reportJSON.Permalink;
                                            if (lastBossId != bossId)
                                            {
                                                pullCounter = 0;
                                            }
                                            lastBossId = bossId;
                                            if (reportJSON.Encounter.Success ?? false)
                                            {
                                                pullCounter = 0;
                                            }
                                            else
                                            {
                                                pullCounter++;
                                            }
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
                                        }
                                        else if(reportJSON.Error.Length > 0)
                                        {
                                            AddToText($">:> Unable to process file {Path.GetFileName(file)}, dps.report responded with following error message: {reportJSON.Error}");
                                        }
                                        else
                                        {
                                            AddToText($">:> Unable to process file {Path.GetFileName(file)}, error while deserilising the response.");
                                        }
                                    }
                                    catch
                                    {
                                        AddToText($">:> Unable to process file {Path.GetFileName(file)}, dps.report responded with invalid permanent link");
                                    }
                                }
                            }
                            catch
                            {
                                AddToText($">:> Unable to upload file {Path.GetFileName(file)}, dps.report not responding");
                                Interlocked.Increment(ref recentUploadFailCounter);
                                if (recentUploadFailCounter > 3)
                                {
                                    Interlocked.Exchange(ref recentUploadFailCounter, 0);
                                    AddToText($">:> Upload retry failed 3 times for {Path.GetFileName(file)}");
                                }
                                else
                                {
                                    await Task.Run(async () =>
                                    {
                                        int delay = 0;
                                        switch (recentUploadFailCounter)
                                        {
                                            case 3:
                                                delay = 45000;
                                                break;
                                            case 2:
                                                delay = 15000;
                                                break;
                                            default:
                                                delay = 3000;
                                                break;
                                        }
                                        AddToText($">:> Retrying in {(int)(delay/1000)}s...");
                                        await Task.Delay(delay);
                                        await HttpUploadLogAsync(file, postData, bypassMessage);
                                    });
                                }
                            }
                        }
                    }
                }
                catch
                {
                    Thread.Sleep(650);
                    await HttpUploadLogAsync(file, postData, bypassMessage);
                }
            }
        }

        public async Task ExecuteSessionLogWebhooksAsync(LogSessionSettings logSessionSettings) => await discordWebhooksLink.ExecuteSessionWebhooksAsync(SessionLogs, logSessionSettings);
        #endregion

        #region Twitch bot methods
        public bool IsTwitchConnectionNull() => chatConnect == null;

        public bool IsOBSRunning()
        {
            var processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                if ((process.ProcessName.ToLower() == "obs") || (process.ProcessName.ToLower() == "obs64") || (process.ProcessName.ToLower() == "streamlabs obs"))
                {
                    return true;
                }
            }
            return false;
        }

        public void ConnectTwitchBot()
        {
            if (InvokeRequired)
            {
                Invoke((Action)delegate { ConnectTwitchBot(); });
                return;
            }
            buttonDisConnectTwitch.Text = "Disconnect from Twitch";
            buttonChangeTwitchChannel.Enabled = true;
            toolStripMenuItemPostToTwitch.Enabled = true;
            toolStripMenuItemOpenTwitchCommands.Enabled = true;
            buttonCustomName.Enabled = true;
            buttonTwitchCommands.Enabled = true;
            checkBoxPostToTwitch.Enabled = true;
            if (Properties.Settings.Default.CustomTwitchNameEnabled)
            {
                chatConnect = new TwitchIrcClient(Properties.Settings.Default.CustomTwitchName, Properties.Settings.Default.CustomTwitchOAuthPassword);
            }
            else
            {
                chatConnect = new TwitchIrcClient("gw2loguploader", "oauth:ycgqr3dyef7gp5r8uk7d5jz30nbrc6");
            }
            chatConnect.ReceiveMessage += ReadMessagesAsync;
            chatConnect.StateChange += OnIrcStateChanged;
            chatConnect.BeginConnection();
            Properties.Settings.Default.ConnectToTwitch = true;
        }

        public void DisconnectTwitchBot()
        {
            if (InvokeRequired)
            {
                Invoke((Action)delegate { DisconnectTwitchBot(); });
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
            Properties.Settings.Default.ConnectToTwitch = false;
        }

        public void ReconnectTwitchBot()
        {
            if (InvokeRequired)
            {
                Invoke((Action)delegate { ReconnectTwitchBot(); });
                return;
            }
            chatConnect.ReceiveMessage -= ReadMessagesAsync;
            chatConnect.StateChange -= OnIrcStateChanged;
            chatConnect.Dispose();
            chatConnect = null;
            if (Properties.Settings.Default.CustomTwitchNameEnabled)
            {
                chatConnect = new TwitchIrcClient(Properties.Settings.Default.CustomTwitchName, Properties.Settings.Default.CustomTwitchOAuthPassword);
            }
            else
            {
                chatConnect = new TwitchIrcClient("gw2loguploader", "oauth:ycgqr3dyef7gp5r8uk7d5jz30nbrc6");
            }
            chatConnect.ReceiveMessage += ReadMessagesAsync;
            chatConnect.StateChange += OnIrcStateChanged;
            chatConnect.BeginConnection();
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
                        Invoke((Action)delegate () { reconnectedFailCounter++; });
                    }
                    else
                    {
                        reconnectedFailCounter++;
                    }
                    if (reconnectedFailCounter <= 3)
                    {
                        AddToText($"<-?-> TRYING TO RECONNECT TO TWITCH IN {reconnectedFailCounter*10}s");
                        await Task.Run(() =>
                        {
                            Thread.Sleep(reconnectedFailCounter * 10000);
                            ReconnectTwitchBot();
                        });
                    }
                    else
                    {
                        AddToText("<-?-> FAILED TO RECONNECT TO TWITCH AFTER 3 ATTEMPTS, TRY TO CONNECT MANUALLY");
                        DisconnectTwitchBot();
                    }
                    break;
                case IrcStates.Connecting:
                    AddToText("<-?-> BOT CONNECTING TO TWITCH");
                    break;
                case IrcStates.Connected:
                    AddToText("<-?-> CONNECTION ESTABILISHED");
                    reconnectedFailCounter = 0;
                    if (Properties.Settings.Default.TwitchChannelName != "")
                    {
                        await chatConnect.JoinRoomAsync(Properties.Settings.Default.TwitchChannelName);
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
            if ((e == null) || (e.Message == null))
            {
                return;
            }
            string[] messageSplit = e.Message.Split(new string[] { $"#{Properties.Settings.Default.TwitchChannelName} :" }, StringSplitOptions.None);
            if (messageSplit.Length > 1)
            {
                string command = messageSplit[1].Split(' ')[0].ToLower();
                if (command.Equals(twitchCommandsLink.textBoxUploaderCommand.Text.ToLower()) && twitchCommandsLink.checkBoxUploaderEnable.Checked)
                {
                    AddToText("> UPLOADER COMMAND USED");
                    await chatConnect.SendChatMessageAsync(Properties.Settings.Default.TwitchChannelName, $"PlenBot Log Uploader r{Properties.Settings.Default.ReleaseVersion} | https://plenbot.net/uploader/ | https://github.com/DelusionalElitists/PlenBotLogUploader/");
                }
                else if (command.Equals(twitchCommandsLink.textBoxLastLogCommand.Text.ToLower()) && twitchCommandsLink.checkBoxLastLogEnable.Checked)
                {
                    if (LastLogLocation != "")
                    {
                        AddToText("> LAST LOG COMMAND USED");
                        await chatConnect.SendChatMessageAsync(Properties.Settings.Default.TwitchChannelName, $"Link to the last log: {LastLogLocation}");
                    }
                }
                else if (command.Equals(twitchCommandsLink.textBoxPullCounter.Text.ToLower()) && twitchCommandsLink.checkBoxPullCounterEnable.Checked)
                {
                    if (lastBossId > 0)
                    {
                        AddToText("> PULLS COMMAND USED");
                        var bossDataRef = allBosses
                            .Where(anon => anon.Value.BossId.Equals(lastBossId))
                            .Select(anon => anon.Value);
                        await chatConnect.SendChatMessageAsync(Properties.Settings.Default.TwitchChannelName, $"{bossDataRef.First().Name}{((lastBossCM) ? " CM" : "")} | Current pull: {pullCounter}");
                    }
                }
                else if (command.Equals(twitchCommandsLink.textBoxSongCommand.Text.ToLower()) && twitchCommandsLink.checkBoxSongEnable.Checked)
                {
                    AddToText("> (Spotify) SONG COMMAND USED");
                    try
                    {
                        Process process = Process.GetProcessesByName("Spotify").FirstOrDefault(anon => !string.IsNullOrWhiteSpace(anon.MainWindowTitle));
                        if (process.MainWindowTitle.Contains("Spotify"))
                        {
                            await chatConnect.SendChatMessageAsync(Properties.Settings.Default.TwitchChannelName, "No song is being played.");
                        }
                        else
                        {
                            await chatConnect.SendChatMessageAsync(Properties.Settings.Default.TwitchChannelName, process.MainWindowTitle);
                        }
                    }
                    catch
                    {
                        await chatConnect.SendChatMessageAsync(Properties.Settings.Default.TwitchChannelName, "Spotify is not running.");
                    }
                }
                else if (command.Equals(twitchCommandsLink.textBoxGW2Ign.Text.ToLower()) && twitchCommandsLink.checkBoxGW2IgnEnable.Checked)
                {
                    AddToText("> (GW2) IGN COMMAND USED");
                    if (Properties.Settings.Default.GW2APIKey != "")
                    {
                        using (Gw2APIHelper gw2Api = new Gw2APIHelper(Properties.Settings.Default.GW2APIKey))
                        {
                            var userInfo = await gw2Api.GetUserInfoAsync();
                            var playerWorld = GW2.GW2Servers[userInfo.World];
                            await chatConnect.SendChatMessageAsync(Properties.Settings.Default.TwitchChannelName, $"GW2 Account name: {userInfo.Name} | Server: {playerWorld.Name} ({playerWorld.Region})");
                        }
                    }
                }
            }
        }
        #endregion

        #region buttons & checks, events
        private void CheckBoxUploadAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUploadLogs.Checked)
            {
                Properties.Settings.Default.UploadLogs = true;
                toolStripMenuItemUploadLogs.Checked = true;
                checkBoxPostToTwitch.Enabled = true;
                toolStripMenuItemPostToTwitch.Enabled = true;
            }
            else
            {
                Properties.Settings.Default.UploadLogs = false;
                toolStripMenuItemUploadLogs.Checked = false;
                checkBoxPostToTwitch.Enabled = false;
                checkBoxPostToTwitch.Checked = false;
                toolStripMenuItemPostToTwitch.Enabled = false;
                toolStripMenuItemPostToTwitch.Checked = false;
            }
        }

        private void ButtonReconnectBot_Click(object sender, EventArgs e)
        {
            reconnectedFailCounter = 0;
            ReconnectTwitchBot();
        }

        private void ButtonLogsLocation_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog() { Description = "Select the arcdps folder containing the combat logs.\nThe default location is in \"My Documents\\Guild Wars 2\\addons\\arcdps\\arcdps.cbtlogs\\\"" })
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    Properties.Settings.Default.LogsLocation = dialog.SelectedPath;
                    logsCount = 0;
                    LogsScan(Properties.Settings.Default.LogsLocation);
                    watcher.Renamed -= OnLogCreated;
                    watcher.Dispose();
                    watcher = null;
                    watcher = new FileSystemWatcher()
                    {
                        Path = Properties.Settings.Default.LogsLocation,
                        Filter = "*.*",
                        IncludeSubdirectories = true,
                        NotifyFilter = NotifyFilters.FileName
                    };
                    watcher.Renamed += OnLogCreated;
                    watcher.EnableRaisingEvents = true;
                    buttonOpenLogs.Enabled = true;
                }
            }
        }

        private void CheckBoxTrayMinimiseToIcon_CheckedChanged(object sender, EventArgs e) => Properties.Settings.Default.TrayMinimise = checkBoxTrayMinimiseToIcon.Checked;

        private void CheckBoxPostToTwitch_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.UploadToTwitch = checkBoxPostToTwitch.Checked;
            toolStripMenuItemPostToTwitch.Checked = checkBoxPostToTwitch.Checked;
            checkBoxTwitchOnlySuccess.Enabled = checkBoxPostToTwitch.Checked;
            if (!checkBoxPostToTwitch.Checked)
            {
                checkBoxTwitchOnlySuccess.Checked = false;
            }
        }

        private void CheckBoxTwitchOnlySuccess_CheckedChanged(object sender, EventArgs e) => Properties.Settings.Default.UploadToTwitchOnlySuccess = checkBoxTwitchOnlySuccess.Checked;

        private void CheckBoxFileSizeIgnore_CheckedChanged(object sender, EventArgs e) => Properties.Settings.Default.UploadIgnoreFileSize = checkBoxFileSizeIgnore.Checked;

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

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e) => Properties.Settings.Default.Save();

        private void ButtonChangeTwitchChannel_Click(object sender, EventArgs e) => twitchNameLink.Show();

        private void ToolStripMenuItemUploadLogs_CheckedChanged(object sender, EventArgs e) => checkBoxUploadLogs.Checked = toolStripMenuItemUploadLogs.Checked;

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) => Close();

        private void ToolStripMenuItemPostToTwitch_CheckedChanged(object sender, EventArgs e) => checkBoxPostToTwitch.Checked = toolStripMenuItemPostToTwitch.Checked;

        private void ButtonOpenLogs_Click(object sender, EventArgs e) => Process.Start(Properties.Settings.Default.LogsLocation);

        private void ButtonDPSReportServer_Click(object sender, EventArgs e)
        {
            dpsReportSettingsLink.Show();
            dpsReportSettingsLink.BringToFront();
        }

        private void ButtonCustomName_Click(object sender, EventArgs e)
        {
            customNameLink.Show();
            customNameLink.BringToFront();
        }

        private void ButtonPingSettings_Click(object sender, EventArgs e)
        {
            pingsLink.Show();
            pingsLink.BringToFront();
        }

        private void ButtonArcVersionChecking_Click(object sender, EventArgs e)
        {
            arcVersionsLink.Show();
            arcVersionsLink.BringToFront();
        }

        private void ButtonBossData_Click(object sender, EventArgs e)
        {
            bossDataLink.Show();
            bossDataLink.BringToFront();
        }

        private void ButtonDiscordWebhooks_Click(object sender, EventArgs e)
        {
            discordWebhooksLink.Show();
            discordWebhooksLink.BringToFront();
        }

        private void ButtonTwitchCommands_Click(object sender, EventArgs e)
        {
            twitchCommandsLink.Show();
            twitchCommandsLink.BringToFront();
        }

        private void ToolStripMenuItemOpenDPSReportServer_Click(object sender, EventArgs e)
        {
            dpsReportSettingsLink.Show();
            dpsReportSettingsLink.BringToFront();
        }

        private void ToolStripMenuItemOpenCustomName_Click(object sender, EventArgs e)
        {
            customNameLink.Show();
            customNameLink.BringToFront();
        }

        private void ToolStripMenuItemOpenPingSettings_Click(object sender, EventArgs e)
        {
            pingsLink.Show();
            pingsLink.BringToFront();
        }

        private void ToolStripMenuItemOpenArcVersionsSettings_Click(object sender, EventArgs e)
        {
            arcVersionsLink.Show();
            arcVersionsLink.BringToFront();
        }

        private void ToolStripMenuItemDiscordWebhooks_Click(object sender, EventArgs e)
        {
            discordWebhooksLink.Show();
            discordWebhooksLink.BringToFront();
        }

        private void ToolStripMenuItemOpenTwitchCommands_Click(object sender, EventArgs e)
        {
            twitchCommandsLink.Show();
            twitchCommandsLink.BringToFront();
        }

        private void ButtonDisConnectTwitch_Click(object sender, EventArgs e)
        {
            reconnectedFailCounter = 0;
            if (chatConnect == null)
            {
                ConnectTwitchBot();
            }
            else
            {
                DisconnectTwitchBot();
                checkBoxPostToTwitch.Checked = false;
            }
        }

        private async void ButtonUpdateNow_Click(object sender, EventArgs e)
        {
            buttonUpdateNow.Enabled = false;
            AddToText(">>> Downloading update...");
            var result = await HttpClientController.DownloadFileAsync("https://plenbot.net/uploader/update/", $"{LocalDir}PlenBotLogUploader_Update.exe");
            if (result)
            {
                Process.Start($"{LocalDir}PlenBotLogUploader_Update.exe", "-update " + Path.GetFileName(Application.ExecutablePath.Replace('/', '\\')));
                if (InvokeRequired)
                {
                    // invokes the function on the main thread
                    Invoke((Action)delegate () { ExitApp(); });
                }
                else
                {
                    ExitApp();
                }
            }
            else
            {
                AddToText(">>> Something went wrong with the download. Please try again later.");
                buttonUpdateNow.Enabled = true;
            }
        }

        private void ButtonSession_Click(object sender, EventArgs e)
        {
            logSessionLink.Show();
            logSessionLink.BringToFront();
        }

        private void CheckBoxStartWhenWindowsStarts_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStartWhenWindowsStarts.Checked)
            {
                using (RegistryKey registryRun = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
                {
                    registryRun.SetValue("PlenBot Log Uploader", $"\"{Application.ExecutablePath.Replace('/', '\\')}\" -m");
                }
            }
            else
            {
                using (RegistryKey registryRun = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
                {
                    registryRun.DeleteValue("PlenBot Log Uploader");
                }
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to do this?\nThis resets all your settings but not boss data, webhooks and ping configurations.\nIf you click yes the application will close itself.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Process.Start(LocalDir);
                Properties.Settings.Default.Reset();
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
                Properties.Settings.Default.MaxConcurrentUploads = threads;
                semaphore?.Dispose();
                semaphore = new SemaphoreSlim(threads, threads);
            }
        }

        private void ButtonGW2API_Click(object sender, EventArgs e)
        {
            gw2APILink.Show();
            gw2APILink.BringToFront();
        }
        #endregion
    }
}
