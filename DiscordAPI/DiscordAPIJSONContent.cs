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
        public string Content { get; set; } = "";

        /// <summary>
        /// embedded (Discord) rich content
        /// </summary>
        public List<DiscordAPIJSONContentEmbed> Embeds { get; set; }
    }
}
