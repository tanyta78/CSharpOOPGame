using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Models;
using BackToBg.Models.Buildings.SpecialBuildings;
using BackToBg.Models.EntityInterfaces;
using BackToBg.Models.Items.Weapons;
using BackToBg.Models.Utility_Models;
using BackToBg.Models.Utility_Models.TradeDialogs;

namespace BackToBg.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TradeDialog td = new ShopTradeDialog(new Point(0,0),new Player()
            {
                PersonalInventory = new List<IItem>()
                {
                    new Axe(0,"Sekachkata",59,"Rare"),
                    new Hammer(1,"Chukaloto",99,"Normal")
                }
            },new Shop(1,"Mall of Sofia",null,));
        }
    }
}
