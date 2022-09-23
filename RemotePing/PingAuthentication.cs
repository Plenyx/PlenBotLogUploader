using Newtonsoft.Json;

namespace PlenBotLogUploader.RemotePing
{
    internal sealed class PingAuthentication
    {
        [JsonProperty("isActive")]
        internal bool Active { get; set; }

        [JsonProperty("useAsAuth")]
        internal bool UseAsAuth { get; set; } = false;

        [JsonProperty("authName")]
        internal string AuthName { get; set; } = string.Empty;

        [JsonProperty("authToken")]
        internal string AuthToken { get; set; } = string.Empty;
    }
}
