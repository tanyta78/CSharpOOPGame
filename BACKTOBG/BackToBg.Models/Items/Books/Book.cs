namespace BackToBg.Models.Items.Books
{
    public abstract class Book : Item
    {
        protected Book(int id, string name, int price, int strengthBonus, int intelligenceBonus, int agilityBonus,
            string rarity)
            : base(id, name, price, strengthBonus, intelligenceBonus, agilityBonus, rarity)
        {
        }
    }
}