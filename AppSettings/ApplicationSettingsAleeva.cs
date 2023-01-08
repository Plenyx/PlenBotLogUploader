using Newtonsoft.Json;
using System;

namespace PlenBotLogUploader.AppSettings
{
    internal sealed class ApplicationSettingsAleeva : Aleeva.AleevaIntegration
    {
        [JsonProperty("refreshToken")]
        internal string RefreshToken { get; set; } = "";

        [JsonProperty("refreshTokenExpire")]
        internal DateTime RefreshTokenExpire { get; set; } = DateTime.Now;
    }
}
