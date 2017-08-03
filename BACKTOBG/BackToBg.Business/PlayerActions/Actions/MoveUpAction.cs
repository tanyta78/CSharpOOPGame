using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Business.PlayerActions.Actions
{
    public class MoveUpAction : PlayerAction
    {
        public MoveUpAction(IPlayer player, char[][] map) : base(player, map)
        {
        }

        public override void Execute()
        {
            var info = this.player.GetDrawingInfo();
            var x = info.row;
            var y = info.col;
            if (this.map[x - 1][y] == ' ')
            {
                this.player.MoveNorth();
            }
        }
    }
}
