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
            if (SessionRunning)
            {
                buttonSessionStarter.Text = "Start a log session";
                SessionRunning = false;
                await mainLink.ExecuteSessionLogWebhooksAsync();
                mainLink.SessionLogs.Clear();
            }
            else
            {
                buttonSessionStarter.Text = "Stop the log session";
                SessionRunning = true;
            }
        }
    }
}
