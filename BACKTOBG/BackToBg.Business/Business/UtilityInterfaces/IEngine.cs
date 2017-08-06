using System.Collections.Generic;

namespace BackToBg.Core.Business.UtilityInterfaces
{
    public interface IEngine
    {
        void Run();
        ITown GetCurrentTown();
        IList<ITown> GetTowns();
        void AddTown(ITown town);
        void SetCurrentTown(ITown town);
    }
}