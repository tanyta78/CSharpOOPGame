using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Business.Exceptions;
using BackToBg.Business.PlayerActions.Actions;
using BackToBg.Client.Core.PlayerActions;
using BACKTOBG.Models;

namespace BackToBg.Client.Core
{
    public class PlayerActionFactory
    {
        public IPlayerAction CreateAction(ConsoleKey key, IPlayer player)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    return new MoveUpAction(player);
                case ConsoleKey.DownArrow:
                    return new MoveDownAction(player);
                case ConsoleKey.LeftArrow:
                    return new MoveLeftAction(player);
                case ConsoleKey.RightArrow:
                    return new MoveRightAction(player);
                default:
                    throw new InvalidKeyPressException();
            }
        }
    }
}
