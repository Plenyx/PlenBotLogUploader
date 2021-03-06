﻿using Newtonsoft.Json;
using PlenBotLogUploader.DPSReport.ExtraJSON;
using System;
using System.Linq;
using System.Collections.Generic;

namespace PlenBotLogUploader.DPSReport
{
    public class DPSReportJSONExtraJSON
    {
        [JsonProperty("eliteInsightsVersion")]
        public string EliteInsightsVersion { get; set; }

        [JsonProperty("recordedBy")]
        public string RecordedBy { get; set; }

        [JsonProperty("timeStart")]
        public DateTime TimeStart { get; set; }

        [JsonProperty("timeEnd")]
        public DateTime TimeEnd { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("triggerID")]
        public int TriggerID { get; set; }

        [JsonProperty("fightName")]
        public string FightName { get; set; }

        [JsonProperty("gw2Build")]
        public int GW2Build { get; set; }

        [JsonProperty("fightIcon")]
        public string FightIcon { get; set; }

        [JsonProperty("isCM")]
        public bool IsCM { get; set; }

        [JsonProperty("targets")]
        public List<Target> Targets { get; set; }

        [JsonProperty("players")]
        public List<Player> Players { get; set; }

        public Dictionary<Player, int> PlayerTargetDPS
        {
            get
            {
                var dict = new Dictionary<Player, int>();
                Players.ForEach(player => {
                    var damage = player.DpsTargets
                        .Select(x => x.First().DPS)
                        .Sum();
                    dict.Add(player, damage);
                });
                return dict;
            }
        }
    }
}
