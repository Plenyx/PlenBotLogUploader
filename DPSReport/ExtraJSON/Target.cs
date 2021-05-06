using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlenBotLogUploader.DPSReport.ExtraJSON
{
    public class Target
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("dpsAll")]
        public List<DpsAll> DpsAll { get; set; }

        [JsonProperty("statsAll")]
        public List<StatsAll> StatsAll { get; set; }

        [JsonProperty("defenses")]
        public List<Defenses> Defenses { get; set; }
    }
}
