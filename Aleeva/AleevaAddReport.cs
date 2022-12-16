using Newtonsoft.Json;

namespace PlenBotLogUploader.Aleeva
{
    internal sealed class AleevaAddReport
    {
        [JsonProperty("sendNotification")]
        internal bool SendNotification { get; set; }

        [JsonProperty("notificationServerId")]
        internal string NotificationServerId { get; set; }

        [JsonProperty("notificationChannelId")]
        internal string NotificationChannelId { get; set; }

        [JsonProperty("dpsReportPermalink")]
        internal string DpsReportPermalink { get; set; }
    }
}
