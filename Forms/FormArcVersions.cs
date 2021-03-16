using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormArcVersions : Form
    {
        #region definitions
        // properties
        public string GW2Location { get; set; } = "";

        // fields
        private readonly FormMain mainLink;
        private int gw2Instances = 0;
        #endregion

        public FormArcVersions(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
        }

        private void FormArcVersions_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void ButtonChangeGWLocation_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Guild Wars 2|Gw2-64.exe";
                var result = dialog.ShowDialog();
                if (result.Equals(DialogResult.OK) && !string.IsNullOrWhiteSpace(dialog.FileName))
                {
                    string location = Path.GetDirectoryName(dialog.FileName);
                    if (File.Exists($@"{location}\bin64\d3d9.dll"))
                    {
                        GW2Location = location;
                        Properties.Settings.Default.GW2Location = location;
                        buttonEnabler.Enabled = true;
                        buttonCheckNow.Enabled = true;
                    }
                }
            }
        }

        public async Task StartTimerAsync(bool checkNow = false)
        {
            timerCheckNewArcversion.Stop();
            if (checkNow)
            {
                await CheckNewVersionAsync();
            }
            timerCheckNewArcversion.Start();
        }

        public async Task StopTimerAsync(bool checkNow = false)
        {
            timerCheckNewArcversion.Stop();
            if (checkNow)
            {
                await CheckNewVersionAsync();
            }
        }

        private void SetInformationText(string text)
        {
            if (labelInformation.InvokeRequired)
            {
                labelInformation.Invoke((Action<string>)delegate (string newText) { SetInformationText(newText); }, text);
                return;
            }
            labelInformation.Text = text;
        }

        private async Task UpdateArcAsync()
        {
            buttonUpdate.Enabled = false;
            var processes = Process.GetProcessesByName("Gw2-64").ToList();
            if (processes.Count == 0)
            {
                SetInformationText("Downloading newest version of arcdps...");
                await mainLink.HttpClientController.DownloadFileAsync("https://deltaconnected.com/arcdps/x64/d3d9.dll", $@"{GW2Location}\bin64\d3d9.dll");
                SetInformationText("Update complete.");
                groupBoxUpdating.Enabled = false;
                buttonCheckNow.Enabled = true;
                buttonUpdate.Enabled = true;
                await StartTimerAsync();
            }
            else
            {
                Interlocked.Exchange(ref gw2Instances, processes.Count);
                foreach (var process in processes)
                {
                    process.EnableRaisingEvents = true;
                    process.Exited += ProcessExited;
                }
                SetInformationText("Waiting for Guild Wars 2 to close...");
            }
        }

        private async void ProcessExited(object sender, EventArgs e)
        {
            Interlocked.Decrement(ref gw2Instances);
            if (gw2Instances == 0)
            {
                await UpdateArcAsync();
            }
        }

        public async Task CheckNewVersionAsync(bool manual = false)
        {
            string availableVersionResponse = await mainLink.HttpClientController.DownloadFileToStringAsync("https://deltaconnected.com/arcdps/x64/d3d9.dll.md5sum");
            string availableVersion = availableVersionResponse.Split(' ')[0];
            if ((availableVersion != "") && (File.Exists($@"{GW2Location}\bin64\d3d9.dll")))
            {
                using (var md5 = System.Security.Cryptography.MD5.Create())
                {
                    try
                    {
                        if (File.Exists($@"{GW2Location}\bin64\d3d9.dll"))
                        {
                            byte[] hash = null;
                            using (var stream = File.OpenRead($@"{GW2Location}\bin64\d3d9.dll"))
                            {
                                hash = md5.ComputeHash(stream);
                            }
                            if (!BitConverter.ToString(hash).Replace("-", "").ToLower().Equals(availableVersion))
                            {
                                buttonCheckNow.Enabled = false;
                                groupBoxUpdating.Enabled = true;
                                if (manual)
                                {
                                    var result = MessageBox.Show("New arcdps version available.\nDo you want to download the new version?", "arcdps version checker", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                    if (result.Equals(DialogResult.Yes))
                                    {
                                        await UpdateArcAsync();
                                    }
                                }
                                else
                                {
                                    if (Properties.Settings.Default.ArcAutoUpdate)
                                    {
                                        await UpdateArcAsync();
                                    }
                                    else
                                    {
                                        mainLink.ShowBalloon("arcdps version checking", "New version of arcdps available.\nGo to arcdps version checking settings to use the auto-update.", 8500);
                                    }
                                }
                            }
                            else
                            {
                                if (manual)
                                {
                                    MessageBox.Show("arcdps is up to date.", "arcdps version checker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            buttonCheckNow.Enabled = false;
                            groupBoxUpdating.Enabled = true;
                            if (manual)
                            {
                                var result = MessageBox.Show("New arcdps version available.\nDo you want to download the new version?", "arcdps version checker", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (result.Equals(DialogResult.Yes))
                                {
                                    await UpdateArcAsync();
                                }
                            }
                            else
                            {
                                mainLink.ShowBalloon("arcdps version checking", "New version of arcdps available.\nGo to arcdps version checking settings to use the auto-update.", 8500);
                            }
                        }
                    }
                    catch
                    {
                        if (manual)
                        {
                            MessageBox.Show("There has been an error trying to check if arcdps is up to date.", "arcdps version checker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                buttonCheckNow.Enabled = false;
                groupBoxUpdating.Enabled = true;
                if (manual)
                {
                    var result = MessageBox.Show("New arcdps version available\nDo you want to download the new version?", "arcdps version checker", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.Yes))
                    {
                        await UpdateArcAsync();
                    }
                }
            }
        }

        private async void ButtonCheckNow_Click(object sender, EventArgs e) => await CheckNewVersionAsync(true);

        private async void TimerCheckNewArcversion_Tick(object sender, EventArgs e) => await CheckNewVersionAsync();

        private async void ButtonEnabler_Click(object sender, EventArgs e)
        {
            await StopTimerAsync();
            GW2Location = "";
            Properties.Settings.Default.GW2Location = "";
            buttonEnabler.Enabled = false;
        }

        private void LinkLabelLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://deltaconnected.com/arcdps/");

        private async void ButtonUpdate_Click(object sender, EventArgs e) => await UpdateArcAsync();

        private void FormArcVersions_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Process.Start("https://deltaconnected.com/arcdps/");
        }

        public void CheckBoxAutoUpdateArc_CheckedChanged(object sender, EventArgs e) => Properties.Settings.Default.ArcAutoUpdate = checkBoxAutoUpdateArc.Checked;
    }
}
