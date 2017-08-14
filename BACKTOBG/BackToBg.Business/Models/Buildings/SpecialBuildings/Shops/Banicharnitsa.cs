using BackToBg.Core.Business.Attributes;
using BackToBg.Core.Business.IO.Reader;
using BackToBg.Core.Business.IO.Writer;
using BackToBg.Core.Business.Menu;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Models.Buildings.SpecialBuildings.Shops
{
    public class Banicharnitsa : Shop
    {
        [Inject] private IReader reader = new ConsoleReader();
        [Inject] private IWriter writer = new ConsoleWriter(Constants.ConsoleHeight, Constants.ConsoleWidth);
        private IPlayer player;

        public Banicharnitsa(int id, string name, string description, int x, int y, IPlayerManager playerManager, int sizeFactor = Constants.DefaultSizeFactor)
            : base(id, name, description, x, y, sizeFactor)
        {
            this.player = playerManager.Player;
        }

        public override (int row, int col, string[] figure) GetDrawingInfo()
        {
            return (this.x, this.y, this.GetFigure());
        }

        private string[] GetFigure()
        {
            var figure = new string[6];

            figure[0] = "********";
            figure[1] = "*      *";
            figure[2] = "* Bani *";
            figure[3] = "* tsi  *";
            figure[4] = "*      *";
            figure[5] = "********";

            return figure;
        }

        public override void Interact()
        {
            var menu = new BuyMenu("Banicharnitsa", this.reader, this.writer, this.player);
            menu.StartMenu();
        }
    }
}