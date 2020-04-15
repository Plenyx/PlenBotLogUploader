using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using PlenBotLogUploader.Tools;
using PlenBotLogUploader.DPSReport;
using PlenBotLogUploader.PlenyxAPI;
using Newtonsoft.Json;

namespace PlenBotLogUploader.RemotePing
{
    public class PingConfiguration
    {
        public bool Active { get; set; } = false;
        public string Name { get; set; } = "";
        public string URL { get; set; } = "";
        public PingMethod Method { get; set; } = PingMethod.Post;
        public PingAuthentication Authentication { get; set; }

        public async Task<bool> PingServerAsync(FormMain mainLink, DPSReportJSON reportJSON) => await PingConfiguration.PingServerAsync(this, mainLink, reportJSON);

        public static async Task<bool> PingServerAsync(PingConfiguration configuration, FormMain mainLink, DPSReportJSON reportJSON)
        {
            bool result = false;
            using (HttpClientController controller = new HttpClientController())
            {
                if (configuration.Method.Equals(PingMethod.Post) || configuration.Method.Equals(PingMethod.Put))
                {
                    var fields = new Dictionary<string, string>();
                    if (reportJSON != null)
                    {
                        fields.Add("permalink", reportJSON.Permalink);
                        fields.Add("bossId", reportJSON.Encounter.BossId.ToString());
                        fields.Add("success", (reportJSON.Encounter.Success ?? false) ? "1" : "0");
                        fields.Add("arcversion", $"{reportJSON.EVTC.Type}{reportJSON.EVTC.Version}");
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
                    using (FormUrlEncodedContent content = new FormUrlEncodedContent(fields))
                    {
                        HttpResponseMessage responseMessage = null;
                        try
                        {
                            if (configuration.Method.Equals(PingMethod.Put))
                            {
                                responseMessage = await controller.PutAsync(configuration.URL, content);
                            }
                            else
                            {
                                responseMessage = await controller.PostAsync(configuration.URL, content);
                            }
                            string response = await responseMessage.Content.ReadAsStringAsync();
                            var statusJSON = JsonConvert.DeserializeObject<PlenyxAPIPingResponse>(response);
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
                        finally
                        {
                            responseMessage?.Dispose();
                        }
                    }
                }
                else if (configuration.Method.Equals(PingMethod.Get) || configuration.Method.Equals(PingMethod.Delete))
                {
                    string fullLink = $"{configuration.URL}?";
                    if (reportJSON != null)
                    {
                        string success = (reportJSON.Encounter.Success ?? false) ? "1" : "0";
                        string encounterInfo = $"bossId={reportJSON.Encounter.BossId}&success={success}&arcversion={reportJSON.EVTC.Type}{reportJSON.EVTC.Version}&permalink={System.Web.HttpUtility.UrlEncode(reportJSON.Permalink)}";
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
                    HttpResponseMessage responseMessage = null;
                    try
                    {
                        if (configuration.Method.Equals(PingMethod.Delete))
                        {
                            responseMessage = await controller.DeleteAsync(fullLink);
                        }
                        else
                        {
                            responseMessage = await controller.GetAsync(fullLink);
                        }
                        string response = await responseMessage.Content.ReadAsStringAsync();
                        var statusJSON = JsonConvert.DeserializeObject<PlenyxAPIPingResponse>(response);
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
                    finally
                    {
                        responseMessage?.Dispose();
                    }
                }
                return result;
            }
        }
    }
}
