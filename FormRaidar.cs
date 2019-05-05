using System;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using PlenBotLogUploader.GW2Raidar;

namespace PlenBotLogUploader
{
    public partial class FormRaidar : Form
    {
        #region definitions
        // fields
        private FormMain mainLink;
        #endregion

        public FormRaidar(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
        }

        private void FormRaidar_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            mainLink.SetRegistryValue("raidarEnabled", checkBoxEnableRaidar.Checked ? 1 : 0);
            mainLink.SetRegistryValue("raidarTags", textBoxTags.Text);
        }

        private async Task AuthoriseCredentials()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>
            {
                { "username", textBoxUsername.Text },
                { "password", textBoxPassword.Text }
            };
            using (FormUrlEncodedContent content = new FormUrlEncodedContent(fields))
            {
                try
                {
                    using (var responseMessage = await mainLink.MainHttpClient.PostAsync(new Uri("https://gw2raidar.com/api/v2/token"), content))
                    {
                        string response = await responseMessage.Content.ReadAsStringAsync();
                        GW2RaidarJSONAuth responseJSON = new JavaScriptSerializer().Deserialize<GW2RaidarJSONAuth>(response);
                        if ((responseJSON.Non_field_errors == null) || (responseJSON.Non_field_errors.Count() == 0))
                        {
                            mainLink.RaidarOAuth = responseJSON.Token;
                            mainLink.SetRegistryValue("raidarOAuth", responseJSON.Token);
                            textBoxUsername.Text = "";
                            textBoxPassword.Text = "";
                            groupBoxCredentials.Enabled = false;
                            groupBoxSettings.Enabled = true;
                        }
                        else if (responseJSON.Non_field_errors.Count() > 0)
                        {
                            MessageBox.Show(responseJSON.Non_field_errors[0], "An error authenticating with GW2Raidar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error processing Raidar response.", "An error authenticating with GW2Raidar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void buttonAuthenticate_Click(object sender, EventArgs e) => await AuthoriseCredentials();

        private void buttonRelog_Click(object sender, EventArgs e)
        {
            mainLink.RaidarOAuth = "";
            mainLink.SetRegistryValue("raidarOAuth", "");
            checkBoxEnableRaidar.Checked = false;
            groupBoxCredentials.Enabled = true;
            groupBoxSettings.Enabled = false;
        }

        public void checkBoxEnableRaidar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEnableRaidar.Checked)
            {
                MessageBox.Show("The uploader only uploads to Raidar. It is not waiting for the uploaded file to be fully processed.\nThis will cause the uploader to upload both to DPS.report and GW2Raidar.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
