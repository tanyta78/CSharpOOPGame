using System;
using BackToBg.Models.Buildings.SpecialBuildings;
using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Models.Utility_Models.TradeDialogs
{
    public class InventoryDialog : IDrawable
    {
        public Point Location { get; set; }

        //Could be shop
        public IInventoryOwner InventoryOwner { get; set; }

        public InventoryDialog(IInventoryOwner p,Point location)
        {
            this.InventoryOwner = p;
        }

        public (int row, int col, string[] figure) GetDrawingInfo()
        {
            return (this.Location.X, this.Location.Y, GenerateFigure());

        }

        private string[] GenerateFigure()
        {
            throw new NotImplementedException();
        }
    }
}
