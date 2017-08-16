using System.Text;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Enums;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Models.Items
{
    public abstract class Item : Merchandise, IItem
    {
        private int agilityBonus;
        private int intelligenceBonus;
        private int strengthBonus;

        protected Item(int id, string name, int price, int strengthBonus, int intelligenceBonus, int agilityBonus,
            Rarity rarity) : base(id, name, price)
        {
            this.Rarity = rarity;
            this.StrengthBonus = strengthBonus;
            this.IntelligenceBonus = intelligenceBonus;
            this.AgilityBonus = agilityBonus;
        }

        public int StrengthBonus
        {
            get => this.strengthBonus;
            private set
            {
                Validator.IsPositive(value, nameof(this.StrengthBonus) + Messages.ValueShouldBePositive);
                this.strengthBonus = value * (int) this.Rarity;
            }
        }

        public int IntelligenceBonus
        {
            get => this.intelligenceBonus;
            private set
            {
                Validator.IsPositive(value, nameof(this.IntelligenceBonus) + Messages.ValueShouldBePositive);
                this.intelligenceBonus = value * (int) this.Rarity;
            }
        }

        public int AgilityBonus
        {
            get => this.agilityBonus;
            private set
            {
                Validator.IsPositive(value, nameof(this.AgilityBonus) + Messages.ValueShouldBePositive);
                this.agilityBonus = value * (int) this.Rarity;
            }
        }

        public Rarity Rarity { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Id:{this.ID} Name:{this.Name} Price:{this.Price}");
            sb.AppendLine(
                $"Strength:{this.StrengthBonus} Intelligence:{this.IntelligenceBonus} Agility:{this.AgilityBonus}");
            sb.AppendLine($"Rarity: {this.Rarity}");

            return sb.ToString().Trim();
        }
    }
}