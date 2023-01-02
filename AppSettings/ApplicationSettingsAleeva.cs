using Newtonsoft.Json;
using System;

namespace PlenBotLogUploader.AppSettings
{
    internal sealed class ApplicationSettingsAleeva
    {
        [JsonProperty("selectedChannel")]
        internal string SelectedChannel { get; set; } = "";

        [JsonProperty("selectedServer")]
        internal string SelectedServer { get; set; } = "";

        [JsonProperty("selectedTeamId")]
        internal int SelectedTeamId { get; set; } = 0;

        [JsonProperty("sendNotification")]
        internal bool SendNotification { get; set; } = false;

        [JsonProperty("sendOnSuccessOnly")]
        internal bool SendOnSuccessOnly { get; set; } = false;

        [JsonProperty("refreshToken")]
        internal string RefreshToken { get; set; } = "";

        [JsonProperty("refreshTokenExpire")]
        internal DateTime RefreshTokenExpire { get; set; } = DateTime.Now;
    }
}
