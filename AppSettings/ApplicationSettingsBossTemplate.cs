using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings;

internal sealed class ApplicationSettingsBossTemplate
{
    [JsonProperty("failText")]
    internal string FailText { get; set; } = "<boss> pull: <log> | Current wipes: <pulls> | Phase: <phase> | <percent>";

    [JsonProperty("successText")]
    internal string SuccessText { get; set; } = "<boss> kill: <log>";
}
