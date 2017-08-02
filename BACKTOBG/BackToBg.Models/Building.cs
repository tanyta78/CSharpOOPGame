using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToBg.Models.EntityInterfaces
{
    public abstract class Building : IBuilding
    {
        protected int x;
        protected int y;
        protected int sizeFactor; // coefficient of how big compared to the default size of the building the current instance should be

        protected Building(int x, int y, int sizeFactor = 1)
        {
            this.x = x;
            this.y = y;
            this.sizeFactor = sizeFactor;
        }

        public abstract (int x, int y, string[] figure) GetDrawingInfo();
    }
}
