using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlenBotLogUploader.Aleeva;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.DPSReport;
using PlenBotLogUploader.Teams;
using PlenBotLogUploader.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormAleeva : Form
    {
        #region definitions
        // properties
        internal string AleevaAccessToken { get; set; }
        internal DateTime AleevaAccessTokenExpires { get; set; }
        internal bool AleevaAuthorised
        {
            get => _authorised;
            set
            {
                _authorised = value;
                groupBoxServer.Enabled = value;
                groupBoxChannel.Enabled = value;
                groupBoxUploadSettings.Enabled = value;
                if (groupBoxAleevaStatus.InvokeRequired)
                {
                    groupBoxAleevaStatus.Invoke((Action)(() => groupBoxAleevaStatus.Text = (value) ? "Status: Aleeva successfully authorised" : "Status: Not authorised"));
                }
                else
                {
                    groupBoxAleevaStatus.Text = (value) ? "Status: Aleeva successfully authorised" : "Status: Not authorised";
                }
                if (buttonGetBearerFromAccess.InvokeRequired)
                {
                    buttonGetBearerFromAccess.Invoke((Action)(() => buttonGetBearerFromAccess.Text = (value) ? "Deauthorise" : "Authorise"));
                }
                else
                {
                    buttonGetBearerFromAccess.Text = (value) ? "Deauthorise" : "Authorise";
                }
                if (textBoxAccessCode.InvokeRequired)
                {
                    textBoxAccessCode.Invoke((Action)(() => textBoxAccessCode.Enabled = !value));
                }
                else
                {
                    textBoxAccessCode.Enabled = !value;
                }
            }
        }

        // fields
        private readonly FormMain mainLink;
        private bool _authorised = false;
        private const string aleevaAPIBaseUrl = "https://api.aleeva.io";
        private const string aleevaUrl = "https://www.aleeva.io/";
        private readonly HttpClientController controller = new();
        private readonly List<AleevaServer> aleevaServers = new();
        private readonly List<AleevaChannel> aleevaServerChannels = new();
        #endregion

        internal FormAleeva(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.aleeva_icon;
            checkBoxSendNotification.Checked = ApplicationSettings.Current.Aleeva.SendNotification;
            checkBoxOnlySuccessful.Checked = ApplicationSettings.Current.Aleeva.SendOnSuccessOnly;
        }

        private void FormAleeva_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void FormAleeva_FormClosed(object sender, FormClosedEventArgs e) => controller.Dispose();

        internal async Task PostLogToAleeva(DPSReportJSON reportJSON)
        {
            if (AleevaAuthorised)
            {
                if (AleevaAccessTokenExpires <= DateTime.Now)
                {
                    await GetAleevaTokenFromRefreshToken();
                }
                if ((checkBoxOnlySuccessful.Checked && !(reportJSON.Encounter.Success ?? false)) ||
                    ((ApplicationSettings.Current.Aleeva.SelectedTeamId > 0) &&
                        Teams.Teams.All.ContainsKey(ApplicationSettings.Current.Aleeva.SelectedTeamId) &&
                        !Teams.Teams.All[ApplicationSettings.Current.Aleeva.SelectedTeamId].IsSatisfied(reportJSON.ExtraJSON)))
                {
                    return;
                }
                try
                {
                    var uri = new Uri($"{aleevaAPIBaseUrl}/report");
                    var logObject = new AleevaAddReport() { DPSReportPermalink = reportJSON.ConfigAwarePermalink, SendNotification = checkBoxSendNotification.Checked };
                    if (checkBoxSendNotification.Checked)
                    {
                        logObject.NotificationServerId = ApplicationSettings.Current.Aleeva.SelectedServer;
                        logObject.NotificationChannelId = ApplicationSettings.Current.Aleeva.SelectedChannel;
                    }
                    var jsonLogObject = JsonConvert.SerializeObject(logObject);
                    using var content = new StringContent(jsonLogObject, Encoding.UTF8, "application/json");
                    await controller.PostAsync(uri, content);
                }
                catch
                {
                    // do nothing
                }
            }
        }

        internal async Task GetAleevaTokenFromAccessCode(string access_code)
        {
            var aleeva = new AleevaAuthToken() { AccessCode = access_code, GrantType = "access_code" };
            var uri = new Uri($"{aleevaAPIBaseUrl}/auth/token");
            var aleevaKeyValues = new List<KeyValuePair<string, string>>
            {
                new ("grant_type", aleeva.GrantType),
                new ("client_id", aleeva.ClientId),
                new ("client_secret", aleeva.ClientSecret),
                new ("access_code", aleeva.AccessCode),
                new ("scopes", "report:write server:read channel:read")
            };
            try
            {
                using var content = new FormUrlEncodedContent(aleevaKeyValues);
                using var response = await mainLink.HttpClientController.PostAsync(uri, content);
                var responseMessage = await response.Content.ReadAsStringAsync();
                var responseToken = JsonConvert.DeserializeObject<AleevaAuthTokenResponse>(responseMessage);
                AleevaAuthorised = responseToken.IsSuccess;
                if (responseToken.IsSuccess)
                {
                    AleevaAccessToken = responseToken.AccessToken;
                    controller.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AleevaAccessToken);
                    AleevaAccessTokenExpires = DateTime.Now.AddSeconds(responseToken.ExpiresIn);
                    ApplicationSettings.Current.Aleeva.RefreshToken = responseToken.RefreshToken;
                    ApplicationSettings.Current.Aleeva.RefreshTokenExpire = DateTime.Now.AddSeconds(responseToken.RefreshExpiresIn);
                    ApplicationSettings.Current.Save();
                }
                else
                {
                    AleevaAccessToken = string.Empty;
                    controller.DefaultRequestHeaders.Authorization = null;
                    AleevaAccessTokenExpires = DateTime.Now;
                    ApplicationSettings.Current.Aleeva.RefreshToken = string.Empty;
                    ApplicationSettings.Current.Aleeva.RefreshTokenExpire = DateTime.Now;
                    ApplicationSettings.Current.Save();
                }
            }
            catch (JsonReaderException)
            {
                mainLink.AddToText("??>> There was an error authenticating with Aleeva while trying to exchange the access code. Is your access code correct? Make sure you select the PlenBotLogUploader when creating the access code.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "An error has occured.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal async Task GetAleevaTokenFromRefreshToken()
        {
            var aleeva = new AleevaAuthToken()
            {
                RefreshToken = ApplicationSettings.Current.Aleeva.RefreshToken,
                GrantType = "refresh_token"
            };
            var uri = new Uri($"{aleevaAPIBaseUrl}/auth/token");
            var aleevaKeyValues = new List<KeyValuePair<string, string>>
            {
                new ("grant_type", aleeva.GrantType),
                new ("client_id", aleeva.ClientId),
                new ("client_secret", aleeva.ClientSecret),
                new ("refresh_token", aleeva.RefreshToken),
                new ("scopes", "report:write server:read channel:read")
            };
            try
            {
                using var content = new FormUrlEncodedContent(aleevaKeyValues);
                using var response = await mainLink.HttpClientController.PostAsync(uri, content);
                var responseMessage = await response.Content.ReadAsStringAsync();
                var responseToken = JsonConvert.DeserializeObject<AleevaAuthTokenResponse>(responseMessage);
                AleevaAuthorised = responseToken.IsSuccess;
                if (responseToken.IsSuccess)
                {
                    AleevaAccessToken = responseToken.AccessToken;
                    controller.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AleevaAccessToken);
                    AleevaAccessTokenExpires = DateTime.Now.AddSeconds(responseToken.ExpiresIn);
                    ApplicationSettings.Current.Aleeva.RefreshToken = responseToken.RefreshToken;
                    ApplicationSettings.Current.Aleeva.RefreshTokenExpire = DateTime.Now.AddSeconds(responseToken.RefreshExpiresIn);
                    ApplicationSettings.Current.Save();
                    await AleevaLoadServers();
                    var selectedServer = aleevaServers.Find(x => x.ID.Equals(ApplicationSettings.Current.Aleeva.SelectedServer));
                    if (selectedServer is not null)
                    {
                        comboBoxServer.SelectedItem = selectedServer;
                        await AleevaLoadChannels(selectedServer.ID);
                        var selectedChannel = aleevaServerChannels.First(x => x.ID.Equals(ApplicationSettings.Current.Aleeva.SelectedChannel));
                        if (selectedChannel is not null)
                        {
                            comboBoxChannel.SelectedItem = selectedChannel;
                        }
                    }
                }
            }
            catch (JsonReaderException)
            {
                mainLink.AddToText("??>> There was an error authenticating with Aleeva while trying to refresh refresh token.");
            }
            catch (Exception e)
            {
                mainLink.AddToText(e.Message);
            }
        }

        private async void ButtonGetBearerFromAccess_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AleevaAccessToken))
            {
                await GetAleevaTokenFromAccessCode(textBoxAccessCode.Text);
            }
            else
            {
                DeauthoriseAleeva();
            }
        }

        private void DeauthoriseAleeva()
        {
            if (InvokeRequired)
            {
                Invoke(() => DeauthoriseAleeva());
                return;
            }
            AleevaAccessToken = string.Empty;
            AleevaAccessTokenExpires = DateTime.Now;
            AleevaAuthorised = false;
            ApplicationSettings.Current.Aleeva.RefreshToken = string.Empty;
            ApplicationSettings.Current.Aleeva.RefreshTokenExpire = DateTime.Now;
            ApplicationSettings.Current.Save();
        }

        private async Task AleevaLoadServers()
        {
            if (AleevaAccessTokenExpires <= DateTime.Now)
            {
                await GetAleevaTokenFromRefreshToken();
            }
            try
            {
                aleevaServers.Clear();
                if (comboBoxServer.InvokeRequired)
                {
                    comboBoxServer.Invoke(() => comboBoxServer.Items.Clear());
                }
                else
                {
                    comboBoxServer.Items.Clear();
                }
                aleevaServerChannels.Clear();
                if (comboBoxChannel.InvokeRequired)
                {
                    comboBoxChannel.Invoke(() => comboBoxChannel.Items.Clear());
                }
                else
                {
                    comboBoxChannel.Items.Clear();
                }
                var uri = new Uri($"{aleevaAPIBaseUrl}/server?mode=UPLOADS");
                using var response = await controller.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var responseMessage = await response.Content.ReadAsStringAsync();
                    foreach (var token in JArray.Parse(responseMessage))
                    {
                        var server = token.ToObject<AleevaServer>();
                        aleevaServers.Add(server);
                    }
                }
                AddServersToView();
            }
            catch (Exception e)
            {
                mainLink.AddToText(e.Message);
            }
        }


        private async void ComboBoxServer_DropDown(object sender, EventArgs e) => await AleevaLoadServers();

        private async void ComboBoxServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxServer.SelectedItem is AleevaServer server)
            {
                ApplicationSettings.Current.Aleeva.SelectedServer = server.ID;
                ApplicationSettings.Current.Save();
                await AleevaLoadChannels(server.ID);
            }
        }

        private async Task AleevaLoadChannels(string serverId)
        {
            if (AleevaAccessTokenExpires <= DateTime.Now)
            {
                await GetAleevaTokenFromRefreshToken();
            }
            try
            {
                aleevaServerChannels.Clear();
                if (comboBoxChannel.InvokeRequired)
                {
                    comboBoxChannel.Invoke(() => comboBoxChannel.Items.Clear());
                }
                else
                {
                    comboBoxChannel.Items.Clear();
                }
                var uri = new Uri($"{aleevaAPIBaseUrl}/server/{serverId}/channel?mode=UPLOADS");
                using var response = await controller.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var responseMessage = await response.Content.ReadAsStringAsync();
                    foreach (var token in JArray.Parse(responseMessage))
                    {
                        var channel = token.ToObject<AleevaChannel>();
                        aleevaServerChannels.Add(channel);
                    }
                }
                AddServersToView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxChannel.SelectedItem is AleevaChannel channel)
            {
                ApplicationSettings.Current.Aleeva.SelectedChannel = channel.ID;
                ApplicationSettings.Current.Save();
            }
        }

        private void CheckBoxSendNotification_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Aleeva.SendNotification = checkBoxSendNotification.Checked;
            ApplicationSettings.Current.Save();
        }

        private void CheckBoxOnlySuccessful_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Aleeva.SendOnSuccessOnly = checkBoxOnlySuccessful.Checked;
            ApplicationSettings.Current.Save();
        }

        private void FormAleeva_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Process.Start(new ProcessStartInfo() { UseShellExecute = true, FileName = aleevaUrl });
        }

        private void FormAleeva_Shown(object sender, EventArgs e)
        {
            comboBoxSelectedTeam.Items.Clear();
            var teams = Teams.Teams.All;
            foreach (var team in teams.Values)
            {
                comboBoxSelectedTeam.Items.Add(team);
            }
            comboBoxSelectedTeam.SelectedItem = (ApplicationSettings.Current.Aleeva.SelectedTeamId > 0) ? teams[ApplicationSettings.Current.Aleeva.SelectedTeamId] : teams[0];
        }

        private void ComboBoxSelectedTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Aleeva.SelectedTeamId = (comboBoxSelectedTeam.SelectedItem as Team)?.ID ?? 0;
            ApplicationSettings.Current.Save();
        }

        private void AddServersToView()
        {
            foreach (var server in aleevaServers.AsSpan())
            {
                comboBoxServer.Items.Add(server);
            }
        }
    }
}
