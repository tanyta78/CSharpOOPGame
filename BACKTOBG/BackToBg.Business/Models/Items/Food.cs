using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Models.Items
{
	public abstract class Food: Merchandise,IFood
	{
		private int stamina;

		public Food(int id, string name, int price,int stamina) : base(id, name, price)
		{
			this.Stamina = stamina;
		}

		public int Stamina
		{
			get => this.stamina;
			set => this.stamina = value;	//Validation
		}
	}
}
