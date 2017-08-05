using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Business.UtilityInterfaces;

namespace BackToBg.Business.Menu
{
    public class PauseMenu : Menu
    {
        private readonly IDictionary<int, Action> actions = new Dictionary<int, Action>
        {
            {0, () => ShouldBeRunning = false},
            {
                4, () =>
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
            }
        };

        private readonly IList<string> menuText = new List<string>
        {
            "Resume",
            "Switch Town",
            "View stats",
            "View quests",
            "Exit"
        };

        public PauseMenu(IReader reader, IWriter writer) : base("Pause", reader, writer)
        {
        }

        protected override IDictionary<int, Action> Actions => this.actions;
        protected override IList<string> MenuText => this.menuText;
    }
}
