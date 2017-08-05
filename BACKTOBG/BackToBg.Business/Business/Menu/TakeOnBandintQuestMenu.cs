using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Business.Models.Quests;
using BackToBg.Business.UtilityInterfaces;

namespace BackToBg.Business.Menu
{
    public class TakeOnBandintQuestMenu : Menu
    {
        private IMap map;

        public TakeOnBandintQuestMenu(string name, IReader reader, IWriter writer, IMap map) : base(name, reader, writer)
        {
            this.map = map;
        }

        protected override IDictionary<int, Action> Actions => new Dictionary<int, Action>
        {
            {0, () => ShouldBeRunning = false },
            {1, () =>
                {
                    this.map.AddQuest(new BanditQuest(1, "BanditQuest", "A random quest", 100, 100, this.map));
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
