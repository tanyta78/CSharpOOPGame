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

        public override void Execute()
        {
            var pauseMenu = new PauseMenu(this.reader, this.writer);
            pauseMenu.StartMenu();
        }
    }
}