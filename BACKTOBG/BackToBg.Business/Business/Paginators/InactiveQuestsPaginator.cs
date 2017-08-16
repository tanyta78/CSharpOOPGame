using System.Collections.Generic;
using System.Linq;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.Paginators
{
    public class InactiveQuestsPaginator : QuestsPaginator
    {
        public InactiveQuestsPaginator(IReader reader, IWriter writer, IPlayerManager playerManager) : base(reader,
            writer, playerManager)
        {
            this.Quests = playerManager.Player.GetQuests().Where(q => q.IsFinished).ToList();
        }

        protected override IReadOnlyList<IQuest> Quests { get; }
    }
}