using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using ZLinq;

namespace PlenBotLogUploader.DpsReport;

/// <summary>
///     Contains static methods for working with encounters
/// </summary>
internal static class Bosses
{
    internal static string JsonFileLocation => $@"{ApplicationSettings.LocalDir}\boss_data.json";

    /// <summary>
    ///     Returns a list with all encounters.
    /// </summary>
    /// <returns>A list with all encounters.</returns>
    internal static List<BossData> All { get; private set; } = [];

    /// <summary>
    ///     Loads a list of BossData from a specified json file.
    /// </summary>
    /// <param name="filePath">The json file form which the data is loaded.</param>
    /// <returns>A Dictionary containing the loaded BossData.</returns>
    internal static void FromJsonFile(string filePath)
    {
        var jsonData = File.ReadAllText(filePath);

        All = ParseJsonString(jsonData);
    }

    /// <summary>
    ///     Deserializes a json string to BossData
    /// </summary>
    /// <param name="jsonString">The json to parse</param>
    /// <exception cref="JsonException"></exception>
    private static List<BossData> ParseJsonString(string jsonString)
    {
        var parsedJson = JsonConvert.DeserializeObject<IEnumerable<BossData>>(jsonString)
                         ?? throw new JsonException("Could not parse json to BossData");
        
        var raidEncounterConversion = new List<BossData>();

        foreach (var bossData in parsedJson.AsValueEnumerable())
        {
            if (bossData.Type is BossType.StrikeDoNotUse)
            {
                bossData.Type = BossType.RaidEncounter;
            }
            raidEncounterConversion.Add(bossData);
        }

        return raidEncounterConversion;
    }

    /// <summary>
    ///     Saves BossData to specified json file.
    /// </summary>
    /// <param name="bossDataToSave">BossData to persist.</param>
    internal static void SaveToJson(List<BossData> bossDataToSave)
    {
        var jsonString = JsonConvert.SerializeObject(bossDataToSave, Formatting.Indented);

        File.WriteAllText(JsonFileLocation, jsonString, Encoding.UTF8);
    }

    /// <summary>
    ///     Returns a dictionary with default BossData values.
    /// </summary>
    /// <returns>Dictionary with default BossData values</returns>
    internal static List<BossData> GetDefaultSettingsForBossesAsDictionary()
    {
        const string defaultBossData = "PlenBotLogUploader.Resources.boss_data.default.json";
        var assembly = Assembly.GetExecutingAssembly();

        using var stream = assembly.GetManifestResourceStream(defaultBossData);
        using var reader = new StreamReader(stream);
        var jsonString = reader.ReadToEnd();

        All = ParseJsonString(jsonString);
        foreach (var boss in All.AsValueEnumerable())
        {
            if (boss.Type is BossType.Golem or BossType.WvW || boss.Event)
            {
                continue;
            }
            boss.SuccessMsg = ApplicationSettings.Current.BossTemplate.SuccessText;
            boss.FailMsg = ApplicationSettings.Current.BossTemplate.FailText;
        }
        SaveToJson(All);

        return All;
    }

    /// <summary>
    ///     Returns a BossData object based on its boss id, null if no object has been found.
    /// </summary>
    /// <param name="bossId">The boss id to query for</param>
    /// <returns>BossData object or null</returns>
    internal static BossData GetBossDataFromId(int bossId) => All.Find(x => x.BossId.Equals(bossId));

    /// <summary>
    ///     Returns a category number based on a given encounter ID.
    /// </summary>
    /// <param name="bossId">ID of the encounter</param>
    /// <returns>category number</returns>
    internal static RaidEncounterCategory GetCategoryForBoss(int bossId)
        => bossId switch
        {
            (int)BossIds.Freezie or (int)BossIds.WatchknightTriumvirate or (int)BossIds.WatchknightTriumvirateCMArsenite or (int)BossIds.WatchknightTriumvirateCMIndigo or (int)BossIds.WatchknightTriumvirateCMVermilion => RaidEncounterCategory.CoreGame,
            (int)BossIds.ValeGuardian or (int)BossIds.SpiritRace or (int)BossIds.Gorseval or (int)BossIds.Sabetha => RaidEncounterCategory.SpiritVale,
            (int)BossIds.Slothasor or (int)BossIds.BanditTrioBerg or (int)BossIds.BanditTrioZane or (int)BossIds.BanditTrioNarella or (int)BossIds.Matthias => RaidEncounterCategory.SalvationPass,
            (int)BossIds.Escort or (int)BossIds.KeepConstruct or (int)BossIds.TwistedCastle or (int)BossIds.Xera => RaidEncounterCategory.StrongholdOfTheFaithful,
            (int)BossIds.Cairn or (int)BossIds.MursaatOverseer or (int)BossIds.Samarog or (int)BossIds.Deimos => RaidEncounterCategory.BastionOfThePenitent,
            (int)BossIds.SoullessHorror or (int)BossIds.RiverOfSouls or (int)BossIds.BrokenKing or (int)BossIds.EaterOfSouls or (int)BossIds.EyeOfFate or (int)BossIds.EyeOfJudgement or (int)BossIds.Dhuum => RaidEncounterCategory.HallOfChains,
            (int)BossIds.ConjuredAmalgamate or (int)BossIds.LargosTwinsKenut or (int)BossIds.LargosTwinsNikare or (int)BossIds.Qadim => RaidEncounterCategory.MythwrightGambit,
            (int)BossIds.CardinalAdina or (int)BossIds.CardinalSabir or (int)BossIds.QadimThePeerless => RaidEncounterCategory.TheKeyOfAhdashim,
            (int)BossIds.IcebroodConstruct or (int)BossIds.FraenirOfJormag or (int)BossIds.TheVoiceAndTheClawOfTheFallen or (int)BossIds.Boneskinner or (int)BossIds.WhisperOfJormag => RaidEncounterCategory.IcebroodSaga,
            (int)BossIds.AetherbladeHideout or (int)BossIds.Ankka or (int)BossIds.MinisterLi or (int)BossIds.MinisterLiCM or (int)BossIds.TheDragonvoidVoidAmalgamate or (int)BossIds.TheDragonvoidGadget1 or (int)BossIds.TheDragonvoidGadget2 => RaidEncounterCategory.EndOfDragons,
            (int)BossIds.Dagda or (int)BossIds.Cerus => RaidEncounterCategory.SecretsOfTheObscure,
            (int)BossIds.Greer or (int)BossIds.Decima or (int)BossIds.DecimaCM or (int)BossIds.Ura => RaidEncounterCategory.MountBalrior,
            (int)BossIds.KelaSeneschalOfWaves => RaidEncounterCategory.VisionsOfEternity,
            _ => RaidEncounterCategory.Unknown,
        };

    /// <summary>
    ///     Returns the order of the encounter within a category based on given encounter ID.
    /// </summary>
    /// <param name="bossId">ID of the encounter</param>
    /// <returns>order of the encounter within a category</returns>
    internal static int GetBossOrder(int bossId)
        => bossId switch
        {
            (int)BossIds.Freezie or (int)BossIds.ValeGuardian or (int)BossIds.Slothasor or (int)BossIds.Escort or (int)BossIds.Cairn or (int)BossIds.SoullessHorror or (int)BossIds.ConjuredAmalgamate or (int)BossIds.CardinalAdina or (int)BossIds.IcebroodConstruct or (int)BossIds.AetherbladeHideout or (int)BossIds.Dagda or (int)BossIds.Greer or (int)BossIds.KelaSeneschalOfWaves => 1,
            (int)BossIds.WatchknightTriumvirate or (int)BossIds.WatchknightTriumvirateCMArsenite or (int)BossIds.WatchknightTriumvirateCMIndigo or (int)BossIds.WatchknightTriumvirateCMVermilion or (int)BossIds.SpiritRace or (int)BossIds.BanditTrioBerg or (int)BossIds.BanditTrioNarella or (int)BossIds.BanditTrioZane or (int)BossIds.KeepConstruct or (int)BossIds.MursaatOverseer or (int)BossIds.RiverOfSouls or (int)BossIds.LargosTwinsKenut or (int)BossIds.LargosTwinsNikare or (int)BossIds.CardinalSabir or (int)BossIds.FraenirOfJormag or (int)BossIds.Ankka or (int)BossIds.Cerus or (int)BossIds.Decima or (int)BossIds.DecimaCM /* VoE RE 2 */ => 2,
            (int)BossIds.Gorseval or (int)BossIds.Matthias or (int)BossIds.TwistedCastle or (int)BossIds.Samarog or (int)BossIds.BrokenKing or (int)BossIds.Qadim or (int)BossIds.QadimThePeerless or (int)BossIds.TheVoiceAndTheClawOfTheFallen or (int)BossIds.MinisterLi or (int)BossIds.MinisterLiCM or (int)BossIds.Ura => 3,
            (int)BossIds.Sabetha or (int)BossIds.Xera or (int)BossIds.Deimos or (int)BossIds.EaterOfSouls or (int)BossIds.Boneskinner or (int)BossIds.TheDragonvoidVoidAmalgamate or (int)BossIds.TheDragonvoidGadget1 or (int)BossIds.TheDragonvoidGadget2 => 4,
            (int)BossIds.EyeOfFate or (int)BossIds.EyeOfJudgement or (int)BossIds.WhisperOfJormag => 5,
            (int)BossIds.Dhuum => 6,
            _ => 99,
        };

    /// <summary>
    ///     Returns a raid category name based on its number.
    /// </summary>
    /// <param name="raidCategory">the raid category</param>
    /// <returns>raid category name</returns>
    internal static string GetRaidEncounterCategoryName(RaidEncounterCategory raidCategory)
        => raidCategory switch
        {
            RaidEncounterCategory.CoreGame => "Core Game",
            RaidEncounterCategory.SpiritVale => "Spirit Vale (Wing 1)",
            RaidEncounterCategory.SalvationPass => "Salvation Pass (Wing 2)",
            RaidEncounterCategory.StrongholdOfTheFaithful => "Stronghold of the Faithful (Wing 3)",
            RaidEncounterCategory.BastionOfThePenitent => "Bastion of the Penitent (Wing 4)",
            RaidEncounterCategory.HallOfChains => "Hall of Chains (Wing 5)",
            RaidEncounterCategory.MythwrightGambit => "Mythwright Gambit (Wing 6)",
            RaidEncounterCategory.TheKeyOfAhdashim => "The Key of Ahdashim (Wing 7)",
            RaidEncounterCategory.IcebroodSaga => "Icebrood Saga",
            RaidEncounterCategory.EndOfDragons => "End of Dragons",
            RaidEncounterCategory.SecretsOfTheObscure => "Secrets of the Obscure",
            RaidEncounterCategory.MountBalrior => "Mount Balrior (Wing 8)",
            RaidEncounterCategory.VisionsOfEternity => "Visions of Eternity",
            _ => "Unknown raid encounter category",
        };
}
