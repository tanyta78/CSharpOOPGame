﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Business.Paginators
{
    public abstract class QuestsPaginator : Paginator<IQuest>
    {
        private IEngine engine;

        public QuestsPaginator(IReader reader, IWriter writer, IEngine engine) : base(reader, writer, "Quests")
        {
            this.engine = engine;
        }

        protected abstract IReadOnlyList<IQuest> Quests { get; }

        protected override IReadOnlyList<IQuest> Items
        {
            get => this.Quests;
        }

        protected override void ExecuteAction()
        {
            throw new NotImplementedException("Viewing item details not yet implemented");
        }

        protected override string RepresentItem(IQuest item)
        {
            return item.Name;
        }
    }
}
