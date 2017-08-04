using System;
using System.Collections.Generic;
using BackToBg.Models.EntityInterfaces;
using BackToBg.Models.Items;

namespace BackToBg.Models.People
{
    public class Peddler : ITradingEntity
    {
        //TODO

        public List<Item> Items { get; set; }

        public IList<IItem> Inventory { get; set; }
        public string Name { get; set; }

        public void Trade()
        {
            throw new NotImplementedException();
        }
    }
}