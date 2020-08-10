using Newtonsoft.Json;

namespace PlenBotLogUploader.Aleeva
{
    public partial class AleevaResponseStatus
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        public bool IsSuccess
        {
            get
            {
                return ((Status ?? "successful") != "failed");
            }
        }
    }
}
