using Newtonsoft.Json;

namespace PlenBotLogUploader.PlenyxAPI
{
    public class PlenyxAPIStatus
    {
        [JsonProperty("code")]
        public int? Code { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; } = "";

        public bool IsSuccess() => (Code ?? 400) == 200 || (Code ?? 400) == 201 || (Code ?? 400) == 204;
    }
}
