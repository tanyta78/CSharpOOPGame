using System;
using System.Linq;
using System.Reflection;
using BackToBg.Core.Business.Attributes;
using BackToBg.Core.Business.Common;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Business.Factories
{
    public class QuestFactory
    {
        private readonly ITown town;
        private readonly IRandomNumberGenerator randomNumberGenerator;
        private readonly CustomEventHandler handler;

        public QuestFactory(ITown town, IRandomNumberGenerator randomNumberGenerator, CustomEventHandler handler)
        {
            this.town = town;
            this.randomNumberGenerator = randomNumberGenerator;
            this.handler = handler;
        }

        public IQuest InjectQuest(Type buildingType)
        {
            var fieldAttribute = buildingType
                .GetCustomAttribute<QuestAttribute>();

            var parameters = new object[]
            {
                fieldAttribute.Name,
                fieldAttribute.Description,
                fieldAttribute.RewardExperiancePoints,
                fieldAttribute.RewardMoney,
                this.handler
            };

            var quest = (IQuest) Activator.CreateInstance(fieldAttribute.QuestType, parameters);
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
                .Where(m => m.GetCustomAttribute<InvokeAttribute>() != null);

            var factoryFields = typeof(QuestFactory)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in questFields)
                if (factoryFields.Any(f => f.FieldType == field.FieldType))
                    field.SetValue(quest, factoryFields
                        .First(f => f.FieldType == field.FieldType)
                        .GetValue(this));

            foreach (var method in questMethods)
                method.Invoke(quest, new object[] { });
        }
    }
}