﻿using BackToBg.Core.Models.Enums;

namespace BackToBg.Core.Models.Items.Books
{
    public class Primer : Book
    {
        private const int StrengthGain = 2;
        private const int AgilityGain = 3;
        private const int IntelligenceGain = 18;

        public Primer(int id, string name, int price, Rarity rarity)
            : base(id, name, price, StrengthGain, IntelligenceGain, AgilityGain, rarity)
        {
        }
    }
}