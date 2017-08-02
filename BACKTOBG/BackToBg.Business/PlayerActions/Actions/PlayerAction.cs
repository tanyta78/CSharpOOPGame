using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Client.Core;
using BACKTOBG.Models;

namespace BackToBg.Business.PlayerActions
{
    public abstract class PlayerAction : IPlayerAction
    {
        protected IPlayer player;

        protected PlayerAction(IPlayer player)
        {
            this.player = player;
        }

        public abstract void Execute();
    }
}
