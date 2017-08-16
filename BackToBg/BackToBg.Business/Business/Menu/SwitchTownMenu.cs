using System;
using System.Collections.Generic;
using BackToBg.Core.Business.UtilityInterfaces;

namespace BackToBg.Core.Business.Menu
{
    public class SwitchTownMenu : Menu
    {
        private readonly IList<string> menuText;
        private readonly IPlayerManager playerManager;
        private readonly ITownsManager townsManager;

        public SwitchTownMenu(string name, IReader reader, IWriter writer, ITownsManager townsManager,
            IPlayerManager playerManager) : base(name, reader, writer)
        {
            this.townsManager = townsManager;
            this.playerManager = playerManager;

            //generate the text of the menu
            this.menuText = new List<string>();
            foreach (var town in townsManager.GetTowns())
                this.menuText.Add(town.Name);
        }

        protected override IDictionary<int, Action> Actions { get; }

        protected override IList<string> MenuText => this.menuText;

        protected override void ExecuteCommand(int commandNumber)
        {
            this.playerManager.Player.ResetPosition();
            this.townsManager.SetCurrentTown(this.townsManager.GetTowns()[commandNumber]);
            ShouldBeRunning = false;
        }
    }
}