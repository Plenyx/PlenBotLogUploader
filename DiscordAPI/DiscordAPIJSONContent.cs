using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlenBotLogUploader.DiscordAPI
{
    /// <summary>
    /// Discord Message content
    /// </summary>
    public class DiscordAPIJSONContent
    {
        /// <summary>
        /// the message contents (up to 2000 characters)
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// embedded (Discord) rich content
        /// </summary>
        [JsonProperty("embeds")]
        public List<DiscordAPIJSONContentEmbed> Embeds { get; set; }

        /// <summary>
        /// allowed mentions for the message (content)
        /// </summary>
        [JsonProperty("allowed_mentions")]
        public DiscordAPIJSONContentAllowedMentions AllowedMentions { get; set; } = new DiscordAPIJSONContentAllowedMentions();
    }
}
