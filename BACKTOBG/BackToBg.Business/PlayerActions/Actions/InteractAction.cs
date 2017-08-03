using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Business.Exceptions;
using BackToBg.Business.UtilityInterfaces;
using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Business.PlayerActions.Actions
{
    public class InteractAction : PlayerAction
    {
        private IEnumerable<IBuilding> buildings;

        public InteractAction(IPlayer player, char[][] mapArray, IMap map) : base(player, mapArray)
        {
            this.buildings = map.Drawables;
        }

        public override void Execute()
        {
            var building = this.GetAdjacentBuilding();
            this.player.Interact(building);
        }

        private IBuilding GetAdjacentBuilding()
        {
            foreach (var building in this.buildings)
            {
                if (this.player.AdjacentTo(building))
                {
                    return building;
                }
            }

            throw new PlayerNotNearAnyBuildingException();
        }
    }
}
