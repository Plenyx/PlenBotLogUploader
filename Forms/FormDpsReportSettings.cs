using PlenBotLogUploader.AppSettings;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormDpsReportSettings : Form
    {
        #region definitions
        // fields
        private readonly FormMain mainLink;
        #endregion

        internal FormDpsReportSettings(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            if (ApplicationSettings.Current.Upload.DpsReportUserTokens.Count(x => x.Active) > 1)
            {
                foreach (var userToken in ApplicationSettings.Current.Upload.DpsReportUserTokens)
                {
                    userToken.Active = false;
                }
                ApplicationSettings.Current.Save();
            }
            RedrawList();
        }

        private void FormDPSReportSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            if (radioButtonB.Checked)
            {
                ApplicationSettings.Current.Upload.DpsReportServer = DpsReportServer.B;
            }
            else if (radioButtonA.Checked)
            {
                ApplicationSettings.Current.Upload.DpsReportServer = DpsReportServer.A;
            }
            else
            {
                ApplicationSettings.Current.Upload.DpsReportServer = DpsReportServer.Main;
            }
            ApplicationSettings.Current.Save();
        }

        internal void RedrawList()
        {
            checkedListBoxUserTokens.ItemCheck -= CheckedListBoxUserTokens_ItemCheck;
            checkedListBoxUserTokens.Items.Clear();
            foreach (var userToken in ApplicationSettings.Current.Upload.DpsReportUserTokens.OrderBy(x => x.Name).ToArray())
            {
                checkedListBoxUserTokens.Items.Add(userToken, userToken.Active);
            }
            checkedListBoxUserTokens.ItemCheck += CheckedListBoxUserTokens_ItemCheck;
            mainLink.RedrawUserTokenContext();
        }

        private void CheckedListBoxUserTokens_DoubleClick(object sender, EventArgs e)
        {
            checkedListBoxUserTokens.SelectedItem = null;
        }

        private void ButtonAddUserToken_Click(object sender, EventArgs e) => (new FormEditDpsReportUserToken(this, mainLink.HttpClientController)).ShowDialog();

        private void ToolStripMenuItemAddUserToken_Click(object sender, EventArgs e) => (new FormEditDpsReportUserToken(this, mainLink.HttpClientController)).ShowDialog();

        private void ToolStripMenuItemEditUserToken_Click(object sender, EventArgs e) => (new FormEditDpsReportUserToken(this, mainLink.HttpClientController, (ApplicationSettingsUploadUserToken)checkedListBoxUserTokens.SelectedItem)).ShowDialog();

        private void ToolStripMenuItemDeleteUserToken_Click(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Upload.DpsReportUserTokens.Remove((ApplicationSettingsUploadUserToken)checkedListBoxUserTokens.SelectedItem);
            ApplicationSettings.Current.Save();
            RedrawList();
        }

        private void ContextMenuStripUserTokens_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var toggle = checkedListBoxUserTokens.SelectedItem is not null;
            toolStripMenuItemEditUserToken.Enabled = toggle;
            toolStripMenuItemDeleteUserToken.Enabled = toggle;
        }

        private void CheckedListBoxUserTokens_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var checkedItems = checkedListBoxUserTokens.CheckedItems;
            if (checkedItems.Count > 0)
            {
                foreach (var checkedItem in checkedItems)
                {
                    ((ApplicationSettingsUploadUserToken)checkedItem).Active = false;
                }
            }
            ((ApplicationSettingsUploadUserToken)checkedListBoxUserTokens.Items[e.Index]).Active = true;
            ApplicationSettings.Current.Save();
            RedrawList();
        }
    }
}
