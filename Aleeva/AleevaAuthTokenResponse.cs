using Newtonsoft.Json;

namespace PlenBotLogUploader.Aleeva;

internal sealed class AleevaAuthTokenResponse : AleevaResponseStatus
{
    [JsonProperty("accessToken")]
    internal string AccessToken { get; set; }

    [JsonProperty("refreshToken")]
    internal string RefreshToken { get; set; }

    [JsonProperty("tokenType")]
    internal string TokenType { get; set; }

    [JsonProperty("refreshExpiresIn")]
    internal int RefreshExpiresIn { get; set; }

    [JsonProperty("expiresIn")]
    internal int ExpiresIn { get; set; }
}
