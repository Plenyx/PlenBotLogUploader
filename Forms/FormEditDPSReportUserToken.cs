using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.Tools;
using System;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormEditDPSReportUserToken : Form
    {
        #region definitions
        private readonly FormDPSReportSettings settingsLink;
        private readonly HttpClientController httpClientController;
        private ApplicationSettingsUploadUserToken data;
        #endregion

        internal FormEditDPSReportUserToken(FormDPSReportSettings settingsLink, HttpClientController httpClientController, ApplicationSettingsUploadUserToken data = null)
        {
            this.settingsLink = settingsLink;
            this.httpClientController = httpClientController;
            this.data = data;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            Text = (data is null) ? "Add a new user token" : "Edit user token";
            if (!(data is null))
            {
                textBoxName.Text = data.Name;
                textBoxUserToken.Text = data.UserToken;
            }
        }

        private void FormEditDPSReportUserToken_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                if (!(data is null))
                {
                    ApplicationSettings.Current.Upload.DPSReportUserTokens.Remove(data);
                    ApplicationSettings.Current.Save();
                }
                settingsLink.RedrawList();
                return;
            }
            if (data is null)
            {
                data = new ApplicationSettingsUploadUserToken() { Active = false, Name = textBoxName.Text, UserToken = textBoxUserToken.Text };
                ApplicationSettings.Current.Upload.DPSReportUserTokens.Add(data);
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
                var uri = new Uri("https://dps.report/getUserToken");
                using var responseMessage = await httpClientController.GetAsync(uri);
                var response = await responseMessage.Content.ReadAsStringAsync();
                var responseJson = JsonConvert.DeserializeObject<DPSReportUserTokenHelperClass>(response);
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
