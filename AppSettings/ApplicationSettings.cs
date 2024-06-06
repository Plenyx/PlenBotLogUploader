using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace PlenBotLogUploader.AppSettings
{
    [JsonObject(MemberSerialization.OptIn)]
    internal sealed class ApplicationSettings
    {
        #region application version
        internal static int Version => 90;
        #endregion

        #region load & save functionality
        internal static ApplicationSettings Current { get; private set; }

        internal static string FileName => "app_settings.json";

        internal static string LocalDir { get; set; }

        internal event EventHandler<EventArgs> SettingsSaved;

        internal ApplicationSettings()
        {
            Current = this;
        }

        private void SerialiseToFile(string saveLocation)
        {
            SettingsSaved?.Invoke(this, EventArgs.Empty);
            File.WriteAllText(saveLocation, JsonConvert.SerializeObject(this, Formatting.Indented));
        }

        private static ApplicationSettings DeserialiseFromFile(string loadLocation)
        {
            if (File.Exists(loadLocation))
            {
                var json = File.ReadAllText(loadLocation);
                var settings = JsonConvert.DeserializeObject<ApplicationSettings>(json);
                if (settings is not null)
                {
                    return settings;
                }
            }
            var sett = new ApplicationSettings();
            sett.Save();
            return sett;
        }

        internal static bool Exists() => File.Exists(LocalDir + FileName);
        internal static ApplicationSettings Load() => DeserialiseFromFile(LocalDir + FileName);
        internal void Save() => SerialiseToFile(LocalDir + FileName);
        #endregion

        #region internal properties
        [JsonProperty("aleeva")]
        internal ApplicationSettingsAleeva Aleeva { get; set; } = new ApplicationSettingsAleeva();

        [JsonProperty("arcUpdate")]
        internal ApplicationSettingsArcUpdate ArcUpdate { get; set; } = new ApplicationSettingsArcUpdate();

        [JsonProperty("autoUpdate")]
        internal bool AutoUpdate { get; set; } = false;

        [JsonProperty("bossTemplate")]
        internal ApplicationSettingsBossTemplate BossTemplate { get; set; } = new ApplicationSettingsBossTemplate();

        [JsonProperty("buildCodes")]
        internal ApplicationSettingsBuildCodes BuildCodes { get; set; } = new();

        [JsonProperty("firstApplicationRun")]
        internal bool FirstApplicationRun { get; set; } = true;

        [JsonProperty("firstTimeMinimised")]
        internal bool FirstTimeMinimised { get; set; } = false;

        [JsonProperty("gw2APIKeys")]
        internal List<ApplicationSettingsGw2Api> Gw2Apis { get; set; } = [];

        [JsonProperty("gw2Bot")]
        internal ApplicationSettingsGw2Bot Gw2Bot { get; set; } = new ApplicationSettingsGw2Bot();

        [JsonProperty("gw2Location")]
        internal string Gw2Location { get; set; } = "";

        [JsonProperty("logsLocation")]
        internal string LogsLocation { get; set; } = "";

        [JsonProperty("usePollingForLogs")]
        internal bool UsePollingForLogs { get; set; } = false;

        [JsonProperty("mainFormSize")]
        internal System.Drawing.Size MainFormSize { get; set; } = new System.Drawing.Size(649, 784);

        [JsonProperty("mainFormState")]
        internal System.Windows.Forms.FormWindowState MainFormState { get; set; } = System.Windows.Forms.FormWindowState.Normal;

        [JsonProperty("maxConcurrentUploads")]
        internal int MaxConcurrentUploads { get; set; } = 4;

        [JsonProperty("minimiseToTry")]
        internal bool MinimiseToTray { get; set; } = true;

        [JsonProperty("closeToTry")]
        internal bool CloseToTray { get; set; } = false;

        [JsonProperty("session")]
        internal ApplicationSettingsSession Session { get; set; } = new ApplicationSettingsSession();

        [JsonProperty("shortenThousands")]
        internal bool ShortenThousands { get; set; } = false;

        [JsonProperty("twitch")]
        internal ApplicationSettingsTwitch Twitch { get; set; } = new ApplicationSettingsTwitch();

        [JsonProperty("upload")]
        internal ApplicationSettingsUpload Upload { get; set; } = new ApplicationSettingsUpload();
        #endregion
    }
}
