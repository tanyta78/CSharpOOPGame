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

        void Update(IPlayerAction action);
        void GenerateMap();
        void DrawMap();
        void AddPunchable(IPunchable punchable);
        void RemovePunchable(IPunchable punchable);
        void AddBuilding(IBuilding building);
    }
}