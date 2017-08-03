using System;

namespace BackToBg.Business.UtilityInterfaces
{
    public interface IMap
    {
        char[][] GetMap();

        void Update(ConsoleKey key);
    }
}
