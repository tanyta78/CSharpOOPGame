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
        public MoveUpAction(IPlayer player) : base(player)
        {
        }

        public override void Execute()
        {
            this.player.MoveNorth();
        }
    }
}
