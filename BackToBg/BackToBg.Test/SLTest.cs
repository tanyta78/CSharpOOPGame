using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Core.Models;
using BackToBg.Core.Models.Buildings.SpecialBuildings.Shops;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Enums;
using BackToBg.Core.Models.Items.Books;
using BackToBg.Core.Models.Items.Boots;
using BackToBg.Core.Models.Items.Weapons;
using BackToBg.Core.Models.Utility_Models;
using BackToBg.Core.Models.Utility_Models.TradeDialogs;

namespace BackToBg.Test
{
    public class SLTest
    {
        public void Execute()
        {
            Player pesho = new Player
            {
                Name = "Pesho",
                Inventory = new List<IItem>
                {
                    new Axe(1, "Cepeni4kata", 99, Rarity.Common),
                    new Hammer(2, "Za dinozavrite", 15, Rarity.Epic),
                    new Sword(3, "Me4a na Ahil", 15, Rarity.Epic),
                    new Booklet(4, "Priklu4eniq", 15, Rarity.Epic),
                    new Sneaker(5, "Adidas", 15, Rarity.Epic),
                    new Sneaker(6, "Nike", 15, Rarity.Epic),
                    new Sneaker(7, "Reebok", 15, Rarity.Epic),
                    new Sneaker(8, "Puma", 15, Rarity.Epic),
                    new Sneaker(9, "Guma", 15, Rarity.Epic),
                }
            };

            var mall = new MallShop(1, "Mall of Sofia", null, 10, 10)
            {
                Inventory = new List<IItem>
                {
                    new Primer(10, "Primer", 55, Rarity.Epic),
                    new Overshoe(11, "Obushta", 60, Rarity.Epic)
                }
            };

            TradeDialog td = new TradeDialog(new Point(0, 0),
                pesho,
                mall
            );

            var id = new InventoryDialog<Player>(pesho, new Point(0, 0));

            td.Use();
        }
    }
}