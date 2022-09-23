using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings
{
    internal sealed class ApplicationSettingsUploadUserToken
    {
        [JsonProperty("name")]
        internal string Name { get; set; } = string.Empty;

        [JsonProperty("active")]
        internal bool Active { get; set; } = false;

        [JsonProperty("userToken")]
        internal string UserToken { get; set; } = string.Empty;

        public override string ToString() => Name;
    }
}
