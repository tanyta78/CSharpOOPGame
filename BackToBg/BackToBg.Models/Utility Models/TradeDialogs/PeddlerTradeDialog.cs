using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Models.Items;

namespace BackToBg.Models.Utility_Models.TradeDialogs
{
    class PeddlerTradeDialog : TradeDialog
    {
        public PeddlerTradeDialog(Point startingLocation, List<Item> _playerItems, List<Item> _shopItems) : base(startingLocation, _playerItems, _shopItems)
        {
        }

        public override string[] GenerateFigure()
        {
            throw new NotImplementedException();
        }
    }
}
