using BackToBg.Core.Business.Attributes;
using BackToBg.Core.Business.Menu;
using BackToBg.Core.Business.UtilityInterfaces;

namespace BackToBg.Core.Business.PlayerActions.Actions
{
    [PlayerAction("Escape")]
    public class PauseMenuAction : PlayerAction
    {
        [Inject] private IPlayerManager playerManager;

        [Inject] private IReader reader;

        [Inject] private ITownsManager townsManager;

        [Inject] private IWriter writer;

        public override void Execute()
        {
            var pauseMenu = new PauseMenu("Pause", this.reader, this.writer, this.townsManager, this.playerManager);
            pauseMenu.StartMenu();
        }
    }
}