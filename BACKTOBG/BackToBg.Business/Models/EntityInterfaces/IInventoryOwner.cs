using System.Collections.Generic;

namespace BackToBg.Models.EntityInterfaces
{
    public interface IInventoryOwner
    {
        IList<IItem> Inventory { get; set; }
        string Name { get; set; }
    }
}