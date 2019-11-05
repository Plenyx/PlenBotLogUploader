namespace PlenBotLogUploader.DiscordAPI
{
    /// <summary>
    /// Discord embedded rich content's field
    /// </summary>
    public class DiscordAPIJSONContentEmbedField
    {
        /// <summary>
        /// name of the field
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// value of the field
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// whether or not this field should display inline
        /// </summary>
        public bool Inline { get; set; } = false;
    }
}
