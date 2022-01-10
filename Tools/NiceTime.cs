using System;

namespace PlenBotLogUploader.Tools
{
    public static class NiceTime
    {
        /// <summary>
        /// Outputs TimeSpan as Hh Mm Ss.
        /// </summary>
        /// <param name="span">TimeSpan in question</param>
        /// <returns>TimeSpan as Hh Mm Ss</returns>
        public static string ParseTimeSpanHMS(TimeSpan span)
        {
            string elapsedTime = $"{span.Seconds}s";
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

        /// <summary>
        /// Outputs TimeSpan as Hh Mm Ss.
        /// </summary>
        /// <param name="span">TimeSpan in question</param>
        /// <returns>TimeSpan as Hh Mm Ss</returns>
        public static string ParseHMS(this TimeSpan span) => ParseTimeSpanHMS(span);
    }
}
