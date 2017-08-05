using BackToBg.Business.Attributes;
using BackToBg.Business.Exceptions;
using BackToBg.Business.UtilityInterfaces;
using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Business.PlayerActions.Actions
{
    [PlayerAction("Spacebar")]
    public class InteractAction : PlayerAction
    {
        [Inject] private readonly IMap map;

        [Inject] private readonly IPlayer player;

        public override void Execute()
        {
            var building = GetAdjacentBuilding();
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