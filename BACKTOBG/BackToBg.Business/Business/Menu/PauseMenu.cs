using System;
using System.Collections.Generic;
using BackToBg.Core.Business.InfoDisplayer;
using BackToBg.Core.Business.UtilityInterfaces;

namespace BackToBg.Core.Business.Menu
{
    public class PauseMenu : Menu
    {
        private ITownsManager townsManager;
        private IPlayerManager playerManager;

        private IDictionary<int, Action> actions;

        private IList<string> menuText = new List<string>
        {
            "Resume",
            "Switch Town",
            "View stats",
            "View quests",
            "Exit"
        };

        public PauseMenu(string name, IReader reader, IWriter writer, ITownsManager townsManager, IPlayerManager playerManager) : base(name, reader, writer)
        {
            this.townsManager = townsManager;
            this.playerManager = playerManager;
            this.actions = new Dictionary<int, Action>
            {
                {0, () => ShouldBeRunning = false},
                {1, () =>
                {
                    var stm = new SwitchTownMenu("Switch town", this.Reader, this.Writer, this.townsManager, playerManager);
                    stm.StartMenu();
                }},
                {2, () =>
                {
                    var pid = new PlayerInfoDisplayer(this.Reader, this.Writer, this.playerManager.Player);
                    pid.Display();
                }},
                {3, () =>
                    {
                        var bqm = new BrowseQuestsMenu("Quests menu", this.Reader, this.Writer, this.playerManager);
                        bqm.StartMenu();
                    }
                },
                {
                    4, () =>
                    {
                        Console.Clear();
                        Environment.Exit(0);
                    }
                }
            };
        }


        protected override IDictionary<int, Action> Actions => this.actions;
        protected override IList<string> MenuText => this.menuText;
    }
}