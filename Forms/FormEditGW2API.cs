using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.Tools;
using PlenBotLogUploader.GW2API;
using System;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormEditGW2API : Form
    {
        #region definitions
        private readonly HttpClientController httpClientController = new HttpClientController();
        private ApplicationSettingsGW2API data = null;
        private readonly FormGW2API gw2apiLink;
        #endregion

        internal FormEditGW2API(FormGW2API gw2apiLink, ApplicationSettingsGW2API data)
        {
            this.gw2apiLink = gw2apiLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            Text = (data is null) ? "Add a new API key" : $"Edit an existing API key";
            if (!(data is null))
            {
                this.data = data;
                textBoxAPIKeyName.Text = data.Name;
                textBoxAPIKeyKey.Text = data.APIKey;
                labelIsTokenValid.Text = "Verifying the token...";
            }
        }

        private async void FormEditGW2API_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxAPIKeyName.Text))
            {
                if (!(data is null))
                {
                    ApplicationSettings.Current.GW2APIs.Remove(data);
                    ApplicationSettings.Current.Save();
                    gw2apiLink.RedrawList();
                }
                httpClientController.Dispose();
                return;
            }
            if (data is null)
            {
                data = new ApplicationSettingsGW2API() { Name = textBoxAPIKeyName.Text, APIKey = textBoxAPIKeyKey.Text };
                ApplicationSettings.Current.GW2APIs.Add(data);
                ApplicationSettings.Current.Save();
            }
            else
            {
                data.Name = textBoxAPIKeyName.Text;
                data.APIKey = textBoxAPIKeyKey.Text;
                ApplicationSettings.Current.Save();
            }
            await data.ValidateToken(httpClientController);
            gw2apiLink.RedrawList();
            httpClientController.Dispose();
        }

        private async void ButtonGetNameFromKey_Click(object sender, EventArgs e)
        {
            using var response = await httpClientController.GetAsync($"https://api.guildwars2.com/v2/tokeninfo?access_token={textBoxAPIKeyKey.Text}");
            if (response.IsSuccessStatusCode)
            {
                var responseMessage = await response.Content.ReadAsStringAsync();
                var tokenInfo = JsonConvert.DeserializeObject<GW2APITokenInfo>(responseMessage);
                textBoxAPIKeyName.Text = tokenInfo.Name;
            }
        }

        private void TextBoxAPIKeyKey_TextChanged(object sender, EventArgs e)
        {
            if (timerCheckToken.Enabled)
            {
                timerCheckToken.Stop();
                timerCheckToken.Start();
                return;
            }
            timerCheckToken.Enabled = true;
            timerCheckToken.Start();
        }

        private async void TimerCheckToken_Tick(object sender, EventArgs e)
        {
            timerCheckToken.Stop();
            timerCheckToken.Enabled = false;
            using var response = await httpClientController.GetAsync($"https://api.guildwars2.com/v2/tokeninfo?access_token={textBoxAPIKeyKey.Text}");
            labelIsTokenValid.Text = (response.IsSuccessStatusCode) ? "Token is valid." : "Token is not valid.";
        }
    }
}
