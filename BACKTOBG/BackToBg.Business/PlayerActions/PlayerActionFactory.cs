using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Business.Exceptions;
using BackToBg.Business.PlayerActions.Actions;
using BackToBg.Client.Core.PlayerActions;
using BACKTOBG.Models;
using BackToBg.Business;
using BackToBg.Business.Contracts;
using BackToBg.Map;

namespace BackToBg.Client.Core
{
    public class PlayerActionFactory : IPlayerActionFactory
    {
        private IMap map;
        private IPlayer player;

        public PlayerActionFactory(IMap map, IPlayer player)
        {
            this.map = map;
            this.player = player;
        }

        public IPlayerAction CreateAction(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    return new MoveUpAction(this.player, this.map.GetMap());
                case ConsoleKey.DownArrow:
                    return new MoveDownAction(this.player, this.map.GetMap());
                case ConsoleKey.LeftArrow:
                    return new MoveLeftAction(this.player, this.map.GetMap());
                case ConsoleKey.RightArrow:
                    return new MoveRightAction(this.player, this.map.GetMap());
                default:
                    throw new InvalidKeyPressException();
            }
        }
    }
}
