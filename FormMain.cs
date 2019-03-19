using System;
using System.IO;
using System.Net;
using System.Linq;
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
        private RegistryKey rk { get; set; } = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Plenyx\PlenBotUploader");
        private List<string> Logs { get; set; } = new List<string>();
        private string LogsLocation { get; set; } = "";
        private string LastLog { get; set; } = "";
        private double Version { get; } = 0.4;

        public FormMain()
        {
            InitializeComponent();
            this.Text += " v"+Version.ToString().Replace(',', '.')+" - Powered by ";
            string[] memes = { "dank memes", "raids being broken after patch", "so toxic wow much elitist", "Flaming during raid sells", "Never lucky BabyRage" };
            Random mt_rand = new Random();
            memes = memes.OrderBy(x => mt_rand.Next()).ToArray();
            this.Text += memes[mt_rand.Next(0, memes.Count() - 1)];
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string response = await DownloadFileAsyncToString("https://raw.githubusercontent.com/Plenyx/PlenBotLogUploader/master/plenbot-releases/VERSION");
                if(Double.TryParse(response, NumberStyles.Float, CultureInfo.InvariantCulture, out double currentversion))
                {
                    if(currentversion > Version)
                    {
                        DialogResult result = MessageBox.Show("Do you want to download the newest version?", "New version available (v" + currentversion.ToString().Replace(',', '.') + ")", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (result == DialogResult.Yes)
                        {
                            await DownloadFileAsync("https://github.com/Plenyx/PlenBotLogUploader/raw/master/plenbot-releases/" + currentversion.ToString().Replace(',', '.') + "/PlenBotLogUploader.exe", GetLocalDir() + "/PlenBotLogUploaderUpdate.exe");
                            ProcessStartInfo Info = new ProcessStartInfo();
                            Info.Arguments = "/C ping 127.0.0.1 -n 2 && move /Y \"" + GetLocalDir() + "PlenBotLogUploaderUpdate.exe\" \"" + Application.ExecutablePath + "\"";
                            Info.WindowStyle = ProcessWindowStyle.Hidden;
                            Info.CreateNoWindow = true;
                            Info.FileName = "cmd.exe";
                            Process.Start(Info);
                            notifyIconTray.Visible = false;
                            Application.Exit();
                        }
                    }
                }
            }
            catch { /* do nothing */ }
            try
            {
                if(rk.GetValue("logsLocation") == null)
                    rk.SetValue("logsLocation", "");
                if(rk.GetValue("channel") == null)
                    rk.SetValue("channel", "");
                if(rk.GetValue("uploadAll") == null)
                    rk.SetValue("uploadAll", 1);
                if(rk.GetValue("uploadToTwitch") == null)
                    rk.SetValue("uploadToTwitch", 1);
                if(rk.GetValue("wepSkill1") == null)
                    rk.SetValue("wepSkill1", 1);
                if(rk.GetValue("trayEnabled") == null)
                    rk.SetValue("trayEnabled", 1);
                if(rk.GetValue("trayMinimise") == null)
                    rk.SetValue("trayMinimise", 1);
                if(rk.GetValue("trayInfo") == null)
                    rk.SetValue("trayInfo", 0);
                LogsLocation = (string)rk.GetValue("logsLocation", "");
                if(LogsLocation == "")
                    labelLocationInfo.Text = "!!! Select a directory with the logs !!!";
                else
                {
                    TreeScanStart(LogsLocation);
                    UpdateLogCount();
                    buttonStartChecker.Enabled = false;
                    buttonStopChecker.Enabled = true;
                    timerLogsCheck.Start();
                }
                textBoxChannel.Text = (string)rk.GetValue("channel", "");
                if((int)rk.GetValue("uploadAll", 0) == 1)
                    checkBoxUploadLogs.Checked = true;
                if((int)rk.GetValue("uploadToTwitch", 0) == 1)
                    checkBoxPostToTwitch.Checked = true;
                if((int)rk.GetValue("wepSkill1", 0) == 1)
                    checkBoxWepSkill1.Checked = true;
                if((int)rk.GetValue("trayEnabled", 0) == 1)
                    checkBoxTrayEnable.Checked = true;
                if((int)rk.GetValue("trayMinimise", 0) == 1)
                    checkBoxTrayMinimiseToIcon.Checked = true;
                if((int)rk.GetValue("trayInfo", 0) == 1)
                    checkBoxTrayNotification.Checked = true;
                if(checkBoxUploadLogs.Checked)
                    checkBoxPostToTwitch.Enabled = true;
                if(checkBoxTrayEnable.Checked)
                    notifyIconTray.Visible = true;
                string channel = (string)rk.GetValue("channel", "");
                if(channel != "")
                {
                    chatConnect = new TwitchIrcClient("gw2loguploader", "oauth:ycgqr3dyef7gp5r8uk7d5jz30nbrc6", channel);
                    AddToText("> BOT CONNECTED TO THE CHANNEL " + channel);
                }
                else
                {
                    chatConnect = new TwitchIrcClient("gw2loguploader", "oauth:ycgqr3dyef7gp5r8uk7d5jz30nbrc6");
                    AddToText("> BOT CONNECTED BUT TO NO CHANNEL");
                }
            }
            catch
            {
                Registry.CurrentUser.DeleteSubKey(@"SOFTWARE\Plenyx\PlenBotUploader");
                MessageBox.Show("An error in the Windows' registry has occurred.\nAll settings are reset.\nThe application will now restart.", "An error has occurred");
                RestartApp();
            }
        }

        private string GetLocalDir() { return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase.Remove(0, 8)) + "\\"; }

        private void RestartApp()
        {
            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = "/C ping 127.0.0.1 -n 2 && \"" + Application.ExecutablePath + "\"";
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "cmd.exe";
            Process.Start(Info);
            notifyIconTray.Visible = false;
            Application.Exit();
        }

        private void AddToText(string s)
        {
            textBoxUploadInfo.AppendText(s + System.Environment.NewLine);
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
                WebClient downloader = new WebClient();
                await downloader.DownloadFileTaskAsync(new Uri(url), @destination);
            }
            catch { /* do nothing */ }
        }

        public async Task<string> DownloadFileAsyncToString(string url)
        {
            WebClient downloader = new WebClient();
            return await downloader.DownloadStringTaskAsync(new Uri(url));
        }

        public async void HttpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;
            Stream rs = wr.GetRequestStream();
            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach(string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);
            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, file, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);
            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0) { rs.Write(buffer, 0, bytesRead); }
            fileStream.Close();
            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();
            WebResponse wresp = null;
            try
            {
                wresp = await wr.GetResponseAsync();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                string response = reader2.ReadToEnd();
                string split1 = response.Split(new string[] { "\"permalink\":\"" }, StringSplitOptions.None)[1];
                string link = split1.Split(new string[] { "\"" }, StringSplitOptions.None)[0];
                link = link.Replace("\\", "");
                File.AppendAllText(GetLocalDir() + "logs.txt", link+"\n");
                if(checkBoxPostToTwitch.Checked)
                {
                    AddToText("File uploaded, link received and posted to chat: " + link);
                    LastLog = link;
                    await chatConnect.SendChatMessage(textBoxChannel.Text, "Link to the log: " + link);
                }
                else
                    AddToText("File uploaded, link received: " + link);
            }
            catch
            {
                if(wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
            }
            finally { wr = null; }
        }

        private void TreeScan(string sDir)
        {
            foreach(string f in Directory.GetFiles(sDir))
            {
                if(!Logs.Contains(f))
                {
                    Logs.Add(f);
                    if(!checkBoxUploadLogs.Checked)
                        continue;
                    try
                    {
                        if(new FileInfo(f).Length >= 122880)
                        {
                            string zipfilelocation = f;
                            if(!Path.GetFileName(f).Contains(".zip") && !Path.GetFileName(f).Contains(".zevtc"))
                            {
                                zipfilelocation = GetLocalDir() + Path.GetFileName(f) + ".zip";
                                using(ZipArchive zipfile = ZipFile.Open(zipfilelocation, ZipArchiveMode.Create)) { zipfile.CreateEntryFromFile(@f, Path.GetFileName(f)); }
                            }
                            try
                            {
                                NameValueCollection nvc = new NameValueCollection();
                                nvc.Add("generator", "ei");
                                if(checkBoxWepSkill1.Checked)
                                    nvc.Add("rotation_weap1", "1");
                                HttpUploadFile("https://dps.report/uploadContent", zipfilelocation, "file", "text/plain", nvc);
                            }
                            catch
                            {
                                Logs.Remove(f);
                                AddToText("Unable to upload the file: " + f);
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
            foreach(string d in Directory.GetDirectories(sDir)) { TreeScan(d); }
        }

        private void TreeScanStart(string sDir)
        {
            foreach(string f in Directory.GetFiles(sDir)) { Logs.Add(f); }
            foreach(string d in Directory.GetDirectories(sDir)) { TreeScanStart(d); }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            rk.Flush();
            rk.Close();
        }

        private void checkBoxUploadAll_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxUploadLogs.Checked)
            {
                rk.SetValue("uploadAll", 1);
                checkBoxPostToTwitch.Enabled = true;
            }
            else
            {
                rk.SetValue("uploadAll", 0);
                checkBoxPostToTwitch.Enabled = false;
                checkBoxPostToTwitch.Checked = false;
            }
        }

        private void textBoxChannel_TextChanged(object sender, EventArgs e)
        {
            rk.SetValue("channel", textBoxChannel.Text);
        }

        private void buttonReconnectBot_Click(object sender, EventArgs e)
        {
            chatConnect = null;
            chatConnect = new TwitchIrcClient("gw2loguploader", "oauth:ycgqr3dyef7gp5r8uk7d5jz30nbrc6", textBoxChannel.Text);
            AddToText("> BOT RECONNECTED");
        }

        private void checkBoxWepSkill1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxUploadLogs.Checked)
                rk.SetValue("wepSkill1", 1);
            else
                rk.SetValue("wepSkill1", 0);
        }

        private void buttonLogsLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Select the arcdps folder containing the combat logs.\nThe folder you are looking for name is arcdps.cbtlogs";
            DialogResult result = dialog.ShowDialog();
            if(result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
            {
                if(dialog.SelectedPath.Contains("arcdps.cbtlogs"))
                {
                    LogsLocation = dialog.SelectedPath;
                    rk.SetValue("logsLocation", LogsLocation);
                    TreeScanStart(LogsLocation);
                    UpdateLogCount();
                    timerLogsCheck.Stop();
                    timerLogsCheck.Start();
                    buttonStartChecker.Enabled = false;
                    buttonStopChecker.Enabled = true;
                }
                else
                    MessageBox.Show("The specified location does not appear to be an arcdps folder.\nCheck your directory and try again.", "An error has occurred");
            }
            dialog = null;
        }

        private void timerLogsCheck_Tick(object sender, EventArgs e)
        {
            TreeScan(LogsLocation);
            UpdateLogCount();
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            if(LogsLocation.Contains("arcdps.cbtlogs"))
            {
                timerLogsCheck.Stop();
                timerLogsCheck.Start();
                buttonStartChecker.Enabled = false;
                buttonStopChecker.Enabled = true;
            }
            else
                MessageBox.Show("You are unable to reset the checker without having set the location for the logs.", "An error has occurred");
        }

        private void buttonStartChecker_Click(object sender, EventArgs e)
        {
            if(LogsLocation.Contains("arcdps.cbtlogs"))
            {
                buttonStartChecker.Enabled = false;
                buttonStopChecker.Enabled = true;
                timerLogsCheck.Start();
            }
            else
                MessageBox.Show("You are unable to start the checker without having set the location for the logs.", "An error has occurred");
        }

        private void buttonStopChecker_Click(object sender, EventArgs e)
        {
            buttonStartChecker.Enabled = true;
            buttonStopChecker.Enabled = false;
            timerLogsCheck.Stop();
        }

        private void checkBoxTrayEnable_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxTrayEnable.Checked)
            {
                checkBoxTrayMinimiseToIcon.Enabled = true;
                checkBoxTrayNotification.Enabled = true;
                rk.SetValue("trayEnabled", 1);
                notifyIconTray.Visible = true;
            }
            else
            {
                checkBoxTrayMinimiseToIcon.Enabled = false;
                checkBoxTrayNotification.Enabled = false;
                checkBoxTrayMinimiseToIcon.Checked = false;
                checkBoxTrayNotification.Checked = false;
                rk.SetValue("trayEnabled", 0);
                rk.SetValue("trayMinimise", 0);
                rk.SetValue("trayInfo", 0);
                notifyIconTray.Visible = false;
            }
        }

        private void checkBoxTrayMinimiseToIcon_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxTrayMinimiseToIcon.Checked)
                rk.SetValue("trayMinimise", 1);
            else
                rk.SetValue("trayMinimise", 0);
        }

        private void checkBoxTrayNotification_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxTrayNotification.Checked)
                rk.SetValue("trayInfo", 1);
            else
                rk.SetValue("trayInfo", 0);
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if((this.WindowState == FormWindowState.Minimized) && checkBoxTrayMinimiseToIcon.Checked)
                this.ShowInTaskbar = false;
        }

        private void notifyIconTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(this.ShowInTaskbar)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
            else
            {
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void checkBoxPostToTwitch_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxPostToTwitch.Checked)
                rk.SetValue("uploadToTwitch", 1);
            else
                rk.SetValue("uploadToTwitch", 0);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIconTray.Visible = false;
        }

        protected async void ReadMessages(object sender, EventArgs e)
        {
            if(e == null)
            {
                return;
            }
            IrcMessageEventArgs ea = (IrcMessageEventArgs)e;
            if(ea == null)
            {
                return;
            }
            string command = ea.Message.Split(' ')[0];
            if(command.Contains("!lastlog") || command.Contains("!log"))
            {
                if(LastLog != "")
                {
                    AddToText("> LAST LOG COMMAND USED");
                    await chatConnect.SendChatMessage(textBoxChannel.Text, $"Link to the last log: {LastLog}");
                }
            }
        }
    }
}
