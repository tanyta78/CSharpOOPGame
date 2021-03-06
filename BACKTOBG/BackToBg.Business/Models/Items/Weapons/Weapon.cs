﻿using BackToBg.Core.Models.Enums;

namespace BackToBg.Core.Models.Items.Weapons
{
    public abstract class Weapon : Item
    {
        protected Weapon(int id, string name, int price, int strengthBonus, int intelligenceBonus, int agilityBonus,
            Rarity rarity)
            : base(id, name, price, strengthBonus, intelligenceBonus, agilityBonus, rarity)
        {
        }
    }
}