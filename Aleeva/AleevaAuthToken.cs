using Newtonsoft.Json;

namespace PlenBotLogUploader.Aleeva;

internal sealed class AleevaAuthToken
{
    [JsonProperty("grant_type")]
    internal string GrantType { get; set; }

    [JsonProperty("client_id")]
    internal string ClientId { get; } = "plen_bot_log_uploader";

    [JsonProperty("client_secret")]
    internal string ClientSecret { get; } = "5d5c6e0e-f658-4083-b0f1-db30f8a2e1ce";

    [JsonProperty("access_code")]
    internal string AccessCode { get; set; }

    [JsonProperty("refresh_token")]
    internal string RefreshToken { get; set; }

    [JsonProperty("scope")]
    internal string[] Scope { get; set; }
}
