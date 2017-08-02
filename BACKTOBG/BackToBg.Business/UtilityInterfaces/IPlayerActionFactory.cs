using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Client.Core;

namespace BackToBg.Business.Contracts
{
    public interface IPlayerActionFactory
    {
        IPlayerAction CreateAction(ConsoleKey key);
    }
}
