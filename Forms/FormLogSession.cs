using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormLogSession : Form
    {
        #region definitions
        // properties
        public bool SessionRunning { get; private set; } = false;

        // fields
        private FormMain mainLink;
        private bool sessionPaused = false;
        private readonly Stopwatch stopWatch = new Stopwatch();
        #endregion

        public FormLogSession(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
        }

        private void FormLogSession_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            Properties.Settings.Default.SessionName = textBoxSessionName.Text;
            Properties.Settings.Default.SessionMessage = textBoxSessionContent.Text;
        }

        private async void ButtonSessionStarter_Click(object sender, EventArgs e)
        {
            if (SessionRunning || sessionPaused)
            {
                buttonSessionStarter.Text = "Start a log session";
                buttonUnPauseSession.Text = "Pause session";
                buttonUnPauseSession.Enabled = false;
                SessionRunning = false;
                sessionPaused = false;
                groupBoxSessionSettings.Enabled = true;
                stopWatch.Stop();
                var elapsed = stopWatch.Elapsed;
                string elapsedTime = $"{elapsed.Seconds}s";
                if (elapsed.Hours > 0 || elapsed.Days > 0)
                {
                    elapsedTime = $"{elapsed.Days * 24 + elapsed.Hours}h {elapsed.Minutes}m {elapsed.Seconds}s";
                }
                else if (elapsed.Minutes > 0)
                {
                    elapsedTime = $"{elapsed.Minutes}m {elapsed.Seconds}s";
                }
                await mainLink.ExecuteSessionLogWebhooksAsync(textBoxSessionName.Text, textBoxSessionContent.Text, !checkBoxOnlySuccess.Checked, elapsedTime);
                mainLink.SessionLogs.Clear();
            }
            else
            {
                buttonSessionStarter.Text = "Stop the log session";
                buttonUnPauseSession.Text = "Pause session";
                buttonUnPauseSession.Enabled = true;
                SessionRunning = true;
                sessionPaused = false;
                groupBoxSessionSettings.Enabled = false;
                stopWatch.Start();
            }
        }

        private void ButtonUnPauseSession_Click(object sender, EventArgs e)
        {
            if (!sessionPaused)
            {
                SessionRunning = false;
                sessionPaused = true;
                buttonUnPauseSession.Text = "Unpause session";
            }
            else
            {
                SessionRunning = true;
                sessionPaused = false;
                buttonUnPauseSession.Text = "Pause session";
            }
        }

        public void CheckBoxSupressWebhooks_CheckedChanged(object sender, EventArgs e) => Properties.Settings.Default.SessionSuppressWebhooks = checkBoxSupressWebhooks.Checked;

        public void CheckBoxOnlySuccess_CheckedChanged(object sender, EventArgs e) => Properties.Settings.Default.SessionOnlySuccess = checkBoxOnlySuccess.Checked;
    }
}
