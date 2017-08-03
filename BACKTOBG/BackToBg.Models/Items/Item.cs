using System;
using System.Text;
using BackToBg.Models.EntityInterfaces;
using BackToBg.Models.Enums;

namespace BackToBg.Models.Items
{
    public abstract class Item : IItem
    {
        private int agilityBonus;
        private int id;
        private int intelligenceBonus;
        private string name;
        private int price;
        private int strengthBonus;

        protected Item(int id, string name, int price, int strengthBonus, int intelligenceBonus, int agilityBonus,
            string rarity)
        {
            this.Rarity = (Rarity) Enum.Parse(typeof(Rarity), rarity);
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.StrengthBonus = strengthBonus;
            this.IntelligenceBonus = intelligenceBonus;
            this.AgilityBonus = agilityBonus;
        }

        public int ID
        {
            get => this.id;

            private set
            {
                if (value <= 0)
                    throw new ArgumentException($"{nameof(this.id)} should be positive integer!");

                this.id = value;
            }
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"{nameof(this.name)} should not be null empty or white space!");

                this.name = value;
            }
        }

        public int Price
        {
            get => this.price;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException($"{nameof(this.price)} should be positive integer!");

                this.price = value;
            }
        }

        public int StrengthBonus
        {
            get => this.strengthBonus;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException($"{nameof(this.strengthBonus)} should be positive integer!");

                this.strengthBonus = value * (int) this.Rarity;
            }
        }

        public int IntelligenceBonus
        {
            get => this.intelligenceBonus;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException($"{nameof(this.intelligenceBonus)} should be positive integer!");

                this.intelligenceBonus = value * (int) this.Rarity;
            }
        }

        public int AgilityBonus
        {
            get => this.agilityBonus;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException($"{nameof(this.agilityBonus)} should be positive integer!");

                this.agilityBonus = value * (int) this.Rarity;
            }
        }

        public Rarity Rarity { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Id:{this.id} Name:{this.name} Price:{this.price}");
            sb.AppendLine(
                $"Strength:{this.strengthBonus} Intelligence:{this.intelligenceBonus} Agility:{this.agilityBonus}");
            sb.AppendLine($"Rarity: {this.Rarity}");

            return sb.ToString().Trim();
        }
    }
}