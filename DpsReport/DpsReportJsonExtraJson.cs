using Newtonsoft.Json;
using PlenBotLogUploader.DpsReport.ExtraJson;
using System;
using System.Collections.Generic;
using ZLinq;

namespace PlenBotLogUploader.DpsReport;

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

    [JsonProperty("durationMs")]
    internal ulong DurationMs { get; set; }

    [JsonProperty("success")]
    internal bool Success { get; set; }

    [JsonProperty("triggerID")]
    internal int TriggerId { get; set; }

    [JsonProperty("fightName")]
    internal string FightName { get; set; }

    [JsonProperty("gw2Build")]
    internal ulong GameBuild { get; set; }

    [JsonProperty("fightIcon")]
    internal string FightIcon { get; set; }

    [JsonProperty("isCM")]
    internal bool IsCm { get; set; }

    [JsonProperty("isLegendaryCM")]
    internal bool IsLegendaryCm { get; set; }

    [JsonProperty("targets")]
    internal Target[] Targets { get; set; }

    [JsonProperty("players")]
    internal Player[] Players { get; set; }

    [JsonProperty("phases")]
    internal Phase[] Phases { get; set; }

    [JsonProperty("logErrors")]
    internal string[] LogErrors { get; set; }

    private Phase LastNonBreakbarPhase => GetLastNonBreakbarPhase();

    private List<Target> GetTargetsByIndexes(List<int> indexes)
    {
        var result = new List<Target>();
        foreach (var targetIndex in indexes.AsValueEnumerable())
        {
            result.Add(Targets[targetIndex]);
        }
        return result;
    }

    internal Dictionary<Player, int> GetPlayerTargetDps()
    {
        var dict = new Dictionary<Player, int>();
        foreach (var player in Players.AsValueEnumerable())
        {
            var damage = player.DpsTargets
                .AsValueEnumerable()
                .Select(x => x[0].Dps)
                .Sum();
            dict.Add(player, damage);
        }
        return dict;
    }

    private Phase GetLastNonBreakbarPhase()
    {
        Phase lastNonBreakbarPhase = null;
        foreach (var phase in Phases.AsValueEnumerable())
        {
            if (!phase?.BreakbarPhase ?? false)
            {
                lastNonBreakbarPhase = phase;
            }
        }
        return lastNonBreakbarPhase ?? (Phases.Length > 0 ? Phases[0] : null);
    }

    internal string GetLastPhaseName() => LastNonBreakbarPhase?.Name ?? "Unknown phase";

    internal string GetLastPhaseTargets()
    {
        var lastPhase = LastNonBreakbarPhase;
        if (lastPhase is null)
        {
            return "";
        }
        var resultTargetTexts = new List<string>();
        var phaseTargetsIndexes = lastPhase.GetMainAndBlockingTargetIndexes();
        if (phaseTargetsIndexes.Count == 0)
        {
            return "No phase targets found";
        }
        var phaseTargets = GetTargetsByIndexes(phaseTargetsIndexes);
        foreach (var target in phaseTargets.AsValueEnumerable())
        {
            resultTargetTexts.Add($"{target.Name} - {Math.Round(100 - target.HealthPercentBurned, 2)}%");
        }
        return string.Join(" | ", resultTargetTexts);
    }
}
