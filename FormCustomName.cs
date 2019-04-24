using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormCustomName : Form
    {
        // fields
        private FormMain mainLink;

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
            mainLink.RegistryAccess.SetValue("twitchCustomName", textBoxCustomName.Text.ToLower());
            mainLink.RegistryAccess.SetValue("twitchCustomOAuth", textBoxCustomOAuth.Text);
            mainLink.CustomTwitchName = textBoxCustomName.Text.ToLower();
            mainLink.CustomOAuthPassword = textBoxCustomOAuth.Text;
            mainLink.ReconnectTwitchBot();
        }

        private void checkBoxCustomNameEnable_CheckedChanged(object sender, EventArgs e)
        {
            mainLink.RegistryAccess.SetValue("twitchCustomNameEnabled", checkBoxCustomNameEnable.Checked ? 1 : 0);
            groupBoxCustomNameSettings.Enabled = checkBoxCustomNameEnable.Checked;
        }

        private void linkLabelGetOAuth_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://twitchapps.com/tmi/");
    }
}
