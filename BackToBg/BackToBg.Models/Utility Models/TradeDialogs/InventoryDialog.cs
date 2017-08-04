using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackToBg.Models.EntityInterfaces;
using BackToBg.Models.Utilities;

namespace BackToBg.Models.Utility_Models.TradeDialogs
{
    public class InventoryDialog : IDrawable
    {
        public Point Location { get; set; }

        //Could be Shop or Player
        public IInventoryOwner InventoryOwner { get; set; }

        public InventoryDialog(IInventoryOwner p, Point location)
        {
            this.InventoryOwner = p;
        }

        public (int row, int col, string[] figure) GetDrawingInfo()
        {
            return (this.Location.X, this.Location.Y, GenerateFigure());

        }

        private string[] GenerateFigure()
        {
            int rows = Constants.TradeDialogRows + 1;
            IList<string> figureRows = new List<string>(rows)
            {
                [0] = $"{this.InventoryOwner.Name} items" + new string(' ', Constants.TradeDialogSpacingColumns) +
                            $"{this.InventoryOwner.Name}'s items"
            };

            for (int i = 1; i < rows; i++)
            {
                StringBuilder sb = new StringBuilder();

                //Build shop item string
                if (this.InventoryOwner.Inventory.Count - 1 >= i) //shop has such index in items collection
                {
                    var shopItem = this.InventoryOwner.Inventory[i];
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
