using Hardstuck.Http;
using Newtonsoft.Json;
using PlenBotLogUploader.DpsReport;
using PlenBotLogUploader.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlenBotLogUploader.RemotePing
{
    internal sealed class PingConfiguration
    {
        [JsonProperty("isActive")]
        internal bool Active { get; set; } = false;

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

        internal async Task<bool> PingServerAsync(FormMain mainLink, DpsReportJson reportJSON) => await PingServerAsync(this, mainLink, reportJSON);

        internal static async Task<bool> PingServerAsync(PingConfiguration configuration, FormMain mainLink, DpsReportJson reportJSON)
        {
            var result = false;
            using var controller = new HttpClientController();
            if (configuration.Method.Equals(PingMethod.Post) || configuration.Method.Equals(PingMethod.Put) || configuration.Method.Equals(PingMethod.Patch))
            {
                if (configuration.SendDataAsJson)
                {
                    PingData pingData = null;
                    if (reportJSON is not null)
                    {
                        pingData = new PingData()
                        {
                            Permalink = reportJSON.ConfigAwarePermalink,
                            BossId = reportJSON.ExtraJson?.TriggerId ?? reportJSON.Encounter.BossId,
                            Success = (reportJSON.Encounter.Success ?? false),
                            ArcVersion = $"{reportJSON.Evtc.Type}{reportJSON.Evtc.Version}",
                            GW2Build = reportJSON.ExtraJson?.GameBuild ?? reportJSON.Encounter.GameBuild ?? 0,
                            FightName = reportJSON.ExtraJson?.FightName ?? reportJSON.Encounter.Boss,
                            LogTimestamp = reportJSON.ExtraJson?.TimeStart.ToLocalTimeZoneString() ?? DateTime.UnixEpoch.AddSeconds(reportJSON.EncounterTime ?? 0).ToLocalTimeZoneString() ?? "unknown",
                            DurationMs = reportJSON.ExtraJson?.DurationMs ?? ((ulong)(reportJSON.Encounter.Duration ?? 0)),
                            IsEmboldened = reportJSON.Emboldened,
                            IsChallengeMode = reportJSON.ChallengeMode,
                            IsLegendaryChallengeMode = reportJSON.LegendaryChallengeMode,
                            Players = reportJSON.ExtraJson?.Players.Where(x => !x.FriendlyNpc).Select(x => x.Account).ToArray() ?? reportJSON.Players.Select(x => x.Value.DisplayName).ToArray(),
                            LogErrors = reportJSON.ExtraJson?.LogErrors ?? [],
                        };
                    }

                    if (configuration.Authentication.Active && configuration.Authentication.UseAsAuth)
                    {
                        controller.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(configuration.Authentication.AuthName, configuration.Authentication.AuthToken);
                    }
                    using var content = new StringContent(JsonConvert.SerializeObject(pingData), Encoding.UTF8, "application/json");
                    try
                    {
                        using var responseMessage = configuration.Method.Equals(PingMethod.Put) ?
                            await controller.PutAsync(configuration.Url, content) :
                                (configuration.Method.Equals(PingMethod.Patch) ?
                                    await controller.PatchAsync(configuration.Url, content) :
                                    await controller.PostAsync(configuration.Url, content));
                        var response = await responseMessage.Content.ReadAsStringAsync();
                        if (response.Contains("msg"))
                        {
                            var statusJSON = JsonConvert.DeserializeObject<PingResponse>(response);
                            if (responseMessage.IsSuccessStatusCode)
                            {
                                mainLink?.AddToText($">:> Log {reportJSON.UrlId} pinged. {statusJSON.Message} (code: {responseMessage.StatusCode})");
                                result = true;
                            }
                            else
                            {
                                mainLink?.AddToText($">:> Log {reportJSON.UrlId} couldn't be pinged. {statusJSON.Message} (code: {responseMessage.StatusCode})");
                            }
                        }
                        else
                        {
                            if (responseMessage.IsSuccessStatusCode)
                            {
                                mainLink?.AddToText($">:> Log {reportJSON.UrlId} pinged. (code: {responseMessage.StatusCode})");
                                result = true;
                            }
                            else
                            {
                                mainLink?.AddToText($">:> Log {reportJSON.UrlId} couldn't be pinged. (code: {responseMessage.StatusCode})");
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
                    if (reportJSON is not null)
                    {
                        fields.Add("permalink", reportJSON.ConfigAwarePermalink);
                        fields.Add("bossId", reportJSON.ExtraJson?.TriggerId.ToString() ?? reportJSON.Encounter.BossId.ToString());
                        fields.Add("success", (reportJSON.Encounter.Success ?? false).ToString().ToLower());
                        fields.Add("arcVersion", $"{reportJSON.Evtc.Type}{reportJSON.Evtc.Version}");
                        fields.Add("gw2Build", reportJSON.ExtraJson?.GameBuild.ToString() ?? reportJSON.Encounter.GameBuild?.ToString() ?? "unknown");
                        fields.Add("fightName", reportJSON.ExtraJson?.FightName ?? reportJSON.Encounter.Boss);
                        fields.Add("logTimestamp", reportJSON.ExtraJson?.TimeStart.ToLocalTimeZoneString() ?? DateTime.UnixEpoch.AddSeconds(reportJSON.EncounterTime ?? 0).ToLocalTimeZoneString() ?? "unknown");
                        fields.Add("durationMs", reportJSON.ExtraJson?.DurationMs.ToString() ?? ((long)(reportJSON.Encounter.Duration ?? 0)).ToString());
                        fields.Add("isEmboldened", reportJSON.Emboldened.ToString().ToLower());
                        fields.Add("isCM", reportJSON.ChallengeMode.ToString().ToLower());
                        fields.Add("isLCM", reportJSON.LegendaryChallengeMode.ToString().ToLower());
                        fields.Add("players", string.Join(';', reportJSON.ExtraJson?.Players.Where(x => !x.FriendlyNpc).Select(x => x.Account).ToList() ?? reportJSON.Players.Select(x => x.Value.DisplayName).ToList()));
                    }
                    if (configuration.Authentication.Active)
                    {
                        if (!configuration.Authentication.UseAsAuth)
                        {
                            fields.Add(configuration.Authentication.AuthName, configuration.Authentication.AuthToken);
                        }
                        else
                        {
                            controller.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(configuration.Authentication.AuthName, configuration.Authentication.AuthToken);
                        }
                    }
                    using var content = new FormUrlEncodedContent(fields);
                    try
                    {
                        using var responseMessage = configuration.Method.Equals(PingMethod.Put) ?
                            await controller.PutAsync(configuration.Url, content) :
                                (configuration.Method.Equals(PingMethod.Patch) ?
                                    await controller.PatchAsync(configuration.Url, content) :
                                    await controller.PostAsync(configuration.Url, content));
                        var response = await responseMessage.Content.ReadAsStringAsync();
                        if (response.Contains("msg"))
                        {
                            var statusJSON = JsonConvert.DeserializeObject<PingResponse>(response);
                            if (responseMessage.IsSuccessStatusCode)
                            {
                                mainLink?.AddToText($">:> Log {reportJSON.UrlId} pinged. {statusJSON.Message} (code: {responseMessage.StatusCode})");
                                result = true;
                            }
                            else
                            {
                                mainLink?.AddToText($">:> Log {reportJSON.UrlId} couldn't be pinged. {statusJSON.Message} (code: {responseMessage.StatusCode})");
                            }
                        }
                        else
                        {
                            if (responseMessage.IsSuccessStatusCode)
                            {
                                mainLink?.AddToText($">:> Log {reportJSON.UrlId} pinged. (code: {responseMessage.StatusCode})");
                                result = true;
                            }
                            else
                            {
                                mainLink?.AddToText($">:> Log {reportJSON.UrlId} couldn't be pinged. (code: {responseMessage.StatusCode})");
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
                if (reportJSON is not null)
                {
                    var success = (reportJSON.Encounter.Success ?? false).ToString().ToLower();
                    var encounterInfo = $"bossId={reportJSON.Encounter.BossId}&success={success}&arcVersion={reportJSON.Evtc.Type}{reportJSON.Evtc.Version}&permalink={System.Web.HttpUtility.UrlEncode(reportJSON.ConfigAwarePermalink)}";
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
                        controller.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(configuration.Authentication.AuthName, configuration.Authentication.AuthToken);
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
                        var statusJSON = JsonConvert.DeserializeObject<PingResponse>(response);
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            mainLink?.AddToText($">:> Log {reportJSON.UrlId} pinged. {statusJSON.Message} (code: {responseMessage.StatusCode})");
                            result = true;
                        }
                        else
                        {
                            mainLink?.AddToText($">:> Log {reportJSON.UrlId} couldn't be pinged. {statusJSON.Message} (code: {responseMessage.StatusCode})");
                        }
                    }
                    else
                    {
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            mainLink?.AddToText($">:> Log {reportJSON.UrlId} pinged. (code: {responseMessage.StatusCode})");
                            result = true;
                        }
                        else
                        {
                            mainLink?.AddToText($">:> Log {reportJSON.UrlId} couldn't be pinged. (code: {responseMessage.StatusCode})");
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
}
