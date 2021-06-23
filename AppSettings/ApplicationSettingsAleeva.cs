using Newtonsoft.Json;
using System;

namespace PlenBotLogUploader.AppSettings
{
    public class ApplicationSettingsAleeva
    {
        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; } = "";

        [JsonProperty("refreshTokenExpire")]
        public DateTime RefreshTokenExpire { get; set; } = DateTime.Now;

        [JsonProperty("selectedServer")]
        public string SelectedServer { get; set; } = "";

        [JsonProperty("selectedChannel")]
        public string SelectedChannel { get; set; } = "";

        [JsonProperty("sendNotification")]
        public bool SendNotification { get; set; } = false;

        [JsonProperty("sendOnSuccessOnly")]
        public bool SendOnSuccessOnly { get; set; } = false;
    }
}
