using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.Paginators
{
    public class AllQuestsPaginator : QuestsPaginator
    {
        private IReadOnlyList<IQuest> quests;

        public AllQuestsPaginator(IReader reader, IWriter writer, IPlayerManager playerManager) : base(reader, writer, playerManager)
        {
            this.quests = playerManager.Player.GetQuests();
        }

        protected override IReadOnlyList<IQuest> Quests
        {
            get => this.quests;
        }
    }
}
