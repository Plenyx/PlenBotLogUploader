﻿using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings
{
    internal sealed class ApplicationSettingsGw2Bot
    {
        [JsonProperty("enabled")]
        internal bool Enabled { get; set; } = false;

        [JsonProperty("apiKey")]
        internal string ApiKey { get; set; } = "";

        [JsonProperty("selectedTeamId")]
        internal int TeamId { get; set; } = 0;

        [JsonProperty("sendOnSuccessOnly")]
        internal bool SendOnSuccessOnly { get; set; } = false;
    }
}
