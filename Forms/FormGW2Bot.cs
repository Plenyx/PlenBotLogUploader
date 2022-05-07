using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.DPSReport;
using PlenBotLogUploader.GW2Bot;
using PlenBotLogUploader.Teams;
using PlenBotLogUploader.Tools;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormGW2Bot : Form
    {
        #region definitions
        private readonly FormMain mainLink;
        private const string gw2botAPIBaseUrl = "https://api.gw2bot.info/v1";
        private readonly HttpClientController controller = new HttpClientController();
        #endregion

        public FormGW2Bot(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.gw2bot_icon;
            checkBoxModuleEnabled.Checked = ApplicationSettings.Current.GW2Bot.Enabled;
            textBoxAPIKey.Text = ApplicationSettings.Current.GW2Bot.APIKey;
            checkBoxOnlySuccessful.Checked = ApplicationSettings.Current.GW2Bot.SendOnSuccessOnly;
            if (!string.IsNullOrWhiteSpace(ApplicationSettings.Current.GW2Bot.APIKey))
            {
                controller.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ApplicationSettings.Current.GW2Bot.APIKey);
            }
        }

        private void FormGW2Bot_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            ApplicationSettings.Current.GW2Bot.Enabled = checkBoxModuleEnabled.Checked;
            ApplicationSettings.Current.GW2Bot.APIKey = textBoxAPIKey.Text;
            ApplicationSettings.Current.GW2Bot.SendOnSuccessOnly = checkBoxOnlySuccessful.Checked;
            ApplicationSettings.Current.GW2Bot.SelectedTeamId = (comboBoxSelectedTeam.SelectedItem as Team).ID;
            ApplicationSettings.Current.Save();
            controller.DefaultRequestHeaders.Authorization = (!string.IsNullOrWhiteSpace(ApplicationSettings.Current.GW2Bot.APIKey)) ? new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ApplicationSettings.Current.GW2Bot.APIKey) : null;
        }

        private void FormGW2Bot_FormClosed(object sender, FormClosedEventArgs e) => controller.Dispose();

        public async Task<bool> PostLogToGW2Bot(DPSReportJSON reportJSON)
        {
            if (checkBoxModuleEnabled.Checked)
            {
                if (ApplicationSettings.Current.GW2Bot.SelectedTeamId > 0)
                {
                    if (Teams.Teams.All.ContainsKey(ApplicationSettings.Current.GW2Bot.SelectedTeamId))
                    {
                        if (!Teams.Teams.All[ApplicationSettings.Current.GW2Bot.SelectedTeamId].IsSatisfied(reportJSON.ExtraJSON))
                        {
                            return true;
                        }
                    }
                }
                if (checkBoxOnlySuccessful.Checked && !(reportJSON.Encounter.Success ?? false))
                {
                    return true;
                }
                try
                {
                    var uri = new Uri($"{gw2botAPIBaseUrl}/evtc/notification");
                    var logObject = new GW2BotAddReport() { LogLink = reportJSON.Permalink };
                    var jsonLogObject = JsonConvert.SerializeObject(logObject);
                    using var content = new StringContent(jsonLogObject, Encoding.UTF8, "application/json");
                    using var response = await controller.PostAsync(uri, content);
                    if (!response.IsSuccessStatusCode)
                    {
                        mainLink.AddToText($"??>> There was an error with GW2Bot while trying to post the log. Status code on response: {response.StatusCode}");
                        return false;
                    }
                    return true;
                }
                catch (Exception e)
                {
                    mainLink.AddToText($"??>> There was an error with GW2Bot while trying to post the log. Error: {e.Message}");
                    return false;
                }
            }
            return true;
        }

        private void CheckBoxModuleEnabled_CheckedChanged(object sender, EventArgs e)
        {
            var toggle = checkBoxModuleEnabled.Checked;
            groupBoxAPIKey.Enabled = toggle;
            groupBoxUploadSettings.Enabled = toggle;
        }

        private void FormGW2Bot_Shown(object sender, EventArgs e)
        {
            comboBoxSelectedTeam.Items.Clear();
            var teams = Teams.Teams.All;
            foreach (var team in teams.Values)
            {
                comboBoxSelectedTeam.Items.Add(team);
            }
            comboBoxSelectedTeam.SelectedItem = (ApplicationSettings.Current.GW2Bot.SelectedTeamId > 0) ? teams[ApplicationSettings.Current.GW2Bot.SelectedTeamId] : teams[0];
        }
    }
}
