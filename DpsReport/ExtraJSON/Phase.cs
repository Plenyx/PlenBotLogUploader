using Newtonsoft.Json;
using System.Collections.Generic;
using ZLinq;

namespace PlenBotLogUploader.DpsReport.ExtraJson;

internal sealed class Phase
{
    [JsonProperty("start")]
    internal long Start { get; set; }

    [JsonProperty("end")]
    internal long End { get; set; }

    [JsonProperty("name")]
    internal string Name { get; set; }

    [JsonProperty("targetPriorities")]
    internal Dictionary<int, string> TargetPriorities { get; set; }

    [JsonProperty("breakbarPhase")]
    internal bool BreakbarPhase { get; set; }

    internal List<int> GetMainAndBlockingTargetIndexes()
    {
        var result = new List<int>();
        foreach (var targetIndex in TargetPriorities.Keys.AsValueEnumerable())
        {
            var targetType = TargetPriorities[targetIndex];
            if (targetType.Equals("MAIN") || targetType.Equals("BLOCKING"))
            {
                result.Add(targetIndex);
            }
        }
        return result;
    }
}
