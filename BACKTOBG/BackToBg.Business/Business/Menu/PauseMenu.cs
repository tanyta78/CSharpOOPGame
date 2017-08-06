using System;
using System.Collections.Generic;
using BackToBg.Core.Business.UtilityInterfaces;

namespace BackToBg.Core.Business.Menu
{
    public class PauseMenu : Menu
    {
        public PauseMenu(IReader reader, IWriter writer)
            : base("Pause", reader, writer)
        {
        }

        protected override IDictionary<int, Action> Actions { get; } = new Dictionary<int, Action>
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

        protected override IList<string> MenuText { get; } = new List<string>
        {
            "Resume",
            "Switch Town",
            "View stats",
            "View quests",
            "Exit"
        };
    }
}