using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
		
        private IEngine engine;

        private IDictionary<int, Action> actions;

        private IList<string> menuText = new List<string>
        {
            "Resume",
            "Switch Town",
            "View stats",
            "View quests",
            "Exit"
        };

        public PauseMenu(string name, IReader reader, IWriter writer, IEngine engine) : base(name, reader, writer)
        {
            this.engine = engine;
            this.actions = new Dictionary<int, Action>
            {
                {0, () => ShouldBeRunning = false},
                {1, () =>
                {
                    var stm = new SwitchTownMenu("Switch town", this.Reader, this.Writer, this.engine);
                    stm.StartMenu();
                }},
                {
                    4, () =>
                    {
                        Console.Clear();
                        Environment.Exit(0);
                    }
                }
            };
        }
        

        public PauseMenu(IReader reader, IWriter writer)
            : base("Pause", reader, writer)
        {
        }

        protected override IDictionary<int, Action> Actions => this.actions;
        protected override IList<string> MenuText => this.menuText;
    }
}