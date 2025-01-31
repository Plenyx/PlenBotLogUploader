using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PlenBotLogUploader.AppSettings;

[JsonObject(MemberSerialization.OptIn)]
internal sealed class ApplicationSettings
{

    private static string _fileName = "app_settings.json";

    internal ApplicationSettings()
    {
        Current = this;
    }
    internal static int Version => 97;

    internal static ApplicationSettings Current { get; private set; }

    internal static string LocalDir { get; set; }

    [JsonProperty("aleeva")]
    internal ApplicationSettingsAleeva Aleeva { get; set; } = new();

    [JsonProperty("arcUpdate")]
    internal ApplicationSettingsArcUpdate ArcUpdate { get; set; } = new();

    [JsonProperty("autoUpdate")]
    internal bool AutoUpdate { get; set; }

    [JsonProperty("bossTemplate")]
    internal ApplicationSettingsBossTemplate BossTemplate { get; set; } = new();

    [JsonProperty("buildCodes")]
    internal ApplicationSettingsBuildCodes BuildCodes { get; set; } = new();

    [JsonProperty("firstApplicationRun")]
    internal bool FirstApplicationRun { get; set; } = true;

    [JsonProperty("firstTimeMinimised")]
    internal bool FirstTimeMinimised { get; set; }

    [JsonProperty("gw2APIKeys")]
    internal List<ApplicationSettingsGw2Api> Gw2Apis { get; set; } = [];

    [JsonProperty("gw2Bot")]
    internal ApplicationSettingsGw2Bot Gw2Bot { get; set; } = new();

    [JsonProperty("gw2Location")]
    internal string Gw2Location { get; set; } = "";

    [JsonProperty("logsLocation")]
    internal string LogsLocation { get; set; } = "";

    [JsonProperty("usePollingForLogs")]
    internal bool UsePollingForLogs { get; set; }

    [JsonProperty("mainFormSize")]
    internal Size MainFormSize { get; set; } = new(649, 784);

    [JsonProperty("mainFormState")]
    internal FormWindowState MainFormState { get; set; } = FormWindowState.Normal;

    [JsonProperty("maxConcurrentUploads")]
    internal int MaxConcurrentUploads { get; set; } = 4;

    [JsonProperty("minimiseToTry")]
    internal bool MinimiseToTray { get; set; } = true;

    [JsonProperty("closeToTry")]
    internal bool CloseToTray { get; set; }

    [JsonProperty("session")]
    internal ApplicationSettingsSession Session { get; set; } = new();

    [JsonProperty("shortenThousands")]
    internal bool ShortenThousands { get; set; }

    [JsonProperty("twitch")]
    internal ApplicationSettingsTwitch Twitch { get; set; } = new();

    [JsonProperty("upload")]
    internal ApplicationSettingsUpload Upload { get; set; } = new();

    internal event EventHandler<EventArgs> SettingsSaved;

    private static void AppendSettingsCrashWithMessage(string message)
    {
        try
        {
            File.AppendAllText("settings_crash.log", message);
        }
        catch
        {
            MessageBox.Show(message, "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SerialiseToFile(string saveLocation)
    {
        SettingsSaved?.Invoke(this, EventArgs.Empty);
        try
        {
            File.WriteAllText(saveLocation, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
        catch (Exception ex)
        {
            AppendSettingsCrashWithMessage(ex.Message);
        }
    }

    private static ApplicationSettings DeserialiseFromFile(string loadLocation)
    {
        if (File.Exists(loadLocation))
        {
            try
            {
                var json = File.ReadAllText(loadLocation);
                var settings = JsonConvert.DeserializeObject<ApplicationSettings>(json);
                if (settings is not null)
                {
                    return settings;
                }
            }
            catch (Exception ex)
            {
                AppendSettingsCrashWithMessage(ex.Message);
            }
            try
            {
                // error when loading occured, save previous settings before resetting
                File.Copy("app_settings.json", $"app_settings {DateTime.Now:yyyy-MM-dd HHmmss}.json");
            }
            catch (Exception ex)
            {
                AppendSettingsCrashWithMessage(ex.Message);
                ;
            }
        }
        var sett = new ApplicationSettings();
        sett.Save();
        return sett;
    }

    internal static bool Exists() => File.Exists(LocalDir + _fileName);
    internal static ApplicationSettings Load() => DeserialiseFromFile(LocalDir + _fileName);
    internal void Save() => SerialiseToFile(LocalDir + _fileName);
}
