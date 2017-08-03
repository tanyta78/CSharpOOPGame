using BackToBg.Models.EntityInterfaces;
using BackToBg.Business.Attributes;

namespace BackToBg.Business.PlayerActions.Actions
{
    [PlayerAction("DownArrow")]
    public class MoveDownAction : PlayerAction
    {
        public MoveDownAction(IPlayer player, char[][] map) : base(player, map)
        {
        }

        public override void Execute()
        {
            var info = this.player.GetDrawingInfo();
            var x = info.row;
            var y = info.col;
            if (this.map[x + 1][y] == ' ')
            {
                this.player.MoveSouth();
            }
        }
    }
}
