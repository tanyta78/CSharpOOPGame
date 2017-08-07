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
        private IEngine engine;
        private ITown town;
        private QuestFactory questFactory;

        public TakeOnQuestMenu(string name, IReader reader, IWriter writer, IEngine engine)
            : base(name, reader, writer)
        {
            this.engine = engine;
            this.town = engine.GetCurrentTown();
            this.questFactory = new QuestFactory(this.town);
        }

        protected override IDictionary<int, Action> Actions => new Dictionary<int, Action>
        {
            {0, () => ShouldBeRunning = false},
            {
                1, () =>
                {
                    this.engine.AddQuest(this.questFactory.InjectQuest(typeof(T)));
                    ShouldBeRunning = false;
                }
            }
        };

        protected override IList<string> MenuText => new List<string>
        {
            "No",
            "Yes"
        };
    }
}