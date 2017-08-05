using BackToBg.Core.Models.Enums;

namespace BackToBg.Core.Models.Items.Boots
{
    public class Overshoe : Boot
    {
        private const int StrengthGain = 1;
        private const int AgilityGain = 12;
        private const int IntelligenceGain = 1;

        public Overshoe(int id, string name, int price, Rarity rarity)
            : base(id, name, price, StrengthGain, IntelligenceGain, AgilityGain, rarity)
        {
        }
    }
}