using Newtonsoft.Json;

namespace PlenBotLogUploader.Aleeva
{
    internal class AleevaResponseStatus
    {
        [JsonProperty("status")]
        internal string Status { get; set; }

        internal bool IsSuccess => (Status ?? "successful") != "failed";
    }
}
