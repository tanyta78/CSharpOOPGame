using BackToBg.Models.Enums;

namespace BackToBg.Models.Items.Books
{
    public abstract class Book : Item
    {
        protected Book(int id, string name, int price, int strengthBonus, int intelligenceBonus, int agilityBonus,
            Rarity rarity)
            : base(id, name, price, strengthBonus, intelligenceBonus, agilityBonus, rarity)
        {
        }
    }
}