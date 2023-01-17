using Newtonsoft.Json;

namespace PlenBotLogUploader.DiscordApi
{
    /// <summary>
    /// Discord embedded rich content's thumbnail
    /// </summary>
    internal sealed class DiscordApiJsonContentEmbedThumbnail
    {
        /// <summary>
        /// source url of the thumbnail (only supports http(s) and attachments)
        /// </summary>
        [JsonProperty("url")]
        internal string Url { get; set; }
    }
}
