using Hardstuck.Http;
using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.Tools;
using System;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormEditDpsReportUserToken : Form
    {
        #region definitions
        // fields
        private readonly FormDpsReportSettings settingsLink;
        private readonly HttpClientController httpClientController;
        private ApplicationSettingsUploadUserToken data;

        // constants
        private const string dpsReportUserTokenURL = "https://dps.report/getUserToken";
        #endregion

        internal FormEditDpsReportUserToken(FormDpsReportSettings settingsLink, HttpClientController httpClientController, ApplicationSettingsUploadUserToken data = null)
        {
            this.settingsLink = settingsLink;
            this.httpClientController = httpClientController;
            this.data = data;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            Text = (data is null) ? "Add a new user token" : "Edit user token";
            if (data is not null)
            {
                textBoxName.Text = data.Name;
                textBoxUserToken.Text = data.UserToken;
            }
        }

        private void FormEditDPSReportUserToken_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                if (data is not null)
                {
                    ApplicationSettings.Current.Upload.DpsReportUserTokens.Remove(data);
                    ApplicationSettings.Current.Save();
                }
                settingsLink.RedrawList();
                return;
            }
            if (data is null)
            {
                data = new ApplicationSettingsUploadUserToken() { Active = false, Name = textBoxName.Text, UserToken = textBoxUserToken.Text };
                ApplicationSettings.Current.Upload.DpsReportUserTokens.Add(data);
            }
            else
            {
                data.Name = textBoxName.Text;
                data.UserToken = textBoxUserToken.Text;
            }
            ApplicationSettings.Current.Save();
            settingsLink.RedrawList();
        }

        private async void ButtonDPSReportGetToken_Click(object sender, EventArgs e)
        {
            buttonDPSReportGetToken.Enabled = false;
            try
            {
                using var responseMessage = await httpClientController.GetAsync(dpsReportUserTokenURL);
                var response = await responseMessage.Content.ReadAsStringAsync();
                var responseJson = JsonConvert.DeserializeObject<DpsReportUserTokenHelperClass>(response);
                textBoxUserToken.Text = responseJson.UserToken;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error has occured while getting the user token from dps.report API.\n{ex.Message}", "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            buttonDPSReportGetToken.Enabled = true;
        }
    }
}
