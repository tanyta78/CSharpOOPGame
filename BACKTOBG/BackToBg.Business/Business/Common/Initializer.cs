using BackToBg.Models.Buildings;
using BackToBg.Models.Buildings.SpecialBuildings;
using BackToBg.Models.EntityInterfaces;
using System.Collections.Generic;

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
            buildings.Add(new PoliceOffice(1, "Police Station", "Just a police station", 30, 15));
            buildings.Add(new BasicBuilding(20, 23));

            return buildings;
        }
    }
}
