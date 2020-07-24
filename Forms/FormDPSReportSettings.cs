using System;
using System.Windows.Forms;
using Newtonsoft.Json;

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
                mainLink.DPSReportServer = "https://b.dps.report";
                Properties.Settings.Default.DPSReportServer = 2;
            }
            else if (radioButtonA.Checked)
            {
                mainLink.DPSReportServer = "http://a.dps.report";
                Properties.Settings.Default.DPSReportServer = 1;
            }
            else
            {
                mainLink.DPSReportServer = "https://dps.report";
                Properties.Settings.Default.DPSReportServer = 0;
            }
            Properties.Settings.Default.DPSReportUsertokenEnabled = checkBoxDPSReportEnableUsertoken.Checked;
            Properties.Settings.Default.DPSReportUsertoken = textBoxDPSReportUsertoken.Text;
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
                using (var responseMessage = await mainLink.HttpClientController.GetAsync(uri))
                {
                    var response = await responseMessage.Content.ReadAsStringAsync();
                    var anonObject = new { userToken = "" };
                    var responseJson = JsonConvert.DeserializeAnonymousType(response, anonObject);
                    textBoxDPSReportUsertoken.Text = responseJson.userToken;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error has occured while getting the user token from dps.report API.\n{ex.Message}", "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonDPSReportShowUsertoken_Click(object sender, EventArgs e)
        {
            textBoxDPSReportUsertoken.UseSystemPasswordChar = !textBoxDPSReportUsertoken.UseSystemPasswordChar;
            if (textBoxDPSReportUsertoken.UseSystemPasswordChar)
            {
                buttonDPSReportShowUsertoken.Text = "Show token";
            }
            else
            {
                buttonDPSReportShowUsertoken.Text = "Hide token";
            }
        }
    }
}
