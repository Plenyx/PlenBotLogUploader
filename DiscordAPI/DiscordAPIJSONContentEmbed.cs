using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlenBotLogUploader.DiscordAPI
{
    /// <summary>
    /// Discord embedded rich content
    /// </summary>
    public class DiscordAPIJSONContentEmbed
    {
        /// <summary>
        /// title of the embed
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// type of the embed
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = "rich";

        /// <summary>
        /// description of the embed
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// url of the embed
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// color code of the embed
        /// </summary>
        [JsonProperty("color")]
        public int Colour { get; set; }

        /// <summary>
        /// timestamp of embed content (in ISO8601)
        /// </summary>
        [JsonProperty("timestamp")]
        public string TimeStamp { get; set; }

        /// <summary>
        /// author information
        /// </summary>
        [JsonProperty("author")]
        public DiscordAPIJSONContentEmbedAuthor Author { get; set; } = new DiscordAPIJSONContentEmbedAuthor();

        /// <summary>
        /// thumbnail information
        /// </summary>
        [JsonProperty("thumbnail")]
        public DiscordAPIJSONContentEmbedThumbnail Thumbnail { get; set; }

        /// <summary>
        /// footer information
        /// </summary>
        [JsonProperty("footer")]
        public DiscordAPIJSONContentEmbedFooter Footer { get; set; } = new DiscordAPIJSONContentEmbedFooter();

        /// <summary>
        /// fields information
        /// </summary>
        [JsonProperty("fields")]
        public List<DiscordAPIJSONContentEmbedField> Fields { get; set; }
    }
}
