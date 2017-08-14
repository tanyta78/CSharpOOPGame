using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Enums;
using BackToBg.Core.Models.Utilities;
using BackToBg.Core.Business.IO.Writer;

namespace BackToBg.Core.Models.Utility_Models.TradeDialogs
{
    public delegate void EventHandler();

    /// <summary>
    ///     The whole dialog window to display the trade. Consists of two InventarDialogs (Player's and Trader's)
    /// </summary>
    public class TradeDialog : IDrawable
    {
        private int activeRow;

        /// <summary>
        /// </summary>
        /// <param name="startingLocation">Upper left corner of figure</param>
        /// <param name="player">The first member of the trade.</param>
        /// <param name="trader">The second member of the trade. Could be another player, shop, peddlar, etc.</param>
        public TradeDialog(Point startingLocation, IPlayer player, ITradingEntity trader)
        {
            this.activeRow = 3;
            this.Location = startingLocation;
            this.Player = player as Player;
            this.Trader = trader;
            this.PlayerInventoryDialog = new InventoryDialog<ITradingEntity>(this.Player, new Point(0, 0));
            this.TraderInventoryDialog = new InventoryDialog<ITradingEntity>(trader,
                new Point(Constants.TradeDialogItemMaxLength + Constants.TradeDialogSpacingColumns, 0));
            this.ActiveInventoryDialog = this.TraderInventoryDialog;
        }

        public TradeDialog(Point startingLocation, IPlayer player, ITradingEntity trader, Point location)
        {
            this.activeRow = 3;
            this.Location = startingLocation;
            this.Player = player as Player;
            this.Trader = trader;
            this.PlayerInventoryDialog = new InventoryDialog<ITradingEntity>(this.Player, location);
            this.TraderInventoryDialog = new InventoryDialog<ITradingEntity>(trader,
                new Point(location.X + Constants.TradeDialogItemMaxLength + Constants.TradeDialogSpacingColumns,
                    location.Y));
            this.ActiveInventoryDialog = this.TraderInventoryDialog;
        }

        #region Properties

        public Point Location { get; set; }

        private ITradingEntity Trader { get; }

        private Player Player { get; }

        private InventoryDialog<ITradingEntity> TraderInventoryDialog { get; set; }

        private InventoryDialog<ITradingEntity> PlayerInventoryDialog { get; set; }

        private InventoryDialog<ITradingEntity> ActiveInventoryDialog { get; set; }

        #endregion Properties

        #region Methods

        private bool Input(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    this.ActiveInventoryDialog.Refresh(ConsoleKey.UpArrow);
                    if (this.activeRow == 3)
                    {
                        //todo
                        Draw();
                        //activeID.page--;
                    }
                    else
                    {
                        this.activeRow--;
                    }
                    Draw();
                    return true;

                case ConsoleKey.DownArrow:
                    this.ActiveInventoryDialog.Refresh(ConsoleKey.DownArrow);
                    if (this.activeRow == Constants.TradeDialogItemRows + 3 - 1) //top info rows
                    {
                        this.activeRow = 3;
                    }
                    else
                    {
                        this.activeRow++;
                    }
                    this.activeRow++;
                    Draw();
                    return true;

                case ConsoleKey.RightArrow:
                    this.ActiveInventoryDialog.Refresh(ConsoleKey.RightArrow);
                    Draw();
                    return true;

                case ConsoleKey.LeftArrow:
                    this.ActiveInventoryDialog.Refresh(ConsoleKey.LeftArrow);
                    Draw();
                    return true;

                case ConsoleKey.Enter:
                    this.ActiveInventoryDialog.Refresh(ConsoleKey.Enter);
                    var cw = new ConsoleWriter(Console.WindowHeight, Console.WindowWidth);

                    cw.DisplayMessageInColorCentered(
                        this.ActiveInventoryDialog == this.TraderInventoryDialog
                            ? string.Format(Constants.AreYouSureBuy, this.ActiveInventoryDialog.SelectedItem.Name)
                            : string.Format(Constants.AreYouSureSell, this.ActiveInventoryDialog.SelectedItem.Name),
                        Constants.UserPromptColor);

                    var selectionInput = Console.ReadKey();
                    if (selectionInput.Key == ConsoleKey.Y)
                    {
                        Trade(this.ActiveInventoryDialog.SelectedItem);
                        Draw();
                    }
                    else if (selectionInput.Key == ConsoleKey.N)
                    {
                        //draw trade dialog again
                        Draw();
                    }
                    else
                    {
                        selectionInput = Console.ReadKey();
                    }
                    return true;

                case ConsoleKey.S:
                    SwitchActiveInventoryDialog();
                    Draw();
                    return true;

                case ConsoleKey.Escape:
                    Console.Clear();
                    return false;

                default:
                    return true;
            }
        }

        private void Trade(IItem item)
        {
            //TODO: UPDATE DATABASE
            if (this.ActiveInventoryDialog == this.TraderInventoryDialog)
            {
                this.Player.Trade(item, TradingOption.Buy);
                this.Trader.Trade(item, TradingOption.Sell);
            }
            else if (this.ActiveInventoryDialog == this.PlayerInventoryDialog)
            {
                this.Player.Trade(item, TradingOption.Sell);
                this.Trader.Trade(item, TradingOption.Buy);
            }
        }

        public void Use()
        {
            Draw();
            ConsoleKeyInfo input;

            while (Input(input = Console.ReadKey()))
            {
                if (input.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }

            //TODO: show last window (before trading)
        }

        private void SwitchActiveInventoryDialog()
        {
            if (this.ActiveInventoryDialog == this.TraderInventoryDialog)
            {
                this.ActiveInventoryDialog = this.PlayerInventoryDialog;
            }
            else
            {
                this.ActiveInventoryDialog = this.TraderInventoryDialog;
            }

            this.TraderInventoryDialog.Toggle();
            this.PlayerInventoryDialog.Toggle();
        }

        public (int row, int col, string[] figure) GetDrawingInfo()
        {
            return (this.Location.X, this.Location.Y, this.GenerateFigure());
        }

        protected virtual string[] GetFigure()
        {
            return this.GenerateFigure();
        }

        /// <summary>
        /// Generates the graphic represantation of the TradeDialog (no color)
        /// </summary>
        /// <returns></returns>
        private string[] GenerateFigure()
        {
            var traderDialogFigure = this.TraderInventoryDialog.GetDrawingInfo().figure;
            var playerDialogFigure = this.PlayerInventoryDialog.GetDrawingInfo().figure;
            var rows = traderDialogFigure.Length;

            IList<string> figureRows = new List<string>(rows);
            figureRows.Add(traderDialogFigure[0] + new string(' ', Constants.TradeDialogSpacingColumns) +
                           playerDialogFigure[0]);

            for (var i = 1; i < rows; i++)
            {
                var sb = new StringBuilder();

                if (i <= traderDialogFigure.Length - 1)
                {
                    sb.Append(traderDialogFigure[i]);
                }
                else
                {
                    sb.Append(Functions.AlignLine("", Constants.TradeDialogItemMaxLength));
                }

                //append middle separators that are for the ---> <--- arrows
                this.AppendSeparatorColumns(sb, i, rows);

                if (i <= playerDialogFigure.Length - 1)
                {
                    sb.Append(playerDialogFigure[i]);
                }

                if (!string.IsNullOrEmpty(sb.ToString()))
                {
                    figureRows.Add(sb.ToString());
                }
            }

            return figureRows.ToArray();
        }

        private void Draw()
        {
            Console.Clear();

            Console.SetCursorPosition(this.Location.X, this.Location.Y);
            var consoleColors = new Color[3];
            consoleColors[2] = Constants.InventoryActiveRowColor;

            if ((this.ActiveInventoryDialog == this.TraderInventoryDialog))
            {
                consoleColors[0] = Constants.InventoryActiveColor;
                consoleColors[1] = Constants.InventoryInactiveColor;
            }
            else
            {
                consoleColors[1] = Constants.InventoryActiveColor;
                consoleColors[0] = Constants.InventoryInactiveColor;
            }

            var figure = GenerateFigure();
            var y = this.Location.Y;

            for (int i = 0; i < figure.Length; i++)
            {
                int colorId = 0;
                if (i == this.ActiveInventoryDialog.ActiveRow &&
                    this.ActiveInventoryDialog == this.TraderInventoryDialog)
                {
                    colorId = 2;
                }

                Colorful.Console.Write(figure[i].Substring(0, Constants.TradeDialogItemMaxLength - 1),
                    consoleColors[colorId]);

                Console.Write(new string(' ', Constants.TradeDialogSpacingColumns));

                colorId = 1;

                if (i == this.ActiveInventoryDialog.ActiveRow &&
                    this.ActiveInventoryDialog == this.PlayerInventoryDialog)
                {
                    colorId = 2;
                }
                Colorful.Console.Write(figure[i]
                    .Substring(Constants.TradeDialogItemMaxLength - 1 + Constants.TradeDialogSpacingColumns,
                        Constants.TradeDialogItemMaxLength - 1), consoleColors[colorId]);

                Console.SetCursorPosition(this.Location.X, ++y);
            }

            //append arrows after having drawn the rest
            var rows = figure.Length;
            Console.SetCursorPosition(Constants.TradeDialogItemMaxLength, this.Location.Y + rows / 2);
            Colorful.Console.Write("--->", Color.Yellow);
            Console.SetCursorPosition(Constants.TradeDialogItemMaxLength, this.Location.Y + rows / 2 + 1);
            Colorful.Console.Write("<---", Color.Yellow);

            Console.SetCursorPosition(this.Location.X, this.Location.Y + Constants.TradeDialogItemRows + 4);
        }

        private void AppendSeparatorColumns(StringBuilder sb, int i, int rows)
        {
            var rightArrow = new string('-', Constants.TradeDialogSpacingColumns - 1) + '>';
            var leftArrow = '<' + new string('-', Constants.TradeDialogSpacingColumns - 1);

            if (i == rows / 2)
                sb.Append(rightArrow);
            else if (i == rows / 2 + 1)
                sb.Append(leftArrow);
            else
                sb.Append(new string(' ', Constants.TradeDialogSpacingColumns));
        }

        #endregion Methods
    }
}