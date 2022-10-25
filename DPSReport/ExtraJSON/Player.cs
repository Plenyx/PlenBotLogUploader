using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlenBotLogUploader.DPSReport.ExtraJSON
{
    internal sealed class Player
    {
        [JsonProperty("account")]
        internal string Account { get; set; }

        [JsonProperty("group")]
        internal int Group { get; set; }

        [JsonProperty("hasCommanderTag")]
        internal bool IsCommander { get; set; }

        [JsonProperty("profession")]
        internal string Profession { get; set; }

        internal string ProfessionShort => Profession[..3];

        [JsonProperty("friendlyNPC")]
        internal bool FriendNPC { get; set; }

        [JsonProperty("notInSquad")]
        internal bool NotInSquad { get; set; }

        [JsonProperty("support")]
        internal List<PlayerSupport> Support { get; set; }

        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("dpsAll")]
        internal List<DpsAll> DpsAll { get; set; }

        [JsonProperty("dpsTargets")]
        internal List<List<DpsTarget>> DpsTargets { get; set; }

        [JsonProperty("statsTargets")]
        internal List<List<StatsTarget>> StatsTargets { get; set; }

        [JsonProperty("statsAll")]
        internal List<StatsAll> StatsAll { get; set; }

        [JsonProperty("defenses")]
        internal List<Defenses> Defenses { get; set; }
    }
}
