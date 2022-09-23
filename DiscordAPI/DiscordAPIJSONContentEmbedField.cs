using Newtonsoft.Json;

namespace PlenBotLogUploader.DiscordAPI
{
    /// <summary>
    /// Discord embedded rich content's field
    /// </summary>
    internal sealed class DiscordAPIJSONContentEmbedField
    {
        /// <summary>
        /// name of the field
        /// </summary>
        [JsonProperty("name")]
        internal string Name { get; set; }

        /// <summary>
        /// value of the field
        /// </summary>
        [JsonProperty("value")]
        internal string Value { get; set; }

        /// <summary>
        /// whether or not this field should be displayed inline
        /// </summary>
        [JsonProperty("inline")]
        internal bool Inline { get; set; } = false;
    }
}
