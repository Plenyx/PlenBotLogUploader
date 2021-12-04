using System.Collections.Generic;
using System.IO;

namespace PlenBotLogUploader.Teams
{
    public static class WebhookTeams
    {
        private static Dictionary<int, WebhookTeam> _All = null;
        /// <summary>
        /// Returns the main dictionary with all webhook teams.
        /// </summary>
        /// <returns>A dictionary with all webhook teams</returns>
        public static Dictionary<int, WebhookTeam> All
        {
            get
            {
                if (_All is null)
                {
                    _All = new Dictionary<int, WebhookTeam>();
                }
                return _All;
            }
        }

        public static Dictionary<int, WebhookTeam> ResetDictionary()
        {
            All.Clear();
            All.Add(0, new WebhookTeam() { Name = "No team selected" });
            return All;
        }

        /// <summary>
        /// Loads all webhook teams from a specified file.
        /// </summary>
        /// <param name="file">The file from which the webhook teams are loaded from</param>
        /// <returns>A dictionary with all webhook teams</returns>
        public static Dictionary<int, WebhookTeam> FromFile(string file)
        {
            var allTeams = All;
            if (allTeams.Count > 0)
            {
                ResetDictionary();
            }
            using (var reader = new StreamReader(file))
            {
                string line = reader.ReadLine(); // skip the first line
                while (!((line = reader.ReadLine()) is null))
                {
                    var team = WebhookTeam.FromSavedFormat(line);
                    allTeams.Add(team.ID, team);
                }
            }
            return allTeams;
        }
    }
}
