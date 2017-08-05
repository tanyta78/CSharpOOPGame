using System;
using System.Collections.Generic;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.UtilityInterfaces
{
    public interface IMap
    {
        IEnumerable<IBuilding> Drawables { get; }

        IEnumerable<IPunchable> Punchables { get; }

        char[][] GetMap();

        void Update(ConsoleKey key);

        void DrawMap();
        void RefreshQuest(IQuest quest);
        void AddPunchable(IPunchable punchable);
        void AddQuest(IQuest quest);
        void AddBuilding(IBuilding building);
    }
}