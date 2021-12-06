using PlenBotLogUploader.ArcDps;
using System.Diagnostics;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormArcPluginInfo : Form
    {
        private readonly ArcDpsComponentHelperClass infoItem;

        public FormArcPluginInfo(ArcDpsComponentHelperClass infoItem)
        {
            this.infoItem = infoItem;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            Text = infoItem.FullName;
            labelPluginInfo.Text = $"{infoItem.Description}\n\nAuthor(s): {infoItem.Author}\nLicense: {infoItem.License}\nProvided from: {infoItem.Provider}\nLocally stored as: {infoItem.DefaultFileName}";
            linkLabelPluginLink.Text = infoItem.LinkName;
        }

        private void LinkLabelPluginLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(infoItem.LinkURL);
        }
    }
}
