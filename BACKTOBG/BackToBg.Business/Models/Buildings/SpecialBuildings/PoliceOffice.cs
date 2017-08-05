using System;
using BackToBg.Business.Common;
using BackToBg.Business.Menu;
using BackToBg.Business.Reader;
using BackToBg.Business.UtilityInterfaces;
using BackToBg.Business.Writer;
using BackToBg.Models.Enums;
using BackToBg.Models.Items;
using BackToBg.Models.Items.Boots;
using BackToBg.Models.Utilities;

namespace BackToBg.Models.Buildings.SpecialBuildings
{
    public class PoliceOffice : SpecialBuilding
    {
        private const Item ItemToEnter = null;

        private IMap map;

        //private static readonly Quest PoliceQuest = new Quest(1, "Police Quest",
        //    "Now you are in Police office.The police need you. Your mission, if you accept it, is to arrest three famous criminals. Go and find them. The mission will end up bringing three pairs of boots. You will receive boot, 50 experience and 500 money",
        //    50, 500);

        public PoliceOffice(IMap map, int id, string name, string description, int x, int y, int sizeFactor = 1) : base(id, name,
            description, x, y, sizeFactor)
        {
            this.map = map;
            //this.QuestAvailableHere = PoliceQuest;
            //this.ItemRequeredToEnter = ItemToEnter;
            //this.QuestAvailableHere.RewardItem = new HeavyBoot(1, "PoliceBoots", 1, Rarity.Epic);
        }

        public override (int row, int col, string[] figure) GetDrawingInfo()
        {
            return (this.x, this.y, GetFigure());
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
            var menu = new TakeOnBandintQuestMenu("Take on police quest", new ConsoleReader(), new ConsoleWriter(Constants.ConsoleHeight, Constants.ConsoleWidth), this.map);
            menu.StartMenu();
        }
    }
}