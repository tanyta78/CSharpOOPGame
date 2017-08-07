using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.Paginators
{
    public class InactiveQuestsPaginator : QuestsPaginator
    {
        private IReadOnlyList<IQuest> quests;

        public InactiveQuestsPaginator(IReader reader, IWriter writer, IEngine engine) : base(reader, writer, engine)
        {
            this.quests = engine.Player.GetQuests().Where(q => q.IsFinished).ToList();
        }

        protected override IReadOnlyList<IQuest> Quests
        {
            get => this.quests;
        }
    }
}
