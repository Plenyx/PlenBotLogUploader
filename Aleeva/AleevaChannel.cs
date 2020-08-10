using Newtonsoft.Json;

namespace PlenBotLogUploader.Aleeva
{
    public class AleevaChannel
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name} ({ID})";
        }
    }
}
