using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.Tools;
using System.Collections.Generic;
using System.Text;

namespace PlenBotLogUploader.DpsReport;

/// <summary>
///     An object holding boss information
/// </summary>
[JsonObject(MemberSerialization.OptIn)]
internal sealed class BossData : IListViewItemInfo<BossData>
{
    /// <summary>
    ///     ID of the encounter
    /// </summary>
    [JsonProperty("bossId")]
    internal int BossId { get; set; }

    /// <summary>
    ///     Name of the encounter
    /// </summary>
    [JsonProperty("name")]
    internal string Name { get; set; }

    /// <summary>
    ///     Internal description of the boss, only visible in the Uploader app
    /// </summary>
    [JsonProperty("internalDescription")]
    internal string InternalDescription { get; set; } = "";

    /// <summary>
    ///     Twitch message when encounter is a success
    /// </summary>
    [JsonProperty("successMsg")]
    internal string SuccessMsg { get; set; } = ApplicationSettings.Current.BossTemplate.SuccessText;

    /// <summary>
    ///     Twitch message when encounter is a failure
    /// </summary>
    [JsonProperty("failMsg")]
    internal string FailMsg { get; set; } = ApplicationSettings.Current.BossTemplate.FailText;

    /// <summary>
    ///     Icon used for Discord webhooks
    /// </summary>
    [JsonProperty("icon")]
    internal string Icon { get; set; } = "";

    /// <summary>
    ///     Type of the boss
    /// </summary>
    [JsonProperty("type")]
    internal BossType Type { get; set; } = BossType.None;

    /// <summary>
    ///     Indication if the encounter is an event
    /// </summary>
    [JsonProperty("isEvent")]
    internal bool Event { get; set; }

    string IListViewItemInfo<BossData>.NameToDisplay => BossId.ToString();

    string IListViewItemInfo<BossData>.TextToDisplay => string.IsNullOrWhiteSpace(InternalDescription) ? Name : $"{Name} [{InternalDescription}]";

    bool IListViewItemInfo<BossData>.CheckedToDisplay => false;

    List<ListViewItemCustom<BossData>> IListViewItemInfo<BossData>.ConnectedItems { get; } = [];

    internal string FightName(DpsReportJson reportJson)
    {
        if (!reportJson.ChallengeMode)
        {
            return Name;
        }
        var builder = new StringBuilder(Name);
        builder.Append(' ');
        if (reportJson.LegendaryChallengeMode)
        {
            builder.Append('L');
        }
        builder.Append("CM");
        return builder.ToString();
    }

    /// <summary>
    ///     Formats Twitch message based on the dps.report's JSON response.
    /// </summary>
    /// <param name="reportJson">dps.report's JSON response</param>
    /// <param name="pullCounter">the current pull counter</param>
    /// <returns>Formatted string</returns>
    internal string TwitchMessageFormat(DpsReportJson reportJson, int pullCounter)
    {
        var format = reportJson.Encounter.Success ?? false ? SuccessMsg : FailMsg;
        format = format.Replace("<boss>", FightName(reportJson));
        format = format.Replace("<log>", reportJson.ConfigAwarePermalink);
        format = format.Replace("<pulls>", pullCounter.ToString());
        format = reportJson.ExtraJson is not null
            ? format.Replace("<percent>", $"{reportJson.ExtraJson.GetLastPhaseName()} - {reportJson.ExtraJson.GetLastPhaseTargets()}")
            : format.Replace("<percent>", "");
        return format;
    }
}
