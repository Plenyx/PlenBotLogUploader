using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using PlenBotLogUploader.GW2Raidar;

namespace PlenBotLogUploader
{
    public partial class FormRaidar : Form
    {
        // fields
        private FormMain mainLink;

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
            mainLink.RegistryAccess.SetValue("raidarEnabled", checkBoxEnableRaidar.Checked ? 1 : 0);
            mainLink.RegistryAccess.SetValue("raidarTags", textBoxTags.Text);
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
                            mainLink.RegistryAccess.SetValue("raidarOAuth", responseJSON.Token);
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
            mainLink.RegistryAccess.SetValue("raidarOAuth", "");
            checkBoxEnableRaidar.Checked = false;
            groupBoxCredentials.Enabled = true;
            groupBoxSettings.Enabled = false;
        }
    }
}
