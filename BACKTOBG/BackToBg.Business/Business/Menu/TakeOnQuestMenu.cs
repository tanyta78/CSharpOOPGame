using System;
using System.Collections.Generic;
using BackToBg.Core.Business.Factories;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.Menu
{
    public class TakeOnQuestMenu<T> : Menu
        where T : IBuilding
    {
        private readonly ITown town;
        private readonly QuestFactory questFactory;

        public TakeOnQuestMenu(string name, IReader reader, IWriter writer, ITown town)
            : base(name, reader, writer)
        {
            this.town = town;
            this.questFactory = new QuestFactory(this.town);
        }

        protected override IDictionary<int, Action> Actions => new Dictionary<int, Action>
        {
            {0, () => ShouldBeRunning = false },
            {1, () =>
                {
                    this.town.AddQuest(this.questFactory.InjectQuest(typeof(T)));
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
