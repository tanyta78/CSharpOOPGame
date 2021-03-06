﻿using System;
using System.Collections.Generic;
using BackToBg.Core.Business.Common;
using BackToBg.Core.Business.Factories;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Business.Menu
{
    public class TakeOnQuestMenu<T> : Menu
        where T : IBuilding
    {
        private readonly IRandomNumberGenerator randomNumberGenerator;
        private ICustomEventHandler handler;
        private readonly IPlayerManager playerManager;
        private readonly QuestFactory questFactory;
        private readonly ITownsManager townsManager;

        public TakeOnQuestMenu(string name, IReader reader, IWriter writer, ITownsManager townsManager,
            IPlayerManager playerManager, IRandomNumberGenerator randomNumberGenerator, ICustomEventHandler handler)
            : base(name, reader, writer)
        {
            this.townsManager = townsManager;
            this.playerManager = playerManager;
            this.randomNumberGenerator = randomNumberGenerator;
            this.handler = handler;
            this.questFactory = new QuestFactory(this.townsManager.GetCurrentTown(), this.randomNumberGenerator,
                handler);
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