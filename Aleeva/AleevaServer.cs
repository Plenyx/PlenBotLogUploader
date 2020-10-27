using Newtonsoft.Json;

namespace PlenBotLogUploader.Aleeva
{
    public class AleevaServer
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        public override string ToString() => $"{Name} ({ID})";
    }
}
