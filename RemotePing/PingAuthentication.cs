using Newtonsoft.Json;

namespace PlenBotLogUploader.RemotePing
{
    public class PingAuthentication
    {
        [JsonProperty("isActive")]
        public bool Active { get; set; }

        [JsonProperty("useAsAuth")]
        public bool UseAsAuth { get; set; } = false;

        [JsonProperty("authName")]
        public string AuthName { get; set; } = "";

        [JsonProperty("authToken")]
        public string AuthToken { get; set; } = "";
    }
}
