using System.Collections.Generic;
using Newtonsoft.Json;

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
        public string Content { get; set; } = "";

        /// <summary>
        /// embedded (Discord) rich content
        /// </summary>
        [JsonProperty("embeds")]
        public List<DiscordAPIJSONContentEmbed> Embeds { get; set; }
    }
}
