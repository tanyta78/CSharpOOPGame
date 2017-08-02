using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Business.PlayerActions;
using BACKTOBG.Models;

namespace BackToBg.Client.Core.PlayerActions
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
