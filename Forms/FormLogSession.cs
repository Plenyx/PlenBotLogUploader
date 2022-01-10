using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.DiscordAPI;
using PlenBotLogUploader.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormLogSession : Form
    {
        #region definitions
        // properties
        public bool SessionRunning { get; private set; } = false;

        // fields
        private readonly FormMain mainLink;
        private bool sessionPaused = false;
        private readonly Stopwatch stopWatch = new Stopwatch();
        private DateTime sessionTimeStarted;
        #endregion

        public FormLogSession(FormMain mainLink)
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
            ApplicationSettings.Current.Session.MakeWvWSummaryEmbed = checkBoxMakeWvWSummary.Checked;
            ApplicationSettings.Current.Save();
        }

        private async void ButtonSessionStarter_Click(object sender, EventArgs e)
        {
            if (SessionRunning || sessionPaused)
            {
                buttonSessionStarter.Text = "Start a log session";
                buttonUnPauseSession.Text = "Pause session";
                buttonUnPauseSession.Enabled = false;
                SessionRunning = false;
                sessionPaused = false;
                stopWatch.Stop();
                string elapsedTime = stopWatch.Elapsed.ParseHMS();
                var elapsedTimeSpan = stopWatch.Elapsed;
                stopWatch.Reset();
                int sortBy = radioButtonSortByUpload.Checked ? 1 : 0;
                var logSessionSettings = new LogSessionSettings()
                {
                    Name = textBoxSessionName.Text,
                    ContentText = textBoxSessionContent.Text,
                    ShowSuccess = !checkBoxOnlySuccess.Checked,
                    ElapsedTime = elapsedTime,
                    ElapsedTimeSpan = elapsedTimeSpan,
                    SortBy = (LogSessionSortBy)sortBy,
                    MakeWvWSummaryEmbed = checkBoxMakeWvWSummary.Checked,
                    UseSelectedWebhooksInstead = radioButtonOnlySelectedWebhooks.Checked,
                    SelectedWebhooks = ConvertCheckboxListToList()
                };
                var fileName = $"{textBoxSessionName.Text.ToLower().Replace(" ", "")} {sessionTimeStarted.Year}-{sessionTimeStarted.Month}-{sessionTimeStarted.Day} {sessionTimeStarted.Hour}-{sessionTimeStarted.Minute}-{sessionTimeStarted.Second}";
                File.AppendAllText($"{ApplicationSettings.LocalDir}{fileName}.csv", "Boss;BossId;Success;Duration;RecordedBy;EliteInsightsVersion;arcdpsVersion;Permalink\n");
                foreach (var reportJSON in mainLink.SessionLogs)
                {
                    string success = (reportJSON.Encounter.Success ?? false) ? "true" : "false";
                    File.AppendAllText($"{ApplicationSettings.LocalDir}{fileName}.csv",
                        $"{reportJSON.ExtraJSON?.FightName ?? reportJSON.Encounter.Boss};{reportJSON.Encounter.BossId};{success};{reportJSON.ExtraJSON?.Duration ?? ""};{reportJSON.ExtraJSON?.RecordedBy ?? ""};{reportJSON.ExtraJSON?.EliteInsightsVersion ?? ""};{reportJSON.EVTC.Type}{reportJSON.EVTC.Version};{reportJSON.Permalink}\n");
                }
                await mainLink.ExecuteSessionLogWebhooksAsync(logSessionSettings);
                mainLink.SessionLogs.Clear();
            }
            else
            {
                buttonSessionStarter.Text = "Stop the log session";
                buttonUnPauseSession.Text = "Pause session";
                buttonUnPauseSession.Enabled = true;
                SessionRunning = true;
                sessionPaused = false;
                stopWatch.Start();
                sessionTimeStarted = DateTime.Now;
            }
        }

        private void ButtonUnPauseSession_Click(object sender, EventArgs e)
        {
            sessionPaused = !sessionPaused;
            SessionRunning = !sessionPaused;
            buttonUnPauseSession.Text = (!sessionPaused) ? "Pause session" : "Unpause session";
        }

        public void CheckBoxSupressWebhooks_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Session.SupressWebhooks = checkBoxSupressWebhooks.Checked;
            ApplicationSettings.Current.Save();
        }

        public void CheckBoxOnlySuccess_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.Session.OnlySuccess = checkBoxOnlySuccess.Checked;
            ApplicationSettings.Current.Save();
        }

        public void CheckBoxSaveToFile_CheckedChanged(object sender, EventArgs e)
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
            for (int i = 0; i < checkedListBoxSelectedWebhooks.Items.Count; i++)
            {
                var item = checkedListBoxSelectedWebhooks.Items[i];
                if (item.GetType().Equals(typeof(DiscordWebhooksHelperClass)))
                {
                    var discordWebhookHelper = (DiscordWebhooksHelperClass)item;
                    var checkedState = checkedListBoxSelectedWebhooks.GetItemChecked(i);
                    if (checkedState)
                    {
                        if (allWebhooks.ContainsKey(discordWebhookHelper.WebhookID))
                        {
                            list.Add(allWebhooks[discordWebhookHelper.WebhookID]);
                        }
                    }
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
                checkedListBoxSelectedWebhooks.Items.Add(new DiscordWebhooksHelperClass() { WebhookID = webhookNumber, Text = $"{allWebhooks[webhookNumber].Name}" }, allWebhooks[webhookNumber].Active);
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

        private void ButtonReloadWebhooks_Click(object sender, EventArgs e)
        {
            ReloadWebhooks();
        }
    }
}
