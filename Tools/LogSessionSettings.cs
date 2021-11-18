using PlenBotLogUploader.DiscordAPI;
using System;
using System.Collections.Generic;

namespace PlenBotLogUploader.Tools
{
    public class LogSessionSettings
    {
        /// <summary>
        /// Log session name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Discord "content" field text
        /// </summary>
        public string ContentText { get; set; }

        /// <summary>
        /// Only show successes
        /// </summary>
        public bool ShowSuccess { get; set; }

        /// <summary>
        /// Session elapsed time
        /// </summary>
        public string ElapsedTime { get; set; }

        /// <summary>
        /// Session elapsed timespan
        /// </summary>
        public TimeSpan ElapsedTimeSpan { get; set; }

        /// <summary>
        /// Sort the logs by LogSessionSortBy
        /// </summary>
        public LogSessionSortBy SortBy { get; set; }

        /// <summary>
        /// Make the WvW summary embed appended to the beginning of the session texts
        /// </summary>
        public bool MakeWvWSummaryEmbed { get; set; }

        /// <summary>
        /// Whether to use SelectedWebhooks for the session ping instead of all active sessions
        /// </summary>
        public bool UseSelectedWebhooksInstead { get; set; }

        /// <summary>
        /// Selected webhooks to be executed
        /// </summary>
        public List<DiscordWebhookData> SelectedWebhooks { get; set; } = new List<DiscordWebhookData>();
    }
}
