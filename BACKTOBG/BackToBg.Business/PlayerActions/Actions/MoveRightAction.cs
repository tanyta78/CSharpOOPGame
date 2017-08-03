using BackToBg.Models.EntityInterfaces;
using BackToBg.Business.Attributes;

namespace BackToBg.Business.PlayerActions.Actions
{
    [PlayerAction("RightArrow")]
    public class MoveRightAction : PlayerAction
    {
        public MoveRightAction(IPlayer player, char[][] map) : base(player, map)
        {
        }

        public override void Execute()
        {
            var info = this.player.GetDrawingInfo();
            var x = info.row;
            var y = info.col;
            if (this.map[x][y + 1] == ' ')
            {
                this.player.MoveEast();
            }
        }
    }
}
