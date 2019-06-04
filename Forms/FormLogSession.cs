using System;
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
                await mainLink.ExecuteSessionLogWebhooksAsync();
                mainLink.SessionLogs.Clear();
            }
            else
            {
                buttonSessionStarter.Text = "Stop the log session";
                buttonUnPauseSession.Text = "Pause session";
                buttonUnPauseSession.Enabled = true;
                SessionRunning = true;
                sessionPaused = false;
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
    }
}
