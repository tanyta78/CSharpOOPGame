using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Models.EntityInterfaces;
using BackToBg.Models.Items;
using BackToBg.Models.Items.Boots;

namespace BackToBg.Models.Buildings.SpecialBuildings
{
    public class PoliceOffice : SpecialBuilding
    {
        private static readonly Quest PoliceQuest = new Quest(1, "Police Quest", "Now you are in Police office.The police need you. Your mission, if you accept it, is to arrest three famous criminals. Go and find them. The mission will end up bringing three pairs of boots. You will receive boot, 50 experience and 500 money", 50, 500);

        private const Item ItemToEnter = null;

        public PoliceOffice(int id, string name, string description, int x, int y, int sizeFactor = 1) : base(id, name, description, x, y, sizeFactor)
        {
            this.QuestAvailableHere = PoliceQuest;
            this.ItemRequeredToEnter = ItemToEnter;
            this.QuestAvailableHere.RewardItem = new HeavyBoot(1, "PoliceBoots", 0, "Epic");
        }

        public override (int row, int col, string[] figure) GetDrawingInfo()
        {
            //TO DO
            throw new NotImplementedException();
        }

        public override void Interact()
        {
            //TO DO
            throw new NotImplementedException();
        }
    }
}