using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormNETV6Upgrade : Form
    {
        #region definitions
        private readonly FormMain mainLink;
        #endregion

        internal FormNETV6Upgrade(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
        }

        private void ButtonAcknowledge_Click(object sender, EventArgs e)
        {
            mainLink.NETV6RisksAccepted = true;
            _ = mainLink.PerformUpdate();
            Close();
        }

        private void RichTextBoxUpgradeInfo_LinkClicked(object sender, LinkClickedEventArgs e) => Process.Start(e.LinkText);
    }
}
