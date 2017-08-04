using System;

namespace BackToBg.Business.UtilityInterfaces
{
    public interface IPlayerActionFactory
    {
        IPlayerAction CreateAction(ConsoleKey key);
    }
}