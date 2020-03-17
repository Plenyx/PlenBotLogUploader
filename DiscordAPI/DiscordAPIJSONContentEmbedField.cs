using Newtonsoft.Json;

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
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// value of the field
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// whether or not this field should be displayed inline
        /// </summary>
        [JsonProperty("inline")]
        public bool Inline { get; set; } = false;
    }
}
