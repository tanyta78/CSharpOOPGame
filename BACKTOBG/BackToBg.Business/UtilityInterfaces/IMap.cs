using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BACKTOBG.Models;

namespace BackToBg.Map
{
    public interface IMap
    {
        char[][] GetMap();

        void Update(ConsoleKey key);
    }
}
