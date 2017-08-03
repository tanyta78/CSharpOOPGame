using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Business.PlayerActions.Actions
{
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
