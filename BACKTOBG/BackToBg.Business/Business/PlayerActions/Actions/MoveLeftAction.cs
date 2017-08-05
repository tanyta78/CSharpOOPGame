using BackToBg.Business.Attributes;
using BackToBg.Business.UtilityInterfaces;
using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Business.PlayerActions.Actions
{
    [PlayerAction("LeftArrow")]
    public class MoveLeftAction : PlayerAction
    {
        [Inject] private readonly IMap map;

        [Inject] private readonly IPlayer player;

        public override void Execute()
        {
            var info = this.player.GetDrawingInfo();
            var x = info.row;
            var y = info.col;
            if (this.map.GetMap()[x][y - 1] == ' ')
                this.player.MoveWest();
        }
    }
}