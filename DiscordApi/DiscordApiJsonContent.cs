using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace PlenBotLogUploader.DiscordApi
{
    /// <summary>
    /// Discord Message content
    /// </summary>
    internal sealed class DiscordApiJsonContent
    {
        private static string _spacer = null;

        internal static string Spacer
        {
            get
            {
                if (_spacer is null)
                {
                    var spacerBuilder = new StringBuilder();

                    for (int i = 0; i < 26; i++)
                    {
                        spacerBuilder.Append("〰️");
                    }

                    _spacer = spacerBuilder.ToString();
                }
                return _spacer;
            }
        }

        /// <summary>
        /// the message contents (up to 2000 characters)
        /// </summary>
        [JsonProperty("content")]
        internal string Content { get; set; } = "";

        /// <summary>
        /// embedded (Discord) rich content
        /// </summary>
        [JsonProperty("embeds")]
        internal List<DiscordApiJsonContentEmbed> Embeds { get; set; }

        /// <summary>
        /// allowed mentions for the message (content)
        /// </summary>
        [JsonProperty("allowed_mentions")]
        internal DiscordApiJsonContentAllowedMentions AllowedMentions { get; set; } = new DiscordApiJsonContentAllowedMentions();
    }
}
