using System.Collections.Generic;
using BackToBg.Business.Exceptions;
using BackToBg.Business.UtilityInterfaces;
using BackToBg.Models.EntityInterfaces;
using BackToBg.Business.Attributes;

namespace BackToBg.Business.PlayerActions.Actions
{
    [PlayerAction("Spacebar")]
    public class InteractAction : PlayerAction
    {
        [Inject]
        private IEnumerable<IBuilding> buildings;

        public InteractAction(IPlayer player, char[][] mapArray) : base(player, mapArray)
        {
            //this.buildings = map.Drawables;
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
