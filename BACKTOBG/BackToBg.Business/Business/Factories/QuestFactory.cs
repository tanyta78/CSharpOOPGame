using BackToBg.Core.Business.Attributes;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;
using System;
using System.Linq;
using System.Reflection;

namespace BackToBg.Core.Business.Factories
{
    public class QuestFactory
    {
        private readonly IMap map;

        public QuestFactory(IMap map)
        {
            this.map = map;
        }

        public IQuest CreateQuest(Type questType)
        {
            var parameters = new object[] { "Bandit Quest", "Finding the bandits and punching them to death", 100, 10 };

            var quest = (IQuest)Activator.CreateInstance(questType, parameters);

            if (quest == null)
            {
                throw new ArgumentException("Unsupported quest type");
            }

            this.InjectDependencies(quest);

            return quest;
        }

        private void InjectDependencies(IQuest quest)
        {
            var questFields = quest.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(t => t.GetCustomAttribute<InjectAttribute>() != null);

            var questMethods = quest.GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(m=>m.GetCustomAttribute<InvokeAttribute>() != null);

            var factoryFields = typeof(QuestFactory)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in questFields)
            {
                if (factoryFields.Any(f => f.FieldType == field.FieldType))
                {
                    field.SetValue(quest, factoryFields
                        .First(f => f.FieldType == field.FieldType)
                        .GetValue(this));
                }
            }

            foreach (var method in questMethods)
            {
                method.Invoke(quest, new object[] { });
            }
        }
    }
}
