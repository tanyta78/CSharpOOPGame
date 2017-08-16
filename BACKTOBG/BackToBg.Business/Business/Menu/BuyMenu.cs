using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BackToBg.Core.Business.Exceptions;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Items.Foods;

namespace BackToBg.Core.Business.Menu
{
    public class BuyMenu : Menu
    {
        private IEngine engine;
        private readonly IPlayer player;
        private readonly IList<IFood> shopList;

        public BuyMenu(string name, IReader reader, IWriter writer, IPlayer player) : base(name, reader, writer)
        {
            this.player = player;
            this.shopList = new List<IFood>
            {
                new Kifla(1, "Kifla s marmalad", 1000, 15),
                new Kifla(2, "Kifla s shokolad", 2, 20),
                new Kifla(4, "Kifla s krem", 2, 13)
            };
            this.MenuText = this.shopList.Select(i => i.Name).ToList();
            this.Actions = new Dictionary<int, Action>();
        }

        protected override IDictionary<int, Action> Actions { get; }

        protected override IList<string> MenuText { get; } = new List<string>();

        protected override void PrintMenu()
        {
            this.Writer.Clear();
            this.Writer.SetCursorPosition((this.Writer.ConsoleWidth - this.name.Length) / 2,
                (this.Writer.ConsoleHeight - this.shopList.Count) / 2 - 1);
            this.Writer.DisplayMessageInColor(this.name, ConsoleColor.Green);
            for (var i = 0; i < this.shopList.Count; i++)
            {
                this.Writer.SetCursorPosition(this.Writer.ConsoleWidth / 2 - this.shopList[0].Name.Length,
                    (this.Writer.ConsoleHeight - this.shopList.Count) / 2 + i + 1);
                if (i == this.selectedIndex)
                    this.Writer.WriteLine($">{this.shopList[i]}<");
                else
                    this.Writer.WriteLine(this.shopList[i].ToString());
            }
        }

        private void BuySelectedFood(int selected)
        {
            var restMoney = this.player.Money - this.shopList[selected].Price;
            if (restMoney >= 0)
            {
                this.player.Money -= this.shopList[selected].Price;
                this.player.Stamina += this.shopList[selected].Stamina;
                this.writer.DisplayMessageInColorCentered($"You just bought a {this.shopList[selected].Name}",
                    ConsoleColor.Green);
                Thread.Sleep(1000);
            }
            else
            {
                throw new NotEnoughMoneyException(
                    $"Not enough money to buy {this.shopList[selected].Name}"); //TODO catch ex 
            }
        }

        protected override void ExecuteCommand(int commandNumber)
        {
            BuySelectedFood(this.selectedIndex);
        }
    }
}