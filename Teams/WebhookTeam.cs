using System;
using System.Collections.Generic;
using System.Linq;

namespace PlenBotLogUploader.Teams
{
    public class WebhookTeam
    {
        /// <summary>
        /// ID of the team, for internal use
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Name of the webhook team
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// What limiter to the team should be applied
        /// </summary>
        public WebhookTeamLimiter Limiter { get; set; }

        /// <summary>
        /// What value for the limiter should be applied
        /// </summary>
        public int LimiterValue { get; set; }

        /// <summary>
        /// List of account names in the given team
        /// </summary>
        public List<string> AccountNames { get; set; } = new List<string>();

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() => Name;

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <param name="savableFormat">whether the text should be in savable format</param>
        /// <returns>Returns a string that represents the current object.</returns>
        public string ToString(bool savableFormat = false)
        {
            if (!savableFormat)
            {
                return base.ToString();
            }
            return $"{ID}<;>{Name}<;>{(int)Limiter}<;>{LimiterValue}<;>{string.Join(";", AccountNames.ToArray())}";
        }

        public bool IsTeamSatisfied(Dictionary<string, DPSReport.DPSReportJSONPlayers> players)
        {
            var sumOfTeamMembers = AccountNames.Select(x => players.Values.Where(y => y.DisplayName.Equals(x)).Count()).Sum();
            return sumOfTeamMembers >= LimiterValue;
        }

        /// <summary>
        /// Creates an WebhookTeam object from a serialised format.
        /// </summary>
        /// <param name="savedFormat">string representing the object</param>
        /// <returns>deserilised object of WebhookTeam type</returns>
        public static WebhookTeam FromSavedFormat(string serialisedFormat)
        {
            try
            {
                string[] values = serialisedFormat.Split(new string[] { "<;>" }, StringSplitOptions.None);
                int.TryParse(values[0], out int id);
                int.TryParse(values[2], out int limiter);
                int.TryParse(values[3], out int limiterValue);
                var accountNames = values[4].Split(new string[] { ";" }, StringSplitOptions.None).ToList();
                return new WebhookTeam()
                {
                    ID = id,
                    Name = values[1],
                    Limiter = (WebhookTeamLimiter)limiter,
                    LimiterValue = limiterValue,
                    AccountNames = accountNames
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
