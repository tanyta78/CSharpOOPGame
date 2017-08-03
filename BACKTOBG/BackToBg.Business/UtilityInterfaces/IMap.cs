using System;
using System.Collections.Generic;
using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Business.UtilityInterfaces
{
    public interface IMap
    {
        IEnumerable<IBuilding> Drawables { get; }

        char[][] GetMap();

        void Update(ConsoleKey key);
    }
}
