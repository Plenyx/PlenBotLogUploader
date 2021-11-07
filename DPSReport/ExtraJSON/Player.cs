using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlenBotLogUploader.DPSReport.ExtraJSON
{
    public class Player
    {
        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("group")]
        public int Group { get; set; }

        [JsonProperty("profession")]
        public string Profession { get; set; }

        public string ProfessionShort
        {
            get
            {
                return Profession.Substring(0, 3);
            }
        }

        [JsonProperty("friendlyNPC")]
        public bool FriendNPC { get; set; }

        [JsonProperty("notInSquad")]
        public bool NotInSquad { get; set; }

        [JsonProperty("support")]
        public List<PlayerSupport> Support { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("dpsAll")]
        public List<DpsAll> DpsAll { get; set; }

        [JsonProperty("dpsTargets")]
        public List<List<DpsTarget>> DpsTargets { get; set; }

        [JsonProperty("statsAll")]
        public List<StatsAll> StatsAll { get; set; }

        [JsonProperty("defenses")]
        public List<Defenses> Defenses { get; set; }
    }
}
