using PlenBotLogUploader.AppSettings;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormTwitchCommands : Form
    {
        public FormTwitchCommands()
        {
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
        }

        private void FormTwitchCommands_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            ApplicationSettings.Current.Twitch.Commands.BuildEnabled = checkBoxGW2BuildEnable.Checked;
            ApplicationSettings.Current.Twitch.Commands.BuildCommand = textBoxGW2Build.Text;
            ApplicationSettings.Current.Twitch.Commands.UploaderEnabled = checkBoxUploaderEnable.Checked;
            ApplicationSettings.Current.Twitch.Commands.UploaderCommand = textBoxUploaderCommand.Text;
            ApplicationSettings.Current.Twitch.Commands.LastLogEnabled = checkBoxLastLogEnable.Checked;
            ApplicationSettings.Current.Twitch.Commands.LastLogCommand = textBoxLastLogCommand.Text;
            ApplicationSettings.Current.Twitch.Commands.SongEnabled = checkBoxSongEnable.Checked;
            ApplicationSettings.Current.Twitch.Commands.SongCommand = textBoxSongCommand.Text;
            ApplicationSettings.Current.Twitch.Commands.SmartRecognition = checkBoxSongSmartRecognition.Checked;
            ApplicationSettings.Current.Twitch.Commands.IGNEnabled = checkBoxGW2IgnEnable.Checked;
            ApplicationSettings.Current.Twitch.Commands.IGNCommand = textBoxGW2Ign.Text;
            ApplicationSettings.Current.Twitch.Commands.PullCounterEnabled = checkBoxPullCounterEnable.Checked;
            ApplicationSettings.Current.Twitch.Commands.PullCounterCommand = textBoxPullCounter.Text;
            ApplicationSettings.Current.Save();
        }
    }
}
