namespace PlenBotLogUploader.DiscordAPI
{
    public class DiscordAPIJSONContentEmbed
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int Color { get; set; }
        public DiscordAPIJSONContentEmbedThumbnail Thumbnail { get; set; }
        public DiscordAPIJSONContentEmbedFooter Footer { get; set; } = new DiscordAPIJSONContentEmbedFooter();
        public DiscordAPIJSONContentEmbedField[] Fields { get; set; }
    }
}
