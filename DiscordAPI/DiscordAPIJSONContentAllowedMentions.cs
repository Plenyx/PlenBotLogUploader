using Newtonsoft.Json;

namespace PlenBotLogUploader.DiscordAPI
{
    internal sealed class DiscordAPIJSONContentAllowedMentions
    {
        /// <summary>
        /// list of allowed mention types
        /// </summary>
        [JsonProperty("parse")]
        internal string[] Parse { get; set; } = new string[] { "roles", "users", "everyone" };
    }
}
