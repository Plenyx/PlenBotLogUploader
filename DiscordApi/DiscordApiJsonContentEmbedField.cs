using Newtonsoft.Json;

namespace PlenBotLogUploader.DiscordApi;

/// <summary>
///     Discord embedded rich content's field
/// </summary>
internal sealed class DiscordApiJsonContentEmbedField
{
    /// <summary>
    ///     name of the field
    /// </summary>
    [JsonProperty("name")]
    internal string Name { get; set; }

    /// <summary>
    ///     value of the field
    /// </summary>
    [JsonProperty("value")]
    internal string Value { get; set; }

    /// <summary>
    ///     whether this field should be displayed inline
    /// </summary>
    [JsonProperty("inline")]
    internal bool Inline { get; set; }
}
