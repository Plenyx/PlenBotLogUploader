using Hardstuck.Http;
using Newtonsoft.Json;
using PlenBotLogUploader.Gw2Api;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PlenBotLogUploader.Tools;

internal sealed class Gw2ApiHelper : IDisposable
{
    private const string Gw2ApiUrl = "https://api.guildwars2.com/";
    private readonly HttpClientController _httpClientController = new();

    internal Gw2ApiHelper(string apiKey = "")
    {
        if (!string.IsNullOrWhiteSpace(apiKey))
        {
            _httpClientController.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        }
    }

    public void Dispose() => _httpClientController?.Dispose();

    internal async Task<Gw2Account> GetUserInfoAsync()
    {
        try
        {
            using var accountResponse = await _httpClientController.GetAsync($"{Gw2ApiUrl}v2/account?v=latest");
            var accountContent = await accountResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Gw2Account>(accountContent);
        }
        catch
        {
            return null;
        }
    }
}
