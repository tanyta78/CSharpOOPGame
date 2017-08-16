using System;
using System.Collections.Generic;

namespace BackToBg.Core.Business.UtilityInterfaces
{
    public interface IRandomEncountersManager
    {
        IDictionary<int, Action> RandomEncounters { get; }
    }
}