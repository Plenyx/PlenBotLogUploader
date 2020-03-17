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

        public async Task<TestPingResult> TestPingAsync()
        {
            try
            {
                using (HttpClientController controller = new HttpClientController())
                {
                    string auth = "";
                    if (Authentication.Active)
                    {
                        if (Authentication.UseAsAuth)
                        {
                            controller.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Authentication.AuthName, Authentication.AuthToken);
                        }
                        else
                        {
                            auth = $"?{Authentication.AuthName.ToLower()}={Authentication.AuthToken}";
                        }
                    }
                    string response = await controller.DownloadFileToStringAsync($"{URL}pingtest/{auth}");
                    try
                    {
                        var pingTest = JsonConvert.DeserializeObject<PlenyxAPIPingTest>(response);
                        if (pingTest.IsValid())
                        {
                            return new TestPingResult(true, "Ping settings are valid.");
                        }
                        else
                        {
                            return new TestPingResult(false, "Sign is not valid.");
                        }
                    }
                    catch
                    {
                        return new TestPingResult(false, "There has been an error checking the server settings.\nIs the server correctly set?");
                    }
                }
            }
            catch
            {
                return new TestPingResult(false, "There has been an error pinging the server.\nCheck your settings.");
            }
        }

        public async Task PingServerAsync(FormMain mainLink, DPSReportJSON reportJSON)
        {
            using (HttpClientController controller = new HttpClientController())
            {
                if (Method.Equals(PingMethod.Post) || Method.Equals(PingMethod.Put))
                {
                    Dictionary<string, string> fields = new Dictionary<string, string>
                    {
                        { "permalink", reportJSON.Permalink },
                        { "bossId", reportJSON.Encounter.BossId.ToString() },
                        { "success", (reportJSON.Encounter.Success ?? false) ? "1" : "0" },
                        { "arcversion", $"{reportJSON.EVTC.Type}{reportJSON.EVTC.Version}" }
                    };
                    if (Authentication.Active)
                    {
                        if (!Authentication.UseAsAuth)
                        {
                            fields.Add(Authentication.AuthName, Authentication.AuthToken);
                        }
                        else
                        {
                            controller.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Authentication.AuthName, Authentication.AuthToken);
                        }
                    }
                    using (FormUrlEncodedContent content = new FormUrlEncodedContent(fields))
                    {
                        HttpResponseMessage responseMessage = null;
                        try
                        {
                            if (Method.Equals(PingMethod.Put))
                            {
                                responseMessage = await controller.PutAsync(URL, content);
                            }
                            else
                            {
                                responseMessage = await controller.PostAsync(URL, content);
                            }
                            string response = await responseMessage.Content.ReadAsStringAsync();
                            var statusJSON = JsonConvert.DeserializeObject<PlenyxAPIPingResponse>(response);
                            if (statusJSON.Status?.IsSuccess() ?? false)
                            {
                                mainLink.AddToText($">:> Log {reportJSON.UrlId} pinged. {statusJSON.Status.Msg} (code: {statusJSON.Status.Code})");
                            }
                            else
                            {
                                mainLink.AddToText($">:> Log {reportJSON.UrlId} couldn't be pinged. {statusJSON.Error.Msg} (code: {statusJSON.Error.Code})");
                            }
                        }
                        catch
                        {
                            mainLink.AddToText($">:> Unable to ping the server \"{Name}\", check the settings or the server is not responding.");
                        }
                        finally
                        {
                            responseMessage?.Dispose();
                        }
                    }
                }
                else if (Method.Equals(PingMethod.Get) || Method.Equals(PingMethod.Delete))
                {
                    string success = (reportJSON.Encounter.Success ?? false) ? "1" : "0";
                    string encounterInfo = $"bossId={reportJSON.Encounter.BossId.ToString()}&success={success}&arcversion={reportJSON.EVTC.Type}{reportJSON.EVTC.Version}&permalink={System.Web.HttpUtility.UrlEncode(reportJSON.Permalink)}";
                    string fullLink = $"{URL}?{encounterInfo}";
                    if (URL.Contains("?"))
                    {
                        fullLink = $"{URL}&{encounterInfo}";
                    }
                    if (Authentication.Active)
                    {
                        if (!Authentication.UseAsAuth)
                        {
                            fullLink = $"{fullLink}&{Authentication.AuthName.ToLower()}={Authentication.AuthToken}";
                        }
                        else
                        {
                            controller.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Authentication.AuthName, Authentication.AuthToken);
                        }
                    }
                    HttpResponseMessage responseMessage = null;
                    try
                    {
                        if (Method.Equals(PingMethod.Delete))
                        {
                            responseMessage = await controller.DeleteAsync(fullLink);
                        }
                        else
                        {
                            responseMessage = await controller.GetAsync(fullLink);
                        }
                        string response = await responseMessage.Content.ReadAsStringAsync();
                        var statusJSON = JsonConvert.DeserializeObject<PlenyxAPIPingResponse>(response);
                        if (statusJSON.Status?.IsSuccess() ?? false)
                        {
                            mainLink.AddToText($">:> Log {reportJSON.UrlId} pinged. {statusJSON.Status.Msg} (code: {statusJSON.Status.Code})");
                        }
                        else
                        {
                            mainLink.AddToText($">:> Log {reportJSON.UrlId} couldn't be pinged. {statusJSON.Error.Msg} (code: {statusJSON.Error.Code})");
                        }
                    }
                    catch
                    {
                        mainLink.AddToText($">:> Unable to ping the server \"{Name}\", check the settings or the server is not responding.");
                    }
                    finally
                    {
                        responseMessage?.Dispose();
                    }
                }
            }
        }
    }
}
