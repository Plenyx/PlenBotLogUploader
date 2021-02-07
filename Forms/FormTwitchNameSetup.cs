using System;
using System.Linq;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormTwitchNameSetup : Form
    {
        #region definitions
        // fields
        private readonly FormMain mainLink;
        #endregion

        public FormTwitchNameSetup(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            string channelUrl = textBoxChannelUrl.Text.ToLower();
            string[] channelUrlSplit = channelUrl.Split(new string[] { "twitch.tv/" }, StringSplitOptions.None);
            if (channelUrlSplit.Count() > 1)
            {
                string channelName = channelUrlSplit[1].Split('/')[0];
                var result = MessageBox.Show($"Is this your channel name?\n\n{channelName}", "Channel name confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result.Equals(DialogResult.Yes))
                {
                    Properties.Settings.Default.TwitchChannelName = channelName;
                    if (mainLink.IsTwitchConnectionNull())
                    {
                        mainLink.ConnectTwitchBot();
                    }
                    else
                    {
                        mainLink.ReconnectTwitchBot();
                    }
                    Hide();
                }
            }
            else
            {
                MessageBox.Show("The URL doesn't seem to be valid. Check your provided URL.", "An error has occurred");
            }
        }

        private void FormTwitchNameSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void ButtonDoNotUseTwitch_Click(object sender, EventArgs e)
        {
            if (!mainLink.IsTwitchConnectionNull())
            {
                mainLink.DisconnectTwitchBot();
            }
            Properties.Settings.Default.ConnectToTwitch = false;
            mainLink.checkBoxPostToTwitch.Checked = false;
            Hide();
        }
    }
}
