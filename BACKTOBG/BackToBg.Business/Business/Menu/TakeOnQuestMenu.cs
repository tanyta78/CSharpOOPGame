using System;
using System.Collections.Generic;
using BackToBg.Core.Business.Factories;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Business.Menu
{
    public class TakeOnQuestMenu<T> : Menu
        where T : IBuilding
    {
        private ITownsManager townsManager;
        private IPlayerManager playerManager;
        private QuestFactory questFactory;
        private readonly IRandomNumberGenerator randomNumberGenerator;

        public TakeOnQuestMenu(string name, IReader reader, IWriter writer, ITownsManager townsManager, IPlayerManager playerManager, IRandomNumberGenerator randomNumberGenerator)
            : base(name, reader, writer)
        {
            this.townsManager = townsManager;
            this.playerManager = playerManager;
            this.randomNumberGenerator = randomNumberGenerator;
            this.questFactory = new QuestFactory(this.townsManager.GetCurrentTown(), this.randomNumberGenerator);
        }

        protected override IDictionary<int, Action> Actions => new Dictionary<int, Action>
        {
            {0, () => ShouldBeRunning = false},
            {
                1, () =>
                {
                    this.playerManager.AddQuest(this.questFactory.InjectQuest(typeof(T)));
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