using Newtonsoft.Json;
using PlenBotLogUploader.DPSReport;
using PlenBotLogUploader.Tools;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlenBotLogUploader.RemotePing
{
    public class PingConfiguration
    {
        [JsonProperty("isActive")]
        public bool Active { get; set; } = false;

        [JsonProperty("name")]
        public string Name { get; set; } = "";

        [JsonProperty("url")]
        public string URL { get; set; } = "";

        [JsonProperty("method")]
        public PingMethod Method { get; set; } = PingMethod.Post;

        [JsonProperty("authentication")]
        public PingAuthentication Authentication { get; set; }

        public async Task<bool> PingServerAsync(FormMain mainLink, DPSReportJSON reportJSON) => await PingServerAsync(this, mainLink, reportJSON);

        public static async Task<bool> PingServerAsync(PingConfiguration configuration, FormMain mainLink, DPSReportJSON reportJSON)
        {
            var result = false;
            using var controller = new HttpClientController();
            if (configuration.Method.Equals(PingMethod.Post) || configuration.Method.Equals(PingMethod.Put))
            {
                var fields = new Dictionary<string, string>();
                if (!(reportJSON is null))
                {
                    fields.Add("permalink", reportJSON.Permalink);
                    fields.Add("bossId", reportJSON.Encounter.BossId.ToString());
                    fields.Add("success", (reportJSON.Encounter.Success ?? false) ? "1" : "0");
                    fields.Add("arcVersion", $"{reportJSON.EVTC.Type}{reportJSON.EVTC.Version}");
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
                    using var responseMessage = (configuration.Method.Equals(PingMethod.Put)) ?
                        await controller.PutAsync(configuration.URL, content) :
                        await controller.PostAsync(configuration.URL, content);
                    var response = await responseMessage.Content.ReadAsStringAsync();
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
                catch
                {
                    mainLink?.AddToText($">:> Unable to ping the server \"{configuration.Name}\", check the settings or the server is not responding.");
                }
            }
            else if (configuration.Method.Equals(PingMethod.Get) || configuration.Method.Equals(PingMethod.Delete))
            {
                var fullLink = $"{configuration.URL}?";
                if (!(reportJSON is null))
                {
                    var success = (reportJSON.Encounter.Success ?? false) ? "1" : "0";
                    var encounterInfo = $"bossId={reportJSON.Encounter.BossId}&success={success}&arcVersion={reportJSON.EVTC.Type}{reportJSON.EVTC.Version}&permalink={System.Web.HttpUtility.UrlEncode(reportJSON.Permalink)}";
                    fullLink = $"{fullLink}{encounterInfo}";
                    if (configuration.URL.Contains("?"))
                    {
                        fullLink = $"{configuration.URL}&{encounterInfo}";
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
                    using var responseMessage = (configuration.Method.Equals(PingMethod.Delete)) ?
                        await controller.DeleteAsync(fullLink) :
                        await controller.GetAsync(fullLink);
                    var response = await responseMessage.Content.ReadAsStringAsync();
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
                catch
                {
                    mainLink?.AddToText($">:> Unable to ping the server \"{configuration.Name}\", check the settings or the server is not responding.");
                }
            }
            return result;
        }
    }
}
