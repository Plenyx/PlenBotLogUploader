using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Collections.Specialized;
using Microsoft.Win32;
using System.Diagnostics;
using IRCClient;

namespace PlenBotLogUploader
{
    public partial class FormMain : Form
    {
        private IrcClient chatconnect;
        private RegistryKey rk;
        private List<string> logs;
        private string logslocation = "";

        public FormMain()
        {
            logs = new List<string>();
            rk = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Plenyx\PlenBotUploader");
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if(rk.GetValue("logsLocation") == null)
                    rk.SetValue("logsLocation", "");
                if(rk.GetValue("channel") == null)
                    rk.SetValue("channel", "");
                if(rk.GetValue("uploadAll") == null)
                    rk.SetValue("uploadAll", 1);
                if(rk.GetValue("wepSkill1") == null)
                    rk.SetValue("wepSkill1", 1);
                logslocation = (string)rk.GetValue("logsLocation", "");
                if(logslocation == "")
                    labelLocationInfo.Text = "!!! Select a directory with the arc logs !!!";
                else
                {
                    TreeScanStart(logslocation);
                    UpdateLogCount();
                    buttonStartChecker.Enabled = false;
                    buttonStopChecker.Enabled = true;
                    timerLogsCheck.Start();
                }
                textBoxChannel.Text = (string)rk.GetValue("channel", "");
                if((int)rk.GetValue("uploadAll", 0) == 1)
                    checkBoxUploadLogs.Checked = true;
                if((int)rk.GetValue("uploadAll", 0) == 1)
                    checkBoxWepSkill1.Checked = true;
                chatconnect = new IrcClient("gw2loguploader", "oauth:ycgqr3dyef7gp5r8uk7d5jz30nbrc6");
                string channel = (string)rk.GetValue("channel", "");
                if(channel != "")
                    await chatconnect.joinRoom(channel);
            }
            catch
            {
                Registry.CurrentUser.DeleteSubKey(@"SOFTWARE\Plenyx\PlenBotUploader");
                MessageBox.Show("An error in the Windows' registry has occurred.\nAll settings are reset.\nThe application will now restart.", "An error has occurred");
                ProcessStartInfo Info = new ProcessStartInfo();
                Info.Arguments = "/C ping 127.0.0.1 -n 2 && \"" + Application.ExecutablePath + "\"";
                Info.WindowStyle = ProcessWindowStyle.Hidden;
                Info.CreateNoWindow = true;
                Info.FileName = "cmd.exe";
                Process.Start(Info);
                Application.Exit();
            }
        }

        private string GetLocalDir()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase.Remove(0, 8)) + "\\";
        }

        private void AddToText(string s)
        {
            textBoxUploadInfo.AppendText(s + System.Environment.NewLine);
            textBoxUploadInfo.SelectionStart = textBoxUploadInfo.TextLength;
            textBoxUploadInfo.ScrollToCaret();
        }

        private void UpdateLogCount()
        {
            labelLocationInfo.Text = "Logs in the directory: " + logs.Count;
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
            foreach (string key in nvc.Keys)
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
                AddToText("File uploaded, link received: " + link);
                await chatconnect.sendChatMessage("Link to the log: " + link);
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
                if(!logs.Contains(f))
                {
                    logs.Add(f);
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
                                using(ZipArchive zipfile = ZipFile.Open(zipfilelocation, ZipArchiveMode.Create))
                                {
                                    zipfile.CreateEntryFromFile(@f, Path.GetFileName(f));
                                }
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
                                logs.Remove(f);
                                AddToText("Unable to upload the file: " + f);
                            }
                        }
                    }
                    catch
                    {
                        logs.Remove(f);
                        AddToText("Unable to upload the file: " + f);
                    }
                }
            }
            foreach(string d in Directory.GetDirectories(sDir)) { TreeScan(d); }
        }

        private void TreeScanStart(string sDir)
        {
            foreach(string f in Directory.GetFiles(sDir)) { logs.Add(f); }
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
                rk.SetValue("uploadAll", 1);
            else
                rk.SetValue("uploadAll", 0);
        }

        private void textBoxChannel_TextChanged(object sender, EventArgs e)
        {
            rk.SetValue("channel", textBoxChannel.Text);
        }

        private async void buttonReconnectBot_Click(object sender, EventArgs e)
        {
            chatconnect = null;
            chatconnect = new IrcClient("gw2loguploader", "oauth:ycgqr3dyef7gp5r8uk7d5jz30nbrc6");
            await chatconnect.joinRoom(textBoxChannel.Text);
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
                    logslocation = dialog.SelectedPath;
                    rk.SetValue("logsLocation", logslocation);
                    TreeScanStart(logslocation);
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
            TreeScan(@logslocation);
            UpdateLogCount();
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            if(logslocation.Contains("arcdps.cbtlogs"))
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
            if(logslocation.Contains("arcdps.cbtlogs"))
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
    }
}
