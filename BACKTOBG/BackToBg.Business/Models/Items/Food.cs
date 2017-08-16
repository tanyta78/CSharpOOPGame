using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Models.Items
{
    public abstract class Food : Merchandise, IFood
    {
        private int stamina;

        public Food(int id, string name, int price, int stamina) : base(id, name, price)
        {
            this.Stamina = stamina;
        }

        public int Stamina
        {
            get => this.stamina;
            set
            {
                Validator.IsPositive(value, nameof(this.stamina) + Messages.ValueShouldBePositive);
                this.stamina = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Price}$";
        }
    }
}