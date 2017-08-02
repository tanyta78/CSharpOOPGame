namespace BackToBg.Models.Items.Boots
{
    public class Sneaker : Boot
    {
        private const int StrengthGain = 2;
        private const int AgilityGain = 15;
        private const int IntelligenceGain = 2;

        public Sneaker(int id, string name, int price, string rarity) 
            : base(id, name, price, StrengthGain, IntelligenceGain, AgilityGain, rarity)
        {
        }
    }
}
