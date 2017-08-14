using System;
using System.Collections.Generic;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.UtilityInterfaces
{
    public interface IMap
    {
        IEnumerable<IBuilding> Drawables { get; }

        IEnumerable<IPunchable> Punchables { get; }
        int Size { get; }

        char[][] GetMap();
        
        void GenerateMap();
        void DrawMap();
        void AddPunchable(IPunchable punchable);
        void RemovePunchable(IPunchable punchable);
        void AddBuilding(IBuilding building);
        bool CanSpawnEntityInSpot(int row, int col);
    }
}