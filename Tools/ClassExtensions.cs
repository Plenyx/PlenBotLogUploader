﻿using Hardstuck.Http;
using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.GitHub;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ZLinq;

namespace PlenBotLogUploader.Tools;

internal static class ClassExtensions
{
    /// <summary>
    ///     Outputs TimeSpan as Hh Mm Ss.
    /// </summary>
    /// <param name="span">TimeSpan in question</param>
    /// <returns>TimeSpan as Hh Mm Ss</returns>
    internal static string ParseHMS(this TimeSpan span)
    {
        if (span.Hours > 0 || span.Days > 0)
        {
            return $"{(span.Days * 24) + span.Hours}h {span.Minutes}m {span.Seconds}s";
        }
        return span.Minutes > 0 ? $"{span.Minutes}m {span.Seconds}s" : $"{span.Seconds}s";
    }

    private static string ParseDoubleAsK(double number) => ApplicationSettings.Current.ShortenThousands ? $"{Math.Round(number / 1000, 1).ToString(CultureInfo.InvariantCulture)}k" : number.ToString();

    internal static string ParseAsK(this double number) => ParseDoubleAsK(number);

    internal static string ParseAsK(this int number) => ParseDoubleAsK(number);

    internal static string ParseAsK(this long number) => ParseDoubleAsK(number);

    internal static void AddRange<T>(this List<T> list, params T[] items)
    {
        if (list == null)
        {
            return;
        }
        foreach (var item in items.AsValueEnumerable())
        {
            if (item is null)
            {
                continue;
            }
            list.Add(item);
        }
    }

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

    internal static string ToLocalTimeZoneString(this DateTime dateTime) => $"{dateTime.ToLocalTime():yyyy-MM-dd HH:mm:ss} GMT {dateTime.ToLocalTime():%K}";
}
