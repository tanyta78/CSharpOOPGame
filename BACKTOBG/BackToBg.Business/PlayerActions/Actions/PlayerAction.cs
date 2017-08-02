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
        protected char[][] map;

        protected PlayerAction(IPlayer player, char[][] map)
        {
            this.player = player;
            this.map = map;
        }

        public abstract void Execute();
    }
}
