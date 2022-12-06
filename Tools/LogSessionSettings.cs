using PlenBotLogUploader.DiscordApi;
using System;
using System.Collections.Generic;

namespace PlenBotLogUploader.Tools
{
    internal sealed class LogSessionSettings
    {
        /// <summary>
        /// Log session name
        /// </summary>
        internal string Name { get; set; }

        /// <summary>
        /// Discord "content" field text
        /// </summary>
        internal string ContentText { get; set; }

        /// <summary>
        /// Only show successes
        /// </summary>
        internal bool ShowSuccess { get; set; }

        /// <summary>
        /// Session elapsed time
        /// </summary>
        internal string ElapsedTime { get; set; }

        /// <summary>
        /// Session elapsed timespan
        /// </summary>
        internal TimeSpan ElapsedTimeSpan { get; set; }

        /// <summary>
        /// Sort the logs by LogSessionSortBy
        /// </summary>
        internal LogSessionSortBy SortBy { get; set; }

        /// <summary>
        /// Make the WvW summary embed appended to the beginning of the session texts
        /// </summary>
        internal bool MakeWvWSummaryEmbed { get; set; }

        /// <summary>
        /// Whether to use SelectedWebhooks for the session ping instead of all active sessions
        /// </summary>
        internal bool UseSelectedWebhooksInstead { get; set; }

        /// <summary>
        /// Selected webhooks to be executed
        /// </summary>
        internal List<DiscordWebhookData> SelectedWebhooks { get; set; } = new();
    }
}
