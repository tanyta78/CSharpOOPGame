using System;
using System.Collections.Generic;
using BackToBg.Business.Models.EntityInterfaces;
using BackToBg.Business.Models.Quests;
using BackToBg.Models;
using BackToBg.Models.Buildings.SpecialBuildings;
using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Business.UtilityInterfaces
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