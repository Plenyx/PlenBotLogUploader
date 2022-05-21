using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using System;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormDPSReportSettings : Form
    {
        #region definitions
        // fields
        private readonly FormMain mainLink;
        #endregion

        public FormDPSReportSettings(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
        }

        private void FormDPSReportSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            if (radioButtonB.Checked)
            {
                ApplicationSettings.Current.Upload.DPSReportServer = DPSReportServer.B;
            }
            else if (radioButtonA.Checked)
            {
                ApplicationSettings.Current.Upload.DPSReportServer = DPSReportServer.A;
            }
            else
            {
                ApplicationSettings.Current.Upload.DPSReportServer = DPSReportServer.Main;
            }
            ApplicationSettings.Current.Upload.DPSReportUsertokenEnabled = checkBoxDPSReportEnableUsertoken.Checked;
            ApplicationSettings.Current.Upload.DPSReportUsertoken = textBoxDPSReportUsertoken.Text;
            ApplicationSettings.Current.Save();
        }

        private void CheckBoxDPSReportEnableUsertoken_CheckedChanged(object sender, EventArgs e)
        {
            var enable = checkBoxDPSReportEnableUsertoken.Checked;
            textBoxDPSReportUsertoken.Enabled = enable;
            buttonDPSReportShowUsertoken.Enabled = enable;
        }

        private async void ButtonDPSReportGetToken_Click(object sender, EventArgs e)
        {
            try
            {
                var uri = new Uri("https://dps.report/getUserToken");
                using var responseMessage = await mainLink.HttpClientController.GetAsync(uri);
                var response = await responseMessage.Content.ReadAsStringAsync();
                var anonObject = new { userToken = string.Empty };
                var responseJson = JsonConvert.DeserializeAnonymousType(response, anonObject);
                textBoxDPSReportUsertoken.Text = responseJson.userToken;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error has occured while getting the user token from dps.report API.\n{ex.Message}", "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonDPSReportShowUsertoken_Click(object sender, EventArgs e)
        {
            textBoxDPSReportUsertoken.UseSystemPasswordChar = !textBoxDPSReportUsertoken.UseSystemPasswordChar;
            buttonDPSReportShowUsertoken.Text = (textBoxDPSReportUsertoken.UseSystemPasswordChar) ? "Show token" : "Hide token";
        }
    }
}
