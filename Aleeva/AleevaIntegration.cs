using Newtonsoft.Json;

namespace PlenBotLogUploader.Aleeva
{
    internal class AleevaIntegration
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
    }
}
