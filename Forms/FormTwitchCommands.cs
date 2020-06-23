using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormTwitchCommands : Form
    {
        #region definitions
        // fields
        private readonly FormMain mainLink;
        #endregion

        public FormTwitchCommands(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
        }

        private void FormTwitchCommands_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            Properties.Settings.Default.TwitchCommandUploaderEnabled = checkBoxUploaderEnable.Checked;
            Properties.Settings.Default.TwitchCommandUploader = textBoxUploaderCommand.Text;
            Properties.Settings.Default.TwitchCommandLastLogEnabled = checkBoxLastLogEnable.Checked;
            Properties.Settings.Default.TwitchCommandLastLog = textBoxLastLogCommand.Text;
            Properties.Settings.Default.TwitchCommandSongEnabled = checkBoxSongEnable.Checked;
            Properties.Settings.Default.TwitchCommandSong = textBoxSongCommand.Text;
            Properties.Settings.Default.TwitchCommandGW2IgnEnabled = checkBoxGW2IgnEnable.Checked;
            Properties.Settings.Default.TwitchCommandGW2Ign = textBoxGW2Ign.Text;
            Properties.Settings.Default.TwitchCommandPullCounterEnabled = checkBoxPullCounterEnable.Checked;
            Properties.Settings.Default.TwitchCommandPullCounter = textBoxPullCounter.Text;
        }
    }
}
