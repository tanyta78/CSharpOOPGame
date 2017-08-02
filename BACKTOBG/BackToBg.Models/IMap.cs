using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToBg.Map
{
    public interface IMap
    {
        char[][] GetMap();

        void Update();
    }
}
