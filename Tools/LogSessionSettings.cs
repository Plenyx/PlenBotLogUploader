using PlenBotLogUploader.DiscordAPI;
using System.Collections.Generic;

namespace PlenBotLogUploader.Tools
{
    public class LogSessionSettings
    {
        public string Name { get; set; }

        public string ContentText { get; set; }

        public bool ShowSuccess { get; set; }

        public string ElapsedTime { get; set; }

        public LogSessionSortBy SortBy { get; set; }

        public bool UseSelectedWebhooksInstead { get; set; }

        public List<DiscordWebhookData> SelectedWebhooks { get; set; } = new List<DiscordWebhookData>();
    }
}
