using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings
{
    internal sealed class ApplicationSettingsUploadUserToken
    {
        [JsonProperty("name")]
        internal string Name { get; set; } = "";

        [JsonProperty("active")]
        internal bool Active { get; set; } = false;

        [JsonProperty("userToken")]
        internal string UserToken { get; set; } = "";

        public override string ToString() => Name;
    }
}
