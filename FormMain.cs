using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.Win32;
using TwitchIRCClient;

namespace PlenBotLogUploader
{
    public partial class FormMain : Form
    {
        private TwitchIrcClient chatConnect;
        private RegistryKey RegistryAccess { get; set; } = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Plenyx\PlenBotUploader");
        private List<string> Logs { get; set; } = new List<string>();
        private string LogsLocation { get; set; } = "";
        private string LastLog { get; set; } = "";
        private double Version { get; } = 0.7;
        private const int maxFileSize = 122880;

        public FormMain()
        {
            InitializeComponent();
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                string response = await DownloadFileAsyncToString("https://raw.githubusercontent.com/Plenyx/PlenBotLogUploader/master/plenbot-releases/VERSION");
                if (Double.TryParse(response, NumberStyles.Float, CultureInfo.InvariantCulture, out double currentversion))
                {
                    if (currentversion > Version)
                    {
                        DialogResult result = MessageBox.Show("Do you want to download the newest version?", $"New version available (v{currentversion.ToString().Replace(',', '.')})", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (result == DialogResult.Yes)
                        {
                            await DownloadFileAsync($"https://github.com/Plenyx/PlenBotLogUploader/raw/master/plenbot-releases/{currentversion.ToString().Replace(',', '.')}/PlenBotLogUploader.exe", $"{GetLocalDir()}/PlenBotLogUploaderUpdate.exe");
                            if (File.Exists($"{GetLocalDir()}/PlenBotLogUploaderUpdate.exe"))
                            {
                                ProcessStartInfo Info = new ProcessStartInfo
                                {
                                    Arguments = "/C ping 127.0.0.1 -n 2 && move /Y \"" + GetLocalDir() + "PlenBotLogUploaderUpdate.exe\" \"" + Application.ExecutablePath + "\"",
                                    WindowStyle = ProcessWindowStyle.Hidden,
                                    CreateNoWindow = true,
                                    FileName = "cmd.exe"
                                };
                                Process.Start(Info);
                                notifyIconTray.Visible = false;
                                Application.Exit();
                            }
                            else
                            {
                                MessageBox.Show("There has been an error downloading the new version of the Uploader.\nPlease retry again or update it manually.", "An error has occurred");
                            }
                        }
                    }
                }
            }
            catch { /* do nothing */ }
            try
            {
                if (RegistryAccess.GetValue("logsLocation") == null)
                {
                    RegistryAccess.SetValue("logsLocation", "");
                }
                if (RegistryAccess.GetValue("channel") == null)
                {
                    RegistryAccess.SetValue("channel", "");
                }
                if (RegistryAccess.GetValue("uploadAll") == null)
                {
                    RegistryAccess.SetValue("uploadAll", 1);
                }
                if (RegistryAccess.GetValue("uploadToTwitch") == null)
                {
                    RegistryAccess.SetValue("uploadToTwitch", 1);
                }
                if (RegistryAccess.GetValue("wepSkill1") == null)
                {
                    RegistryAccess.SetValue("wepSkill1", 1);
                }
                if (RegistryAccess.GetValue("trayEnabled") == null)
                {
                    RegistryAccess.SetValue("trayEnabled", 1);
                }
                if (RegistryAccess.GetValue("trayMinimise") == null)
                {
                    RegistryAccess.SetValue("trayMinimise", 1);
                }
                if (RegistryAccess.GetValue("trayInfo") == null)
                {
                    RegistryAccess.SetValue("trayInfo", 0);
                }
                LogsLocation = (string)RegistryAccess.GetValue("logsLocation", "");
                if (LogsLocation == "")
                {
                    labelLocationInfo.Text = "!!! Select a directory with the logs !!!";
                }
                else
                {
                    TreeScanStart(LogsLocation);
                    UpdateLogCount();
                    buttonStartChecker.Enabled = false;
                    buttonStopChecker.Enabled = true;
                    timerLogsCheck.Start();
                }
                textBoxChannel.Text = (string)RegistryAccess.GetValue("channel", "");
                if ((int)RegistryAccess.GetValue("uploadAll", 0) == 1)
                {
                    checkBoxUploadLogs.Checked = true;
                }
                if ((int)RegistryAccess.GetValue("uploadToTwitch", 0) == 1)
                {
                    checkBoxPostToTwitch.Checked = true;
                }
                if ((int)RegistryAccess.GetValue("wepSkill1", 0) == 1)
                {
                    checkBoxWepSkill1.Checked = true;
                }
                if ((int)RegistryAccess.GetValue("trayEnabled", 0) == 1)
                {
                    checkBoxTrayEnable.Checked = true;
                }
                if ((int)RegistryAccess.GetValue("trayMinimise", 0) == 1)
                {
                    checkBoxTrayMinimiseToIcon.Checked = true;
                }
                if ((int)RegistryAccess.GetValue("trayInfo", 0) == 1)
                {
                    checkBoxTrayNotification.Checked = true;
                }
                if (checkBoxUploadLogs.Checked)
                {
                    checkBoxPostToTwitch.Enabled = true;
                }
                if (checkBoxTrayEnable.Checked)
                {
                    notifyIconTray.Visible = true;
                }
                string channel = (string)RegistryAccess.GetValue("channel", "");
                if (channel != "")
                {
                    chatConnect = new TwitchIrcClient("gw2loguploader", "oauth:ycgqr3dyef7gp5r8uk7d5jz30nbrc6", channel);
                    chatConnect.ReceiveMessage += ReadMessages;
                    AddToText("> BOT CONNECTED TO THE CHANNEL " + channel.ToUpper());
                }
                else
                {
                    chatConnect = new TwitchIrcClient("gw2loguploader", "oauth:ycgqr3dyef7gp5r8uk7d5jz30nbrc6");
                    chatConnect.ReceiveMessage += ReadMessages;
                    AddToText("> BOT CONNECTED TO TWITCH");
                }
                new Thread(DoCommandArgs).Start();
            }
            catch
            {
                Registry.CurrentUser.DeleteSubKey(@"SOFTWARE\Plenyx\PlenBotUploader");
                MessageBox.Show("An error in the Windows' registry has occurred.\nAll settings are reset.\nThe application will now restart.", "An error has occurred");
                RestartApp();
            }
        }

        protected void DoCommandArgs()
        {
            string[] args = Environment.GetCommandLineArgs();
            NameValueCollection nvc = new NameValueCollection
            {
                { "generator", "ei" }
            };
            if (checkBoxWepSkill1.Checked)
            {
                nvc.Add("rotation_weap1", "1");
            }
            foreach (string arg in args)
            {
                if (File.Exists(arg))
                {
                    if (arg.Contains(".zevtc"))
                    {
                        HttpUploadFile("https://dps.report/uploadContent", arg, "file", "text/plain", nvc, true);
                    }
                }
            }
        }

        private string GetLocalDir() => $"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase.Remove(0, 8))}\\";

        private void RestartApp()
        {
            ProcessStartInfo Info = new ProcessStartInfo
            {
                Arguments = "/C ping 127.0.0.1 -n 2 && \"" + Application.ExecutablePath + "\"",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = "cmd.exe"
            };
            Process.Start(Info);
            notifyIconTray.Visible = false;
            Application.Exit();
        }

        private void AddToText(string s)
        {
            textBoxUploadInfo.AppendText(s + Environment.NewLine);
            textBoxUploadInfo.SelectionStart = textBoxUploadInfo.TextLength;
            textBoxUploadInfo.ScrollToCaret();
        }

        private void UpdateLogCount() { labelLocationInfo.Text = "Logs in the directory: " + Logs.Count; }

        public async Task DownloadFileAsync(string url, string destination)
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                using (WebClient downloader = new WebClient())
                {
                    await downloader.DownloadFileTaskAsync(new Uri(url), @destination);
                }
            }
            catch { /* do nothing */ }
        }

        public async Task<string> DownloadFileAsyncToString(string url)
        {
            string response = "";
            using (WebClient client = new WebClient())
            {
                response = await client.DownloadStringTaskAsync(new Uri(url));
            }
            return response;
        }

        public async void HttpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc, bool bypassMessage = false)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = CredentialCache.DefaultCredentials;
            using (Stream rs = wr.GetRequestStream())
            {
                foreach (string key in nvc.Keys)
                {
                    rs.Write(boundarybytes, 0, boundarybytes.Length);
                    byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes($"Content-Disposition: form-data; name=\"{key}\"\r\n\r\n{nvc[key]}");
                    rs.Write(formitembytes, 0, formitembytes.Length);
                }
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes($"Content-Disposition: form-data; name=\"{paramName}\"; filename=\"{file}\"\r\nContent-Type: {contentType}\r\n\r\n");
                rs.Write(headerbytes, 0, headerbytes.Length);
                using (FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead = 0;
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0) { rs.Write(buffer, 0, bytesRead); }
                }
                byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
                rs.Write(trailer, 0, trailer.Length);
            }
            try
            {
                using (WebResponse wresp = await wr.GetResponseAsync())
                {
                    using (Stream stream = wresp.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string response = reader.ReadToEnd();
                            string split = response.Split(new string[] { "\"permalink\":\"" }, StringSplitOptions.None)[1];
                            string link = split.Split(new string[] { "\"" }, StringSplitOptions.None)[0];
                            link = link.Replace("\\", "");
                            File.AppendAllText(GetLocalDir() + "logs.txt", link + "\n");
                            if (checkBoxPostToTwitch.Checked && !bypassMessage)
                            {
                                AddToText("File uploaded, link received and posted to chat: " + link);
                                LastLog = link;
                                await chatConnect.SendChatMessage(textBoxChannel.Text, "Link to the log: " + link);
                            }
                            else
                            {
                                AddToText("File uploaded, link received: " + link);
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private void TreeScan(string sDir)
        {
            foreach (string f in Directory.GetFiles(sDir))
            {
                if (!Logs.Contains(f))
                {
                    Logs.Add(f);
                    if (!checkBoxUploadLogs.Checked)
                    {
                        continue;
                    }
                    try
                    {
                        if (new FileInfo(f).Length >= maxFileSize)
                        {
                            string zipfilelocation = f;
                            if (!Path.GetFileName(f).Contains(".zevtc"))
                            {
                                zipfilelocation = GetLocalDir() + Path.GetFileName(f) + ".zevtc";
                                using(ZipArchive zipfile = ZipFile.Open(zipfilelocation, ZipArchiveMode.Create)) { zipfile.CreateEntryFromFile(@f, Path.GetFileName(f)); }
                            }
                            try
                            {
                                NameValueCollection nvc = new NameValueCollection
                                {
                                    { "generator", "ei" }
                                };
                                if (checkBoxWepSkill1.Checked)
                                {
                                    nvc.Add("rotation_weap1", "1");
                                }
                                HttpUploadFile("https://dps.report/uploadContent", zipfilelocation, "file", "text/plain", nvc);
                            }
                            catch
                            {
                                throw;
                            }
                        }
                    }
                    catch
                    {
                        Logs.Remove(f);
                        AddToText("Unable to upload the file: " + f);
                    }
                }
            }
            foreach (string d in Directory.GetDirectories(sDir)) { TreeScan(d); }
        }

        private void TreeScanStart(string sDir)
        {
            foreach (string f in Directory.GetFiles(sDir)) { Logs.Add(f); }
            foreach (string d in Directory.GetDirectories(sDir)) { TreeScanStart(d); }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            RegistryAccess.Flush();
            RegistryAccess.Dispose();
            chatConnect.Dispose();
        }

        private void checkBoxUploadAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUploadLogs.Checked)
            {
                RegistryAccess.SetValue("uploadAll", 1);
                checkBoxPostToTwitch.Enabled = true;
            }
            else
            {
                RegistryAccess.SetValue("uploadAll", 0);
                checkBoxPostToTwitch.Enabled = false;
                checkBoxPostToTwitch.Checked = false;
            }
        }

        private void buttonReconnectBot_Click(object sender, EventArgs e)
        {
            chatConnect.ReceiveMessage -= ReadMessages;
            chatConnect.Dispose();
            chatConnect = null;
            chatConnect = new TwitchIrcClient("gw2loguploader", "oauth:ycgqr3dyef7gp5r8uk7d5jz30nbrc6", textBoxChannel.Text);
            chatConnect.ReceiveMessage += ReadMessages;
            AddToText("> BOT RECONNECTED");
        }

        private void buttonLogsLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                Description = "Select the arcdps folder containing the combat logs.\nThe folder's you are looking for name is arcdps.cbtlogs"
            };
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
            {
                if (dialog.SelectedPath.Contains("arcdps.cbtlogs"))
                {
                    LogsLocation = dialog.SelectedPath;
                    RegistryAccess.SetValue("logsLocation", LogsLocation);
                    TreeScanStart(LogsLocation);
                    UpdateLogCount();
                    timerLogsCheck.Stop();
                    timerLogsCheck.Start();
                    buttonStartChecker.Enabled = false;
                    buttonStopChecker.Enabled = true;
                }
                else
                {
                    MessageBox.Show("The specified location does not appear to be an arcdps folder.\nCheck your directory and try again.", "An error has occurred");
                }
            }
            dialog.Dispose();
        }

        private void timerLogsCheck_Tick(object sender, EventArgs e)
        {
            TreeScan(LogsLocation);
            UpdateLogCount();
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            if (LogsLocation.Contains("arcdps.cbtlogs"))
            {
                timerLogsCheck.Stop();
                timerLogsCheck.Start();
                buttonStartChecker.Enabled = false;
                buttonStopChecker.Enabled = true;
            }
            else
            {
                MessageBox.Show("You are unable to reset the checker without having set the location for the logs.", "An error has occurred");
            }
        }

        private void buttonStartChecker_Click(object sender, EventArgs e)
        {
            if (LogsLocation.Contains("arcdps.cbtlogs"))
            {
                buttonStartChecker.Enabled = false;
                buttonStopChecker.Enabled = true;
                timerLogsCheck.Start();
            }
            else
            {
                MessageBox.Show("You are unable to start the checker without having set the location for the logs.", "An error has occurred");
            }
        }

        private void buttonStopChecker_Click(object sender, EventArgs e)
        {
            buttonStartChecker.Enabled = true;
            buttonStopChecker.Enabled = false;
            timerLogsCheck.Stop();
        }

        private void checkBoxTrayEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTrayEnable.Checked)
            {
                checkBoxTrayMinimiseToIcon.Enabled = true;
                checkBoxTrayNotification.Enabled = true;
                RegistryAccess.SetValue("trayEnabled", 1);
                notifyIconTray.Visible = true;
            }
            else
            {
                checkBoxTrayMinimiseToIcon.Enabled = false;
                checkBoxTrayNotification.Enabled = false;
                checkBoxTrayMinimiseToIcon.Checked = false;
                checkBoxTrayNotification.Checked = false;
                RegistryAccess.SetValue("trayEnabled", 0);
                RegistryAccess.SetValue("trayMinimise", 0);
                RegistryAccess.SetValue("trayInfo", 0);
                notifyIconTray.Visible = false;
            }
        }

        private void textBoxChannel_TextChanged(object sender, EventArgs e) => RegistryAccess.SetValue("channel", textBoxChannel.Text);

        private void checkBoxWepSkill1_CheckedChanged(object sender, EventArgs e) => RegistryAccess.SetValue("wepSkill1", checkBoxUploadLogs.Checked ? 1 : 0);

        private void checkBoxTrayMinimiseToIcon_CheckedChanged(object sender, EventArgs e) => RegistryAccess.SetValue("trayMinimise", checkBoxTrayMinimiseToIcon.Checked ? 1 : 0);

        private void checkBoxTrayNotification_CheckedChanged(object sender, EventArgs e) => RegistryAccess.SetValue("trayInfo", checkBoxTrayNotification.Checked ? 1 : 0);

        private void checkBoxPostToTwitch_CheckedChanged(object sender, EventArgs e) => RegistryAccess.SetValue("uploadToTwitch", checkBoxPostToTwitch.Checked ? 1 : 0);

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if ((WindowState == FormWindowState.Minimized) && checkBoxTrayMinimiseToIcon.Checked)
            {
                ShowInTaskbar = false;
            }
        }

        private void notifyIconTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(ShowInTaskbar)
            {
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
            }
            else
            {
                ShowInTaskbar = true;
                WindowState = FormWindowState.Normal;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e) => notifyIconTray.Visible = false;

        protected async void ReadMessages(object sender, IrcMessageEventArgs e)
        {
            if(e == null)
            {
                return;
            }
            string[] messageSplit = e.Message.Split(new string[] { $"#{textBoxChannel.Text.ToLower()} :" }, StringSplitOptions.None);
            if(messageSplit.Length > 1)
            {
                string command = messageSplit[1].Split(' ')[0];
                if(command.Contains("!lastlog") || command.Contains("!log"))
                {
                    if(LastLog != "")
                    {
                        AddToText("> LAST LOG COMMAND USED");
                        await chatConnect.SendChatMessage(textBoxChannel.Text.ToLower(), $"Link to the last log: {LastLog}");
                    }
                }
            }
        }
    }
}
