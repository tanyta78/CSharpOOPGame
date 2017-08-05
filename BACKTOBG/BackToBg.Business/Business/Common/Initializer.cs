using BackToBg.Models.Buildings;
using BackToBg.Models.Buildings.SpecialBuildings;
using BackToBg.Models.EntityInterfaces;
using System.Collections.Generic;
using BackToBg.Business.UtilityInterfaces;

namespace BackToBg.Business.Common
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
