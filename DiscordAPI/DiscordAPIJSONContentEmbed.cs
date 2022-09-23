using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlenBotLogUploader.DiscordAPI
{
    /// <summary>
    /// Discord embedded rich content
    /// </summary>
    internal sealed class DiscordAPIJSONContentEmbed
    {
        /// <summary>
        /// title of the embed
        /// </summary>
        [JsonProperty("title")]
        internal string Title { get; set; }

        /// <summary>
        /// type of the embed
        /// </summary>
        [JsonProperty("type")]
        internal string Type { get; set; } = "rich";

        /// <summary>
        /// description of the embed
        /// </summary>
        [JsonProperty("description")]
        internal string Description { get; set; }

        /// <summary>
        /// url of the embed
        /// </summary>
        [JsonProperty("url")]
        internal string Url { get; set; }

        /// <summary>
        /// color code of the embed
        /// </summary>
        [JsonProperty("color")]
        internal int Colour { get; set; }

        /// <summary>
        /// timestamp of embed content (in ISO8601)
        /// </summary>
        [JsonProperty("timestamp")]
        internal string TimeStamp { get; set; }

        /// <summary>
        /// author information
        /// </summary>
        [JsonProperty("author")]
        internal DiscordAPIJSONContentEmbedAuthor Author { get; set; } = new DiscordAPIJSONContentEmbedAuthor();

        /// <summary>
        /// thumbnail information
        /// </summary>
        [JsonProperty("thumbnail")]
        internal DiscordAPIJSONContentEmbedThumbnail Thumbnail { get; set; }

        /// <summary>
        /// footer information
        /// </summary>
        [JsonProperty("footer")]
        internal DiscordAPIJSONContentEmbedFooter Footer { get; set; } = new DiscordAPIJSONContentEmbedFooter();

        /// <summary>
        /// fields information
        /// </summary>
        [JsonProperty("fields")]
        internal List<DiscordAPIJSONContentEmbedField> Fields { get; set; }
    }
}
