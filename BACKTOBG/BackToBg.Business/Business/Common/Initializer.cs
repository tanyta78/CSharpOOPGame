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
			
			buildings.Add(new BasicBuilding(2, 5));
	        buildings.Add(new BasicBuilding(2, 12));
	        buildings.Add(new BasicBuilding(2, 18,2));
			buildings.Add(new BasicBuilding(1, 30));
	        buildings.Add(new BasicBuilding(6, 30));
	        buildings.Add(new BasicBuilding(10, 30));
	        buildings.Add(new BasicBuilding(6, 50));
			buildings.Add(new BasicBuilding(10, 4, 2));
            buildings.Add(new BasicBuilding(20, 23));

            return buildings;
        }
    }
}