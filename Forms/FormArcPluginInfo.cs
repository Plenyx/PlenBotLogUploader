using PlenBotLogUploader.ArcDps;
using PlenBotLogUploader.Properties;
using System.Diagnostics;
using System.Windows.Forms;

namespace PlenBotLogUploader;

public partial class FormArcPluginInfo : Form
{
    // fields
    private readonly ArcDpsComponentHelperClass infoItem;

    internal FormArcPluginInfo(ArcDpsComponentHelperClass infoItem)
    {
        this.infoItem = infoItem;
        InitializeComponent();
        Icon = Resources.AppIcon;
        Text = infoItem.FullName;
        labelPluginInfo.Text = $"{infoItem.Description}\n\nAuthor(s): {infoItem.Author}\nLicense: {infoItem.License}\nProvided from: {infoItem.Provider}\nLocally stored as: {infoItem.DefaultFileName}";
        linkLabelPluginLink.Text = infoItem.LinkName;
    }

    private void LinkLabelPluginLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start(new ProcessStartInfo { UseShellExecute = true, FileName = infoItem.LinkUrl });
}
