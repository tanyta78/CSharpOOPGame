using BackToBg.Business.Attributes;
using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Business.PlayerActions.Actions
{
    [PlayerAction("LeftArrow")]
    public class MoveLeftAction : PlayerAction
    {
        public MoveLeftAction(IPlayer player, char[][] map) : base(player, map)
        {
        }

        public override void Execute()
        {
            var info = this.player.GetDrawingInfo();
            var x = info.row;
            var y = info.col;
            if (this.map[x][y - 1] == ' ')
            {
                this.player.MoveWest();
            }
        }
    }
}
