using Newtonsoft.Json;

namespace PlenBotLogUploader.PlenyxAPI
{
    public class PlenyxAPIPingResponse
    {
        [JsonProperty("status")]
        public PlenyxAPIStatus Status { get; set; }

        [JsonProperty("error")]
        public PlenyxAPIStatus Error { get; set; }

        [JsonProperty("user_id")]
        public int? UserId { get; set; }

        [JsonProperty("log_id")]
        public string LogId { get; set; } = "";
    }
}
