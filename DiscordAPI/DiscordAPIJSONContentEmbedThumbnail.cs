namespace PlenBotLogUploader.DiscordAPI
{
    /// <summary>
    /// Discord embedded rich content's thumbnail
    /// </summary>
    public class DiscordAPIJSONContentEmbedThumbnail
    {
        /// <summary>
        /// source url of thumbnail (only supports http(s) and attachments)
        /// </summary>
        public string Url { get; set; }
    }
}
