using System.Collections.Generic;

namespace PlenBotLogUploader.DiscordAPI
{
    public class DiscordAPIJSONContent
    {
        public string Content { get; set; } = "";
        public List<DiscordAPIJSONContentEmbed> Embeds { get; set; }
    }
}
