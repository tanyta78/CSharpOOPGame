using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Core.Business.Paginators;
using BackToBg.Core.Business.UtilityInterfaces;

namespace BackToBg.Core.Business.Menu
{
    public class BrowseQuestsMenu : Menu
    {
        private IEngine engine;

        public BrowseQuestsMenu(string name, IReader reader, IWriter writer, IEngine engine) : base(name, reader, writer)
        {
            this.engine = engine;
        }

        protected override IDictionary<int, Action> Actions => new Dictionary<int, Action>
        {
            {0, () =>
            {
                var allQuestsPaginator = new AllQuestsPaginator(this.Reader, this.Writer, this.engine);
                allQuestsPaginator.Start();
            }},
            {1, () =>
            {
                var activeQuestsPaginator = new ActiveQuestsPaginator(this.Reader, this.Writer, this.engine);
                activeQuestsPaginator.Start();
            }},
            {2, () =>
            {
                var inactiveQuestsPaginator = new InactiveQuestsPaginator(this.Reader, this.Writer, this.engine);
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
