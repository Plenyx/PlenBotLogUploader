using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Microsoft.Win32;
using TwitchIRCClient;
using PlenBotLogUploader.Tools;
using PlenBotLogUploader.DPSReport;
using PlenBotLogUploader.GW2Raidar;

namespace PlenBotLogUploader
{
    public partial class FormMain : Form
    {
        #region definitions
        // properties
        public string LogsLocation { get; set; } = "";
        public DPSReportJSON LastLog { get; set; }
        public string ChannelName { get; set; } = "";
        public string DPSReportServer { get; set; } = "";
        public string CustomTwitchName { get; set; } = "";
        public string CustomOAuthPassword { get; set; } = "";
        public bool ChannelJoined { get; set; } = false;
        public string RaidarOAuth { get; set; } = "";
        public string LocalDir { get; } = $"{Path.GetDirectoryName(Application.ExecutablePath.Replace('/', '\\'))}\\";
        public RegistryController RegistryController { get; } = new RegistryController();
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
        private TwitchIrcClient chatConnect;
        private FileSystemWatcher watcher = new FileSystemWatcher() { Filter = "*.*", IncludeSubdirectories = true, NotifyFilter = NotifyFilters.FileName };
        private bool firstTimeMinimise = true;
        private int reconnectedFailCounter = 0;
        private int logsCount = 0;

        // constants
        private const int minFileSize = 12288;
        private const int uploaderBuild = 36;
        #endregion

        #region constructor
        public FormMain()
        {
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            notifyIconTray.Icon = Properties.Resources.AppIcon;
            Text = $"{Text} b{uploaderBuild}";
            notifyIconTray.Text = $"{notifyIconTray.Text} b{uploaderBuild}";
            twitchNameLink = new FormTwitchNameSetup(this);
            dpsReportServerLink = new FormDPSReportServer(this);
            customNameLink = new FormCustomName(this);
            pingsLink = new FormPings(this);
            raidarLink = new FormRaidar(this);
            arcVersionsLink = new FormArcVersions(this);
            bossDataLink = new FormBossData(this);
            discordWebhooksLink = new FormDiscordWebhooks(this);
            twitchCommandsLink = new FormTwitchCommands(this);
            try
            {
                LogsLocation = RegistryController.GetRegistryValue("logsLocation", "");
                if (LogsLocation == "")
                {
                    labelLocationInfo.Text = "!!! Select a directory with arc logs !!!";
                }
                else
                {
                    if (Directory.Exists(LogsLocation))
                    {
                        LogsScan(LogsLocation);
                        watcher.Path = LogsLocation;
                        watcher.Renamed += OnLogCreated;
                        watcher.EnableRaisingEvents = true;
                        buttonOpenLogs.Enabled = true;
                    }
                    else
                    {
                        RegistryController.SetRegistryValue("logsLocation", "");
                        labelLocationInfo.Text = "!!! Select a directory with arc logs !!!";
                    }
                }
                ChannelName = RegistryController.GetRegistryValue("channel", "").ToLower();
                firstTimeMinimise = RegistryController.GetRegistryValue("trayMinimiseFirst", 1) == 1;
                if (!string.IsNullOrEmpty(ChannelName))
                {
                    twitchNameLink.textBoxChannelUrl.Text = $"https://twitch.tv/{ChannelName}/";
                }
                if (RegistryController.GetRegistryValue("dpsReportServer", 0) == 0)
                {
                    DPSReportServer = "dps.report";
                }
                else
                {
                    DPSReportServer = "a.dps.report";
                    dpsReportServerLink.radioButtonA.Checked = true;
                }
                if (RegistryController.GetRegistryValue("uploadAll", 1) == 1)
                {
                    checkBoxUploadLogs.Checked = true;
                    checkBoxPostToTwitch.Enabled = true;
                    toolStripMenuItemUploadLogs.Checked = true;
                    toolStripMenuItemPostToTwitch.Enabled = true;
                }
                if (RegistryController.GetRegistryValue("uploadToTwitch", 1) == 1)
                {
                    checkBoxPostToTwitch.Checked = true;
                    checkBoxPostToTwitch.Enabled = true;
                    toolStripMenuItemPostToTwitch.Checked = true;
                    toolStripMenuItemPostToTwitch.Enabled = true;
                    checkBoxTwitchOnlySuccess.Enabled = true;
                    if (RegistryController.GetRegistryValue("uploadTwitchOnlySuccess", 0) == 1)
                    {
                        checkBoxTwitchOnlySuccess.Checked = true;
                    }
                }
                if (RegistryController.GetRegistryValue("uploadIgnoreSize", 0) == 1)
                {
                    checkBoxFileSizeIgnore.Checked = true;
                }
                if (RegistryController.GetRegistryValue("wepSkill1", 1) == 1)
                {
                    checkBoxWepSkill1.Checked = true;
                }
                if (RegistryController.GetRegistryValue("trayMinimise", 1) == 1)
                {
                    checkBoxTrayMinimiseToIcon.Checked = true;
                }
                if (RegistryController.GetRegistryValue("twitchCustomNameEnabled", 0) == 1)
                {
                    customNameLink.checkBoxCustomNameEnable.Checked = true;
                    CustomTwitchName = (RegistryController.GetRegistryValue("twitchCustomName", "")).ToLower();
                    CustomOAuthPassword = (RegistryController.GetRegistryValue("twitchCustomOAuth", ""));
                    customNameLink.textBoxCustomName.Text = CustomTwitchName;
                    customNameLink.textBoxCustomOAuth.Text = CustomOAuthPassword;
                }
                RaidarOAuth = RegistryController.GetRegistryValue("raidarOAuth", "");
                if (RaidarOAuth != "")
                {
                    raidarLink.textBoxTags.Text = RegistryController.GetRegistryValue("raidarTags", "");
                    raidarLink.checkBoxEnableRaidar.Checked = RegistryController.GetRegistryValue("raidarEnabled", 0) == 1;
                    raidarLink.groupBoxCredentials.Enabled = false;
                    raidarLink.groupBoxSettings.Enabled = true;
                }
                arcVersionsLink.GW2Location = RegistryController.GetRegistryValue("gw2Location", "");
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
                        RegistryController.SetRegistryValue("gw2Location", "");
                    }
                }
                twitchCommandsLink.checkBoxUploaderEnable.Checked = RegistryController.GetRegistryValue("twitchCommandUploaderEnabled", 1) == 1;
                twitchCommandsLink.textBoxUploaderCommand.Text = RegistryController.GetRegistryValue("twitchCommandUploader", "!uploader");
                twitchCommandsLink.checkBoxLastLogEnable.Checked = RegistryController.GetRegistryValue("twitchCommandLastLogEnabled", 0) == 1;
                twitchCommandsLink.textBoxLastLogCommand.Text = RegistryController.GetRegistryValue("twitchCommandLastLog", "!lastlog");
                if (RegistryController.GetRegistryValue("firstSetup", 0) == 0)
                {
                    MessageBox.Show("It looks like this is the first time you are running this program.\nIf you have any issues feel free to contact me directly by Twitch, Discord (@Plenyx#1029) or on GitHub!\n\nPlenyx", "Thank you for using PlenBotLogUploader", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    twitchNameLink.Show();
                    RegistryController.SetRegistryValue("firstSetup", 1);
                }
                if (RegistryController.GetRegistryValue("connectToTwitch", 0) == 1)
                {
                    if (CustomTwitchName != "")
                    {
                        chatConnect = new TwitchIrcClient(CustomTwitchName, CustomOAuthPassword);
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
                    toolStripMenuItemOpenCustomName.Enabled = false;
                    toolStripMenuItemPostToTwitch.Enabled = false;
                    toolStripMenuItemOpenTwitchCommands.Enabled = false;
                    buttonCustomName.Enabled = false;
                    buttonReconnectBot.Enabled = false;
                    buttonTwitchCommands.Enabled = false;
                    checkBoxPostToTwitch.Enabled = false;
                }
                if (!File.Exists($"{LocalDir}logs.csv"))
                {
                    File.AppendAllText($"{LocalDir}logs.csv", "Boss;BossId;Success;arcdpsVersion;Permalink\n");
                }
                // startup check
                using (RegistryKey registryRun = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
                {
                    if (registryRun.GetValue("PlenBot Log Uploader") != null)
                    {
                        checkBoxStartWhenWindowsStarts.Checked = true;
                    }
                }
                /* Subscribe to field changes events, otherwise they would trigger with load */
                checkBoxPostToTwitch.CheckedChanged += new EventHandler(checkBoxPostToTwitch_CheckedChanged);
                checkBoxWepSkill1.CheckedChanged += new EventHandler(checkBoxWepSkill1_CheckedChanged);
                checkBoxUploadLogs.CheckedChanged += new EventHandler(checkBoxUploadAll_CheckedChanged);
                checkBoxFileSizeIgnore.CheckedChanged += new EventHandler(checkBoxFileSizeIgnore_CheckedChanged);
                checkBoxTrayMinimiseToIcon.CheckedChanged += new EventHandler(checkBoxTrayMinimiseToIcon_CheckedChanged);
                checkBoxTwitchOnlySuccess.CheckedChanged += new EventHandler(checkBoxTwitchOnlySuccess_CheckedChanged);
                checkBoxStartWhenWindowsStarts.CheckedChanged += new EventHandler(checkBoxStartWhenWindowsStarts_CheckedChanged);
                raidarLink.checkBoxEnableRaidar.CheckedChanged += new EventHandler(raidarLink.checkBoxEnableRaidar_CheckedChanged);
            }
            catch
            {
                Registry.CurrentUser.DeleteSubKey(@"SOFTWARE\Plenyx\PlenBotUploader");
                MessageBox.Show("An error in the Windows' registry has occurred.\nAll settings are reset.\nTry running the application again.", "An error has occurred");
                ExitApp();
            }
        }
        #endregion

        #region form events
        private void FormMain_Load(object sender, EventArgs e)
        {
            DoCommandArgs();
            Task.Run(() => NewBuildCheckAsync());
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            chatConnect?.Dispose();
            RegistryController?.Dispose();
            HttpClientController?.Dispose();
            watcher?.Dispose();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if ((WindowState == FormWindowState.Minimized) && checkBoxTrayMinimiseToIcon.Checked)
            {
                ShowInTaskbar = false;
                Hide();
                if (firstTimeMinimise)
                {
                    ShowBalloon("Uploader minimised", "Double click the icon to bring back the uploader.\nYou can also right click for quick settings.", 6500);
                    RegistryController.SetRegistryValue("trayMinimiseFirst", 0);
                    firstTimeMinimise = false;
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

        private async void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            await Task.Run(() => DoDragDropFiles(files));
        }

        protected void DoDragDropFiles(string[] files)
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

        protected async void NewBuildCheckAsync(bool showBaloonOnly = false)
        {
            try
            {
                string response = await HttpClientController.DownloadFileToStringAsync("https://raw.githubusercontent.com/Plenyx/PlenBotLogUploader/master/VERSION");
                if (int.TryParse(response, out int currentversion))
                {
                    if (currentversion > uploaderBuild)
                    {
                        buttonUpdateNow.Invoke((Action)delegate () { buttonUpdateNow.Visible = true; });
                        AddToText($">>> New build available (build n. {response})");
                        AddToText("https://github.com/Plenyx/PlenBotLogUploader/releases/");
                        if (StartedMinimised || showBaloonOnly)
                        {
                            ShowBalloon("New build available for the uploader", $"If you want to begin the update process, use the \"Update uploader\" button.\nThe latest build is build n. {response}.", 8500);
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Do you want to download the newest version?", $"New build available for the uploader (build n. {response})", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (result == DialogResult.Yes)
                            {
                                if (RegistryController.GetRegistryValue("firstUpdate", 0) == 0)
                                {
                                    MessageBox.Show("The folder with the current location of this executable is going to be opened.\nYou can update the bot by simple overwriting the previous executable.\nThe application will now close.", $"Ease of installation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    RegistryController.SetRegistryValue("firstUpdate", 1);
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
                        }
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
                AddToText("> Unable to check new build version.");
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
                LastLog = reportJSON;
                if (bossDataLink.AllBosses.ContainsKey(reportJSON.Encounter.BossId))
                {
                    string format = (reportJSON.Encounter.Success ?? false) ? bossDataLink.AllBosses[reportJSON.Encounter.BossId].SuccessMsg : bossDataLink.AllBosses[reportJSON.Encounter.BossId].FailMsg;
                    await chatConnect.SendChatMessageAsync(ChannelName, $"{format}: {reportJSON.Permalink}");
                }
                else
                {
                    await chatConnect.SendChatMessageAsync(ChannelName, $"Link to the log: {reportJSON.Permalink}");
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
                    HttpClientController.MainHttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", RaidarOAuth);
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
                                        // log file
                                        File.AppendAllText($"{LocalDir}logs.csv", $"{reportJSON.Encounter.Boss};{reportJSON.Encounter.BossId};{success};{reportJSON.Evtc.Type}{reportJSON.Evtc.Version};{reportJSON.Permalink}\n");
                                        // Twitch chat
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
                                        // Discord webhooks
                                        await discordWebhooksLink.ExecuteAllActiveWebhooksAsync(reportJSON, bossDataLink.AllBosses);
                                        // remote server ping
                                        await pingsLink.ExecuteAllPingsAsync(reportJSON);
                                    }
                                    catch
                                    {
                                        AddToText($">:> Unable to upload file {Path.GetFileName(file)}, dps.report responded with invalid permanent link");
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
        #endregion

        #region Twitch bot methods
        public bool IsConnectionNull() => chatConnect == null;

        public void ConnectTwitchBot()
        {
            buttonDisConnectTwitch.Text = "Disconnect from Twitch";
            buttonChangeTwitchChannel.Enabled = true;
            toolStripMenuItemOpenCustomName.Enabled = true;
            toolStripMenuItemPostToTwitch.Enabled = true;
            toolStripMenuItemOpenTwitchCommands.Enabled = true;
            buttonCustomName.Enabled = true;
            buttonReconnectBot.Enabled = true;
            buttonTwitchCommands.Enabled = true;
            checkBoxPostToTwitch.Enabled = true;
            if (CustomTwitchName != "")
            {
                chatConnect = new TwitchIrcClient(CustomTwitchName, CustomOAuthPassword);
            }
            else
            {
                chatConnect = new TwitchIrcClient("gw2loguploader", "oauth:ycgqr3dyef7gp5r8uk7d5jz30nbrc6");
            }
            chatConnect.ReceiveMessage += ReadMessagesAsync;
            chatConnect.StateChange += OnIrcStateChanged;
            chatConnect.BeginConnection();
            RegistryController.SetRegistryValue("connectToTwitch", 1);
        }

        public void DisconnectTwitchBot()
        {
            chatConnect.ReceiveMessage -= ReadMessagesAsync;
            chatConnect.StateChange -= OnIrcStateChanged;
            chatConnect.Dispose();
            chatConnect = null;
            AddToText("<-?-> CONNECTION CLOSED");
            buttonDisConnectTwitch.Text = "Connect to Twitch";
            buttonChangeTwitchChannel.Enabled = false;
            toolStripMenuItemOpenCustomName.Enabled = false;
            toolStripMenuItemPostToTwitch.Enabled = false;
            toolStripMenuItemOpenTwitchCommands.Enabled = false;
            buttonCustomName.Enabled = false;
            buttonReconnectBot.Enabled = false;
            buttonTwitchCommands.Enabled = false;
            checkBoxPostToTwitch.Enabled = false;
            RegistryController.SetRegistryValue("connectToTwitch", 0);
        }

        public void ReconnectTwitchBot()
        {
            chatConnect.ReceiveMessage -= ReadMessagesAsync;
            chatConnect.StateChange -= OnIrcStateChanged;
            chatConnect.Dispose();
            chatConnect = null;
            if (CustomTwitchName != "")
            {
                chatConnect = new TwitchIrcClient(CustomTwitchName, CustomOAuthPassword);
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
                    if (ChannelName != "")
                    {
                        await chatConnect.JoinRoomAsync(ChannelName);
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
                default:
                    AddToText("<-?-> UNRECOGNISED IRC STATE RECEIVED");
                    break;
            }
        }

        protected async void ReadMessagesAsync(object sender, IrcMessageEventArgs e)
        {
            if (e == null)
            {
                return;
            }
            string[] messageSplit = e.Message.Split(new string[] { $"#{ChannelName} :" }, StringSplitOptions.None);
            if (messageSplit.Length > 1)
            {
                string command = messageSplit[1].Split(' ')[0].ToLower();
                if (command.Equals(twitchCommandsLink.textBoxUploaderCommand.Text.ToLower()) && twitchCommandsLink.checkBoxUploaderEnable.Checked)
                {
                    AddToText("> UPLOADER COMMAND USED");
                    await chatConnect.SendChatMessageAsync(ChannelName, $"PlenBot Log Uploader v1 build n.{uploaderBuild} | https://plenbot.net/uploader/");
                }
                else if (command.Equals(twitchCommandsLink.textBoxLastLogCommand.Text.ToLower()) && twitchCommandsLink.checkBoxLastLogEnable.Checked)
                {
                    if (LastLog != null)
                    {
                        AddToText("> LAST LOG COMMAND USED");
                        await chatConnect.SendChatMessageAsync(ChannelName, $"Link to the last {LastLog.Encounter.Boss} log: {LastLog.Permalink}");
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
                RegistryController.SetRegistryValue("uploadAll", 1);
                toolStripMenuItemUploadLogs.Checked = true;
                checkBoxPostToTwitch.Enabled = true;
                toolStripMenuItemPostToTwitch.Enabled = true;
            }
            else
            {
                RegistryController.SetRegistryValue("uploadAll", 0);
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
                        LogsLocation = dialog.SelectedPath;
                        RegistryController.SetRegistryValue("logsLocation", LogsLocation);
                        logsCount = 0;
                        LogsScan(LogsLocation);
                        watcher.Renamed -= OnLogCreated;
                        watcher.Dispose();
                        watcher = null;
                        watcher = new FileSystemWatcher()
                        {
                            Path = LogsLocation,
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

        private void checkBoxWepSkill1_CheckedChanged(object sender, EventArgs e) => RegistryController.SetRegistryValue("wepSkill1", checkBoxUploadLogs.Checked ? 1 : 0);

        private void checkBoxTrayMinimiseToIcon_CheckedChanged(object sender, EventArgs e) => RegistryController.SetRegistryValue("trayMinimise", checkBoxTrayMinimiseToIcon.Checked ? 1 : 0);

        private void checkBoxPostToTwitch_CheckedChanged(object sender, EventArgs e)
        {
            RegistryController.SetRegistryValue("uploadToTwitch", checkBoxPostToTwitch.Checked ? 1 : 0);
            toolStripMenuItemPostToTwitch.Checked = checkBoxPostToTwitch.Checked;
            checkBoxTwitchOnlySuccess.Enabled = checkBoxPostToTwitch.Checked;
            if (!checkBoxPostToTwitch.Checked)
            {
                checkBoxTwitchOnlySuccess.Checked = false;
            }
        }

        private void checkBoxTwitchOnlySuccess_CheckedChanged(object sender, EventArgs e) => RegistryController.SetRegistryValue("uploadTwitchOnlySuccess", checkBoxTwitchOnlySuccess.Checked ? 1 : 0);

        private void checkBoxFileSizeIgnore_CheckedChanged(object sender, EventArgs e) => RegistryController.SetRegistryValue("uploadIgnoreSize", checkBoxFileSizeIgnore.Checked ? 1 : 0);

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

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e) => notifyIconTray.Visible = false;

        private void buttonChangeTwitchChannel_Click(object sender, EventArgs e) => twitchNameLink.Show();

        private void toolStripMenuItemUploadLogs_CheckedChanged(object sender, EventArgs e) => checkBoxUploadLogs.Checked = toolStripMenuItemUploadLogs.Checked;

        private void toolStripMenuItemExit_Click(object sender, EventArgs e) => Close();

        private void toolStripMenuItemPostToTwitch_CheckedChanged(object sender, EventArgs e) => checkBoxPostToTwitch.Checked = toolStripMenuItemPostToTwitch.Checked;

        private void buttonOpenLogs_Click(object sender, EventArgs e) => Process.Start(LogsLocation);

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
                RegistryController.SetRegistryValue("connectToTwitch", 1);
            }
            else
            {
                DisconnectTwitchBot();
                RegistryController.SetRegistryValue("connectToTwitch", 0);
                checkBoxPostToTwitch.Checked = false;
            }
        }

        private void buttonUpdateNow_Click(object sender, EventArgs e)
        {
            if (RegistryController.GetRegistryValue("firstUpdate", 0) == 0)
            {
                MessageBox.Show("The folder with the current location of this executable is going to be opened.\nYou can update the bot by simple overwriting the previous executable.\nThe application will now close.", $"Ease of installation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RegistryController.SetRegistryValue("firstUpdate", 1);
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
        private void TimerCheckUpdate_Tick(object sender, EventArgs e)
        {
            timerCheckUpdate.Stop();
            timerCheckUpdate.Enabled = false;
            Task.Run(() => NewBuildCheckAsync(true));
        }
        #endregion
    }
}
