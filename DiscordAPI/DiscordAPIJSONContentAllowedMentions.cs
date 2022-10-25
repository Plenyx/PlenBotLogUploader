using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlenBotLogUploader.DiscordAPI
{
    internal sealed class DiscordAPIJSONContentAllowedMentions
    {
        /// <summary>
        /// list of allowed mention types
        /// </summary>
        [JsonProperty("parse")]
        internal List<string> Parse { get; set; } = new() { "roles", "users", "everyone" };
    }
}
