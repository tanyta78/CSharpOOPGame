using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Items.Foods;

namespace BackToBg.Core.Business.Menu
{
	public class BuyMenu : Menu
	{
		private IEngine engine;
		private IDictionary<int, Action> actions;
		private IList<IFood> shopList;

		public BuyMenu(string name, IReader reader, IWriter writer) : base(name, reader, writer)
		{
			this.shopList = new List<IFood>();
			this.shopList.Add(new Kifla(1, "Kifla s marmalad", 2, 15));
			this.shopList.Add(new Kifla(2, "Kifla s shokolad", 2, 20));
			this.shopList.Add(new Kifla(4, "Kifla s krem", 2, 13));
			this.AddToItemsToMenu();										//TODO rework adding items of the shopList


			this.actions = new Dictionary<int, Action>
					{
						{0, () => ShouldBeRunning = false},

						{4,() => ShouldBeRunning = false}
					};
		}
		private IList<string> menuText = new List<string>();
		private void AddToItemsToMenu()
		{
			foreach (var food in this.shopList)
			{
				string f = $"{food.Name}-{food.Price}$";
				this.menuText.Add(f);
			}
			this.menuText.Add("Exit");
		}
		protected override IDictionary<int, Action> Actions => this.actions;
		protected override IList<string> MenuText => this.menuText;
	}
}
