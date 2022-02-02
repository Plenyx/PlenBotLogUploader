using Newtonsoft.Json;
using System;

namespace PlenBotLogUploader.AppSettings
{
    public class ApplicationSettingsAleeva
    {
        [JsonProperty("selectedChannel")]
        public string SelectedChannel { get; set; } = "";

        [JsonProperty("selectedServer")]
        public string SelectedServer { get; set; } = "";

        [JsonProperty("selectedTeamId")]
        public int SelectedTeamId { get; set; } = 0;

        [JsonProperty("sendNotification")]
        public bool SendNotification { get; set; } = false;

        [JsonProperty("sendOnSuccessOnly")]
        public bool SendOnSuccessOnly { get; set; } = false;

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; } = "";

        [JsonProperty("refreshTokenExpire")]
        public DateTime RefreshTokenExpire { get; set; } = DateTime.Now;
    }
}
