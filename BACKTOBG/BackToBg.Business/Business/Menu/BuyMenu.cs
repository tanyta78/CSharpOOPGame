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

		public BuyMenu(string name, IReader reader, IWriter writer, IPlayer player) : base(name, reader, writer)
		{
		    this.player = player;
			this.shopList = new List<IFood>
			{
				new Kifla(1, "Kifla s marmalad", 2, 15),
				new Kifla(2, "Kifla s shokolad", 2, 20),
				new Kifla(4, "Kifla s krem", 2, 13)
			};
			this.actions=new Dictionary<int, Action>();
		}

		protected override void PrintMenu()
		{
			this.Writer.Clear();
			this.Writer.SetCursorPosition((this.Writer.ConsoleWidth - this.name.Length) / 2, (this.Writer.ConsoleHeight - this.shopList.Count) / 2 - 1);
			this.Writer.DisplayMessageInColor(this.name, ConsoleColor.Green);
			for (var i = 0; i < this.shopList.Count; i++)
			{			
				this.Writer.SetCursorPosition(this.Writer.ConsoleWidth / 2 - this.shopList[0].Name.Length,
					(this.Writer.ConsoleHeight - this.shopList.Count) / 2 + i + 1);
				if (i == this.selectedIndex)
				{
					this.Writer.WriteLine($">{this.shopList[i]}<");
				}
				else
				{
					this.Writer.WriteLine(this.shopList[i].ToString());
				}
			}
		}
		protected override void ReadKeyInput()
		{
			var key = this.Reader.ReadKey();
			switch (key.Key)
			{
				case ConsoleKey.UpArrow:
					this.selectedIndex--;
					if (this.selectedIndex < 0)
					{
						this.selectedIndex = this.shopList.Count - 1;
					}
					break;
				case ConsoleKey.DownArrow:
					this.selectedIndex++;
					if (this.selectedIndex >= this.shopList.Count)
					{
						this.selectedIndex = 0;
					}
					break;
				case ConsoleKey.Enter:
					this.BuySelectedFood(this.selectedIndex);
					ShouldBeRunning = false;
					break;
				case ConsoleKey.Escape:
					ShouldBeRunning = false;
					break;
			}
		}

		private void BuySelectedFood(int selected)
		{	
			var restMoney = this.player.Money - this.shopList[selected].Price;
			if (restMoney >= 0)
			{
				this.player.Money -= this.shopList[selected].Price;
				this.player.Stamina += this.shopList[selected].Stamina;
			}
			else
			{
				throw new Exception();	//TODO catch ex 

			}
		}
		private IList<string> menuText = new List<string>();
		protected override IDictionary<int, Action> Actions => this.actions;
		protected override IList<string> MenuText => this.menuText;
	}
}
