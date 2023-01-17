using PlenBotLogUploader.AppSettings;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormTwitchNameSetup : Form
    {
        #region definitions
        // fields
        private readonly FormMain mainLink;
        #endregion

        internal FormTwitchNameSetup(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
        }

        private async void ButtonNext_Click(object sender, EventArgs e)
        {
            var channelInput = textBoxChannelUrl.Text.ToLower();
            var channelUrlSplit = channelInput.Split(new string[] { "twitch.tv/" }, StringSplitOptions.None);
            if (channelUrlSplit.Length > 1)
            {
                var channelName = channelUrlSplit[1].Split('/')[0];
                await AskNameToConfirm(channelName);
            }
            else
            {
                await AskNameToConfirm(channelInput);
            }
        }

        private async Task AskNameToConfirm(string input)
        {
            var result = MessageBox.Show($"Is this your channel name?\n\n{input}", "Channel name confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (!result.Equals(DialogResult.Yes))
            {
                return;
            }
            ApplicationSettings.Current.Twitch.ChannelName = input;
            ApplicationSettings.Current.Save();
            if (mainLink.IsTwitchConnectionNull())
            {
                await mainLink.ConnectTwitchBot();
            }
            else
            {
                await mainLink.ReconnectTwitchBot();
            }
            Hide();
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
            ApplicationSettings.Current.Twitch.ConnectToTwitch = false;
            ApplicationSettings.Current.Save();
            mainLink.checkBoxPostToTwitch.Checked = false;
            Hide();
        }
    }
}
