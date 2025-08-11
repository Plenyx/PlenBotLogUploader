using Hardstuck.Http;
using PlenBotLogUploader.Aleeva;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.DpsReport;
using PlenBotLogUploader.Properties;
using PlenBotLogUploader.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZLinq;

namespace PlenBotLogUploader;

public partial class FormAleevaIntegrations : Form
{
    // fields
    private readonly HttpClientController controller = new();
    private readonly FormMain mainLink;

    internal FormAleevaIntegrations(FormMain mainLink)
    {
        this.mainLink = mainLink;
        InitializeComponent();
        Icon = Resources.aleeva_icon;
        ApplicationSettings.Current.Aleeva.AuthorisedChanged += OnAuthoriseResult;
        textBoxAccessCode.Text = ApplicationSettings.Current.Aleeva.ApiKey;
        AleevaIntegrations.LoadAleevaIntegrations();
        RedrawAleevaIntegrations();
    }

    private void FormAleevaIntegrations_FormClosing(object sender, FormClosingEventArgs e)
    {
        AleevaIntegrations.SaveToJson(AleevaIntegrations.All);
        e.Cancel = true;
        Hide();
    }

    internal async Task VerifyAleevaApiKey()
    {
        buttonVerifyCode.Enabled = false;
        if (!ApplicationSettings.Current.Aleeva.Authorised)
        {
            string apiKey = string.IsNullOrEmpty(ApplicationSettings.Current.Aleeva.ApiKey) ? textBoxAccessCode.Text : ApplicationSettings.Current.Aleeva.ApiKey;
            await AleevaStatics.VerifyAleevaApiKey(mainLink, controller, apiKey);
        }
        else // deauthorise
        {
            ApplicationSettings.Current.Aleeva.Authorised = false;
            ApplicationSettings.Current.Aleeva.ApiKey = "";
            ApplicationSettings.Current.Save();
        }
        buttonVerifyCode.Enabled = true;
    }

    private void OnAuthoriseResult(object sender, EventArgs e)
    {
        var toggle = ApplicationSettings.Current.Aleeva.Authorised;
        groupBoxAleevaStatus.Enabled = toggle;
        listViewAleevaIntegrations.Enabled = toggle;
        if (groupBoxAleevaStatus.InvokeRequired)
        {
            groupBoxAleevaStatus.Invoke((Action)(() => groupBoxAleevaStatus.Text = toggle ? "Status: API key verified" : "Status: API key not verified"));
        }
        else
        {
            groupBoxAleevaStatus.Text = toggle ? "Status: API key verified" : "Status: API key not verified";
        }
        if (buttonVerifyCode.InvokeRequired)
        {
            buttonVerifyCode.Invoke((Action)(() => buttonVerifyCode.Text = toggle ? "Change key" : "Verify key"));
        }
        else
        {
            buttonVerifyCode.Text = toggle ? "Change key" : "Verify key";
        }
        if (textBoxAccessCode.InvokeRequired)
        {
            textBoxAccessCode.Invoke((Action)(() => textBoxAccessCode.Enabled = !toggle));
        }
        else
        {
            textBoxAccessCode.Enabled = !toggle;
        }
    }

    private async void ButtonVerifyCode_Click(object sender, EventArgs e)
    {
        await VerifyAleevaApiKey();
    }

    internal void RedrawAleevaIntegrations()
    {
        if (InvokeRequired)
        {
            Invoke(RedrawAleevaIntegrations);
            return;
        }
        listViewAleevaIntegrations.Items.Clear();
        foreach (var integration in AleevaIntegrations.All.AsValueEnumerable())
        {
            listViewAleevaIntegrations.Items.Add(new ListViewItemCustom<AleevaIntegration> { Item = integration });
        }
    }

    internal async Task ExecuteAllActiveAleevaIntegrations(DpsReportJson reportJson, List<LogPlayer> players)
    {
        if (!ApplicationSettings.Current.Aleeva.Authorised)
        {
            return;
        }
        foreach (var integration in AleevaIntegrations.All)
        {
            if (!integration.Active || !integration.Valid || !(integration.Team?.IsSatisfied(players) ?? false))
            {
                continue;
            }
            await integration.PostLogToAleeva(mainLink, controller, reportJson, players);
        }
        if (AleevaIntegrations.All.Count > 0)
        {
            mainLink.AddToText(">:> All active Aleeva integrations successfully executed.");
        }
    }

    private void ListViewAleevaIntegrations_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
        if (e.Item is not ListViewItemCustom<AleevaIntegration> itemIntegration)
        {
            return;
        }
        if (e.Item.Checked && !itemIntegration.Item.Valid)
        {
            e.Item.Checked = false;
            MessageBox.Show("For Aleeva integration to work you must set both a server and a channel.\nPlease edit the integration first to include both to be able to activate the integration.", "Unable to activate Aleeva integration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        itemIntegration.Item.Active = e.Item.Checked;
    }

    private void ButtonAddAleevaIntegration_Click(object sender, EventArgs e) => new FormEditAleevaIntegration(mainLink, this, controller, null).ShowDialog();

    private void ToolStripMenuItemAdd_Click(object sender, EventArgs e) => new FormEditAleevaIntegration(mainLink, this, controller, null).ShowDialog();

    private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
    {
        if (listViewAleevaIntegrations.SelectedItems.Count == 0 || listViewAleevaIntegrations.SelectedItems[0] is not ListViewItemCustom<AleevaIntegration> itemIntegration)
        {
            return;
        }
        new FormEditAleevaIntegration(mainLink, this, controller, itemIntegration.Item).ShowDialog();
    }

    private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
    {
        if (listViewAleevaIntegrations.SelectedItems.Count == 0 || listViewAleevaIntegrations.SelectedItems[0] is not ListViewItemCustom<AleevaIntegration> itemIntegration)
        {
            return;
        }
        AleevaIntegrations.All.Remove(itemIntegration.Item);
        RedrawAleevaIntegrations();
    }

    private void ContextMenuStripInteract_Opening(object sender, CancelEventArgs e)
    {
        var toggle = listViewAleevaIntegrations.SelectedItems.Count > 0;
        toolStripMenuItemEdit.Enabled = toggle;
        toolStripMenuItemDelete.Enabled = toggle;
    }
    private void FormAleevaIntegrations_HelpButtonClicked(object sender, CancelEventArgs e)
    {
        e.Cancel = true;
        Process.Start(new ProcessStartInfo
        {
            UseShellExecute = true,
            FileName = AleevaStatics.AleevaPlenBotHelpPage,
        });
    }
}
