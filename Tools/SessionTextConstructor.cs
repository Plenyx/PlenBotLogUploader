using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlenBotLogUploader.DiscordAPI;

namespace PlenBotLogUploader.Tools
{
    public static class SessionTextConstructor
    {
        private static readonly DiscordAPIJSONContentEmbedThumbnail defaultThumbnail = new DiscordAPIJSONContentEmbedThumbnail()
        {
            Url = "https://wiki.guildwars2.com/images/5/5e/Legendary_Insight.png"
        };

        public static DiscordAPIJSONContentEmbed MakeEmbedFromText(string title, string text)
        {
            return new DiscordAPIJSONContentEmbed()
            {
                Title = title,
                Description = text,
                Colour = 32768,
                TimeStamp = DateTime.UtcNow.ToString("yyyy'-'MM'-'ddTHH':'mm':'ssZ"),
                Thumbnail = defaultThumbnail
            };
        }
    }
}
