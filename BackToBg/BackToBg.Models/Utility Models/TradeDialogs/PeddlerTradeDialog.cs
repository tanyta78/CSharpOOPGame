using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Models.Buildings.SpecialBuildings;
using BackToBg.Models.Items;

namespace BackToBg.Models.Utility_Models.TradeDialogs
{
    public class PeddlerTradeDialog : TradeDialog
    {
        public PeddlerTradeDialog(Point startingLocation, Player player, Shop shop) : base(startingLocation, player, shop)
        {
        }

        public override string[] GenerateFigure()
        {
            throw new NotImplementedException();
        }
    }
}
