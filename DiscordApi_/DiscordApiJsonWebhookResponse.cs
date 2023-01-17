using Newtonsoft.Json;

namespace PlenBotLogUploader.DiscordApi
{
    /// <summary>
    /// Discord's response to CreateMessage endpoint
    /// </summary>
    internal sealed class DiscordApiJsonWebhookResponse
    {
        // On success
        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("channel_id")]
        internal string ChannelId { get; set; }

        [JsonProperty("token")]
        internal string Token { get; set; }

        [JsonProperty("avatar")]
        internal string Avatar { get; set; }

        [JsonProperty("guild_id")]
        internal string GuildId { get; set; }

        [JsonProperty("id")]
        internal string Id { get; set; }

        // On fail
        [JsonProperty("code")]
        internal int? Code { get; set; }

        [JsonProperty("message")]
        internal string Message { get; set; }

        internal bool Success => Code is null;
    }
}
