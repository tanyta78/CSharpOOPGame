using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Client.Core;
using BACKTOBG.Models;

namespace BackToBg.Business.PlayerActions.Actions
{
    public class MoveLeftAction : PlayerAction
    {
        public MoveLeftAction(IPlayer player, char[][] map) : base(player, map)
        {
        }

        public override void Execute()
        {
            var info = this.player.GetDrawingInfo();
            var x = info.x;
            var y = info.y;
            if (this.map[x][y - 1] == ' ')
            {
                this.player.MoveWest();
            }
        }
    }
}
