using Newtonsoft.Json;

namespace PlenBotLogUploader.PlenyxAPI
{
    public class PlenyxAPIPingTest
    {
        [JsonProperty("status")]
        public PlenyxAPIStatus Status { get; set; }

        [JsonProperty("error")]
        public PlenyxAPIStatus Error { get; set; }

        public bool IsValid() => (Status?.Code ?? 400) == 200 || (Status?.Code ?? 400) == 201;
    }
}
