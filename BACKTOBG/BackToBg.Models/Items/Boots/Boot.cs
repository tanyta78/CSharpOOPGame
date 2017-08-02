namespace BackToBg.Models.Items.Boots
{
    public abstract class Boot : Item
    {
        protected Boot(int id, string name, int price, int strengthBonus, int intelligenceBonus, int agilityBonus, string rarity) 
            : base(id, name, price, strengthBonus, intelligenceBonus, agilityBonus, rarity)
        {
        }
    }
}
