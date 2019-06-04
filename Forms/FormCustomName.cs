using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormCustomName : Form
    {
        #region definitions
        // fields
        private FormMain mainLink;
        #endregion

        public FormCustomName(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
        }

        private void FormCustomName_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            Properties.Settings.Default.CustomTwitchName = textBoxCustomName.Text.ToLower();
            Properties.Settings.Default.CustomTwitchOAuthPassword = textBoxCustomOAuth.Text;
            if (!mainLink.IsConnectionNull())
            {
                mainLink.ReconnectTwitchBot();
            }
        }

        private void checkBoxCustomNameEnable_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CustomTwitchNameEnabled = checkBoxCustomNameEnable.Checked;
            groupBoxCustomNameSettings.Enabled = checkBoxCustomNameEnable.Checked;
        }

        private void linkLabelGetOAuth_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://twitchapps.com/tmi/");
    }
}
