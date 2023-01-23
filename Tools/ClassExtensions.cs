using Hardstuck.Http;
using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.GitHub;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace PlenBotLogUploader.Tools
{
    internal static class ClassExtensions
    {
        /// <summary>
        /// Outputs TimeSpan as Hh Mm Ss.
        /// </summary>
        /// <param name="span">TimeSpan in question</param>
        /// <returns>TimeSpan as Hh Mm Ss</returns>
        internal static string ParseHMS(this TimeSpan span)
        {
            if (span.Hours > 0 || span.Days > 0)
            {
                return $"{(span.Days * 24) + span.Hours}h {span.Minutes}m {span.Seconds}s";
            }
            if (span.Minutes > 0)
            {
                return $"{span.Minutes}m {span.Seconds}s";
            }
            return $"{span.Seconds}s";
        }

        private static string ParseDoubleAsK(double number) => ApplicationSettings.Current.ShortenThousands ? $"{Math.Round(number / 1000, 1).ToString(CultureInfo.InvariantCulture)}k" : number.ToString();

        internal static string ParseAsK(this double number) => ParseDoubleAsK(number);

        internal static string ParseAsK(this int number) => ParseDoubleAsK(number);

        internal static ReadOnlySpan<T> AsSpan<T>(this List<T> list) => CollectionsMarshal.AsSpan(list);

        internal static async Task<GitHubReleaseLatest> GetGitHubLatestReleaseAsync(this HttpClientController controller, string repository)
        {
            try
            {
                var response = await controller.DownloadFileToStringAsync($"https://api.github.com/repos/{repository}/releases/latest");
                return JsonConvert.DeserializeObject<GitHubReleaseLatest>(response);
            }
            catch
            {
                return null;
            }
        }
    }
}
