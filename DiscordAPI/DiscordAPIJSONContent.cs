using System.Collections.Generic;

namespace PlenBotLogUploader.DiscordAPI
{
    public class DiscordAPIJSONContent
    {
        public string content = "";
        public List<DiscordAPIJSONContentEmbed> embeds;
    }

    public class DiscordAPIJSONContentEmbed
    {
        public string title;
        public string description;
        public string url;
        public int color;
        public DiscordAPIJSONContentEmbedThumbnail thumbnail;
        public DiscordAPIJSONContentEmbedFooter footer = new DiscordAPIJSONContentEmbedFooter();
    }

    public class DiscordAPIJSONContentEmbedThumbnail
    {
        public string url;
    }

    public class DiscordAPIJSONContentEmbedFooter
    {
        public string text = "PlenBot Log Uploader";
        public string icon_url = "https://plenbot.net/img/favicon.png";
    }
}
