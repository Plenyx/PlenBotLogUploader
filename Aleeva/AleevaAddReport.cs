using Newtonsoft.Json;

namespace PlenBotLogUploader.Aleeva
{
    public class AleevaAddReport
    {
        [JsonProperty("sendNotification")]
        public bool SendNotification { get; set; }

        [JsonProperty("notificationServerId")]
        public string NotificationServerId { get; set; }

        [JsonProperty("notificationChannelId")]
        public string NotificationChannelId { get; set; }

        [JsonProperty("dpsReportPermalink")]
        public string DPSReportPermalink { get; set; }
    }
}
