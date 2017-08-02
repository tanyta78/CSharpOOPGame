namespace BackToBg.Models.Items.Weapons
{
    public abstract class Weapon : Item
    {
        protected Weapon(int id, string name, int price, int strengthBonus, int intelligenceBonus, int agilityBonus, string rarity) 
            : base(id, name, price, strengthBonus, intelligenceBonus, agilityBonus, rarity)
        {
        }
    }
}
