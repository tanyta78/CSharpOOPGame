using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Models.EntityInterfaces;
using BackToBg.Models.Items;

namespace BackToBg.Models.Buildings.SpecialBuildings
{
    public class Shop : SpecialBuilding, IInventoryOwner
    {
        public IList<IItem> Inventory { get; set; }

        //intended hiding (to use IInventoryOwner's Name property)
        public new string Name { get; set; }

        public Shop(int id, string name, string description, int x, int y, int sizeFactor = 1) : base(id, name,
            description, x, y, sizeFactor)
        {
            this.Inventory = new List<IItem>();
        }

        public override (int row, int col, string[] figure) GetDrawingInfo()
        {
            throw new NotImplementedException();
        }

        public override void Interact()
        {
            throw new NotImplementedException();
        }
    }
}