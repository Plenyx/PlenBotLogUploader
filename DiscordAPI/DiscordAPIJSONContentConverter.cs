using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace PlenBotLogUploader.DiscordAPI
{
    /// <summary>
    /// Content Converter used to serialise object to fire up CreateMessage Discord endpoint
    /// </summary>
    public class DiscordAPIJSONContentConverter : JavaScriptConverter
    {
        public override IEnumerable<Type> SupportedTypes
        {
            get
            {
                return new[]
                {
                    typeof(DiscordAPIJSONContent),
                    typeof(DiscordAPIJSONContentEmbed),
                    typeof(DiscordAPIJSONContentEmbedFooter),
                    typeof(DiscordAPIJSONContentEmbedThumbnail),
                    typeof(DiscordAPIJSONContentEmbedField)
                };
            }
        }

        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }

        // convert all properties to lowercase and serialise only properties
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            IDictionary<string, object> serialised = new Dictionary<string, object>();
            foreach (var key in obj.GetType().GetProperties())
            {
                serialised[key.Name.ToLower()] = key.GetValue(obj);
            }
            return serialised;
        }
    }
}
