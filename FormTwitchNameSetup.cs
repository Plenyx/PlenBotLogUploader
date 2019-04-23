using System;
using System.Linq;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormTwitchNameSetup : Form
    {
        private FormMain mainLink;

        public FormTwitchNameSetup(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            string channelUrl = textBoxChannelUrl.Text.ToLower();
            string[] channelUrlSplit = channelUrl.Split(new string[] { "twitch.tv/" }, StringSplitOptions.None);
            if (channelUrlSplit.Count() > 1)
            {
                string channelName = channelUrlSplit[1].Split('/')[0];
                DialogResult result = MessageBox.Show($"Is this your channel name?\n\n{channelName}", "Channel name confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    mainLink.ChannelName = channelName;
                    mainLink.RegistryAccess.SetValue("channel", channelName);
                    mainLink.ReconnectTwitchBot();
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

        private void buttonDoNotUseTwitch_Click(object sender, EventArgs e)
        {
            mainLink.DisconnectTwitchBot();
            mainLink.RegistryAccess.SetValue("connectToTwitch", 0);
            mainLink.checkBoxPostToTwitch.Checked = false;
            Hide();
        }
    }
}
