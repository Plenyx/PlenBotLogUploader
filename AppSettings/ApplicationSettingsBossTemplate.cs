using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings
{
    public class ApplicationSettingsBossTemplate
    {
        [JsonProperty("successText")]
        public string SuccessText { get; set; } = "";

        [JsonProperty("failText")]
        public string FailText { get; set; } = "";
    }
}
