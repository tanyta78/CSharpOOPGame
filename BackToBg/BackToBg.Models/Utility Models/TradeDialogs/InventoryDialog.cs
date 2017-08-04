using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackToBg.Models.EntityInterfaces;
using BackToBg.Models.Utilities;

namespace BackToBg.Models.Utility_Models.TradeDialogs
{
    public class InventoryDialog<T> : IDrawable where T : ITradingEntity
    {
        public InventoryDialog(T tradingEntity, Point location)
        {
            this.TradingEntity = tradingEntity;
            this.Location = location;
        }

        #region Properties

        public Point Location { get; set; }

        //Could be Shop, Player, Peddlar
        private T TradingEntity { get; }

        #endregion

        #region Methods

        private string[] GenerateFigure()
        {
            var rows = Constants.TradeDialogRows + 1;
            IList<string> figureRows = new List<string>(rows)
            {
                [0] = $"{this.TradingEntity.Name}'s items" + new string(' ', Constants.TradeDialogSpacingColumns)
            };

            for (var i = 1; i < rows; i++)
            {
                var sb = new StringBuilder();

                //Build inventory item string
                if (this.TradingEntity.Inventory.Count - 1 >= i) //shop has such index in items collection
                {
                    var item = this.TradingEntity.Inventory[i];

                    //TODO: add some popup to display items details
                    var shopItemText = $"{i}. {item.Name} {item.Price}";

                    if (shopItemText.Length > Constants.TradeDialogItemMaxLength)
                        shopItemText = shopItemText.Substring(0, Constants.TradeDialogItemMaxLength - 3) + "...";

                    sb.Append(shopItemText);
                }
            }

            return figureRows.ToArray();
        }

        public (int row, int col, string[] figure) GetDrawingInfo()
        {
            return (this.Location.X, this.Location.Y, GenerateFigure());
        }

        #endregion
    }
}