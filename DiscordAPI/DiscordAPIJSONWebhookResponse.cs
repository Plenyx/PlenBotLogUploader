using Newtonsoft.Json;

namespace PlenBotLogUploader.DiscordAPI
{
    /// <summary>
    /// Discord's response to CreateMessage endpoint
    /// </summary>
    public class DiscordAPIJSONWebhookResponse
    {
        // On success
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("channel_id")]
        public string Channel_id { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("guild_id")]
        public string Guild_id { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        // On fail
        [JsonProperty("code")]
        public int? Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public bool Success
        {
            get => Code is null;
        }
    }
}
