using System;
using System.Collections.Generic;
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
		private IPlayer player;

		public BuyMenu(string name, IReader reader, IWriter writer,IPlayer player) : base(name, reader, writer)
		{
			this.player = player;
			this.shopList = new List<IFood>();
			this.shopList.Add(new Kifla(1, "Kifla s marmalad", 2, 15));
			this.shopList.Add(new Kifla(2, "Kifla s shokolad", 2, 20));
			this.shopList.Add(new Kifla(4, "Kifla s krem", 2, 13));
			this.AddToItemsToMenu();										//TODO rework adding items of the shopList


			this.actions = new Dictionary<int, Action>
					{
						{0, () =>												//TODO with foreach?
						{
							this.player.Stamina+=this.shopList[0].Stamina;
							this.player.Money -= this.shopList[0].Price;		//TODO if not enough money
							ShouldBeRunning = false;
						}},
						{1, () =>
						{
							this.player.Stamina+=this.shopList[1].Stamina;
							this.player.Money -= this.shopList[1].Price;
							ShouldBeRunning = false;
						}},
						{2, () =>
						{
							this.player.Stamina+=this.shopList[2].Stamina;
							this.player.Money -= this.shopList[2].Price;
							ShouldBeRunning = false;
						}},
						{3,() => ShouldBeRunning = false}
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
