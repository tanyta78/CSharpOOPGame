using BackToBg.Models.Enums;

namespace BACKTOBG.Models
{
    public interface IItem
    {
        int ID { get; }
        string Name { get; }
        int Price { get; }
        int StrengthBonus { get; }
        int IntelligenceBonus { get; }
        int AgilityBonus { get; }
        Rarity Rarity { get; }
    }
}