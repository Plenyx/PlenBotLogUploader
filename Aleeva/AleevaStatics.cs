using Hardstuck.Http;
using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlenBotLogUploader.Aleeva;

internal static class AleevaStatics
{
    internal const string ApiAleevaUrl = "https://api.aleeva.io";
    internal const string AleevaUrl = "https://www.aleeva.io/";
    internal const string AleevaPlenBotHelpPage = "https://www.aleeva.io/tutorials-blog/how-to-connect-plenbot-log-uploader-to-aleeva";

    internal static async Task VerifyAleevaApiKey(FormMain mainLink, HttpClientController controller, string apiKey)
    {
        controller.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        using var response = await controller.GetAsync($"{ApiAleevaUrl}/server?mode=UPLOADS");
        if (response.IsSuccessStatusCode)
        {
            ApplicationSettings.Current.Aleeva.Authorised = true;
            ApplicationSettings.Current.Aleeva.ApiKey = apiKey;
            ApplicationSettings.Current.Save();
        }
        else
        {
            mainLink.AddToText(">:> Invalid Aleeva API key");
            ApplicationSettings.Current.Aleeva.Authorised = false;
            ApplicationSettings.Current.Aleeva.ApiKey = "";
            ApplicationSettings.Current.Save();
        }
    }
}
