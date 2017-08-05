using System;
using System.Linq;
using System.Reflection;
using BackToBg.Core.Business.Attributes;
using BackToBg.Core.Business.Exceptions;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.Factories
{
    public class PlayerActionFactory : IPlayerActionFactory
    {
        private IMap map;
        private IPlayer player;
        private IReader reader;
        private IWriter writer;

        public PlayerActionFactory(IMap map, IPlayer player, IReader reader, IWriter writer)
        {
            this.map = map;
            this.player = player;
            this.reader = reader;
            this.writer = writer;
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

            var action = (IPlayerAction)Activator.CreateInstance(actionType, new object[] { });
            action = this.InjectDependencies(action);

            return action;
        }

        private IPlayerAction InjectDependencies(IPlayerAction action)
        {
            var actionFields = action.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.GetCustomAttribute<InjectAttribute>() != null);

            var factoryFields = typeof(PlayerActionFactory)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in actionFields)
            {
                if (factoryFields.Any(f => f.FieldType == field.FieldType))
                {
                    field.SetValue(action, factoryFields
                        .First(f => f.FieldType == field.FieldType)
                        .GetValue(this));
                }
            }
            return action;
        }
    }
}