using Hardstuck.Http;
using Newtonsoft.Json;
using PlenBotLogUploader.DpsReport;
using PlenBotLogUploader.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PlenBotLogUploader.RemotePing;

internal sealed class PingConfiguration
{
    [JsonProperty("isActive")]
    internal bool Active { get; set; }

    [JsonProperty("name")]
    internal string Name { get; set; } = "";

    [JsonProperty("url")]
    internal string Url { get; set; } = "";

    [JsonProperty("method")]
    internal PingMethod Method { get; set; } = PingMethod.Post;

    [JsonProperty("sendAsJson")]
    internal bool SendDataAsJson { get; set; } = true;

    [JsonProperty("authentication")]
    internal PingAuthentication Authentication { get; set; }

    internal async Task<bool> PingServerAsync(FormMain mainLink, DpsReportJson reportJson) => await PingServerAsync(this, mainLink, reportJson);

    private static async Task<bool> PingServerAsync(PingConfiguration configuration, FormMain mainLink, DpsReportJson reportJson)
    {
        var result = false;
        using var controller = new HttpClientController();
        if (configuration.Method.Equals(PingMethod.Post) || configuration.Method.Equals(PingMethod.Put) || configuration.Method.Equals(PingMethod.Patch))
        {
            if (configuration.SendDataAsJson)
            {
                PingData pingData = null;
                if (reportJson is not null)
                {
                    pingData = new PingData
                    {
                        Permalink = reportJson.ConfigAwarePermalink,
                        BossId = reportJson.ExtraJson?.TriggerId ?? reportJson.Encounter.BossId,
                        Success = reportJson.Encounter.Success ?? false,
                        ArcVersion = $"{reportJson.Evtc.Type}{reportJson.Evtc.Version}",
                        Gw2Build = reportJson.ExtraJson?.GameBuild ?? reportJson.Encounter.GameBuild ?? 0,
                        FightName = reportJson.ExtraJson?.FightName ?? reportJson.Encounter.Boss,
                        LogTimestamp = reportJson.ExtraJson?.TimeStart.ToLocalTimeZoneString() ?? DateTime.UnixEpoch.AddSeconds(reportJson.EncounterTime ?? 0).ToLocalTimeZoneString() ?? "unknown",
                        DurationMs = reportJson.ExtraJson?.DurationMs ?? (ulong)(reportJson.Encounter.Duration ?? 0),
                        IsEmboldened = reportJson.Emboldened,
                        IsChallengeMode = reportJson.ChallengeMode,
                        IsLegendaryChallengeMode = reportJson.LegendaryChallengeMode,
                        Players = reportJson.ExtraJson?.Players.Where(x => !x.FriendlyNpc).Select(x => x.Account).ToArray() ?? reportJson.Players.Select(x => x.Value.DisplayName).ToArray(),
                        LogErrors = reportJson.ExtraJson?.LogErrors ?? [],
                    };
                }

                if (configuration.Authentication.Active && configuration.Authentication.UseAsAuth)
                {
                    controller.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(configuration.Authentication.AuthName, configuration.Authentication.AuthToken);
                }
                using var content = new StringContent(JsonConvert.SerializeObject(pingData), Encoding.UTF8, "application/json");
                try
                {
                    using var responseMessage = configuration.Method.Equals(PingMethod.Put) ?
                        await controller.PutAsync(configuration.Url, content) :
                        configuration.Method.Equals(PingMethod.Patch) ?
                            await controller.PatchAsync(configuration.Url, content) :
                            await controller.PostAsync(configuration.Url, content);
                    var response = await responseMessage.Content.ReadAsStringAsync();
                    if (response.Contains("msg"))
                    {
                        var statusJson = JsonConvert.DeserializeObject<PingResponse>(response);
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            mainLink?.AddToText($">:> Log {reportJson.UrlId} pinged. {statusJson.Message} (code: {responseMessage.StatusCode})");
                            result = true;
                        }
                        else
                        {
                            mainLink?.AddToText($">:> Log {reportJson.UrlId} couldn't be pinged. {statusJson.Message} (code: {responseMessage.StatusCode})");
                        }
                    }
                    else
                    {
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            mainLink?.AddToText($">:> Log {reportJson.UrlId} pinged. (code: {responseMessage.StatusCode})");
                            result = true;
                        }
                        else
                        {
                            mainLink?.AddToText($">:> Log {reportJson.UrlId} couldn't be pinged. (code: {responseMessage.StatusCode})");
                        }
                    }
                }
                catch
                {
                    mainLink?.AddToText($">:> Unable to ping the server \"{configuration.Name}\", check the settings or the server is not responding.");
                }
            }
            else
            {
                var fields = new Dictionary<string, string>();
                if (reportJson is not null)
                {
                    fields.Add("permalink", reportJson.ConfigAwarePermalink);
                    fields.Add("bossId", reportJson.ExtraJson?.TriggerId.ToString() ?? reportJson.Encounter.BossId.ToString());
                    fields.Add("success", (reportJson.Encounter.Success ?? false).ToString().ToLower());
                    fields.Add("arcVersion", $"{reportJson.Evtc.Type}{reportJson.Evtc.Version}");
                    fields.Add("gw2Build", reportJson.ExtraJson?.GameBuild.ToString() ?? reportJson.Encounter.GameBuild?.ToString() ?? "unknown");
                    fields.Add("fightName", reportJson.ExtraJson?.FightName ?? reportJson.Encounter.Boss);
                    fields.Add("logTimestamp", reportJson.ExtraJson?.TimeStart.ToLocalTimeZoneString() ?? DateTime.UnixEpoch.AddSeconds(reportJson.EncounterTime ?? 0).ToLocalTimeZoneString() ?? "unknown");
                    fields.Add("durationMs", reportJson.ExtraJson?.DurationMs.ToString() ?? ((long)(reportJson.Encounter.Duration ?? 0)).ToString());
                    fields.Add("isEmboldened", reportJson.Emboldened.ToString().ToLower());
                    fields.Add("isCM", reportJson.ChallengeMode.ToString().ToLower());
                    fields.Add("isLCM", reportJson.LegendaryChallengeMode.ToString().ToLower());
                    fields.Add("players", string.Join(';', reportJson.ExtraJson?.Players.Where(x => !x.FriendlyNpc).Select(x => x.Account).ToList() ?? reportJson.Players.Select(x => x.Value.DisplayName).ToList()));
                }
                if (configuration.Authentication.Active)
                {
                    if (!configuration.Authentication.UseAsAuth)
                    {
                        fields.Add(configuration.Authentication.AuthName, configuration.Authentication.AuthToken);
                    }
                    else
                    {
                        controller.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(configuration.Authentication.AuthName, configuration.Authentication.AuthToken);
                    }
                }
                using var content = new FormUrlEncodedContent(fields);
                try
                {
                    using var responseMessage = configuration.Method.Equals(PingMethod.Put) ?
                        await controller.PutAsync(configuration.Url, content) :
                        configuration.Method.Equals(PingMethod.Patch) ?
                            await controller.PatchAsync(configuration.Url, content) :
                            await controller.PostAsync(configuration.Url, content);
                    var response = await responseMessage.Content.ReadAsStringAsync();
                    if (response.Contains("msg"))
                    {
                        var statusJson = JsonConvert.DeserializeObject<PingResponse>(response);
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            mainLink?.AddToText($">:> Log {reportJson?.UrlId} pinged. {statusJson.Message} (code: {responseMessage.StatusCode})");
                            result = true;
                        }
                        else
                        {
                            mainLink?.AddToText($">:> Log {reportJson?.UrlId} couldn't be pinged. {statusJson.Message} (code: {responseMessage.StatusCode})");
                        }
                    }
                    else
                    {
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            mainLink?.AddToText($">:> Log {reportJson?.UrlId} pinged. (code: {responseMessage.StatusCode})");
                            result = true;
                        }
                        else
                        {
                            mainLink?.AddToText($">:> Log {reportJson?.UrlId} couldn't be pinged. (code: {responseMessage.StatusCode})");
                        }
                    }
                }
                catch
                {
                    mainLink?.AddToText($">:> Unable to ping the server \"{configuration.Name}\", check the settings or the server is not responding.");
                }
            }
        }
        else if (configuration.Method.Equals(PingMethod.Get) || configuration.Method.Equals(PingMethod.Delete))
        {
            var fullLink = $"{configuration.Url}?";
            if (reportJson is not null)
            {
                var success = (reportJson.Encounter.Success ?? false).ToString().ToLower();
                var encounterInfo = $"bossId={reportJson.Encounter.BossId}&success={success}&arcVersion={reportJson.Evtc.Type}{reportJson.Evtc.Version}&permalink={HttpUtility.UrlEncode(reportJson.ConfigAwarePermalink)}";
                fullLink += encounterInfo;
                if (configuration.Url.Contains('?'))
                {
                    fullLink = $"{configuration.Url}&{encounterInfo}";
                }
            }
            if (configuration.Authentication.Active)
            {
                if (!configuration.Authentication.UseAsAuth)
                {
                    fullLink = $"{fullLink}&{configuration.Authentication.AuthName.ToLower()}={configuration.Authentication.AuthToken}";
                }
                else
                {
                    controller.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(configuration.Authentication.AuthName, configuration.Authentication.AuthToken);
                }
            }
            try
            {
                using var responseMessage = configuration.Method.Equals(PingMethod.Delete) ?
                    await controller.DeleteAsync(fullLink) :
                    await controller.GetAsync(fullLink);
                var response = await responseMessage.Content.ReadAsStringAsync();
                if (response.Contains("msg"))
                {
                    var statusJson = JsonConvert.DeserializeObject<PingResponse>(response);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        mainLink?.AddToText($">:> Log {reportJson?.UrlId} pinged. {statusJson.Message} (code: {responseMessage.StatusCode})");
                        result = true;
                    }
                    else
                    {
                        mainLink?.AddToText($">:> Log {reportJson?.UrlId} couldn't be pinged. {statusJson.Message} (code: {responseMessage.StatusCode})");
                    }
                }
                else
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        mainLink?.AddToText($">:> Log {reportJson?.UrlId} pinged. (code: {responseMessage.StatusCode})");
                        result = true;
                    }
                    else
                    {
                        mainLink?.AddToText($">:> Log {reportJson?.UrlId} couldn't be pinged. (code: {responseMessage.StatusCode})");
                    }
                }
            }
            catch
            {
                mainLink?.AddToText($">:> Unable to ping the server \"{configuration.Name}\", check the settings or the server is not responding.");
            }
        }
        return result;
    }
}
