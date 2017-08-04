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
            var rows = Constants.TradeDialogRows +
                       2; // one for the name row (top) + two for the ------- lines underneath and above it

            string nameRow = $"{this.TradingEntity.Name}'s items" +
                             new string(' ', Constants.TradeDialogSpacingColumns);
            nameRow = Functions.AlignLine(nameRow, Constants.TradeDialogItemMaxLength);

            IList<string> figureRows = new List<string>()
            {
                $"{new string('-', Constants.TradeDialogItemMaxLength)}",
                nameRow,
                $"{new string('-', Constants.TradeDialogItemMaxLength)}"
            };

            if (rows > this.TradingEntity.Inventory.Count)
            {
                rows = this.TradingEntity.Inventory.Count; //info row (top)
            }

            for (var i = 0; i < rows; i++)
            {
                //Build inventory item string
                var sb = new StringBuilder();

                if (this.TradingEntity.Inventory.Count - 1 >= i) //entity has such index in items collection
                {
                    var item = this.TradingEntity.Inventory[i];
                    var shopItemText = $"{i}. {item.Name} {item.Price}";

                    shopItemText = Functions.AlignLine(shopItemText, Constants.TradeDialogItemMaxLength);

                    sb.Append(shopItemText);
                }

                if (!string.IsNullOrEmpty(sb.ToString()))
                {
                    figureRows.Add(sb.ToString());
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