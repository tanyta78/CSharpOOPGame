using BackToBg.Core.Business.Attributes;
using BackToBg.Core.Business.Menu;
using BackToBg.Core.Business.Reader;
using BackToBg.Core.Business.Writer;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Business.PlayerActions.Actions
{
    [PlayerAction("Escape")]
    public class PauseMenuAction : PlayerAction
    {
        public override void Execute()
        {
            var pauseMenu = new PauseMenu(new ConsoleReader(), new ConsoleWriter(Constants.ConsoleHeight, Constants.ConsoleWidth));
            pauseMenu.StartMenu();
        }
    }
}