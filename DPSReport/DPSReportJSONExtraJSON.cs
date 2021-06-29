using Newtonsoft.Json;
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

        public double DurationDouble
        {
            get
            {
                var result = 0d;
                var durationSplit = Duration.Split(' ');
                foreach (var pieceOfDuration in durationSplit)
                {
                    if (pieceOfDuration.Contains('m') && !pieceOfDuration.Contains('s'))
                    {
                        var extraction = pieceOfDuration.Substring(0, pieceOfDuration.Length - 1);
                        result += double.Parse(extraction) * 60;
                    }
                    else if (pieceOfDuration.Contains('m') && pieceOfDuration.Contains('s'))
                    {
                        var extraction = pieceOfDuration.Substring(0, pieceOfDuration.Length - 2);
                        result += double.Parse(extraction) / 1000;
                    }
                    else if (!pieceOfDuration.Contains('m') && pieceOfDuration.Contains('s'))
                    {
                        var extraction = pieceOfDuration.Substring(0, pieceOfDuration.Length - 1);
                        result += double.Parse(extraction);
                    }
                    else if (!pieceOfDuration.Contains('h'))
                    {
                        var extraction = pieceOfDuration.Substring(0, pieceOfDuration.Length - 1);
                        result += double.Parse(extraction) * 3600;
                    }
                }
                return result;
            }
        }

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

        public Dictionary<Player, int> PlayerDamage
        {
            get
            {
                var dict = new Dictionary<Player, int>();
                Players.ForEach(player => {
                    var damage = player.DpsTargets
                        .Select(x => x.First().Damage)
                        .Sum();
                    dict.Add(player, damage);
                });
                return dict;
            }
        }
    }
}
