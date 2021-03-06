﻿using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Models.Buildings
{
    public abstract class Building : IBuilding
    {
        protected int sizeFactor
            ; // coefficient of how big compared to the default size of the building the current instance should be

        protected int x;
        protected int y;

        protected Building(int x, int y, int sizeFactor = Constants.DefaultSizeFactor)
        {
            this.x = x;
            this.y = y;
            this.sizeFactor = sizeFactor;
        }

        public abstract (int row, int col, string[] figure) GetDrawingInfo();

        public abstract void Interact();
    }
}