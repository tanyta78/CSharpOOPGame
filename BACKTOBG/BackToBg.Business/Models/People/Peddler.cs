using System;
using System.Collections.Generic;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Enums;
using BackToBg.Core.Models.Items;

namespace BackToBg.Core.Models.People
{
    public class Peddler : ITradingEntity
    {
        //TODO

        public List<Item> Items { get; set; }

        public IList<IItem> Inventory { get; set; }
        public string Name { get; set; }

        public void Trade(IItem item, TradingOption tradingOption)
        {
            if (tradingOption == TradingOption.Buy)
            {
                this.Inventory.Add(item);
            }
            else if (tradingOption == TradingOption.Sell)
            {
                this.Inventory.Remove(item);
            }
        }
    }
}