using Newtonsoft.Json;
using System.Collections.Generic;

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
