namespace BackToBg.Models.Items.Boots
{
    public class HeavyBoot : Boot
    {
        private const int StrengthGain = 7;
        private const int AgilityGain = 3;
        private const int IntelligenceGain = 1;

        public HeavyBoot(int id, string name, int price, string rarity)
            : base(id, name, price, StrengthGain, IntelligenceGain, AgilityGain, rarity)
        {
        }
    }
}