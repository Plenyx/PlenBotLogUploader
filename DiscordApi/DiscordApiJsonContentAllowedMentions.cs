using Newtonsoft.Json;

namespace PlenBotLogUploader.DiscordApi;

internal sealed class DiscordApiJsonContentAllowedMentions
{
    private static readonly string[] AllMentions = ["roles", "users", "everyone"];

    /// <summary>
    ///     list of allowed mention types
    /// </summary>
    [JsonProperty("parse")]
    internal string[] Parse { get; set; } = AllMentions;
}
