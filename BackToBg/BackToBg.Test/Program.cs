using System;
using System.Collections.Generic;
using BackToBg.Models;
using BackToBg.Models.Buildings.SpecialBuildings;
using BackToBg.Models.Buildings.SpecialBuildings.Shops;
using BackToBg.Models.EntityInterfaces;
using BackToBg.Models.Enums;
using BackToBg.Models.Items.Books;
using BackToBg.Models.Items.Boots;
using BackToBg.Models.Items.Weapons;
using BackToBg.Models.Utility_Models;
using BackToBg.Models.Utility_Models.TradeDialogs;

namespace BackToBg.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TradeDialog td = new TradeDialog(new Point(0, 0),
                new Player("Pesho")
                {
                    Inventory = new List<IItem>
                    {
                        new Axe(1, "Cepeni4kata", 99, Rarity.Common),
                        new Encyclopedia(2, "Za dinozavrite", 15, Rarity.Epic)
                    }
                },
                new MallShop(1, "Mall of Sofia", null, 10, 10)
                {
                    Inventory = new List<IItem>
                    {
                        new Primer(1, "Primer", 55, Rarity.Epic),
                        new Overshoe(5, "Obushta", 60, Rarity.Epic)
                    }
                });

            var figureInfo = td.GetDrawingInfo();
            var figure = figureInfo.figure;

            for (int i = 0; i < figure.Length; i++)
            {
                Console.WriteLine(figure[i]);
            }



            Console.WriteLine("Praznite redove sa za6toto sym hardcodenal w constanta broq na itemi per page");
            Console.WriteLine("TODO: add pagination + Active inventory selection + Item selection");
        }
    }
}