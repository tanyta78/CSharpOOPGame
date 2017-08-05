using BackToBg.Core.Models.Enums;

namespace BackToBg.Core.Models.Items.Books
{
    public class Encyclopedia : Book
    {
        private const int StrengthGain = 3;
        private const int AgilityGain = 4;
        private const int IntelligenceGain = 30;

        public Encyclopedia(int id, string name, int price, Rarity rarity)
            : base(id, name, price, StrengthGain, IntelligenceGain, AgilityGain, rarity)
        {
        }
    }
}