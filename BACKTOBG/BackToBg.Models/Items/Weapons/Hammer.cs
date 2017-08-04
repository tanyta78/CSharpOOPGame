using BackToBg.Models.Enums;

namespace BackToBg.Models.Items.Weapons
{
    public class Hammer : Weapon
    {
        private const int StrengthGain = 24;
        private const int AgilityGain = 1;
        private const int IntelligenceGain = 1;

        public Hammer(int id, string name, int price, Rarity rarity)
            : base(id, name, price, StrengthGain, IntelligenceGain, AgilityGain, rarity)
        {
        }
    }
}