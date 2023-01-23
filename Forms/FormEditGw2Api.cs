using Hardstuck.Http;
using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.Gw2Api;
using System;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormEditGw2Api : Form
    {
        #region definitions
        private readonly HttpClientController httpClientController = new();
        private ApplicationSettingsGw2Api data = null;
        private readonly FormGw2Api gw2apiLink;
        #endregion

        internal FormEditGw2Api(FormGw2Api gw2apiLink, ApplicationSettingsGw2Api data)
        {
            this.gw2apiLink = gw2apiLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            Text = (data is null) ? "Add a new API key" : "Edit an existing API key";
            if (data is not null)
            {
                this.data = data;
                textBoxAPIKeyName.Text = data.Name;
                textBoxAPIKeyKey.Text = data.ApiKey;
                labelIsTokenValid.Text = "Verifying the token...";
            }
        }

        private async void FormEditGW2API_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxAPIKeyName.Text))
            {
                if (data is not null)
                {
                    ApplicationSettings.Current.Gw2Apis.Remove(data);
                    ApplicationSettings.Current.Save();
                    gw2apiLink.RedrawList();
                }
                httpClientController.Dispose();
                return;
            }
            if (data is null)
            {
                data = new ApplicationSettingsGw2Api() { Name = textBoxAPIKeyName.Text, ApiKey = textBoxAPIKeyKey.Text };
                ApplicationSettings.Current.Gw2Apis.Add(data);
                ApplicationSettings.Current.Save();
            }
            else
            {
                data.Name = textBoxAPIKeyName.Text;
                data.ApiKey = textBoxAPIKeyKey.Text;
                ApplicationSettings.Current.Save();
            }
            await data.ValidateToken(httpClientController);
            gw2apiLink.RedrawList();
            httpClientController.Dispose();
        }

        private async void ButtonGetNameFromKey_Click(object sender, EventArgs e)
        {
            using var response = await httpClientController.GetAsync($"https://api.guildwars2.com/v2/tokeninfo?access_token={textBoxAPIKeyKey.Text}");
            if (!response.IsSuccessStatusCode)
            {
                return;
            }
            var responseMessage = await response.Content.ReadAsStringAsync();
            var tokenInfo = JsonConvert.DeserializeObject<Gw2TokenInfo>(responseMessage);
            textBoxAPIKeyName.Text = tokenInfo.Name;
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
