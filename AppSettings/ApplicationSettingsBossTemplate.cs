using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings
{
    public class ApplicationSettingsBossTemplate
    {
        [JsonProperty("failText")]
        public string FailText { get; set; } = "";

        [JsonProperty("successText")]
        public string SuccessText { get; set; } = "";
    }
}
