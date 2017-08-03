using System;
using BackToBg.Business.Exceptions;
using BackToBg.Business.PlayerActions.Actions;
using BackToBg.Business.UtilityInterfaces;
using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Business.PlayerActions
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
                case ConsoleKey.Spacebar:
                    return new InteractAction(this.player, this.map.GetMap(), this.map);
                default:
                    throw new InvalidKeyPressException();
            }
        }
    }
}
