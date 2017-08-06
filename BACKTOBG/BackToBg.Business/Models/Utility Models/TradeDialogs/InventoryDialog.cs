﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Models.Utility_Models.TradeDialogs
{
    public class InventoryDialog<T> : IDrawable where T : ITradingEntity
    {
        #region Fields

        private bool isActive;
        private int page;
        private int activeRow;

        #endregion

        public InventoryDialog(T tradingEntity, Point location)
        {
            this.TradingEntity = tradingEntity;
            this.Location = location;
            this.page = 1;
            this.activeRow = 3;
            this.SelectedItem = this.TradingEntity.Inventory[0];
        }

        #region Properties

        public IItem SelectedItem { get; set; }

        public Point Location { get; set; }

        public int ActiveRow => this.activeRow;

        //Could be Shop, Player, Peddlar
        private T TradingEntity { get; }

        #endregion

        #region Methods

        public (int row, int col, string[] figure) GetDrawingInfo()
        {
            return (this.Location.X, this.Location.Y, this.GenerateFigure());
        }

        public void Toggle()
        {
            this.isActive = !this.isActive;
        }

        private string[] GenerateFigure()
        {
            string nameRow = $"{this.TradingEntity.Name}'s items" +
                             new string(' ', Constants.TradeDialogSpacingColumns);
            nameRow = Functions.AlignLine(nameRow, Constants.TradeDialogItemMaxLength);

            //add first three info rows
            IList<string> figureRows = new List<string>()
            {
                $"{new string('-', Constants.TradeDialogItemMaxLength)}",
                nameRow,
                $"{new string('-', Constants.TradeDialogItemMaxLength)}"
            };

            foreach (var row in ListItemsAndPage())
            {
                figureRows.Add(row);
            }

            return figureRows.ToArray();
        }

        private IList<string> ListItemsAndPage()
        {
            int rows = Constants.TradeDialogItemRows + 1;
            int toSkip = 0;

            if (this.TradingEntity.Inventory.Count >= Constants.TradeDialogItemRows)
            {
                toSkip = (this.page - 1) * Constants.TradeDialogItemRows;
            }

            var itemsOnPage = this.TradingEntity.Inventory
                .Skip(toSkip) // 0 if less than items on one page
                .Take(Constants.TradeDialogItemRows).ToList();

            List<string> figureRows = new List<string>();

            for (var i = 0; i < rows - 1; i++)
            {
                //Build inventory item string
                var sb = new StringBuilder();

                if (i <= itemsOnPage.Count - 1) //such index in inventory exists
                {
                    var item = itemsOnPage[i];
                    var shopItemText =
                        $"{(this.page - 1) * Constants.TradeDialogItemRows + i}. {item.Name} ${item.Price}";

                    shopItemText = Functions.AlignLine(shopItemText, Constants.TradeDialogItemMaxLength);

                    sb.Append(shopItemText);
                }

                figureRows.Add(Functions.AlignLine(sb.ToString(), Constants.TradeDialogItemMaxLength));
            }

            int pages = this.TradingEntity.Inventory.Count / Constants.TradeDialogItemRows;
            if (pages < (double) this.TradingEntity.Inventory.Count / Constants.TradeDialogItemRows)
            {
                pages++;
            }

            //add page info row at the bottom
            figureRows.Add(Functions.AlignLine($"page {this.page}/{pages}", Constants.TradeDialogItemMaxLength));

            return figureRows;
        }

        public void Refresh(ConsoleKey key)
        {
            int pages = this.TradingEntity.Inventory.Count / Constants.TradeDialogItemRows;
            if (pages < (double) this.TradingEntity.Inventory.Count / Constants.TradeDialogItemRows)
            {
                pages++;
            }

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (this.activeRow > 3)
                    {
                        this.activeRow--;
                    }
                    else
                    {
                        if (this.page > 1) //if not first page
                        {
                            this.page--;
                            this.activeRow = Constants.TradeDialogItemRows + 2;
                        }
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (this.activeRow < Constants.TradeDialogItemRows + 2)
                    {
                        //TODO: check if rows under are empty strings
                        if (ListItemsAndPage()[this.activeRow - 2].Trim() == string.Empty)
                        {
                            break;
                        }
                        this.activeRow++;
                    }
                    else
                    {
                        if (this.page < pages) //if not last page
                        {
                            this.page++;
                            this.activeRow = 3;
                        }
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (this.page < pages) //if not last page
                    {
                        this.page++;
                        this.activeRow = 3;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (this.page > 1) //if not first page
                    {
                        this.page--;
                        this.activeRow = 3;
                    }
                    break;
                case ConsoleKey.Enter:
                    this.SelectedItem = this.TradingEntity.Inventory
                        .Skip((this.page - 1) * Constants.TradeDialogItemRows + this.activeRow - 3).First();
                    break;
                case ConsoleKey.S:
                    Toggle();
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}