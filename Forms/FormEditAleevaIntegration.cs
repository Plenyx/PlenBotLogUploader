using Newtonsoft.Json;
using PlenBotLogUploader.Aleeva;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.Teams;
using PlenBotLogUploader.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormEditAleevaIntegration : Form
    {
        #region definitions
        // fields
        private readonly bool emptyInput;
        private readonly FormMain mainLink;
        private readonly FormAleevaIntegrations aleevaLink;
        private readonly AleevaIntegration data;
        private readonly HttpClientController controller;
        private readonly List<AleevaServer> aleevaServers = new();
        private readonly List<AleevaChannel> aleevaServerChannels = new();
        #endregion

        internal FormEditAleevaIntegration(FormMain mainLink, FormAleevaIntegrations aleevaLink, HttpClientController controller, AleevaIntegration data)
        {
            this.mainLink = mainLink;
            this.aleevaLink = aleevaLink;
            this.controller = controller;
            InitializeComponent();
            Icon = Properties.Resources.aleeva_icon;
            Text = (data is null) ? "Add a new Aleeva integration" : "Edit an existing Aleeva integration";
            textBoxName.Text = data?.Name;
            checkBoxSendNotification.Checked = data?.SendNotification ?? false;
            checkBoxOnlySuccessful.Checked = data?.SendOnSuccessOnly ?? false;
            comboBoxServer.Text = data?.Server;
            comboBoxChannel.Text = data?.Channel;
            if (data is not null)
            {
                _ = AleevaLoadServers();
            }
            textBoxName.TextChanged += TextBoxName_TextChanged;
            checkBoxSendNotification.CheckedChanged += CheckBoxSendNotification_CheckedChanged;
            checkBoxOnlySuccessful.CheckedChanged += CheckBoxOnlySuccessful_CheckedChanged;
            comboBoxServer.SelectedIndexChanged += ComboBoxServer_SelectedIndexChanged;
            comboBoxChannel.SelectedIndexChanged += ComboBoxChannel_SelectedIndexChanged;
            emptyInput = data is null;
            this.data = data ?? new AleevaIntegration();
            ApplicationSettings.Current.Aleeva.AuthorisedChanged += OnAuthoriseResult;
        }

        internal void OnAuthoriseResult(object sender, EventArgs e)
        {
            var toggle = ApplicationSettings.Current.Aleeva.Authorised;
            groupBoxName.Enabled = toggle;
            groupBoxServer.Enabled = toggle;
            groupBoxChannel.Enabled = toggle;
            groupBoxUploadSettings.Enabled = toggle;
        }

        private void FormAleeva_FormClosing(object sender, FormClosingEventArgs e)
        {
            ApplicationSettings.Current.Aleeva.AuthorisedChanged -= OnAuthoriseResult;
            if (emptyInput)
            {
                AleevaIntegrations.All.Add(data);
            }
            aleevaLink.RedrawAleevaIntegrations();
        }

        private async Task AleevaLoadServers()
        {
            if (ApplicationSettings.Current.Aleeva.AccessTokenExpire <= DateTime.Now)
            {
                await AleevaStatics.GetAleevaTokenFromRefreshToken(mainLink, controller);
            }
            try
            {
                aleevaServers.Clear();
                if (comboBoxServer.InvokeRequired)
                {
                    comboBoxServer.Invoke(comboBoxServer.Items.Clear);
                }
                else
                {
                    comboBoxServer.Items.Clear();
                }
                aleevaServerChannels.Clear();
                if (comboBoxChannel.InvokeRequired)
                {
                    comboBoxChannel.Invoke(comboBoxChannel.Items.Clear);
                }
                else
                {
                    comboBoxChannel.Items.Clear();
                }
                var uri = new Uri($"{AleevaStatics.ApiBaseUrl}/server?mode=UPLOADS");
                using var response = await controller.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var responseMessage = await response.Content.ReadAsStringAsync();
                    var servers = JsonConvert.DeserializeObject<List<AleevaServer>>(responseMessage);
                    aleevaServers.AddRange(servers);
                }
                AddServersToView();
                comboBoxServer.Text = (!string.IsNullOrWhiteSpace(data.Server) ? aleevaServers.Find(x => x.ID.Equals(data.Server))?.ToString() : "");
                if (!string.IsNullOrWhiteSpace(data.Server))
                {
                    await AleevaLoadChannels(data.Server);
                }
            }
            catch (Exception e)
            {
                mainLink.AddToText(e.Message);
            }
        }

        private async void ComboBoxServer_DropDown(object sender, EventArgs e) => await AleevaLoadServers();

        private async void ComboBoxServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxServer.SelectedItem is not AleevaServer server)
            {
                return;
            }
            data.Server = server.ID;
            await AleevaLoadChannels(server.ID);
        }

        private async Task AleevaLoadChannels(string serverId)
        {
            if (ApplicationSettings.Current.Aleeva.AccessTokenExpire <= DateTime.Now)
            {
                await AleevaStatics.GetAleevaTokenFromRefreshToken(mainLink, controller);
            }
            try
            {
                aleevaServerChannels.Clear();
                if (comboBoxChannel.InvokeRequired)
                {
                    comboBoxChannel.Invoke(comboBoxChannel.Items.Clear);
                }
                else
                {
                    comboBoxChannel.Items.Clear();
                }
                var uri = new Uri($"{AleevaStatics.ApiBaseUrl}/server/{serverId}/channel?mode=UPLOADS");
                using var response = await controller.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var responseMessage = await response.Content.ReadAsStringAsync();
                    var channels = JsonConvert.DeserializeObject<List<AleevaChannel>>(responseMessage);
                    aleevaServerChannels.AddRange(channels);
                }
                AddChannelsToView();
                comboBoxChannel.Text = (!string.IsNullOrWhiteSpace(data.Channel) ? aleevaServerChannels.Find(x => x.ID.Equals(data.Channel))?.ToString() : "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxChannel.SelectedItem is not AleevaChannel channel)
            {
                return;
            }
            data.Channel = channel.ID;
        }

        private void CheckBoxSendNotification_CheckedChanged(object sender, EventArgs e)
        {
            data.SendNotification = checkBoxSendNotification.Checked;
        }

        private void CheckBoxOnlySuccessful_CheckedChanged(object sender, EventArgs e)
        {
            data.SendOnSuccessOnly = checkBoxOnlySuccessful.Checked;
        }

        private void FormAleeva_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Process.Start(new ProcessStartInfo() { UseShellExecute = true, FileName = AleevaStatics.Url });
        }

        private void FormAleeva_Shown(object sender, EventArgs e)
        {
            comboBoxSelectedTeam.Items.Clear();
            var teams = Teams.Teams.All;
            foreach (var team in teams.Values)
            {
                comboBoxSelectedTeam.Items.Add(team);
            }
            comboBoxSelectedTeam.SelectedItem = data.Team ?? teams[0];
        }

        private void ComboBoxSelectedTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            data.Team = (comboBoxSelectedTeam.SelectedItem as Team) ?? Teams.Teams.All[0];
        }

        private void AddServersToView()
        {
            foreach (var server in aleevaServers.AsSpan())
            {
                comboBoxServer.Items.Add(server);
            }
        }

        private void AddChannelsToView()
        {
            comboBoxChannel.Text = "";
            comboBoxChannel.Items.Clear();
            foreach (var channel in aleevaServerChannels.AsSpan())
            {
                comboBoxChannel.Items.Add(channel);
            }
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            data.Name = textBoxName.Text;
        }
    }
}
