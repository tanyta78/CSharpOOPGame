using BackToBg.Core.Business.Attributes;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.PlayerActions.Actions
{
    [PlayerAction("UpArrow")]
    public class MoveUpAction : PlayerAction
    {
        [Inject] private readonly IMap map;

        [Inject] private readonly IPlayer player;

        public override void Execute()
        {
            var info = this.player.GetDrawingInfo();
            var x = info.row;
            var y = info.col;
            if (this.map.GetMap()[x - 1][y] == ' ')
                this.player.MoveNorth();
        }
    }
}