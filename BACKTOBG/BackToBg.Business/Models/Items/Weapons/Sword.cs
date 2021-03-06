﻿using BackToBg.Core.Models.Enums;

namespace BackToBg.Core.Models.Items.Weapons
{
    public class Sword : Weapon
    {
        private const int StrengthGain = 19;
        private const int AgilityGain = 4;
        private const int IntelligenceGain = 1;

        public Sword(int id, string name, int price, Rarity rarity)
            : base(id, name, price, StrengthGain, IntelligenceGain, AgilityGain, rarity)
        {
        }
    }
}