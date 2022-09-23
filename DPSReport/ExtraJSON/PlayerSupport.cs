using Newtonsoft.Json;

namespace PlenBotLogUploader.DPSReport.ExtraJSON
{
    internal sealed class PlayerSupport
    {
        [JsonProperty("condiCleanse")]
        internal int CondiCleanse { get; set; }

        [JsonProperty("condiCleanseSelf")]
        internal int CondiCleanseSelf { get; set; }

        internal int CondiCleanseTotal => CondiCleanse + CondiCleanseSelf;

        [JsonProperty("boonStrips")]
        internal int BoonStrips { get; set; }
    }
}
