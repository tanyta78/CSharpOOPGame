using System;

namespace BackToBg.Core.Business.UtilityInterfaces
{
    public interface IPlayerActionFactory
    {
        IPlayerAction CreateAction(ConsoleKey key);
    }
}