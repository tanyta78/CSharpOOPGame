﻿using System;
using System.Collections.Generic;
using BackToBg.Core.Business.Factories;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.Menu
{
    public class TakeOnQuestMenu<T> : Menu
        where T : IBuilding
    {
        private readonly IMap map;
        private readonly QuestFactory questFactory;

        public TakeOnQuestMenu(string name, IReader reader, IWriter writer, IMap map)
            : base(name, reader, writer)
        {
            this.map = map;
            this.questFactory = new QuestFactory(this.map);
        }

        protected override IDictionary<int, Action> Actions => new Dictionary<int, Action>
        {
            {0, () => ShouldBeRunning = false },
            {1, () =>
                {
                    this.map.AddQuest(this.questFactory.InjectQuest(typeof(T)));
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
