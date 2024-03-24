using Newtonsoft.Json;
using PlenBotLogUploader.DpsReport.ExtraJson;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlenBotLogUploader.DpsReport
{
    internal sealed class DpsReportJsonExtraJson
    {
        [JsonProperty("eliteInsightsVersion")]
        internal string EliteInsightsVersion { get; set; }

        [JsonProperty("recordedBy")]
        internal string RecordedBy { get; set; }

        [JsonProperty("recordedAccountBy")]
        internal string RecordedByAccountName { get; set; }

        [JsonProperty("timeStartStd")]
        internal DateTime TimeStart { get; set; }

        [JsonProperty("timeEndStd")]
        internal DateTime TimeEnd { get; set; }

        [JsonProperty("duration")]
        internal string Duration { get; set; }

        [JsonProperty("triggerID")]
        internal int TriggerId { get; set; }

        [JsonProperty("fightName")]
        internal string FightName { get; set; }

        [JsonProperty("gw2Build")]
        internal int GameBuild { get; set; }

        [JsonProperty("fightIcon")]
        internal string FightIcon { get; set; }

        [JsonProperty("isCM")]
        internal bool IsCm { get; set; }

        [JsonProperty("targets")]
        internal Target[] Targets { get; set; }

        [JsonProperty("players")]
        internal Player[] Players { get; set; }

        internal Target PossiblyLastTarget
        {
            get
            {
                if (TriggerId == (int)BossIds.Cerus)
                {
                    return TargetsByTotalHealth.FirstOrDefault();
                }
                return TargetsByTotalHealth.FirstOrDefault(x => x.HealthPercentBurned <= 98.6);
            }
        }

        private Target[] TargetsByTotalHealth => Targets.OrderByDescending(x => x.TotalHealth).ToArray();


        internal bool IsLegendaryCm
        {
            get
            {
                if (TriggerId != (int)BossIds.Cerus)
                {
                    return false;
                }
                var cerus = TargetsByTotalHealth.FirstOrDefault();
                if (cerus is null)
                {
                    return false;
                }
                return cerus.TotalHealth >= 120_000_000;
            }
        }

        internal Dictionary<Player, int> GetPlayerTargetDPS()
        {
            var dict = new Dictionary<Player, int>();
            foreach (var player in Players.AsSpan())
            {
                var damage = player.DpsTargets
                    .Select(x => x[0].Dps)
                    .Sum();
                dict.Add(player, damage);
            }
            return dict;
        }
    }
}
