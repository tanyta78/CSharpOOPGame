using System;
using System.Collections.Generic;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Models.Buildings.SpecialBuildings
{
    public abstract class Shop : SpecialBuilding, ITradingEntity
    {
        protected Shop(int id, string name, string description, int x, int y, int sizeFactor = Constants.DefaultSizeFactor) : base(id, name,
            description, x, y, sizeFactor)
        {
            this.Inventory = new List<IItem>();
        }

        public IList<IItem> Inventory { get; set; }

        string IInventoryOwner.Name
        {
            get { return this.Name; }
            set { }
        }

        public void Trade()
        {
            throw new NotImplementedException();
        }

        public override (int row, int col, string[] figure) GetDrawingInfo()
        {
            throw new NotImplementedException();
        }

        public override void Interact()
        {
            throw new NotImplementedException();
        }
    }
}