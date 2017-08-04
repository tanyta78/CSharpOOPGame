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
        private readonly IPlayer player;

        [Inject]
        private readonly IMap map;
        
        public override void Execute()
        {
            var building = this.GetAdjacentBuilding();
            this.player.Interact(building);
        }

        private IBuilding GetAdjacentBuilding()
        {
            foreach (var building in this.map.Drawables)
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
