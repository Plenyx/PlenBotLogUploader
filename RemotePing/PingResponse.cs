using Newtonsoft.Json;

namespace PlenBotLogUploader.RemotePing
{
    internal sealed class PingResponse
    {
        [JsonProperty("msg")]
        internal string Message { get; set; }

        [JsonProperty("user_id")]
        internal int? UserId { get; set; }

        [JsonProperty("log_id")]
        internal string LogId { get; set; } = string.Empty;
    }
}
