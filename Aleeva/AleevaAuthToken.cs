using System.Collections.Generic;
using Newtonsoft.Json;

namespace PlenBotLogUploader.Aleeva
{
    public class AleevaAuthToken
    {
        [JsonProperty("grant_type")]
        public string GrantType { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; } = "plen_bot_log_uploader";

        [JsonProperty("client_secret")]
        public string ClientSecret { get; } = "5d5c6e0e-f658-4083-b0f1-db30f8a2e1ce";

        [JsonProperty("access_code")]
        public string AccessCode { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("scope")]
        public List<string> Scope { get; set; } = new List<string>();
    }
}
