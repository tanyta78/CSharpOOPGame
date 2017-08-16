using BackToBg.Core.Business.Menu;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Business.Encounters
{
    public class Injures
    {
        private readonly IPlayer player;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Injures(IPlayer player, IWriter writer, IReader reader)
        {
            this.player = player;
            this.writer = writer;
            this.reader = reader;
        }

        public void FallingBranch()
        {
            this.player.CurrentHitPoints -= Constants.FallinBranchDamage;
            this.player.Experience += 10;
            var menu = new EncounterMenu(Constants.FallingBranchMsg, this.reader, this.writer);
            menu.StartMenu();
        }

        public void BrokenLeg()
        {
            this.player.CurrentHitPoints -= Constants.BrokenLegDamage;
            this.player.Experience += 20;
            var menu = new EncounterMenu(Constants.BrokenLegMsg, this.reader, this.writer);
            menu.StartMenu();
        }
    }
}