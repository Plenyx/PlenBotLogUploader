using Newtonsoft.Json;

namespace PlenBotLogUploader.Aleeva
{
    internal sealed class AleevaChannel
    {
        [JsonProperty("id")]
        internal string ID { get; set; }

        [JsonProperty("name")]
        internal string Name { get; set; }

        public override string ToString() => $"{Name} ({ID})";
    }
}
