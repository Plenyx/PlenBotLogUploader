using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PlenBotLogUploader.DiscordAPI
{
    class DiscordWebhooks
    {
        private static Dictionary<int, DiscordWebhookData> instance = null;
        /// <summary>
        /// Returns the main dictionary with all webhooks.
        /// </summary>
        /// <returns>A dictionary with all webhooks</returns>
        public static Dictionary<int, DiscordWebhookData> GetAllWebhooks()
        {
            if (instance == null)
            {
                instance = new Dictionary<int, DiscordWebhookData>();
            }
            return instance;
        }

        /// <summary>
        /// Loads all webhooks from a specified file.
        /// </summary>
        /// <param name="file">The file from which the webhooks are loaded from</param>
        /// <returns>A dictionary with all webhooks</returns>
        public static Dictionary<int, DiscordWebhookData> FromFile(string file)
        {
            var allWebhooks = GetAllWebhooks();
            if (allWebhooks.Count > 0)
            {
                allWebhooks.Clear();
            }
            using (StreamReader reader = new StreamReader(file))
            {
                string line = reader.ReadLine(); // skip the first line
                while ((line = reader.ReadLine()) != null)
                {
                    allWebhooks.Add(allWebhooks.Count + 1, DiscordWebhookData.FromSavedFormat(line));
                }
            }
            return allWebhooks;
        }
    }
}
