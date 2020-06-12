using System.Collections.Generic;
using Newtonsoft.Json;

namespace PlenBotLogUploader.DiscordAPI
{
    public class DiscordAPIJSONContentAllowedMentions
    {
        /// <summary>
        /// list of allowed mention types
        /// </summary>
        [JsonProperty("parse")]
        public List<string> Parse { get; set; } = new List<string>() { "roles", "users", "everyone" };
    }
}
