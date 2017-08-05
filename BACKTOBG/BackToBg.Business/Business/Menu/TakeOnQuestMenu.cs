using System;
using System.Collections.Generic;
using BackToBg.Core.Business.Factories;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Quests;

namespace BackToBg.Core.Business.Menu
{
    public class TakeOnQuestMenu<T> : Menu 
        where T : IQuest
    {
        private readonly IMap map;
        private readonly IQuest quest;
        private readonly QuestFactory factory;

        public TakeOnQuestMenu(string name, IReader reader, IWriter writer, IMap map, IQuest quest) 
            : base(name, reader, writer)
        {
            this.map = map;
            this.quest = quest;
            this.factory = new QuestFactory(this.map);
        }

        protected override IDictionary<int, Action> Actions => new Dictionary<int, Action>
        {
            {0, () => ShouldBeRunning = false },
            {1, () =>
                {
                    this.factory.InjectDependencies(this.quest);
                    this.map.AddQuest(this.quest);
                    ShouldBeRunning = false;
                }
            }
        };

        protected override IList<string> MenuText => new List<string>()
        {
            "No",
            "Yes"
        };
    }
}
