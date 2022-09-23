using Newtonsoft.Json;

namespace PlenBotLogUploader.DiscordAPI
{
    /// <summary>
    /// Discord embedded rich content's author object
    /// </summary>
    internal sealed class DiscordAPIJSONContentEmbedAuthor
    {
        /// <summary>
        /// author's name
        /// </summary>
        [JsonProperty("name")]
        internal string Name { get; set; }

        /// <summary>
        /// url that can be clicked in the author part of the embed
        /// </summary>
        [JsonProperty("url")]
        internal string Url { get; set; }
    }
}
