using Newtonsoft.Json;

namespace PlenBotLogUploader.Aleeva
{
    internal partial class AleevaResponseStatus
    {
        [JsonProperty("status")]
        internal string Status { get; set; }

        internal bool IsSuccess => (Status ?? "successful") != "failed";
    }
}
