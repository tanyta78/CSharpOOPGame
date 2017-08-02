using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Client.Core;
using BACKTOBG.Models;

namespace BackToBg.Business.PlayerActions.Actions
{
    public class MoveDownAction : PlayerAction
    {
        public MoveDownAction(IPlayer player) : base(player)
        {
        }

        public override void Execute()
        {
            this.player.MoveSouth();
        }
    }
}
