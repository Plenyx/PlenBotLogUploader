using Newtonsoft.Json;
using PlenBotLogUploader.DPSReport.ExtraJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace PlenBotLogUploader.DPSReport
{
    internal sealed class DPSReportJSONExtraJSON
    {
        [JsonProperty("eliteInsightsVersion")]
        internal string EliteInsightsVersion { get; set; }

        [JsonProperty("recordedBy")]
        internal string RecordedBy { get; set; }

        [JsonProperty("timeStart")]
        internal DateTime TimeStart { get; set; }

        [JsonProperty("timeEnd")]
        internal DateTime TimeEnd { get; set; }

        [JsonProperty("duration")]
        internal string Duration { get; set; }

        [JsonProperty("triggerID")]
        internal int TriggerID { get; set; }

        [JsonProperty("fightName")]
        internal string FightName { get; set; }

        [JsonProperty("gw2Build")]
        internal int GW2Build { get; set; }

        [JsonProperty("fightIcon")]
        internal string FightIcon { get; set; }

        [JsonProperty("isCM")]
        internal bool IsCM { get; set; }

        [JsonProperty("targets")]
        internal List<Target> Targets { get; set; }

        [JsonProperty("players")]
        internal List<Player> Players { get; set; }

        internal Target PossiblyLastTarget => Targets.OrderByDescending(x => x.TotalHealth).FirstOrDefault(x => x.HealthPercentBurned <= 99);

        internal Dictionary<Player, int> GetPlayerTargetDPS()
        {
            var dict = new Dictionary<Player, int>();
            foreach (var player in CollectionsMarshal.AsSpan(Players))
            {
                var damage = player.DpsTargets
                    .Select(x => x[0].DPS)
                    .Sum();
                dict.Add(player, damage);
            }
            return dict;
        }
    }
}
