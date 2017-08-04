using BackToBg.Models.EntityInterfaces;
using BackToBg.Business.Attributes;
using BackToBg.Business.UtilityInterfaces;

namespace BackToBg.Business.PlayerActions.Actions
{
    [PlayerAction("RightArrow")]
    public class MoveRightAction : PlayerAction
    {
        [Inject]
        private readonly IPlayer player;

        [Inject]
        private readonly IMap map;

        public override void Execute()
        {
            var info = this.player.GetDrawingInfo();
            var x = info.row;
            var y = info.col;
            if (this.map.GetMap()[x][y + 1] == ' ')
            {
                this.player.MoveEast();
            }
        }
    }
}
