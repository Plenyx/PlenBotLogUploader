using System.Collections.Generic;

namespace PlenBotLogUploader.GW2API
{
    public static class GW2
    {
        private static Dictionary<int, GW2Server> _AllServers;

        public static Dictionary<int, GW2Server> AllServers => _AllServers ??= new Dictionary<int, GW2Server>()
        {
            { 1001, new GW2Server() { ID = 1001, Name = "Anvil Rock" } },
            { 1002, new GW2Server() { ID = 1002, Name = "Borlis Pass" } },
            { 1003, new GW2Server() { ID = 1003, Name = "Yak's Bend" } },
            { 1004, new GW2Server() { ID = 1004, Name = "Henge of Denravi" } },
            { 1005, new GW2Server() { ID = 1005, Name = "Maguuma" } },
            { 1006, new GW2Server() { ID = 1006, Name = "Sorrow's Furnace" } },
            { 1007, new GW2Server() { ID = 1007, Name = "Gate of Madness" } },
            { 1008, new GW2Server() { ID = 1008, Name = "Jade Quarry" } },
            { 1009, new GW2Server() { ID = 1009, Name = "Fort Aspenwood" } },
            { 1010, new GW2Server() { ID = 1010, Name = "Ehmry Bay" } },
            { 1011, new GW2Server() { ID = 1011, Name = "Stormbluff Isle" } },
            { 1012, new GW2Server() { ID = 1012, Name = "Darkhaven" } },
            { 1013, new GW2Server() { ID = 1013, Name = "Sanctum of Rall" } },
            { 1014, new GW2Server() { ID = 1014, Name = "Crystal Desert" } },
            { 1015, new GW2Server() { ID = 1015, Name = "Isle of Janthir" } },
            { 1016, new GW2Server() { ID = 1016, Name = "Sea of Sorrows" } },
            { 1017, new GW2Server() { ID = 1017, Name = "Tarnished Coast" } },
            { 1018, new GW2Server() { ID = 1018, Name = "Northern Shiverpeaks" } },
            { 1019, new GW2Server() { ID = 1019, Name = "Blackgate" } },
            { 1020, new GW2Server() { ID = 1020, Name = "Ferguson's Crossing" } },
            { 1021, new GW2Server() { ID = 1021, Name = "Dragonbrand" } },
            { 1022, new GW2Server() { ID = 1022, Name = "Kaineng" } },
            { 1023, new GW2Server() { ID = 1023, Name = "Devona's Rest" } },
            { 1024, new GW2Server() { ID = 1024, Name = "Eredon Terrace" } },
            { 2001, new GW2Server() { ID = 2001, Name = "Fissure of Woe" } },
            { 2002, new GW2Server() { ID = 2002, Name = "Desolation" } },
            { 2003, new GW2Server() { ID = 2003, Name = "Gandara" } },
            { 2004, new GW2Server() { ID = 2004, Name = "Blacktide" } },
            { 2005, new GW2Server() { ID = 2005, Name = "Ring of Fire" } },
            { 2006, new GW2Server() { ID = 2006, Name = "Underworld" } },
            { 2007, new GW2Server() { ID = 2007, Name = "Far Shiverpeaks" } },
            { 2008, new GW2Server() { ID = 2008, Name = "Whiteside Ridge" } },
            { 2009, new GW2Server() { ID = 2009, Name = "Ruins of Surmia" } },
            { 2010, new GW2Server() { ID = 2010, Name = "Seafarer's Rest" } },
            { 2011, new GW2Server() { ID = 2011, Name = "Vabbi" } },
            { 2012, new GW2Server() { ID = 2012, Name = "Piken Square" } },
            { 2013, new GW2Server() { ID = 2013, Name = "Aurora Glade" } },
            { 2014, new GW2Server() { ID = 2014, Name = "Gunnar's Hold" } },
            { 2101, new GW2Server() { ID = 2101, Name = "Jade Sea [FR]" } },
            { 2102, new GW2Server() { ID = 2102, Name = "Fort Ranik [FR]" } },
            { 2103, new GW2Server() { ID = 2103, Name = "Augury Rock [FR]" } },
            { 2104, new GW2Server() { ID = 2104, Name = "Vizunah Square [FR]" } },
            { 2105, new GW2Server() { ID = 2105, Name = "Arborstone [FR]" } },
            { 2201, new GW2Server() { ID = 2201, Name = "Kodash [DE]" } },
            { 2202, new GW2Server() { ID = 2202, Name = "Riverside [DE]" } },
            { 2203, new GW2Server() { ID = 2203, Name = "Elona Reach [DE]" } },
            { 2204, new GW2Server() { ID = 2204, Name = "Abaddon's Mouth [DE]" } },
            { 2205, new GW2Server() { ID = 2205, Name = "Drakkar Lake [DE]" } },
            { 2206, new GW2Server() { ID = 2206, Name = "Miller's Sound [DE]" } },
            { 2207, new GW2Server() { ID = 2207, Name = "Dzagonur [DE]" } },
            { 2301, new GW2Server() { ID = 2301, Name = "Baruch Bay [SP]" } }
        };
    }
}
