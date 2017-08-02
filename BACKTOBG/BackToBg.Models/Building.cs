using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToBg.Models.EntityInterfaces
{
    public abstract class Building : IDrawable
    {
        private int x;
        private int y;
        private int width;
        private int height;

        protected Building(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public abstract (int x, int y, string figure) GetDrawingInfo();
    }
}
