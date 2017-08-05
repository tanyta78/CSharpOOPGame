using System.Collections.Generic;
using BackToBg.Core.Models.Buildings;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.Common
{
    public static class Initializer
    {
        public static IList<IBuilding> InitializeBuildings()
        {
            IList<IBuilding> buildings = new List<IBuilding>();

            buildings = new List<IBuilding>();
            buildings.Add(new BasicBuilding(5, 26));
            buildings.Add(new BasicBuilding(10, 4, 2));
            buildings.Add(new BasicBuilding(20, 23));

            return buildings;
        }
    }
}
