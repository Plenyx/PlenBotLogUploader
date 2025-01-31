using Hardstuck.Http;
using Newtonsoft.Json;
using PlenBotLogUploader.DpsReport;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlenBotLogUploader.Gw2Wingman;

internal class Gw2WingmanUploader
{
    private const string UploadUrl = "https://gw2wingman.nevermindcreations.de/uploadEVTC";
    private readonly HttpClientController _httpClientController = new()
    {
        Timeout = TimeSpan.FromSeconds(120),
    };

    internal async Task<string> Upload(string file, DpsReportJsonExtraJson extraJson)
    {
        if (extraJson.TriggerId == 1)
        {
            return ">:> Wingman upload has been skipped for a WvW log";
        }
        var fileInfo = new FileInfo(file);
        try
        {
            using var inputStream = File.OpenRead(file);
            using var contentStream = new StreamContent(inputStream);
            using var formDataContent = new MultipartFormDataContent
            {
                { new StringContent(extraJson.RecordedByAccountName), "account" },
                { new StringContent(fileInfo.Length.ToString()), "filesize" },
                { new StringContent(extraJson.TriggerId.ToString()), "triggerID" },
                { contentStream, "file", Path.GetFileName(file) },
            };
            try
            {
                using var response = await _httpClientController.PostAsync(UploadUrl, formDataContent);
                if (!response.IsSuccessStatusCode)
                {
                    return $">:> Wingman upload failed with the following error status code: {response.StatusCode}";
                }
                var responseMessage = await response.Content.ReadAsStringAsync();
                var uploadResult = JsonConvert.DeserializeObject<Gw2WingmanUploadResult>(responseMessage);
                return $">:> Wingman upload result: {(uploadResult.Success ? "success" : $"failure - {uploadResult.Error}")}";
            }
            catch (Exception e)
            {
                return $">:> Wingman upload failed with the following error: {e.Message}";
            }
        }
        catch (Exception e)
        {
            return $">:> Wingman upload failed with the following error: {e.Message}";
        }
    }
}
