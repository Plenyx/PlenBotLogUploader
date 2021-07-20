using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings
{
    public class ApplicationSettingsBossTemplate
    {
        [JsonProperty("failText")]
        public string FailText { get; set; } = "<boss> pull: <log> | Current wipes: <pulls>";

        [JsonProperty("successText")]
        public string SuccessText { get; set; } = "<boss> kill: <log>";
    }
}
