using System;
using System.Collections.Generic;
using BackToBg.Core.Business.UtilityInterfaces;

namespace BackToBg.Core.Business.Menu
{
    public class SwitchTownMenu : Menu
    {
        private ITownsManager townsManager;
        private IPlayerManager playerManager;
        private IDictionary<int, Action> actions;
        private IList<string> menuText;

        public SwitchTownMenu(string name, IReader reader, IWriter writer, ITownsManager townsManager, IPlayerManager playerManager) : base(name, reader, writer)
        {
            this.townsManager = townsManager;
            this.playerManager = playerManager;

            //generate the text of the menu
            this.menuText = new List<string>();
            foreach (var town in townsManager.GetTowns())
            {
                this.menuText.Add(town.Name);
            }
        }

        protected override IDictionary<int, Action> Actions => this.actions;

        protected override IList<string> MenuText
        {
            get => this.menuText;
        }
        
        protected override void ExecuteCommand(int commandNumber)
        {
            this.playerManager.Player.ResetPosition();
            this.townsManager.SetCurrentTown(this.townsManager.GetTowns()[commandNumber]);
            ShouldBeRunning = false;
        }
    }
}
