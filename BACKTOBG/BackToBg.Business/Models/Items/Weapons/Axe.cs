﻿using BackToBg.Core.Models.Enums;

namespace BackToBg.Core.Models.Items.Weapons
{
    public class Axe : Weapon
    {
        private const int StrengthGain = 13;
        private const int AgilityGain = 3;
        private const int IntelligenceGain = 2;

        public Axe(int id, string name, int price, Rarity rarity)
            : base(id, name, price, StrengthGain, IntelligenceGain, AgilityGain, rarity)
        {
        }
    }
}