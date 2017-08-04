﻿using System;
using System.Collections.Generic;
using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Models.Buildings.SpecialBuildings
{
    public abstract class Shop : SpecialBuilding, ITradingEntity
    {
        protected Shop(int id, string name, string description, int x, int y, int sizeFactor = 1) : base(id, name,
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