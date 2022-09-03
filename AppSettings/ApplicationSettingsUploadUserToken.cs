using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings
{
    public class ApplicationSettingsUploadUserToken
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("active")]
        public bool Active { get; set; } = false;

        [JsonProperty("userToken")]
        public string UserToken { get; set; } = string.Empty;

        public override string ToString() => Name;
    }
}
