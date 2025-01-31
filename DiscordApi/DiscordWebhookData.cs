using Hardstuck.Http;
using Newtonsoft.Json;
using PlenBotLogUploader.Teams;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlenBotLogUploader.DiscordApi;

[JsonObject(MemberSerialization.OptIn)]
internal sealed class DiscordWebhookData
{
    private Team team;
    /// <summary>
    ///     Indicates whether the webhook is currently active
    /// </summary>
    [JsonProperty("isActive")]
    internal bool Active { get; set; }

    /// <summary>
    ///     Name of the webhook
    /// </summary>
    [JsonProperty("name")]
    internal string Name { get; set; }

    /// <summary>
    ///     URL of the webhook
    /// </summary>
    [JsonProperty("url")]
    internal string Url { get; set; }

    /// <summary>
    ///     Indicates whether the webhook is executed only if the encounter is a success
    /// </summary>
    [JsonProperty("successFailToggle")]
    internal DiscordWebhookDataSuccessToggle SuccessFailToggle { get; set; } = DiscordWebhookDataSuccessToggle.OnSuccessAndFailure;

    /// <summary>
    ///     Indicates what type of summary is shown on the webhook
    /// </summary>
    [JsonProperty("summaryType")]
    internal DiscordWebhookDataLogSummaryType SummaryType { get; set; } = DiscordWebhookDataLogSummaryType.SquadAndPlayers;

    /// <summary>
    ///     A list containing boss ids which are omitted to be posted via webhook
    /// </summary>
    [JsonProperty("disabledBosses")]
    internal int[] BossesDisable { get; set; } = [];

    [JsonProperty("allowUnknownBossIds")]
    internal bool AllowUnknownBossIds { get; set; }

    [JsonProperty("teamId")]
    internal int TeamId { get; set; }

    [JsonProperty("includeNormalLogs")]
    internal bool IncludeNormalLogs { get; set; } = true;

    [JsonProperty("includeChallengeModeLogs")]
    internal bool IncludeChallengeModeLogs { get; set; } = true;

    [JsonProperty("includeLegendaryChallengeModeLogs")]
    internal bool IncludeLegendaryChallengeModeLogs { get; set; } = true;

    /// <summary>
    ///     A selected webhook team, with which the webhook should evaluate itself
    /// </summary>
    internal Team Team
    {
        get
        {
            if (this.team is null && Teams.Teams.All.TryGetValue(TeamId, out var team))
            {
                this.team = team;
            }
            return this.team;
        }
        set
        {
            team = value;
            TeamId = value.Id;
        }
    }

    /// <summary>
    ///     Tests whether webhook is valid
    /// </summary>
    /// <param name="httpController">HttpClientController class used for using http connection</param>
    /// <returns>True if webhook is valid, false otherwise</returns>
    internal async Task<bool> TestWebhookAsync(HttpClientController httpController)
    {
        try
        {
            var response = await httpController.DownloadFileToStringAsync(Url);
            var pingTest = JsonConvert.DeserializeObject<DiscordApiJsonWebhookResponse>(response);
            return pingTest?.Success ?? false;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    ///     True if boss is enabled for webhook broadcast, false otherwise; default: true
    /// </summary>
    /// <param name="bossId">Queried boss ID</param>
    internal bool IsBossEnabled(int bossId) => !BossesDisable.Contains(bossId);

    internal static Dictionary<int, DiscordWebhookData> FromJsonString(string jsonString)
    {
        var webhookId = 1;

        var parsedData = JsonConvert.DeserializeObject<IEnumerable<DiscordWebhookData>>(jsonString)
                         ?? throw new JsonException("Could not parse json to WebhookData");

        return parsedData.Select(x => (Key: webhookId++, DiscordWebhookData: x))
            .ToDictionary(x => x.Key, x => x.DiscordWebhookData);
    }
}
