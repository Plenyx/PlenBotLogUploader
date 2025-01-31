using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PlenBotLogUploader.Aleeva;

/// <summary>
///     Contains static methods for working with Aleeva Integration
/// </summary>
internal static class AleevaIntegrations
{
    private static readonly string JsonFileLocation = $@"{ApplicationSettings.LocalDir}\aleeva_integrations.json";

    /// <summary>
    ///     Returns the list with all Aleeva integrations.
    /// </summary>
    /// <returns>A list with all Aleeva integrations.</returns>
    internal static List<AleevaIntegration> All { get; private set; } = [];

    /// <summary>
    ///     Loads a list of AleevaIntegration from a specified json file.
    /// </summary>
    /// <param name="filePath">The json file form which the data is loaded.</param>
    /// <returns>A list containing the loaded Aleeva Integrations.</returns>
    private static void FromJsonFile(string filePath)
    {
        var jsonData = File.ReadAllText(filePath);

        All = ParseJsonString(jsonData);
    }

    /// <summary>
    ///     Deserializes a json string to a list of AleevaIntegration.
    /// </summary>
    /// <param name="jsonString">The json to parse.</param>
    /// <exception cref="JsonException"></exception>
    private static List<AleevaIntegration> ParseJsonString(string jsonString)
    {
        var parsedJson = JsonConvert.DeserializeObject<IEnumerable<AleevaIntegration>>(jsonString)
                         ?? throw new JsonException("Could not parse json to AleevaIntegration");

        return parsedJson.ToList();
    }

    /// <summary>
    ///     Saves as list of AleevaIntegration to a specified json file.
    /// </summary>
    /// <param name="aleevaIntegrationToSave">A list of AleevaIntegration to persist.</param>
    internal static void SaveToJson(List<AleevaIntegration> aleevaIntegrationToSave)
    {
        var jsonString = JsonConvert.SerializeObject(aleevaIntegrationToSave, Formatting.Indented);

        File.WriteAllText(JsonFileLocation, jsonString, Encoding.UTF8);
    }

    internal static void LoadAleevaIntegrations()
    {
        try
        {
            if (File.Exists(JsonFileLocation))
            {
                FromJsonFile(JsonFileLocation);
            }
        }
        catch
        {
            // do nothing
        }
    }
}
