using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlenBotLogUploader.DiscordApi
{
    /// <summary>
    /// Discord Message content
    /// </summary>
    internal sealed class DiscordApiJsonContent
    {
        /// <summary>
        /// the message contents (up to 2000 characters)
        /// </summary>
        [JsonProperty("content")]
        internal string Content { get; set; } = "";

        /// <summary>
        /// embedded (Discord) rich content
        /// </summary>
        [JsonProperty("embeds")]
        internal List<DiscordApiJsonContentEmbed> Embeds { get; set; }

        /// <summary>
        /// allowed mentions for the message (content)
        /// </summary>
        [JsonProperty("allowed_mentions")]
        internal DiscordApiJsonContentAllowedMentions AllowedMentions { get; set; } = new DiscordApiJsonContentAllowedMentions();
    }
}
