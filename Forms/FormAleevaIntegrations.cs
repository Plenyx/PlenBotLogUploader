using PlenBotLogUploader.Aleeva;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.DpsReport;
using PlenBotLogUploader.Tools;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormAleevaIntegrations : Form
    {
        #region definitions
        // fields
        private readonly HttpClientController controller = new();
        private readonly FormMain mainLink;
        #endregion

        internal FormAleevaIntegrations(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.aleeva_icon;
            ApplicationSettings.Current.Aleeva.AuthorisedChanged += OnAuthoriseResult;
            AleevaIntegrations.LoadAleevaIntegrations();
            RedrawAleevaIntegrations();
        }

        private void FormAleevaIntegrations_FormClosing(object sender, FormClosingEventArgs e)
        {
            AleevaIntegrations.SaveToJson(AleevaIntegrations.All);
            e.Cancel = true;
            Hide();
        }

        internal async Task GetAleevaTokenFromRefreshToken()
        {
            await AleevaStatics.GetAleevaTokenFromRefreshToken(mainLink, controller);
        }

        internal void OnAuthoriseResult(object sender, EventArgs e)
        {
            var toggle = ApplicationSettings.Current.Aleeva.Authorised;
            groupBoxAleevaStatus.Enabled = toggle;
            if (groupBoxAleevaStatus.InvokeRequired)
            {
                groupBoxAleevaStatus.Invoke((Action)(() => groupBoxAleevaStatus.Text = (toggle) ? "Status: Aleeva successfully authorised" : "Status: Not authorised"));
            }
            else
            {
                groupBoxAleevaStatus.Text = (toggle) ? "Status: Aleeva successfully authorised" : "Status: Not authorised";
            }
            if (buttonGetBearerFromAccess.InvokeRequired)
            {
                buttonGetBearerFromAccess.Invoke((Action)(() => buttonGetBearerFromAccess.Text = (toggle) ? "Deauthorise" : "Authorise"));
            }
            else
            {
                buttonGetBearerFromAccess.Text = (toggle) ? "Deauthorise" : "Authorise";
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

        private async void ButtonGetBearerFromAccess_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(ApplicationSettings.Current.Aleeva.AccessToken))
            {
                await AleevaStatics.GetAleevaTokenFromAccessCode(mainLink, controller, textBoxAccessCode.Text);
                return;
            }
            DeauthoriseAleeva();
        }

        private void DeauthoriseAleeva()
        {
            if (InvokeRequired)
            {
                Invoke(DeauthoriseAleeva);
                return;
            }
            ApplicationSettings.Current.Aleeva.AccessToken = "";
            ApplicationSettings.Current.Aleeva.AccessTokenExpire = DateTime.Now;
            ApplicationSettings.Current.Aleeva.Authorised = false;
            ApplicationSettings.Current.Aleeva.RefreshToken = "";
            ApplicationSettings.Current.Aleeva.RefreshTokenExpire = DateTime.Now;
            ApplicationSettings.Current.Save();
        }

        internal void RedrawAleevaIntegrations()
        {
            if (InvokeRequired)
            {
                Invoke(RedrawAleevaIntegrations);
                return;
            }
            listViewAleevaIntegrations.Items.Clear();
            foreach (var integration in AleevaIntegrations.All.AsSpan())
            {
                listViewAleevaIntegrations.Items.Add(new ListViewItemCustom<AleevaIntegration>() { Item = integration });
            }
        }

        internal async Task ExecuteAllActiveAleevaIntegrations(DpsReportJson reportJson)
        {
            if (!ApplicationSettings.Current.Aleeva.Authorised)
            {
                return;
            }
            foreach (var integration in AleevaIntegrations.All)
            {
                if (!integration.Active || !(integration.Team?.IsSatisfied(reportJson.ExtraJson) ?? false))
                {
                    continue;
                }
                await integration.PostLogToAleeva(mainLink, controller, reportJson);
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

        private void ContextMenuStripInteract_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var toggle = listViewAleevaIntegrations.SelectedItems.Count > 0;
            toolStripMenuItemEdit.Enabled = toggle;
            toolStripMenuItemDelete.Enabled = toggle;
        }
    }
}
