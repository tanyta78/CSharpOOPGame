using System;
using BackToBg.Business.Exceptions;
using BackToBg.Business.PlayerActions.Actions;
using BackToBg.Business.UtilityInterfaces;
using BackToBg.Models.EntityInterfaces;
using System.Collections.Generic;

namespace BackToBg.Business.PlayerActions
{
    public class PlayerActionFactory : IPlayerActionFactory
    {
        private IMap map;
        private IPlayer player;
        private Dictionary<ConsoleKey, IPlayerAction> actions;

        public PlayerActionFactory(IMap map, IPlayer player)
        {
            this.map = map;
            this.player = player;
            this.InitializeActions();
        }

        private void InitializeActions()
        {
            this.actions = new Dictionary<ConsoleKey, IPlayerAction>
            {
                { ConsoleKey.UpArrow, new MoveUpAction(this.player, this.map.GetMap()) },
                { ConsoleKey.DownArrow, new MoveDownAction(this.player, this.map.GetMap()) },
                { ConsoleKey.LeftArrow, new MoveLeftAction(this.player, this.map.GetMap()) },
                { ConsoleKey.RightArrow, new MoveRightAction(this.player, this.map.GetMap()) },
                { ConsoleKey.Spacebar, new InteractAction(this.player, this.map.GetMap(), this.map) }
            };
        }

        public IPlayerAction CreateAction(ConsoleKey key)
        {
            if (!this.actions.ContainsKey(key))
            {
                throw new InvalidKeyPressException();                 
            }

            return this.actions[key];            
        }
    }
}
