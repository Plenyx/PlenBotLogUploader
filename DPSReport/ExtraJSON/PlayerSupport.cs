using Newtonsoft.Json;

namespace PlenBotLogUploader.DPSReport.ExtraJSON
{
    public class PlayerSupport
    {
        [JsonProperty("condiCleanse")]
        public int CondiCleanse { get; set; }

        [JsonProperty("condiCleanseSelf")]
        public int CondiCleanseSelf { get; set; }

        public int CondiCleanseTotal
        {
            get
            {
                return CondiCleanse + CondiCleanseSelf;
            }
        }

        [JsonProperty("boonStrips")]
        public int BoonStrips { get; set; }
    }
}
