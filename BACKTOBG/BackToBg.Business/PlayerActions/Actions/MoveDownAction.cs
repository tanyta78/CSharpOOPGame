using BackToBg.Models.EntityInterfaces;
using BackToBg.Business.Attributes;
using BackToBg.Business.UtilityInterfaces;

namespace BackToBg.Business.PlayerActions.Actions
{
    [PlayerAction("DownArrow")]
    public class MoveDownAction : PlayerAction
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
            if (this.map.GetMap()[x + 1][y] == ' ')
            {
                this.player.MoveSouth();
            }
        }
    }
}
