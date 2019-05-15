using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlenBotLogUploader.Tools
{
    public class HttpClientController: IDisposable
    {
        // public
        public HttpClient MainHttpClient { get; } = new HttpClient();

        public HttpClientController()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        public async Task<bool> DownloadFileAsync(string url, string destination)
        {
            try
            {
                var uri = new Uri(url);
                using (var responseMessage = await MainHttpClient.GetAsync(uri))
                {
                    using (var response = await responseMessage.Content.ReadAsStreamAsync())
                    {
                        using (var stream = new FileStream(@destination, FileMode.Create, FileAccess.Write))
                        {
                            await response.CopyToAsync(stream);
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> DownloadFileToStringAsync(string url)
        {
            try
            {
                var uri = new Uri(url);
                using (var responseMessage = await MainHttpClient.GetAsync(uri))
                {
                    var response = await responseMessage.Content.ReadAsStringAsync();
                    return response;
                }
            }
            catch
            {
                return "";
            }
        }

        public void Dispose()
        {
            MainHttpClient?.Dispose();
        }
    }
}
