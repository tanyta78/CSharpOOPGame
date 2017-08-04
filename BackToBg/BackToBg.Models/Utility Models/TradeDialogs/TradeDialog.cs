﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackToBg.Models.Buildings.SpecialBuildings;
using BackToBg.Models.EntityInterfaces;
using BackToBg.Models.Utilities;

namespace BackToBg.Models.Utility_Models.TradeDialogs
{
    /// <summary>
    ///     The whole dialog window to display the trade. Consists of two InventarDialogs (Player's and Trader's)
    /// </summary>
    public class TradeDialog : IDrawable
    {
        /// <summary>
        /// </summary>
        /// <param name="startingLocation">Upper left corner of figure</param>
        /// <param name="player">The first member of the trade.</param>
        /// <param name="trader">The second member of the trade. Could be another player, shop, peddlar, etc.</param>
        public TradeDialog(Point startingLocation, IPlayer player, ITradingEntity trader)
        {
            this.Location = startingLocation;
            this.Player = player as Player;
            this.Trader = trader;
            this.PlayerInventoryDialog = new InventoryDialog<Player>(this.Player, new Point(0, 0));
            this.TraderInventoryDialog = new InventoryDialog<ITradingEntity>(trader,
                new Point(Constants.TradeDialogItemMaxLength + Constants.TradeDialogSpacingColumns, 0));
        }

        public TradeDialog(Point startingLocation, IPlayer player, ITradingEntity trader, Point location)
        {
            this.Location = startingLocation;
            this.Player = player as Player;
            this.Trader = trader;
            this.PlayerInventoryDialog = new InventoryDialog<Player>(this.Player, location);
            this.TraderInventoryDialog = new InventoryDialog<ITradingEntity>(trader,
                new Point(location.X + Constants.TradeDialogItemMaxLength + Constants.TradeDialogSpacingColumns,
                    location.Y));
        }

        #region Properties

        public Point Location { get; set; }

        private ITradingEntity Trader { get; }

        private Player Player { get; }

        private InventoryDialog<ITradingEntity> TraderInventoryDialog { get; set; }

        private InventoryDialog<Player> PlayerInventoryDialog { get; set; }

        #endregion

        #region Methods

        public (int row, int col, string[] figure) GetDrawingInfo()
        {
            return (this.Location.X, this.Location.Y, GenerateFigure());
        }

        //*Shop items      Player Items
        //            ---> 
        //            <---
        // 1/6 pages       3/3 pages
        //TODO: should be able to move selection from shop items to player items
        private string[] GenerateFigure()
        {
            var rows = Constants.TradeDialogRows + 1;
            var traderDialogFigure = this.TraderInventoryDialog.GetDrawingInfo().figure;
            var playerDialogFigure = this.PlayerInventoryDialog.GetDrawingInfo().figure;

            IList<string> figureRows = new List<string>(rows);
            var sb = new StringBuilder();
            figureRows.Add(traderDialogFigure[0] + new string(' ', Constants.TradeDialogSpacingColumns) +
                            playerDialogFigure[0]);

            for (var i = 1; i < rows; i++)
            {
                //append middle two rows that are for the ---> <--- arrows
                if (i == rows / 2)
                    sb.Append(new string('-', Constants.TradeDialogSpacingColumns - 1) + '>');
                else if (i == rows / 2 + 1)
                    sb.Append('<' + new string('-', Constants.TradeDialogSpacingColumns - 1));
                else
                    sb.Append(new string(' ', Constants.TradeDialogSpacingColumns));
            }

            return figureRows.ToArray();
        }

        protected virtual string[] GetFigure()
        {
            return GenerateFigure();
        }

        #endregion
    }
}