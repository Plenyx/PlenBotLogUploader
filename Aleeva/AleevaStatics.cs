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
    internal const string ApiBaseUrl = "https://api.aleeva.io";
    internal const string Url = "https://www.aleeva.io/";

    internal static async Task GetAleevaTokenFromRefreshToken(FormMain mainLink, HttpClientController controller)
    {
        var aleeva = new AleevaAuthToken
        {
            RefreshToken = ApplicationSettings.Current.Aleeva.RefreshToken,
            GrantType = "refresh_token",
        };
        var aleevaKeyValues = new List<KeyValuePair<string, string>>
        {
            new("grant_type", aleeva.GrantType),
            new("client_id", aleeva.ClientId),
            new("client_secret", aleeva.ClientSecret),
            new("refresh_token", aleeva.RefreshToken),
            new("scopes", "report:write server:read channel:read"),
        };
        try
        {
            using var content = new FormUrlEncodedContent(aleevaKeyValues);
            using var response = await controller.PostAsync($"{ApiBaseUrl}/auth/token", content);
            var responseMessage = await response.Content.ReadAsStringAsync();
            var responseToken = JsonConvert.DeserializeObject<AleevaAuthTokenResponse>(responseMessage);
            ApplicationSettings.Current.Aleeva.Authorised = responseToken.IsSuccess;
            if (responseToken.IsSuccess)
            {
                ApplicationSettings.Current.Aleeva.AccessToken = responseToken.AccessToken;
                controller.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApplicationSettings.Current.Aleeva.AccessToken);
                ApplicationSettings.Current.Aleeva.AccessTokenExpire = DateTime.Now.AddSeconds(responseToken.ExpiresIn);
                ApplicationSettings.Current.Aleeva.RefreshToken = responseToken.RefreshToken;
                ApplicationSettings.Current.Aleeva.RefreshTokenExpire = DateTime.Now.AddSeconds(responseToken.RefreshExpiresIn);
                ApplicationSettings.Current.Save();
            }
        }
        catch (JsonReaderException)
        {
            mainLink.AddToText("??>> There was an error authenticating with Aleeva while trying to refresh refresh token.");
        }
        catch (Exception e)
        {
            mainLink.AddToText(e.Message);
        }
    }

    internal static async Task GetAleevaTokenFromAccessCode(FormMain mainLink, HttpClientController controller, string accessCode)
    {
        var aleeva = new AleevaAuthToken { AccessCode = accessCode, GrantType = "access_code" };
        var aleevaKeyValues = new List<KeyValuePair<string, string>>
        {
            new("grant_type", aleeva.GrantType),
            new("client_id", aleeva.ClientId),
            new("client_secret", aleeva.ClientSecret),
            new("access_code", aleeva.AccessCode),
            new("scopes", "report:write server:read channel:read"),
        };
        try
        {
            using var content = new FormUrlEncodedContent(aleevaKeyValues);
            using var response = await mainLink.HttpClientController.PostAsync($"{ApiBaseUrl}/auth/token", content);
            var responseMessage = await response.Content.ReadAsStringAsync();
            var responseToken = JsonConvert.DeserializeObject<AleevaAuthTokenResponse>(responseMessage);
            ApplicationSettings.Current.Aleeva.Authorised = responseToken.IsSuccess;
            if (responseToken.IsSuccess)
            {
                ApplicationSettings.Current.Aleeva.AccessToken = responseToken.AccessToken;
                controller.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApplicationSettings.Current.Aleeva.AccessToken);
                ApplicationSettings.Current.Aleeva.AccessTokenExpire = DateTime.Now.AddSeconds(responseToken.ExpiresIn);
                ApplicationSettings.Current.Aleeva.RefreshToken = responseToken.RefreshToken;
                ApplicationSettings.Current.Aleeva.RefreshTokenExpire = DateTime.Now.AddSeconds(responseToken.RefreshExpiresIn);
            }
            else
            {
                ApplicationSettings.Current.Aleeva.AccessToken = "";
                controller.DefaultRequestHeaders.Authorization = null;
                ApplicationSettings.Current.Aleeva.AccessTokenExpire = DateTime.Now;
                ApplicationSettings.Current.Aleeva.RefreshToken = "";
                ApplicationSettings.Current.Aleeva.RefreshTokenExpire = DateTime.Now;
            }
            ApplicationSettings.Current.Save();
        }
        catch (JsonReaderException)
        {
            mainLink.AddToText("??>> There was an error authenticating with Aleeva while trying to exchange the access code. Is your access code correct? Make sure you select the PlenBotLogUploader when creating the access code.");
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "An error has occured.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
