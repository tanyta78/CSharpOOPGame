using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Models.Items
{
	public abstract class Merchandise
	{
		private int id;
		private string name;
		private int price;

		protected Merchandise(int id, string name, int price)
		{
			this.ID = id;
			this.Name = name;
			this.Price = price;
		}

		public int ID
		{
			get => this.id;

			private set
			{
				Validator.IsPositive(value, nameof(this.ID) + Messages.ValueShouldBePositive);
				this.id = value;
			}
		}

		public string Name
		{
			get => this.name;

			private set
			{
				Validator.IsNullEmptyOrWhiteSpace(value, nameof(this.name) + Messages.ValueShouldNotBeEmptyOrNull);
				this.name = value;
			}
		}

		public int Price
		{
			get => this.price;
			private set
			{
				Validator.IsPositive(value, nameof(this.Price) + Messages.ValueShouldBePositive);
				this.price = value;
			}
		}
	}
}
