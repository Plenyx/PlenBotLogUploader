using Hardstuck.Http;
using Newtonsoft.Json;
using PlenBotLogUploader.Aleeva;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.Properties;
using PlenBotLogUploader.Teams;
using PlenBotLogUploader.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlenBotLogUploader;

public partial class FormEditAleevaIntegration : Form
{
    // fields
    private readonly FormAleevaIntegrations aleevaLink;
    private readonly List<AleevaChannel> aleevaServerChannels = [];
    private readonly List<AleevaServer> aleevaServers = [];
    private readonly HttpClientController controller;
    private readonly AleevaIntegration data;
    private readonly FormMain mainLink;
    private string selectedChannel;
    private string selectedServer;
    private Team selectedTeam = Teams.Teams.All.Count > 0 ? Teams.Teams.All[0] : null;

    internal FormEditAleevaIntegration(FormMain mainLink, FormAleevaIntegrations aleevaLink, HttpClientController controller, AleevaIntegration data)
    {
        this.mainLink = mainLink;
        this.aleevaLink = aleevaLink;
        this.controller = controller;
        InitializeComponent();
        Icon = Resources.aleeva_icon;
        Text = data is null ? "Add a new Aleeva integration" : "Edit an existing Aleeva integration";
        textBoxName.Text = data?.Name ?? "";
        checkBoxSendNotification.Checked = data?.SendNotification ?? false;
        checkBoxOnlySuccessful.Checked = data?.SendOnSuccessOnly ?? false;
        selectedServer = data?.Server ?? "";
        selectedChannel = data?.Channel ?? "";
        comboBoxServer.Text = selectedServer;
        comboBoxChannel.Text = selectedChannel;
        selectedTeam = data?.Team ?? selectedTeam;
        if (data is not null)
        {
            _ = AleevaLoadServers();
        }
        comboBoxServer.SelectedIndexChanged += ComboBoxServer_SelectedIndexChanged;
        comboBoxChannel.SelectedIndexChanged += ComboBoxChannel_SelectedIndexChanged;
        this.data = data;
        ApplicationSettings.Current.Aleeva.AuthorisedChanged += OnAuthoriseResult;
    }

    private void OnAuthoriseResult(object sender, EventArgs e)
    {
        var toggle = ApplicationSettings.Current.Aleeva.Authorised;
        groupBoxName.Enabled = toggle;
        groupBoxServer.Enabled = toggle;
        groupBoxChannel.Enabled = toggle;
        groupBoxUploadSettings.Enabled = toggle;
    }

    private void FormAleeva_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBoxName.Text) && string.IsNullOrWhiteSpace(selectedServer) && string.IsNullOrWhiteSpace(selectedChannel))
        {
            return;
        }
        if (!string.IsNullOrWhiteSpace(selectedServer) && string.IsNullOrWhiteSpace(selectedChannel))
        {
            var dialog = MessageBox.Show("You have selected a server but not selected a channel.\nThis configuration will not work, you must set both the server and the notification channel.\n\nDo you want to save the current state anyway?", "Do you want to save an incomplete integration?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialog.Equals(DialogResult.No))
            {
                e.Cancel = true;
                return;
            }
        }
        ApplicationSettings.Current.Aleeva.AuthorisedChanged -= OnAuthoriseResult;
        var activeState = !string.IsNullOrWhiteSpace(selectedServer) && !string.IsNullOrWhiteSpace(selectedChannel);
        if (data is null)
        {
            AleevaIntegrations.All.Add(new AleevaIntegration
            {
                Active = activeState,
                Name = textBoxName.Text,
                Server = selectedServer,
                Channel = selectedChannel,
                Team = selectedTeam,
                SendNotification = checkBoxSendNotification.Checked,
                SendOnSuccessOnly = checkBoxOnlySuccessful.Checked,
            });
            aleevaLink.RedrawAleevaIntegrations();
            return;
        }
        data.Active = activeState;
        data.Name = textBoxName.Text;
        data.Server = selectedServer;
        data.Channel = selectedChannel;
        data.Team = selectedTeam;
        data.SendNotification = checkBoxSendNotification.Checked;
        data.SendOnSuccessOnly = checkBoxOnlySuccessful.Checked;
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
            using var response = await controller.GetAsync($"{AleevaStatics.ApiBaseUrl}/server?mode=UPLOADS");
            if (response.IsSuccessStatusCode)
            {
                var responseMessage = await response.Content.ReadAsStringAsync();
                var servers = JsonConvert.DeserializeObject<List<AleevaServer>>(responseMessage);
                aleevaServers.AddRange(servers);
            }
            AddServersToView();
            comboBoxServer.Text = !string.IsNullOrWhiteSpace(selectedServer) ? aleevaServers.Find(x => x.Id.Equals(selectedServer))?.ToString() ?? "" : "";
            if (!string.IsNullOrWhiteSpace(selectedServer))
            {
                await AleevaLoadChannels(selectedServer);
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
        selectedServer = server.Id;
        await AleevaLoadChannels(server.Id);
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
            using var response = await controller.GetAsync($"{AleevaStatics.ApiBaseUrl}/server/{serverId}/channel?mode=UPLOADS");
            if (response.IsSuccessStatusCode)
            {
                var responseMessage = await response.Content.ReadAsStringAsync();
                var channels = JsonConvert.DeserializeObject<List<AleevaChannel>>(responseMessage);
                aleevaServerChannels.AddRange(channels);
            }
            AddChannelsToView();
            comboBoxChannel.Text = !string.IsNullOrWhiteSpace(selectedChannel) ? aleevaServerChannels.Find(x => x.Id.Equals(selectedChannel))?.ToString() ?? "" : "";
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
        selectedChannel = channel.Id;
    }

    private void FormAleeva_HelpButtonClicked(object sender, CancelEventArgs e)
    {
        e.Cancel = true;
        Process.Start(new ProcessStartInfo
        {
            UseShellExecute = true,
            FileName = AleevaStatics.Url,
        });
    }

    private void FormAleeva_Shown(object sender, EventArgs e)
    {
        comboBoxSelectedTeam.Items.Clear();
        var teams = Teams.Teams.All;
        foreach (var team in teams.Values)
        {
            comboBoxSelectedTeam.Items.Add(team);
        }
        comboBoxSelectedTeam.SelectedItem = selectedTeam;
    }

    private void ComboBoxSelectedTeam_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedTeam = comboBoxSelectedTeam.SelectedItem as Team ?? Teams.Teams.All[0];
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
}
