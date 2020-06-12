using Newtonsoft.Json;

namespace PlenBotLogUploader.DiscordAPI
{
    /// <summary>
    /// Discord embedded rich content's author object
    /// </summary>
    public class DiscordAPIJSONContentEmbedAuthor
    {
        /// <summary>
        /// author's name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// url that can be clicked in the author part of the embed
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
