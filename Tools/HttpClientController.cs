using Newtonsoft.Json;
using PlenBotLogUploader.GitHub;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlenBotLogUploader.Tools
{
    internal sealed class HttpClientController : HttpClient
    {
        #region init
        /// <summary>
        /// The initial settings by HttpClientController child of HttpClient.
        /// </summary>
        internal HttpClientController() : base()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("PlenBotLogUploader", AppSettings.ApplicationSettings.Version.ToString()));
        }
        #endregion

        /// <summary>
        /// Downloads a file asynchronously.
        /// </summary>
        internal async Task<bool> DownloadFileAsync(string url, string destination)
        {
            try
            {
                var uri = new Uri(url);
                using (var responseMessage = await GetAsync(uri))
                {
                    using var response = await responseMessage.Content.ReadAsStreamAsync();
                    using var stream = File.Create(@destination);
                    await response.CopyToAsync(stream);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Downloads a file to string asynchronously.
        /// </summary>
        internal async Task<string> DownloadFileToStringAsync(string url)
        {
            try
            {
                var uri = new Uri(url);
                using var responseMessage = await GetAsync(uri);
                var response = await responseMessage.Content.ReadAsStringAsync();
                return response;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets latest release from a specified repository
        /// </summary>
        /// <param name="repository">specified repository</param>
        /// <returns>latest release from a specified repository</returns>
        internal async Task<GitHubReleasesLatest> GetGitHubLatestReleaseAsync(string repository)
        {
            try
            {
                var uri = new Uri($"https://api.github.com/repos/{repository}/releases/latest");
                using var responseMessage = await GetAsync(uri);
                var response = await responseMessage.Content.ReadAsStringAsync();
                var release = JsonConvert.DeserializeObject<GitHubReleasesLatest>(response);
                return release;
            }
            catch
            {
                return null;
            }
        }
    }
}
