using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace PlenBotLogUploader
{
    public partial class FormArcVersions : Form
    {
        // properties
        public string GW2Location { get; set; } = "";

        // fields
        private FormMain mainLink;
        private int gw2Instances = 0;

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

        private void buttonChangeGWLocation_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Guild Wars 2|Gw2-64.exe;Gw2.exe";
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.FileName))
                {
                    string location = Path.GetDirectoryName(dialog.FileName);
                    if (File.Exists($@"{location}\bin64\d3d9.dll"))
                    {
                        GW2Location = location;
                        mainLink.SetRegistryValue("gw2Location", location);
                        buttonEnabler.Enabled = true;
                    }
                }
            }
        }

        public async void StartTimer(bool checkNow = false)
        {
            timerCheckNewArcversion.Stop();
            if (checkNow)
            {
                await CheckNewVersion();
            }
            timerCheckNewArcversion.Start();
        }

        public async void StopTimer(bool checkNow = false)
        {
            timerCheckNewArcversion.Stop();
            if (checkNow)
            {
                await CheckNewVersion();
            }
        }

        private void SetInformationText(string text)
        {
            if (labelInformation.InvokeRequired)
            {
                labelInformation.Invoke((Action<string>)delegate (string newText) { SetInformationText(newText); }, text);
            }
            else
            {
                labelInformation.Text = text;
            }
        }

        private void UpdateArc()
        {
            var processes = Process.GetProcessesByName("Gw2-64").ToList();
            processes.AddRange(Process.GetProcessesByName("Gw2").ToList());
            if (processes.Count == 0)
            {
                SetInformationText("Downloading newest version of arcdps...");
                mainLink.DownloadFile("http://deltaconnected.com/arcdps/x64/d3d9.dll", $@"{GW2Location}\bin64\d3d9.dll");
                SetInformationText("Update complete");
                groupBoxUpdating.Enabled = false;
                buttonCheckNow.Enabled = true;
                StartTimer();
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

        private void ProcessExited(object sender, EventArgs e)
        {
            Interlocked.Decrement(ref gw2Instances);
            if (gw2Instances == 0)
            {
                UpdateArc();
            }
        }

        public async Task CheckNewVersion(bool manual = false)
        {
            string availableVersionResnponse = await mainLink.DownloadFileAsyncToString("https://deltaconnected.com/arcdps/x64/d3d9.dll.md5sum");
            string availableVersion = availableVersionResnponse.Split(' ')[0];
            if (File.Exists($@"{GW2Location}\bin64\d3d9.dll"))
            {
                using (var md5 = System.Security.Cryptography.MD5.Create())
                {
                    using (var stream = File.OpenRead($@"{GW2Location}\bin64\d3d9.dll"))
                    {
                        var hash = md5.ComputeHash(stream);
                        if (!BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant().Equals(availableVersion))
                        {
                            buttonCheckNow.Enabled = false;
                            groupBoxUpdating.Enabled = true;
                            if (manual)
                            {
                                DialogResult result = MessageBox.Show("New arc version available\nDo you want to download the new version?", "arc version checker", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (result == DialogResult.Yes)
                                {
                                    UpdateArc();
                                }
                            }
                            else
                            {
                                mainLink.ShowBalloon("arcdps version checking", "New version of arc available", 6500);
                            }
                        }
                        else
                        {
                            if (manual)
                            {
                                MessageBox.Show("arcdps is up to date", "arc version checker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
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
                    DialogResult result = MessageBox.Show("New arc version available\nDo you want to download the new version?", "arc version checker", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        UpdateArc();
                    }
                }
                else
                {
                    mainLink.ShowBalloon("arcdps version checking", "New version of arc available", 6500);
                }
            }
        }

        private async void buttonCheckNow_Click(object sender, EventArgs e) => await CheckNewVersion(true);

        private async void timerCheckNewArcversion_Tick(object sender, EventArgs e) => await CheckNewVersion();

        private void buttonEnabler_Click(object sender, EventArgs e)
        {
            StopTimer();
            GW2Location = "";
            mainLink.SetRegistryValue("gw2Location", "");
            buttonEnabler.Enabled = false;
        }

        private void linkLabelLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://deltaconnected.com/arcdps/");

        private void buttonUpdate_Click(object sender, EventArgs e) => UpdateArc();
    }
}
