using System.Collections.Generic;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.Paginators
{
    public class AllQuestsPaginator : QuestsPaginator
    {
        public AllQuestsPaginator(IReader reader, IWriter writer, IPlayerManager playerManager) : base(reader, writer,
            playerManager)
        {
            this.Quests = playerManager.Player.GetQuests();
        }

        protected override IReadOnlyList<IQuest> Quests { get; }
    }
}