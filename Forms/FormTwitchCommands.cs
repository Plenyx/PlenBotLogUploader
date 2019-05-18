using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormTwitchCommands : Form
    {
        #region definitions
        // fields
        private FormMain mainLink;
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
            mainLink.RegistryController.SetRegistryValue("twitchCommandUploaderEnabled", checkBoxUploaderEnable.Checked ? 1 : 0);
            mainLink.RegistryController.SetRegistryValue("twitchCommandUploader", textBoxUploaderCommand.Text);
            mainLink.RegistryController.SetRegistryValue("twitchCommandLastLogEnabled", checkBoxLastLogEnable.Checked ? 1 : 0);
            mainLink.RegistryController.SetRegistryValue("twitchCommandLastLog", textBoxLastLogCommand.Text);
        }
    }
}
