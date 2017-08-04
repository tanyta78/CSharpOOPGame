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
            figureRows[0] = $"{this.Shop.Name} items" + new string(' ', Constants.TradeDialogSpacingColumns) +
                            $"{this.Player.Name}'s items";

            for (int i = 1; i < rows; i++)
            {
                StringBuilder sb = new StringBuilder();

                //Build shop item string
                if (this.Shop.Items.Count - 1 >= i) //shop has such index in items collection
                {
                    var shopItem = this.Shop.Items[i];
                    //TODO: add some popup to display items details
                    string shopItemText = $"{i}. {shopItem.Name} {shopItem.Price}";

                    if (shopItemText.Length > Constants.TradeDialogItemMaxLength)
                    {
                        shopItemText = shopItemText.Substring(0, Constants.TradeDialogItemMaxLength - 3) + "...";
                    }

                    sb.Append(shopItemText);
                }

                //middle two rows are for the ---> <--- arrows
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

                //Build player item string
                if (this.Player.PersonalInventory.Count - 1 >= i) //player has such index in items collection
                {
                    var shopItem = this.Shop.Items[i];
                    //TODO: add some popup to display items details
                    string shopItemText = $"{i}. {shopItem.Name} {shopItem.Price}";

                    if (shopItemText.Length > Constants.TradeDialogItemMaxLength)
                    {
                        shopItemText = shopItemText.Substring(0, Constants.TradeDialogItemMaxLength - 3) + "...";
                    }

                    sb.Append(shopItemText);
                }
            }

            return figureRows.ToArray();
        }
    }
}