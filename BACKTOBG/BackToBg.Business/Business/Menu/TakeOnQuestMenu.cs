using System;
using System.Collections.Generic;
using BackToBg.Core.Business.Factories;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Quests;
using System.Reflection;
using System.Linq;
using BackToBg.Core.Business.Attributes;

namespace BackToBg.Core.Business.Menu
{
    public class TakeOnQuestMenu<T> : Menu
        where T : IBuilding
    {
        private readonly IMap map;

        public TakeOnQuestMenu(string name, IReader reader, IWriter writer, IMap map)
            : base(name, reader, writer)
        {
            this.map = map;
        }

        protected override IDictionary<int, Action> Actions => new Dictionary<int, Action>
        {
            {0, () => ShouldBeRunning = false },
            {1, () =>
                {
                    this.map.AddQuest(this.InjectQuest(typeof(T)));
                    ShouldBeRunning = false;
                }
            }
        };

        protected override IList<string> MenuText => new List<string>()
        {
            "No",
            "Yes"
        };

        private IQuest InjectQuest(Type buildingType)
        {
            var fieldAttribute = buildingType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.GetCustomAttribute<QuestAttribute>() != null)
                .GetCustomAttribute<QuestAttribute>();

            var paramenters = new object[] 
            {
                fieldAttribute.Name,
                fieldAttribute.Description,
                fieldAttribute.RewardExperiancePoints,
                fieldAttribute.RewardMoney
            };

            var quest = (IQuest)Activator.CreateInstance(fieldAttribute.QuestType, paramenters);
            this.InjectDependencies(quest);

            return quest;
        }

        public void InjectDependencies(IQuest quest)
        {
            var questFields = quest.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(t => t.GetCustomAttribute<InjectAttribute>() != null);

            var questMethods = quest.GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(m => m.GetCustomAttribute<InvokeAttribute>() != null);

            var factoryFields = typeof(TakeOnQuestMenu<T>)
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
