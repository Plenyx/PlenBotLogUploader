using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using PlenBotLogUploader.DPSReport;
using PlenBotLogUploader.PlenyxAPI;

namespace PlenBotLogUploader.RemotePing
{
    public class PingConfiguration
    {
        public bool Active { get; set; } = false;
        public string Name { get; set; } = "";
        public string URL { get; set; } = "";
        public PingMethod Method { get; set; } = PingMethod.Post;
        public PingAuthentication Authentication { get; set; }

        public async Task<TestPingResult> TestPingAsync(FormMain mainLink)
        {
            try
            {
                string response = await mainLink.DownloadFileToStringAsync($"{URL}pingtest/?sign={Authentication.AuthToken}");
                try
                {
                    PlenyxAPIPingTest pingtest = new JavaScriptSerializer().Deserialize<PlenyxAPIPingTest>(response);
                    if (pingtest.IsValid())
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
            catch
            {
                return new TestPingResult(false, "There has been an error pinging the server.\nCheck your settings.");
            }
        }

        public async Task PingServerAsync(FormMain mainLink, DPSReportJSONMinimal reportJSON)
        {
            if (Method.Equals(PingMethod.Post) || Method.Equals(PingMethod.Put))
            {
                Dictionary<string, string> fields = new Dictionary<string, string>
                {
                    { "permalink", reportJSON.Permalink },
                    { "bossId", reportJSON.Encounter.BossId.ToString() },
                    { "success", (reportJSON.Encounter.Success ?? false) ? "1" : "0" },
                    { "arcversion", $"{reportJSON.Evtc.Type}{reportJSON.Evtc.Version}" }
                };
                if (Authentication.Active)
                {
                    if (!Authentication.UseAsAuth)
                    {
                        fields.Add(Authentication.AuthName, Authentication.AuthToken);
                    }
                    else
                    {
                        mainLink.MainHttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Authentication.AuthName, Authentication.AuthToken);
                    }
                }
                using (FormUrlEncodedContent content = new FormUrlEncodedContent(fields))
                {
                    HttpResponseMessage responseMessage = null;
                    try
                    {
                        if (Method.Equals(PingMethod.Put))
                        {
                            responseMessage = await mainLink.MainHttpClient.PutAsync(URL, content);
                        }
                        else
                        {
                            responseMessage = await mainLink.MainHttpClient.PostAsync(URL, content);
                        }
                        string response = await responseMessage.Content.ReadAsStringAsync();
                        PlenyxAPIPingResponse statusJSON = new JavaScriptSerializer().Deserialize<PlenyxAPIPingResponse>(response);
                        if (statusJSON.Status?.IsSuccess() ?? false)
                        {
                            mainLink.AddToText($">:> Log {reportJSON.GetUrlId()} pinged. {statusJSON.Status.Msg} (code: {statusJSON.Status.Code})");
                        }
                        else
                        {
                            mainLink.AddToText($">:> Log {reportJSON.GetUrlId()} couldn't be pinged. {statusJSON.Error.Msg} (code: {statusJSON.Error.Code})");
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
                if (Authentication.Active)
                {
                    if (Authentication.UseAsAuth)
                    {
                        mainLink.MainHttpClient.DefaultRequestHeaders.Authorization = null;
                    }
                }
            }
            else if (Method.Equals(PingMethod.Get) || Method.Equals(PingMethod.Delete))
            {
                string success = (reportJSON.Encounter.Success ?? false) ? "1" : "0";
                string encounterInfo = $"bossId={reportJSON.Encounter.BossId.ToString()}&success={success}&arcversion={reportJSON.Evtc.Type}{reportJSON.Evtc.Version}&permalink={System.Web.HttpUtility.UrlEncode(reportJSON.Permalink)}";
                string fullLink = $"{URL}?{encounterInfo}";
                if (URL.Contains("?"))
                {
                    fullLink = $"{URL}&{encounterInfo}";
                }
                if (Authentication.Active)
                {
                    if (!Authentication.UseAsAuth)
                    {
                        fullLink = $"{fullLink}&{Authentication.AuthName}={Authentication.AuthToken}";
                    }
                    else
                    {
                        mainLink.MainHttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Authentication.AuthName, Authentication.AuthToken);
                    }
                }
                HttpResponseMessage responseMessage = null;
                try
                {
                    if (Method.Equals(PingMethod.Delete))
                    {
                        responseMessage = await mainLink.MainHttpClient.DeleteAsync(fullLink);
                    }
                    else
                    {
                        responseMessage = await mainLink.MainHttpClient.GetAsync(fullLink);
                    }
                    string response = await responseMessage.Content.ReadAsStringAsync();
                    PlenyxAPIPingResponse statusJSON = new JavaScriptSerializer().Deserialize<PlenyxAPIPingResponse>(response);
                    if (statusJSON.Status?.IsSuccess() ?? false)
                    {
                        mainLink.AddToText($">:> Log {reportJSON.GetUrlId()} pinged. {statusJSON.Status.Msg} (code: {statusJSON.Status.Code})");
                    }
                    else
                    {
                        mainLink.AddToText($">:> Log {reportJSON.GetUrlId()} couldn't be pinged. {statusJSON.Error.Msg} (code: {statusJSON.Error.Code})");
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
                if (Authentication.Active)
                {
                    if (Authentication.UseAsAuth)
                    {
                        mainLink.MainHttpClient.DefaultRequestHeaders.Authorization = null;
                    }
                }
            }
        }
    }
}
