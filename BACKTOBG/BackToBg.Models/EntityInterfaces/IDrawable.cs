using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToBg.Models.EntityInterfaces
{
    public interface IDrawable
    {
        (int row, int col, string[] figure) GetDrawingInfo();
    }
}  
