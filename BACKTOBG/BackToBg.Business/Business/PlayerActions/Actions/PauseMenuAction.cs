using BackToBg.Core.Business.Attributes;
using BackToBg.Core.Business.Menu;
using BackToBg.Core.Business.UtilityInterfaces;

namespace BackToBg.Core.Business.PlayerActions.Actions
{
    [PlayerAction("Escape")]
    public class PauseMenuAction : PlayerAction
    {
        [Inject] private IReader reader;

        [Inject] private IWriter writer;

        [Inject]
        private IEngine engine;

        [Inject]
        private IEngine engine;

        public override void Execute()
        {
            var pauseMenu = new PauseMenu("Pause", this.reader, this.writer, this.engine);
            pauseMenu.StartMenu();
        }
    }
}