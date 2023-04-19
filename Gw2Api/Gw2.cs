using System.Collections.Generic;

namespace PlenBotLogUploader.Gw2Api
{
    internal static class Gw2
    {
        private static Dictionary<int, Gw2Server> _AllServers;

        internal static Dictionary<int, Gw2Server> AllServers => _AllServers ??= new()
        {
            { 1001, new Gw2Server { Id = 1001, Name = "Anvil Rock" } },
            { 1002, new Gw2Server { Id = 1002, Name = "Borlis Pass" } },
            { 1003, new Gw2Server { Id = 1003, Name = "Yak's Bend" } },
            { 1004, new Gw2Server { Id = 1004, Name = "Henge of Denravi" } },
            { 1005, new Gw2Server { Id = 1005, Name = "Maguuma" } },
            { 1006, new Gw2Server { Id = 1006, Name = "Sorrow's Furnace" } },
            { 1007, new Gw2Server { Id = 1007, Name = "Gate of Madness" } },
            { 1008, new Gw2Server { Id = 1008, Name = "Jade Quarry" } },
            { 1009, new Gw2Server { Id = 1009, Name = "Fort Aspenwood" } },
            { 1010, new Gw2Server { Id = 1010, Name = "Ehmry Bay" } },
            { 1011, new Gw2Server { Id = 1011, Name = "Stormbluff Isle" } },
            { 1012, new Gw2Server { Id = 1012, Name = "Darkhaven" } },
            { 1013, new Gw2Server { Id = 1013, Name = "Sanctum of Rall" } },
            { 1014, new Gw2Server { Id = 1014, Name = "Crystal Desert" } },
            { 1015, new Gw2Server { Id = 1015, Name = "Isle of Janthir" } },
            { 1016, new Gw2Server { Id = 1016, Name = "Sea of Sorrows" } },
            { 1017, new Gw2Server { Id = 1017, Name = "Tarnished Coast" } },
            { 1018, new Gw2Server { Id = 1018, Name = "Northern Shiverpeaks" } },
            { 1019, new Gw2Server { Id = 1019, Name = "Blackgate" } },
            { 1020, new Gw2Server { Id = 1020, Name = "Ferguson's Crossing" } },
            { 1021, new Gw2Server { Id = 1021, Name = "Dragonbrand" } },
            { 1022, new Gw2Server { Id = 1022, Name = "Kaineng" } },
            { 1023, new Gw2Server { Id = 1023, Name = "Devona's Rest" } },
            { 1024, new Gw2Server { Id = 1024, Name = "Eredon Terrace" } },
            { 2001, new Gw2Server { Id = 2001, Name = "Fissure of Woe" } },
            { 2002, new Gw2Server { Id = 2002, Name = "Desolation" } },
            { 2003, new Gw2Server { Id = 2003, Name = "Gandara" } },
            { 2004, new Gw2Server { Id = 2004, Name = "Blacktide" } },
            { 2005, new Gw2Server { Id = 2005, Name = "Ring of Fire" } },
            { 2006, new Gw2Server { Id = 2006, Name = "Underworld" } },
            { 2007, new Gw2Server { Id = 2007, Name = "Far Shiverpeaks" } },
            { 2008, new Gw2Server { Id = 2008, Name = "Whiteside Ridge" } },
            { 2009, new Gw2Server { Id = 2009, Name = "Ruins of Surmia" } },
            { 2010, new Gw2Server { Id = 2010, Name = "Seafarer's Rest" } },
            { 2011, new Gw2Server { Id = 2011, Name = "Vabbi" } },
            { 2012, new Gw2Server { Id = 2012, Name = "Piken Square" } },
            { 2013, new Gw2Server { Id = 2013, Name = "Aurora Glade" } },
            { 2014, new Gw2Server { Id = 2014, Name = "Gunnar's Hold" } },
            { 2101, new Gw2Server { Id = 2101, Name = "Jade Sea [FR]" } },
            { 2102, new Gw2Server { Id = 2102, Name = "Fort Ranik [FR]" } },
            { 2103, new Gw2Server { Id = 2103, Name = "Augury Rock [FR]" } },
            { 2104, new Gw2Server { Id = 2104, Name = "Vizunah Square [FR]" } },
            { 2105, new Gw2Server { Id = 2105, Name = "Arborstone [FR]" } },
            { 2201, new Gw2Server { Id = 2201, Name = "Kodash [DE]" } },
            { 2202, new Gw2Server { Id = 2202, Name = "Riverside [DE]" } },
            { 2203, new Gw2Server { Id = 2203, Name = "Elona Reach [DE]" } },
            { 2204, new Gw2Server { Id = 2204, Name = "Abaddon's Mouth [DE]" } },
            { 2205, new Gw2Server { Id = 2205, Name = "Drakkar Lake [DE]" } },
            { 2206, new Gw2Server { Id = 2206, Name = "Miller's Sound [DE]" } },
            { 2207, new Gw2Server { Id = 2207, Name = "Dzagonur [DE]" } },
            { 2301, new Gw2Server { Id = 2301, Name = "Baruch Bay [SP]" } },
        };
    }
}
