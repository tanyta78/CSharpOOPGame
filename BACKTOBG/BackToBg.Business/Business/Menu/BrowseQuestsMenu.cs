using System;
using System.Collections.Generic;
using BackToBg.Core.Business.Paginators;
using BackToBg.Core.Business.UtilityInterfaces;

namespace BackToBg.Core.Business.Menu
{
    public class BrowseQuestsMenu : Menu
    {
        private IPlayerManager playerManager;

        public BrowseQuestsMenu(string name, IReader reader, IWriter writer, IPlayerManager playerManager) : base(name, reader, writer)
        {
            this.playerManager = playerManager;
        }

        protected override IDictionary<int, Action> Actions => new Dictionary<int, Action>
        {
            {0, () =>
            {
                var allQuestsPaginator = new AllQuestsPaginator(this.Reader, this.Writer, this.playerManager);
                allQuestsPaginator.Start();
            }},
            {1, () =>
            {
                var activeQuestsPaginator = new ActiveQuestsPaginator(this.Reader, this.Writer, this.playerManager);
                activeQuestsPaginator.Start();
            }},
            {2, () =>
            {
                var inactiveQuestsPaginator = new InactiveQuestsPaginator(this.Reader, this.Writer, this.playerManager);
                inactiveQuestsPaginator.Start();
            }},
        };

        protected override IList<string> MenuText => new List<string>
        {
            "All",
            "Active",
            "Inactive"
        };
    }
}
