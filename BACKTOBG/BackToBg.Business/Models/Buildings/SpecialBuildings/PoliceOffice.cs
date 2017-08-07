using BackToBg.Core.Business.Attributes;
using BackToBg.Core.Business.Menu;
using BackToBg.Core.Business.Reader;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Business.Writer;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Items;
using BackToBg.Core.Models.Quests;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Models.Buildings.SpecialBuildings
{
    [Quest(typeof(BanditQuest), "Bandit Quest", "Finding the bandits and punching them to death", 100, 10)]
    public class PoliceOffice : SpecialBuilding
    {
        private const Item ItemToEnter = null;
        private readonly IEngine engine;

        //private static readonly Quest PoliceQuest = new Quest(1, "Police Quest",
        //    "Now you are in Police office.The police need you. Your mission, if you accept it, is to arrest three famous criminals. Go and find them. The mission will end up bringing three pairs of boots. You will receive boot, 50 experience and 500 money",
        //    50, 500);

        public PoliceOffice(IEngine engine, int id, string name, string description, int x, int y, int sizeFactor = Constants.DefaultSizeFactor)
            : base(id, name, description, x, y, sizeFactor)
        {
            this.engine = engine;
            //this.QuestAvailableHere = PoliceQuest;
            //this.ItemRequeredToEnter = ItemToEnter;
            //this.QuestAvailableHere.RewardItem = new HeavyBoot(1, "PoliceBoots", 1, Rarity.Epic);
        }

        public override (int row, int col, string[] figure) GetDrawingInfo()
        {
            return (this.x, this.y, this.GetFigure());
        }

        //********
        //* PPP  *
        //* P  P *
        //* PP   *
        //* P    *
        //* P    *
        //*      *
        //********
        private string[] GetFigure()
        {
            var figure = new string[8];

            figure[0] = "********";
            figure[1] = "* PPP  *";
            figure[2] = "* P  P *";
            figure[3] = "* PP   *";
            figure[4] = "* P    *";
            figure[5] = "* P    *";
            figure[6] = "* P    *";
            figure[7] = "********";

            return figure;
        }

        public override void Interact()
        {
            var menu = new TakeOnQuestMenu<PoliceOffice>("Take on police quest", new ConsoleReader(), new ConsoleWriter(Constants.ConsoleHeight, Constants.ConsoleWidth), this.engine);
            menu.StartMenu();
        }
    }
}