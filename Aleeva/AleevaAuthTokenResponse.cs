using Newtonsoft.Json;

namespace PlenBotLogUploader.Aleeva
{
    public class AleevaAuthTokenResponse : AleevaResponseStatus
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }

        [JsonProperty("tokenType")]
        public string TokenType { get; set; }

        [JsonProperty("refreshExpiresIn")]
        public int RefreshExpiresIn { get; set; }

        [JsonProperty("expiresIn")]
        public int ExpiresIn { get; set; }
    }
}
