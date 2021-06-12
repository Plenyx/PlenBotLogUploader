namespace PlenBotLogUploader.ArcDps
{
    public class ArcDpsComponentHelperClass
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public ArcDpsComponentType Type { get; set; }

        public string DefaultFileName
        {
            get
            {
                switch (Type)
                {
                    case ArcDpsComponentType.Mechanics:
                        return "d3d9_arcdps_mechanics.dll";
                    case ArcDpsComponentType.BoonTable:
                        return "d3d9_arcdps_table.dll";
                    case ArcDpsComponentType.KPme:
                        return "d3d9_arcdps_killproof_me.dll";
                    case ArcDpsComponentType.HealStats:
                        return "d3d9_arcdps_healing_stats.dll";
                    case ArcDpsComponentType.SCT:
                        return "d3d9_arcdps_sct.dll";
                    default: // arcdps
                        return "d3d9.dll";
                }
            }
        }

        public override string ToString() => $"{Name} by {Author}";
    }
}
