using Newtonsoft.Json;

namespace PlenBotLogUploader.PlenyxAPI
{
    public class PlenyxAPIPingResponse
    {
        [JsonProperty("msg")]
        public string Message { get; set; }

        [JsonProperty("user_id")]
        public int? UserId { get; set; }

        [JsonProperty("log_id")]
        public string LogId { get; set; } = "";
    }
}
