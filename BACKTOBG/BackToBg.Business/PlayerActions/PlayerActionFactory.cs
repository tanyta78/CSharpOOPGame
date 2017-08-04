using System;
using BackToBg.Business.Exceptions;
using BackToBg.Business.UtilityInterfaces;
using BackToBg.Models.EntityInterfaces;
using System.Reflection;
using System.Linq;
using BackToBg.Business.Attributes;

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
            var actionType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetCustomAttribute<PlayerActionAttribute>() != null)
                .FirstOrDefault(t => t.GetCustomAttribute<PlayerActionAttribute>().ActionKeyName == key.ToString());

            if (actionType == null)
            {
                throw new InvalidKeyPressException();
            }

            IPlayerAction action = (IPlayerAction)Activator.CreateInstance(actionType, new object[] { });
            action = this.InjectDependencies(action);

            return action;
        }

        private IPlayerAction InjectDependencies(IPlayerAction action)
        {
            var actionFields = action.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.GetCustomAttribute<InjectAttribute>() != null);

            var factoryFields = typeof(PlayerActionFactory).
                GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in actionFields)
            {
                if (factoryFields.Any(f => f.FieldType == field.FieldType))
                {
                    field.SetValue(action,
                        factoryFields.First(f => f.FieldType == field.FieldType).GetValue(this));
                }
            }

            return action;
        }
    }
}
