using System.Collections.Generic;

namespace BackToBg.Core.Business.UtilityInterfaces
{
    public interface ITownsManager
    {
        ITown GetCurrentTown();
        IList<ITown> GetTowns();
        void AddTown(ITown town);
        void SetCurrentTown(ITown town);
    }
}