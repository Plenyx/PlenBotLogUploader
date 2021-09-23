using Hardstuck.GuildWars2;
using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings
{
    public class ApplicationSettingsArcUpdate
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; } = false;

        [JsonProperty("notifications")]
        public bool Notifications { get; set; } = true;

        [JsonProperty("renderMode")]
        public GameRenderMode RenderMode { get; set; } = GameRenderMode.DX9;
    }
}
