using System;
using System.Collections.Generic;
using BackToBg.Core.Business.UtilityInterfaces;

namespace BackToBg.Core.Business.Menu
{
    public class SwitchTownMenu : Menu
    {
        private IEngine engine;
        private IDictionary<int, Action> actions;
        private IList<string> menuText;

        public SwitchTownMenu(string name, IReader reader, IWriter writer, IEngine engine) : base(name, reader, writer)
        {
            this.engine = engine;

            //generate the text of the menu
            this.menuText = new List<string>();
            foreach (var town in engine.GetTowns())
            {
                this.menuText.Add(town.Name);
            }
        }

        protected override IDictionary<int, Action> Actions
        {
            get => new Dictionary<int, Action>()
            {
                { 0, () =>
                {
                    this.engine.SetCurrentTown(this.engine.GetTowns()[0]);
                    ShouldBeRunning = false;
                }},
                { 1, () =>
                {
                    this.engine.SetCurrentTown(this.engine.GetTowns()[1]);
                    ShouldBeRunning = false;
                }},
            };
        }

        protected override IList<string> MenuText
        {
            get => this.menuText;
        }
        
        protected override void ExecuteCommand(int commandNumber)
        {
            this.engine.SetCurrentTown(this.engine.GetTowns()[commandNumber]);
            ShouldBeRunning = false;
        }
    }
}
