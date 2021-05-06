using Newtonsoft.Json;

namespace PlenBotLogUploader.DPSReport.ExtraJSON
{
    public class PlayerSupport
    {
        [JsonProperty("condiCleanse")]
        public int CondiCleanse { get; set; }

        [JsonProperty("boonStrips")]
        public int BoonStrips { get; set; }
    }
}
