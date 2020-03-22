namespace PlenBotLogUploader.Tools
{
    public class Gw2SharpHelper
    {
        public static Gw2Sharp.Models.Profession GetProfessionFromString(string profession)
        {
            switch (profession)
            {
                case "Engineer":
                    return Gw2Sharp.Models.Profession.Engineer;
                case "Guardian":
                    return Gw2Sharp.Models.Profession.Guardian;
                case "Mesmer":
                    return Gw2Sharp.Models.Profession.Mesmer;
                case "Necromancer":
                    return Gw2Sharp.Models.Profession.Necromancer;
                case "Ranger":
                    return Gw2Sharp.Models.Profession.Ranger;
                case "Revenant":
                    return Gw2Sharp.Models.Profession.Revenant;
                case "Thief":
                    return Gw2Sharp.Models.Profession.Thief;
                case "Warrior":
                    return Gw2Sharp.Models.Profession.Warrior;
                default:
                    return Gw2Sharp.Models.Profession.Elementalist;
            }
        }
    }
}
