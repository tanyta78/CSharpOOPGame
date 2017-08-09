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

        public InactiveQuestsPaginator(IReader reader, IWriter writer, IPlayerManager playerManager) : base(reader, writer, playerManager)
        {
            this.quests = playerManager.Player.GetQuests().Where(q => q.IsFinished).ToList();
        }

        protected override IReadOnlyList<IQuest> Quests
        {
            get => this.quests;
        }
    }
}
