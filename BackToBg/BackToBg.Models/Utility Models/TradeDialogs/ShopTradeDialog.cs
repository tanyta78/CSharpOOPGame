using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackToBg.Models.Buildings.SpecialBuildings;
using BackToBg.Models.Items;
using BackToBg.Models.Utilities;

namespace BackToBg.Models.Utility_Models.TradeDialogs
{
    public class ShopTradeDialog : TradeDialog
    {
        public ShopTradeDialog(Point startingLocation, Player player, Shop shop) : base(startingLocation, player, shop)
        {
        }

        //*Shop items      Player Items
        //            ---> 
        //            <---
        // 1/6 pages       3/3 pages
        //TODO: should be able to move selection from shop items to player items
        public override string[] GenerateFigure()
        {
            int rows = Constants.TradeDialogRows + 1;
            IList<string> figureRows = new List<string>(rows);
            StringBuilder sb = new StringBuilder();
//            figureRows[0] = 1[0] + spaces + 2[0]

            for (int i = 1; i < rows; i++)
            {
                //append middle two rows that are for the ---> <--- arrows
                if (i == rows / 2)
                {
                    sb.Append(new string('-', Constants.TradeDialogSpacingColumns - 1) + '>');
                }
                else if (i == rows / 2 + 1)
                {
                    sb.Append('<' + new string('-', Constants.TradeDialogSpacingColumns - 1));
                }
                else
                {
                    sb.Append(new string(' ', Constants.TradeDialogSpacingColumns));
                }
            }

            return figureRows.ToArray();
        }
    }
}