using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Business.UtilityInterfaces;

namespace BackToBg.Business.Menu
{
    public class TakeOnQuestMenu : Menu
    {
        public TakeOnQuestMenu(string name, IReader reader, IWriter writer) : base(name, reader, writer)
        {
        }

        protected override IDictionary<int, Action> Actions => new Dictionary<int, Action>
        {
            {0, () => ShouldBeRunning = false },
            {1, () => throw new NotImplementedException("Starting the quest not yet implemented") }
        };
        protected override IList<string> MenuText => new List<string>()
        {
            "No",
            "Yes"
        };
    }
}
