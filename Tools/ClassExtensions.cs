using PlenBotLogUploader.AppSettings;
using System;
using System.Globalization;

namespace PlenBotLogUploader.Tools
{
    public static class ClassExtensions
    {
        /// <summary>
        /// Outputs TimeSpan as Hh Mm Ss.
        /// </summary>
        /// <param name="span">TimeSpan in question</param>
        /// <returns>TimeSpan as Hh Mm Ss</returns>
        public static string ParseHMS(this TimeSpan span)
        {
            var elapsedTime = $"{span.Seconds}s";
            if (span.Hours > 0 || span.Days > 0)
            {
                elapsedTime = $"{span.Days * 24 + span.Hours}h {span.Minutes}m {span.Seconds}s";
            }
            else if (span.Minutes > 0)
            {
                elapsedTime = $"{span.Minutes}m {span.Seconds}s";
            }
            return elapsedTime;
        }

        private static string ParseDoubleAsK(double number) => ApplicationSettings.Current.ShortenedThousands ? $"{Math.Round((double)number / 1000, 1).ToString(CultureInfo.InvariantCulture)}k" : number.ToString();

        public static string ParseAsK(this double number) => ParseDoubleAsK(number);

        public static string ParseAsK(this int number) => ParseDoubleAsK(number);
    }
}
