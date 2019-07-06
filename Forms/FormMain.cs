using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Microsoft.Win32;
using PlenBotLogUploader.Tools;
using PlenBotLogUploader.DPSReport;
using PlenBotLogUploader.GW2Raidar;
using PlenBotLogUploader.TwitchIRCClient;

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
        private readonly FormDPSReportServer dpsReportServerLink;
        private readonly FormCustomName customNameLink;
        private readonly FormRaidar raidarLink;
        private readonly FormArcVersions arcVersionsLink;
        private readonly FormBossData bossDataLink;
        private readonly FormDiscordWebhooks discordWebhooksLink;
        private readonly FormPings pingsLink;
        private readonly FormTwitchCommands twitchCommandsLink;
        private readonly FormLogSession logSessionLink;
        private TwitchIrcClient chatConnect;
        private FileSystemWatcher watcher = new FileSystemWatcher() { Filter = "*.*", IncludeSubdirectories = true, NotifyFilter = NotifyFilters.FileName };
        private int reconnectedFailCounter = 0;
        private int logsCount = 0;

        // constants
        private const int minFileSize = 12288;
        private const int uploaderRelease = 45;
        #endregion

        #region constructor
        public FormMain()
        {
            InitializeComponent();
            #region tooltips
            toolTip.SetToolTip(checkBoxUploadLogs, "If not checked, no logs will be uploaded unless provided manually.");
            toolTip.SetToolTip(checkBoxWepSkill1, "If checked, dps.report renders all autoattacks.");
            toolTip.SetToolTip(checkBoxFileSizeIgnore, "If checked, logs with less than 12 kB filesize will not be uploaded.");
            toolTip.SetToolTip(checkBoxPostToTwitch, "If checked, logs will be posted to Twitch chat if connected to a channel.");
            toolTip.SetToolTip(checkBoxTwitchOnlySuccess, "If checked, only successful logs will be linked to Twitch chat if connected to a channel.");
            #endregion
            Properties.Settings.Default.PropertyChanged += delegate { Properties.Settings.Default.Save(); };
            Icon = Properties.Resources.AppIcon;
            notifyIconTray.Icon = Properties.Resources.AppIcon;
            Text = $"{Text} r{uploaderRelease}";
            notifyIconTray.Text = $"{notifyIconTray.Text} r{uploaderRelease}";
            twitchNameLink = new FormTwitchNameSetup(this);
            dpsReportServerLink = new FormDPSReportServer(this);
            customNameLink = new FormCustomName(this);
            pingsLink = new FormPings(this);
            raidarLink = new FormRaidar(this);
            arcVersionsLink = new FormArcVersions(this);
            bossDataLink = new FormBossData(this);
            discordWebhooksLink = new FormDiscordWebhooks(this);
            twitchCommandsLink = new FormTwitchCommands(this);
            logSessionLink = new FormLogSession(this);
            try
            {
                if (Properties.Settings.Default.LogsLocation == "")
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
                if (Properties.Settings.Default.DPSReportServer == 0)
                {
                    DPSReportServer = "dps.report";
                }
                else
                {
                    DPSReportServer = "a.dps.report";
                    dpsReportServerLink.radioButtonA.Checked = true;
                }
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
                if (Properties.Settings.Default.LogWeaponSkill1)
                {
                    checkBoxWepSkill1.Checked = true;
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
                if (Properties.Settings.Default.RaidarOAuth != "")
                {
                    raidarLink.textBoxTags.Text = Properties.Settings.Default.RaidarTags;
                    raidarLink.checkBoxEnableRaidar.Checked = Properties.Settings.Default.RaidarEnabled;
                    raidarLink.groupBoxCredentials.Enabled = false;
                    raidarLink.groupBoxSettings.Enabled = true;
                }
                arcVersionsLink.GW2Location = Properties.Settings.Default.GW2Location;
                if (arcVersionsLink.GW2Location != "")
                {
                    if (File.Exists($@"{arcVersionsLink.GW2Location}\Gw2-64.exe") || File.Exists($@"{arcVersionsLink.GW2Location}\Gw2.exe"))
                    {
                        Task.Run(() => { arcVersionsLink.StartTimerAsync(true); });
                        arcVersionsLink.buttonEnabler.Enabled = true;
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
                logSessionLink.textBoxSessionName.Text = Properties.Settings.Default.SessionName;
                logSessionLink.checkBoxSupressWebhooks.Checked = Properties.Settings.Default.SessionSuppressWebhooks;
                logSessionLink.checkBoxOnlySuccess.Checked = Properties.Settings.Default.SessionOnlySuccess;
                logSessionLink.textBoxSessionContent.Text = Properties.Settings.Default.SessionMessage;
                if (Properties.Settings.Default.FirstRun)
                {
                    MessageBox.Show("It looks like this is the first time you are running this program.\nIf you have any issues feel free to contact me directly by Twitch, Discord (@Plenyx#1029) or on GitHub!\n\nPlenyx", "Thank you for using PlenBotLogUploader", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    twitchNameLink.Show();
                    Properties.Settings.Default.FirstRun = false;
                }
                else if (Properties.Settings.Default.LogsLocation == "")
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
                checkBoxPostToTwitch.CheckedChanged += new EventHandler(checkBoxPostToTwitch_CheckedChanged);
                checkBoxWepSkill1.CheckedChanged += new EventHandler(checkBoxWepSkill1_CheckedChanged);
                checkBoxUploadLogs.CheckedChanged += new EventHandler(checkBoxUploadAll_CheckedChanged);
                checkBoxFileSizeIgnore.CheckedChanged += new EventHandler(checkBoxFileSizeIgnore_CheckedChanged);
                checkBoxTrayMinimiseToIcon.CheckedChanged += new EventHandler(checkBoxTrayMinimiseToIcon_CheckedChanged);
                checkBoxTwitchOnlySuccess.CheckedChanged += new EventHandler(checkBoxTwitchOnlySuccess_CheckedChanged);
                checkBoxStartWhenWindowsStarts.CheckedChanged += new EventHandler(checkBoxStartWhenWindowsStarts_CheckedChanged);
                raidarLink.checkBoxEnableRaidar.CheckedChanged += new EventHandler(raidarLink.checkBoxEnableRaidar_CheckedChanged);
                logSessionLink.checkBoxSupressWebhooks.CheckedChanged += new EventHandler(logSessionLink.CheckBoxSupressWebhooks_CheckedChanged);
                logSessionLink.checkBoxOnlySuccess.CheckedChanged += new EventHandler(logSessionLink.CheckBoxOnlySuccess_CheckedChanged);
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
            Task.Run(() => DoDragDropFiles(files));
        }

        protected void DoDragDropFiles(List<string> files)
        {
            Dictionary<string, string> postData = new Dictionary<string, string>
            {
                { "generator", "ei" },
                { "json", "1" }
            };
            if (checkBoxWepSkill1.Checked)
            {
                postData.Add("rotation_weap1", "1");
            }
            foreach (string file in files)
            {
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
                        HttpUploadLogAsync(zipfilelocation, postData, true);
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
        #endregion

        #region required methods
        // triggeres when a file is renamed within the folder, renaming is the last process done by arcdps to create evtc or zevtc files
        private void OnLogCreated(object sender, FileSystemEventArgs e)
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
                                if (checkBoxWepSkill1.Checked)
                                {
                                    postData.Add("rotation_weap1", "1");
                                }
                                HttpUploadLogAsync(zipfilelocation, postData);
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
                        AddToText("Unable to upload the file: " + e.FullPath);
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
                string response = await HttpClientController.DownloadFileToStringAsync("https://raw.githubusercontent.com/Plenyx/PlenBotLogUploader/master/VERSION");
                if (int.TryParse(response, out int currentversion))
                {
                    if (currentversion > uploaderRelease)
                    {
                        if (buttonUpdateNow.InvokeRequired)
                        {
                            buttonUpdateNow.Invoke((Action)delegate () { buttonUpdateNow.Visible = true; });
                        }
                        else
                        {
                            buttonUpdateNow.Visible = true;
                        }
                        AddToText($">>> New release available (r{response})");
                        AddToText("https://github.com/Plenyx/PlenBotLogUploader/releases/");
                        ShowBalloon("New release available for the uploader", $"If you want to begin the update process, use the \"Update uploader\" button.\nThe latest release is n. {response}.", 8500);
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
                AddToText("> Unable to check new release version.");
            }
        }

        private void ExitApp()
        {
            Close();
            Application.Exit();
        }

        protected void DoCommandArgs()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                if ((args.Length == 2) && (args[1].Equals("-m")))
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
                    if (checkBoxWepSkill1.Checked)
                    {
                        postData.Add("rotation_weap1", "1");
                    }
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
                                HttpUploadLogAsync(zipfilelocation, postData);
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
            if (textBoxUploadInfo.InvokeRequired)
            {
                // invokes the same function on the main thread
                textBoxUploadInfo.Invoke((Action<string>)delegate (string text) { AddToText(text); }, s);
            }
            else
            {
                textBoxUploadInfo.AppendText(s + Environment.NewLine);
                textBoxUploadInfo.SelectionStart = textBoxUploadInfo.TextLength;
                textBoxUploadInfo.ScrollToCaret();
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
            if (ChannelJoined && checkBoxPostToTwitch.Checked && !bypassMessage)
            {
                AddToText($">:> {reportJSON.Permalink}");
                var bossDataRef = bossDataLink.AllBosses
                    .Where(anon => anon.Value.BossId.Equals(reportJSON.Encounter.BossId))
                    .Select(anon => anon.Value);
                if (bossDataRef.Count() == 1)
                {
                    string format = (reportJSON.Encounter.Success ?? false) ? bossDataRef.First().SuccessMsg : bossDataRef.First().FailMsg;
                    await chatConnect.SendChatMessageAsync(Properties.Settings.Default.TwitchChannelName, $"{format}: {reportJSON.Permalink}");
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

        public async Task HttpUploadLogToRaidarAsync(string file, StreamContent contentStream)
        {
            using (var content = new MultipartFormDataContent())
            {
                if (raidarLink.textBoxTags.Text.Length > 0)
                {
                    content.Add(new StringContent(raidarLink.textBoxTags.Text), "tags");
                }
                content.Add(contentStream, "file", Path.GetFileName(file));
                try
                {
                    HttpClientController.MainHttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", Properties.Settings.Default.RaidarOAuth);
                    using (var responseMessage = await HttpClientController.MainHttpClient.PutAsync("https://gw2raidar.com/api/v2/encounters/new", content))
                    {
                        string response = await responseMessage.Content.ReadAsStringAsync();
                        if (responseMessage.StatusCode == HttpStatusCode.OK)
                        {
                            GW2RaidarJSONEncounterNew responseJSON = new JavaScriptSerializer().Deserialize<GW2RaidarJSONEncounterNew>(response);
                            AddToText($">:> Uploaded {Path.GetFileName(file)} to GW2Raidar under id {responseJSON.Upload_id}");
                        }
                        else if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            AddToText($">:> Unable to upload file {Path.GetFileName(file)}, raidar responded with invalid name/password");
                        }
                        else if ((responseMessage.StatusCode == HttpStatusCode.BadRequest) || responseMessage.StatusCode == HttpStatusCode.InternalServerError)
                        {
                            AddToText($">:> Unable to upload file {Path.GetFileName(file)}, raidar responded with invalid file/file error");
                        }
                    }
                    HttpClientController.MainHttpClient.DefaultRequestHeaders.Authorization = null;
                }
                catch
                {
                    AddToText($">:> Unable to upload file {Path.GetFileName(file)}, raidar not responding");
                }
            }
        }

        public async void HttpUploadLogAsync(string file, Dictionary<string, string> postData, bool bypassMessage = false)
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
                                var uri = new Uri($"https://{DPSReportServer}/uploadContent");
                                using (var responseMessage = await HttpClientController.MainHttpClient.PostAsync(uri, content))
                                {
                                    string response = await responseMessage.Content.ReadAsStringAsync();
                                    try
                                    {
                                        DPSReportJSON reportJSON = new JavaScriptSerializer().Deserialize<DPSReportJSON>(response);
                                        bossId = reportJSON.Encounter.BossId;
                                        string success = (reportJSON.Encounter.Success ?? false) ? "true" : "false";
                                        // extra JSON from Elite Insights
                                        if (reportJSON.Encounter.JsonAvailable ?? false)
                                        {
                                            try
                                            {
                                                string jsonString = await HttpClientController.DownloadFileToStringAsync($"https://{DPSReportServer}/getJson?permalink={reportJSON.Permalink}");
                                                JavaScriptSerializer serilizer = new JavaScriptSerializer() { MaxJsonLength = 15000000 };
                                                DPSReportJSONExtraJSON extraJSON = serilizer.Deserialize<DPSReportJSONExtraJSON>(jsonString);
                                                reportJSON.ExtraJSON = extraJSON;
                                            }
                                            catch
                                            {
                                                AddToText("Extra JSON available but couldn't be obtained.");
                                            }
                                        }
                                        // log file
                                        File.AppendAllText($"{LocalDir}uploaded_logs.csv",
                                            $"{reportJSON.ExtraJSON?.FightName ?? reportJSON.Encounter.Boss};{reportJSON.Encounter.BossId};{success};{reportJSON.ExtraJSON?.Duration ?? ""};{reportJSON.ExtraJSON?.RecordedBy ?? ""};{reportJSON.ExtraJSON?.EliteInsightsVersion ?? ""};{reportJSON.Evtc.Type}{reportJSON.Evtc.Version};{reportJSON.Permalink}\n");
                                        // Twitch chat
                                        LastLogLocation = reportJSON.Permalink;
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
                                                await discordWebhooksLink.ExecuteAllActiveWebhooksAsync(reportJSON, bossDataLink.AllBosses);
                                            }
                                        }
                                        else
                                        {
                                            await discordWebhooksLink.ExecuteAllActiveWebhooksAsync(reportJSON, bossDataLink.AllBosses);
                                        }
                                        // remote server ping
                                        await pingsLink.ExecuteAllPingsAsync(reportJSON);
                                        // dispose
                                        reportJSON = null;
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
                            }
                        }
                    }
                    // upload to raidar
                    if (raidarLink.checkBoxEnableRaidar.Checked && !Bosses.IsWvW(bossId))
                    {
                        using (FileStream inputStream = File.OpenRead(file))
                        {
                            using (StreamContent contentStream = new StreamContent(inputStream))
                            {
                                try
                                {
                                    await HttpUploadLogToRaidarAsync(file, contentStream);
                                }
                                catch
                                {
                                    AddToText($">:> Unable to upload file {Path.GetFileName(file)} to raidar, raidar not responding");
                                }
                            }
                        }
                    }
                }
                catch
                {
                    Thread.Sleep(650);
                    HttpUploadLogAsync(file, postData, bypassMessage);
                }
            }
        }

        public async Task ExecuteSessionLogWebhooksAsync(string sessionName, string contentText, bool showSuccess, string elapsedTime) => await discordWebhooksLink.ExecuteSessionAllActiveWebhooksAsync(SessionLogs, bossDataLink.AllBosses, sessionName, contentText, showSuccess, elapsedTime);
        #endregion

        #region Twitch bot methods
        public bool IsConnectionNull() => chatConnect == null;

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
                        AddToText("<-?-> TRYING TO RECONNECT TO TWITCH");
                        ReconnectTwitchBot();
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
                    await chatConnect.SendChatMessageAsync(Properties.Settings.Default.TwitchChannelName, $"PlenBot Log Uploader r{uploaderRelease} | https://plenbot.net/uploader/");
                }
                else if (command.Equals(twitchCommandsLink.textBoxLastLogCommand.Text.ToLower()) && twitchCommandsLink.checkBoxLastLogEnable.Checked)
                {
                    if (LastLogLocation != "")
                    {
                        AddToText("> LAST LOG COMMAND USED");
                        await chatConnect.SendChatMessageAsync(Properties.Settings.Default.TwitchChannelName, $"Link to the last log: {LastLogLocation}");
                    }
                }
            }
        }
        #endregion

        #region buttons & checks events
        private void checkBoxUploadAll_CheckedChanged(object sender, EventArgs e)
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

        private void buttonReconnectBot_Click(object sender, EventArgs e)
        {
            reconnectedFailCounter = 0;
            ReconnectTwitchBot();
        }

        private void buttonLogsLocation_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog() { Description = "Select the arcdps folder containing the combat logs.\nThe folder's name you are looking for is \"arcdps.cbtlogs\"" })
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    if (dialog.SelectedPath.Contains("arcdps.cbtlogs"))
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
                    else
                    {
                        MessageBox.Show("The specified location does not appear to be an arcdps folder.\nCheck your directory and try again.", "An error has occurred");
                    }
                }
            }
        }

        private void checkBoxWepSkill1_CheckedChanged(object sender, EventArgs e) => Properties.Settings.Default.LogWeaponSkill1 = checkBoxUploadLogs.Checked;

        private void checkBoxTrayMinimiseToIcon_CheckedChanged(object sender, EventArgs e) => Properties.Settings.Default.TrayMinimise = checkBoxTrayMinimiseToIcon.Checked;

        private void checkBoxPostToTwitch_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.UploadToTwitch = checkBoxPostToTwitch.Checked;
            toolStripMenuItemPostToTwitch.Checked = checkBoxPostToTwitch.Checked;
            checkBoxTwitchOnlySuccess.Enabled = checkBoxPostToTwitch.Checked;
            if (!checkBoxPostToTwitch.Checked)
            {
                checkBoxTwitchOnlySuccess.Checked = false;
            }
        }

        private void checkBoxTwitchOnlySuccess_CheckedChanged(object sender, EventArgs e) => Properties.Settings.Default.UploadToTwitchOnlySuccess = checkBoxTwitchOnlySuccess.Checked;

        private void checkBoxFileSizeIgnore_CheckedChanged(object sender, EventArgs e) => Properties.Settings.Default.UploadIgnoreFileSize = checkBoxFileSizeIgnore.Checked;

        private void notifyIconTray_MouseDoubleClick(object sender, MouseEventArgs e)
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

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIconTray.Visible = false;
            Properties.Settings.Default.Save();
        }

        private void buttonChangeTwitchChannel_Click(object sender, EventArgs e) => twitchNameLink.Show();

        private void toolStripMenuItemUploadLogs_CheckedChanged(object sender, EventArgs e) => checkBoxUploadLogs.Checked = toolStripMenuItemUploadLogs.Checked;

        private void toolStripMenuItemExit_Click(object sender, EventArgs e) => Close();

        private void toolStripMenuItemPostToTwitch_CheckedChanged(object sender, EventArgs e) => checkBoxPostToTwitch.Checked = toolStripMenuItemPostToTwitch.Checked;

        private void buttonOpenLogs_Click(object sender, EventArgs e) => Process.Start(Properties.Settings.Default.LogsLocation);

        private void buttonDPSReportServer_Click(object sender, EventArgs e)
        {
            dpsReportServerLink.Show();
            dpsReportServerLink.BringToFront();
        }

        private void buttonCustomName_Click(object sender, EventArgs e)
        {
            customNameLink.Show();
            customNameLink.BringToFront();
        }

        private void buttonPingSettings_Click(object sender, EventArgs e)
        {
            pingsLink.Show();
            pingsLink.BringToFront();
        }

        private void buttonRaidarSettings_Click(object sender, EventArgs e)
        {
            raidarLink.Show();
            raidarLink.BringToFront();
        }

        private void buttonArcVersionChecking_Click(object sender, EventArgs e)
        {
            arcVersionsLink.Show();
            arcVersionsLink.BringToFront();
        }

        private void buttonBossData_Click(object sender, EventArgs e)
        {
            bossDataLink.Show();
            bossDataLink.BringToFront();
        }

        private void buttonDiscordWebhooks_Click(object sender, EventArgs e)
        {
            discordWebhooksLink.Show();
            discordWebhooksLink.BringToFront();
        }

        private void ButtonTwitchCommands_Click(object sender, EventArgs e)
        {
            twitchCommandsLink.Show();
            twitchCommandsLink.BringToFront();
        }

        private void toolStripMenuItemOpenDPSReportServer_Click(object sender, EventArgs e)
        {
            dpsReportServerLink.Show();
            dpsReportServerLink.BringToFront();
        }

        private void toolStripMenuItemOpenCustomName_Click(object sender, EventArgs e)
        {
            customNameLink.Show();
            customNameLink.BringToFront();
        }

        private void toolStripMenuItemOpenPingSettings_Click(object sender, EventArgs e)
        {
            pingsLink.Show();
            pingsLink.BringToFront();
        }

        private void toolStripMenuItemOpenRaidarSettings_Click(object sender, EventArgs e)
        {
            raidarLink.Show();
            raidarLink.BringToFront();
        }

        private void toolStripMenuItemOpenArcVersionsSettings_Click(object sender, EventArgs e)
        {
            arcVersionsLink.Show();
            arcVersionsLink.BringToFront();
        }

        private void toolStripMenuItemDiscordWebhooks_Click(object sender, EventArgs e)
        {
            discordWebhooksLink.Show();
            discordWebhooksLink.BringToFront();
        }

        private void ToolStripMenuItemOpenTwitchCommands_Click(object sender, EventArgs e)
        {
            twitchCommandsLink.Show();
            twitchCommandsLink.BringToFront();
        }

        private void buttonDisConnectTwitch_Click(object sender, EventArgs e)
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

        private void buttonUpdateNow_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.FirstUpdate)
            {
                MessageBox.Show("The folder with the current location of this executable is going to be opened.\nYou can update the bot by simple overwriting the previous executable.\nThe application will now close.", $"Ease of installation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Properties.Settings.Default.FirstUpdate = false;
            }
            Process.Start("https://github.com/Plenyx/PlenBotLogUploader/releases/");
            Process.Start($"{LocalDir}");
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

        private void ButtonSession_Click(object sender, EventArgs e)
        {
            logSessionLink.Show();
            logSessionLink.BringToFront();
        }

        private void checkBoxStartWhenWindowsStarts_CheckedChanged(object sender, EventArgs e)
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
        #endregion
    }
}
