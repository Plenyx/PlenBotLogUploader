using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.DpsReport;
using PlenBotLogUploader.Gw2Bot;
using PlenBotLogUploader.Teams;
using PlenBotLogUploader.Tools;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormGw2Bot : Form
    {
        #region definitions
        private readonly FormMain mainLink;
        private const string gw2botAPIBaseUrl = "https://api.gw2bot.info/v1";
        private readonly HttpClientController controller = new();
        #endregion

        internal FormGw2Bot(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.gw2bot_icon;
            checkBoxModuleEnabled.Checked = ApplicationSettings.Current.Gw2Bot.Enabled;
            textBoxAPIKey.Text = ApplicationSettings.Current.Gw2Bot.ApiKey;
            checkBoxOnlySuccessful.Checked = ApplicationSettings.Current.Gw2Bot.SendOnSuccessOnly;
            if (!string.IsNullOrWhiteSpace(ApplicationSettings.Current.Gw2Bot.ApiKey))
            {
                controller.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ApplicationSettings.Current.Gw2Bot.ApiKey);
            }
        }

        private void FormGW2Bot_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            ApplicationSettings.Current.Gw2Bot.Enabled = checkBoxModuleEnabled.Checked;
            ApplicationSettings.Current.Gw2Bot.ApiKey = textBoxAPIKey.Text;
            ApplicationSettings.Current.Gw2Bot.SendOnSuccessOnly = checkBoxOnlySuccessful.Checked;
            ApplicationSettings.Current.Gw2Bot.TeamId = (comboBoxSelectedTeam.SelectedItem as Team)?.Id ?? 0;
            ApplicationSettings.Current.Save();
            controller.DefaultRequestHeaders.Authorization = (!string.IsNullOrWhiteSpace(ApplicationSettings.Current.Gw2Bot.ApiKey)) ? new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ApplicationSettings.Current.Gw2Bot.ApiKey) : null;
        }

        private void FormGW2Bot_FormClosed(object sender, FormClosedEventArgs e) => controller.Dispose();

        internal async Task<bool> PostLogToGW2Bot(DpsReportJson reportJSON)
        {
            if (!checkBoxModuleEnabled.Checked)
            {
                return true;
            }
            if ((ApplicationSettings.Current.Gw2Bot.TeamId > 0) &&
                Teams.Teams.All.ContainsKey(ApplicationSettings.Current.Gw2Bot.TeamId) &&
                !Teams.Teams.All[ApplicationSettings.Current.Gw2Bot.TeamId].IsSatisfied(reportJSON.ExtraJson) &&
                checkBoxOnlySuccessful.Checked && !(reportJSON.Encounter.Success ?? false))
            {
                return true;
            }
            try
            {
                var uri = new Uri($"{gw2botAPIBaseUrl}/evtc/notification");
                var logObject = new Gw2BotAddReport() { LogLink = reportJSON.ConfigAwarePermalink };
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
            comboBoxSelectedTeam.Items.AddRange(teams.Values.ToArray());
            comboBoxSelectedTeam.SelectedItem = (ApplicationSettings.Current.Gw2Bot.TeamId > 0) ? teams[ApplicationSettings.Current.Gw2Bot.TeamId] : teams[0];
        }
    }
}
