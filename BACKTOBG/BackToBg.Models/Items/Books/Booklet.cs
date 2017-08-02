namespace BackToBg.Models.Items.Books
{
    public class Booklet : Book
    {
        private const int StrengthGain = 1;
        private const int AgilityGain = 2;
        private const int IntelligenceGain = 10;

        public Booklet(int id, string name, int price, string rarity) 
            : base(id, name, price, StrengthGain, IntelligenceGain, AgilityGain, rarity)
        {
        }
    }
}
