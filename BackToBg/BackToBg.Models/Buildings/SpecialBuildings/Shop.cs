using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Models.Items;

namespace BackToBg.Models.Buildings.SpecialBuildings
{
    public class Shop : SpecialBuilding
    {
        //TODO
        private List<Item> items;

        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }

        
        public Shop(int id, string name, string description, int x, int y, int sizeFactor = 1) : base(id, name, description, x, y, sizeFactor)
        {
        }

        public override (int row, int col, string[] figure) GetDrawingInfo()
        {
            throw new NotImplementedException();
        }

        public override string[] GenerateFigure()
        {
            throw new NotImplementedException();
        }

        public override void Interact()
        {
            throw new NotImplementedException();
        }
    }
}
