using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
