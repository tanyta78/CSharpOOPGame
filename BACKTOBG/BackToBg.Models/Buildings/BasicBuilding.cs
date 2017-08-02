using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Models.Buildings
{
    public class BasicBuilding : Building
    {
        private static char border = '*';
        private static char inner = 'O';

        public BasicBuilding(int x, int y, int sizeFactor = 1) : base(x, y, sizeFactor)
        {
        }

        public override (int row, int col, string[] figure) GetDrawingInfo()
        {
            return (this.x, this.y, this.GenerateFigure());
        }

        private string[] GenerateFigure()
        {
            var size = 5 * this.sizeFactor;

            var figure = new string[size];
            for (int i = 0; i < size; i++)
            {
                
            }

            figure[0] = new string(border, size);
            for (int i = 1; i < size - 1; i++)
            {
                figure[i] = $"{border}{new string(inner, size - 2)}{border}";
            }
            figure[size - 1] = new string(border, size);

            return figure;
        }
    }
}
