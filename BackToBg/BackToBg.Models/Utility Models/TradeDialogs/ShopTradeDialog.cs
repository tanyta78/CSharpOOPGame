using System.Collections.Generic;
using System.Linq;
using BackToBg.Models.Buildings.SpecialBuildings;
using BackToBg.Models.Items;

namespace BackToBg.Models.Utility_Models.TradeDialogs
{
    public class ShopTradeDialog : TradeDialog
    {
        public ShopTradeDialog(Point startingLocation, Player player, Shop shop) : base(startingLocation, player, shop)
        {
        }

        //*Shop
        public override string[] GenerateFigure()
        {
            IList<string> figureRows = new List<string>();


            return figureRows.ToArray();
        }
    }
}
