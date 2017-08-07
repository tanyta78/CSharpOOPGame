using System.Collections.Generic;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.UtilityInterfaces
{
    public interface IEngine
    {
        void Run();
        IPlayer Player { get; }
        ITown GetCurrentTown();
        IList<ITown> GetTowns();
        void AddTown(ITown town);
        void SetCurrentTown(ITown town);
        void AddQuest(IQuest quest);
    }
}