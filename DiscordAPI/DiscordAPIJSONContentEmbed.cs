namespace PlenBotLogUploader.DiscordAPI
{
    /// <summary>
    /// Discord embedded rich content
    /// </summary>
    public class DiscordAPIJSONContentEmbed
    {
        /// <summary>
        /// title of embed
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// description of embed
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// url of embed
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// color code of the embed
        /// </summary>
        public int Color { get; set; }
        /// <summary>
        /// thumbnail information
        /// </summary>
        public DiscordAPIJSONContentEmbedThumbnail Thumbnail { get; set; }
        /// <summary>
        /// footer information
        /// </summary>
        public DiscordAPIJSONContentEmbedFooter Footer { get; set; } = new DiscordAPIJSONContentEmbedFooter();
        /// <summary>
        /// fields information
        /// </summary>
        public DiscordAPIJSONContentEmbedField[] Fields { get; set; }
    }
}
