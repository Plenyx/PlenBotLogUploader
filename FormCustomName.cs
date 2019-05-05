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
            mainLink.SetRegistryValue("twitchCustomName", textBoxCustomName.Text.ToLower());
            mainLink.SetRegistryValue("twitchCustomOAuth", textBoxCustomOAuth.Text);
            mainLink.CustomTwitchName = textBoxCustomName.Text.ToLower();
            mainLink.CustomOAuthPassword = textBoxCustomOAuth.Text;
            mainLink.ReconnectTwitchBot();
        }

        private void checkBoxCustomNameEnable_CheckedChanged(object sender, EventArgs e)
        {
            mainLink.SetRegistryValue("twitchCustomNameEnabled", checkBoxCustomNameEnable.Checked ? 1 : 0);
            groupBoxCustomNameSettings.Enabled = checkBoxCustomNameEnable.Checked;
        }

        private void linkLabelGetOAuth_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://twitchapps.com/tmi/");
    }
}
