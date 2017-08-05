using BackToBg.Core.Business.Attributes;
using BackToBg.Core.Business.Exceptions;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.PlayerActions.Actions
{
    [PlayerAction("Spacebar")]
    public class InteractAction : PlayerAction
    {
        [Inject] private readonly IMap map;

        [Inject] private readonly IPlayer player;

        public override void Execute()
        {
            var building = this.GetAdjacentBuilding();
            this.player.Interact(building);
        }

        private IBuilding GetAdjacentBuilding()
        {
            foreach (var building in this.map.Drawables)
                if (this.player.AdjacentTo(building))
                    return building;

            throw new PlayerNotNearAnyBuildingException();
        }
    }
}