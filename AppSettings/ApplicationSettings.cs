using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace PlenBotLogUploader.AppSettings
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ApplicationSettings
    {
        #region application version
        public static int Version { get; } = 77;
        #endregion

        #region load & save functionality
        public static ApplicationSettings Current { get; private set; }

        public static string FileName { get; } = "app_settings.json";

        public static string LocalDir { get; set; }

        public event EventHandler<EventArgs> SettingsSaved;

        public ApplicationSettings()
        {
            Current = this;
        }

        private void SerialiseToFile(string saveLocation)
        {
            SettingsSaved?.Invoke(this, new EventArgs());
            File.WriteAllText(saveLocation, JsonConvert.SerializeObject(this, Formatting.Indented));
        }

        private static ApplicationSettings DeserialiseFromFile(string loadLocation)
        {
            if (File.Exists(loadLocation))
            {
                var json = File.ReadAllText(loadLocation);
                var settings = JsonConvert.DeserializeObject<ApplicationSettings>(json);
                if (!(settings is null))
                {
                    return settings;
                }
            }
            var sett = new ApplicationSettings();
            sett.Save();
            return sett;
        }

        public static bool Exists() => File.Exists($"{LocalDir}{FileName}");
        public static ApplicationSettings Load() => DeserialiseFromFile($"{LocalDir}{FileName}");
        public void Save() => SerialiseToFile($"{LocalDir}{FileName}");
        #endregion

        #region public properties
        [JsonProperty("aleeva")]
        public ApplicationSettingsAleeva Aleeva { get; set; } = new ApplicationSettingsAleeva();

        [JsonProperty("arcUpdate")]
        public ApplicationSettingsArcUpdate ArcUpdate { get; set; } = new ApplicationSettingsArcUpdate();

        [JsonProperty("bossTemplate")]
        public ApplicationSettingsBossTemplate BossTemplate { get; set; } = new ApplicationSettingsBossTemplate();

        [JsonProperty("firstApplicationRun")]
        public bool FirstApplicationRun { get; set; } = true;

        [JsonProperty("firstTimeMinimised")]
        public bool FirstTimeMinimised { get; set; } = false;

        [JsonProperty("gw2APIKeys")]
        public List<ApplicationSettingsGW2API> GW2APIs { get; set; } = new List<ApplicationSettingsGW2API>();

        [JsonProperty("gw2Bot")]
        public ApplicationSettingsGW2Bot GW2Bot { get; set; } = new ApplicationSettingsGW2Bot();

        [JsonProperty("gw2Location")]
        public string GW2Location { get; set; } = string.Empty;

        [JsonProperty("logsLocation")]
        public string LogsLocation { get; set; } = string.Empty;

        [JsonProperty("mainFormSize")]
        public System.Drawing.Size MainFormSize { get; set; } = new System.Drawing.Size(649, 784);

        [JsonProperty("mainFormState")]
        public System.Windows.Forms.FormWindowState MainFormState { get; set; } = System.Windows.Forms.FormWindowState.Normal;

        [JsonProperty("maxConcurrentUploads")]
        public int MaxConcurrentUploads { get; set; } = 4;

        [JsonProperty("minimiseToTry")]
        public bool MinimiseToTray { get; set; } = true;

        [JsonProperty("autoUpdate")]
        public bool AutoUpdate { get; set; } = false;

        [JsonProperty("session")]
        public ApplicationSettingsSession Session { get; set; } = new ApplicationSettingsSession();

        [JsonProperty("shortenThousands")]
        public bool ShortenThousands { get; set; } = false;

        [JsonProperty("twitch")]
        public ApplicationSettingsTwitch Twitch { get; set; } = new ApplicationSettingsTwitch();

        [JsonProperty("upload")]
        public ApplicationSettingsUpload Upload { get; set; } = new ApplicationSettingsUpload();
        #endregion
    }
}
