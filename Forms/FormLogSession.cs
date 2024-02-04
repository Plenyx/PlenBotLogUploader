using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.DiscordApi;
using PlenBotLogUploader.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormLogSession : Form
    {
        #region definitions
        // properties
        internal bool SessionRunning { get; private set; } = false;

        // fields
        private readonly FormMain mainLink;
        private bool sessionPaused = false;
        private readonly Stopwatch stopWatch = new();
        private DateTime sessionTimeStarted;
        #endregion

        internal FormLogSession(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
        }

        private void FormLogSession_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            ApplicationSettings.Current.Session.Name = textBoxSessionName.Text;
            ApplicationSettings.Current.Session.Message = textBoxSessionContent.Text;
            ApplicationSettings.Current.Session.MakeWvwSummaryEmbed = checkBoxMakeWvWSummary.Checked;
            ApplicationSettings.Current.Save();
        }

        private void ButtonSessionStarter_Click(object sender, EventArgs e)
        {
            if (!SessionRunning && !sessionPaused)
            {
                buttonSessionStarter.Text = "Stop the log session";
                buttonUnPauseSession.Text = "Pause session";
                buttonUnPauseSession.Enabled = true;
                SessionRunning = true;
                sessionPaused = false;
                stopWatch.Start();
                sessionTimeStarted = DateTime.Now;
                return;
            }
            buttonSessionStarter.Text = "Start a log session";
            buttonUnPauseSession.Text = "Pause session";
            buttonUnPauseSession.Enabled = false;
            SessionRunning = false;
            sessionPaused = false;
            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ParseHMS();
            var elapsedTimeSpan = stopWatch.Elapsed;
            stopWatch.Reset();
            var logSessionSettings = new LogSessionSettings()
            {
                Name = textBoxSessionName.Text,
                ContentText = textBoxSessionContent.Text,
                ShowSuccess = !checkBoxOnlySuccess.Checked,
                ElapsedTime = elapsedTime,
                ElapsedTimeSpan = elapsedTimeSpan,
                SortBy = radioButtonSortByUpload.Checked ? LogSessionSortBy.UploadTime : LogSessionSortBy.Wing,
                MakeWvwSummaryEmbed = checkBoxMakeWvWSummary.Checked,
                UseSelectedWebhooksInstead = radioButtonOnlySelectedWebhooks.Checked,
                SelectedWebhooks = ConvertCheckboxListToList(),
            };
            var sessionNameFormatted = CleanSessionName();
            var fileName = $"{((!string.IsNullOrWhiteSpace(sessionNameFormatted)) ? $"{sessionNameFormatted} " : "")}{sessionTimeStarted.Year}-{sessionTimeStarted.Month}-{sessionTimeStarted.Day} {sessionTimeStarted.Hour}-{sessionTimeStarted.Minute}-{sessionTimeStarted.Second}";
            File.AppendAllText($"{ApplicationSettings.LocalDir}{fileName}.csv", "Boss;BossId;Success;Duration;RecordedBy;EliteInsightsVersion;arcdpsVersion;Permalink;UserToken\n");
            foreach (var reportJSON in mainLink.SessionLogs.AsSpan())
            {
                var success = (reportJSON.Encounter.Success ?? false) ? "true" : "false";
                File.AppendAllText($"{ApplicationSettings.LocalDir}{fileName}.csv",
                    $"{reportJSON.ExtraJson?.FightName ?? reportJSON.Encounter.Boss};{reportJSON.Encounter.BossId};{success};{reportJSON.ExtraJson?.Duration ?? ""};{reportJSON.ExtraJson?.RecordedBy ?? ""};{reportJSON.ExtraJson?.EliteInsightsVersion ?? ""};{reportJSON.Evtc.Type}{reportJSON.Evtc.Version};{reportJSON.ConfigAwarePermalink};{reportJSON.UserToken}\n");
            }
            _ = SendSessionWebhooks(logSessionSettings);
        }

        private string CleanSessionName()
        {
            var sessionNameFormatted = textBoxSessionName.Text.ToLower().Replace(" ", "");
            foreach (var character in Path.GetInvalidFileNameChars().AsSpan())
            {
                if (!character.Equals('/'))
                {
                    sessionNameFormatted = sessionNameFormatted.Replace(character.ToString(), "");
                }
            }
            return sessionNameFormatted.Replace("/", "-out-of-");
        }

        private async Task SendSessionWebhooks(LogSessionSettings logSessionSettings)
        {
            await mainLink.ExecuteSessionLogWebhooksAsync(logSessionSettings);
            mainLink.SessionLogs.Clear();
        }

        private void ButtonUnPauseSession_Click(object sender, EventArgs e)
        {
            sessionPaused = !sessionPaused;
            SessionRunning = !sessionPaused;
            buttonUnPauseSession.Text = (!sessionPaused) ? "Pause session" : "Unpause session";
        }

        internal void CheckBoxSupressWebhooks_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Session.SupressWebhooks = checkBoxSupressWebhooks.Checked;
            ApplicationSettings.Current.Save();
        }

        internal void CheckBoxOnlySuccess_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Session.OnlySuccess = checkBoxOnlySuccess.Checked;
            ApplicationSettings.Current.Save();
        }

        internal void CheckBoxSaveToFile_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Session.SaveToFile = checkBoxSaveToFile.Checked;
            ApplicationSettings.Current.Save();
        }

        private void RadioButtonSortByWing_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Session.Sort = LogSessionSortBy.Wing;
            ApplicationSettings.Current.Save();
        }

        private void RadioButtonSortByUpload_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Session.Sort = LogSessionSortBy.UploadTime;
            ApplicationSettings.Current.Save();
        }

        private List<DiscordWebhookData> ConvertCheckboxListToList()
        {
            var allWebhooks = DiscordWebhooks.All;
            var list = new List<DiscordWebhookData>();
            for (var i = 0; i < checkedListBoxSelectedWebhooks.Items.Count; i++)
            {
                var item = checkedListBoxSelectedWebhooks.Items[i];
                if ((item is DiscordWebhooksHelperClass discordWebhookHelper) &&
                    checkedListBoxSelectedWebhooks.GetItemChecked(i) &&
                    allWebhooks.TryGetValue(discordWebhookHelper.WebhookId, out DiscordWebhookData discordWebhookData))
                {
                    list.Add(discordWebhookData);
                }
            }
            return list;
        }

        private void ReloadWebhooks()
        {
            checkedListBoxSelectedWebhooks.Items.Clear();
            var allWebhooks = DiscordWebhooks.All;
            foreach (var webhookNumber in allWebhooks.Keys)
            {
                checkedListBoxSelectedWebhooks.Items.Add(new DiscordWebhooksHelperClass() { WebhookId = webhookNumber, Text = $"{allWebhooks[webhookNumber].Name}" }, allWebhooks[webhookNumber].Active);
            }
        }

        private void RadioButtonOnlySelectedWebhooks_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxSelectedWebhooks.Enabled = radioButtonOnlySelectedWebhooks.Checked;
            if (groupBoxSelectedWebhooks.Enabled)
            {
                ReloadWebhooks();
            }
        }

        private void ButtonReloadWebhooks_Click(object sender, EventArgs e) => ReloadWebhooks();
    }
}
