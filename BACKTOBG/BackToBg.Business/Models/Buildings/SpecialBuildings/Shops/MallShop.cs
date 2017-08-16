using BackToBg.Core.Business.Managers;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.Utilities;
using BackToBg.Core.Models.Utility_Models;
using BackToBg.Core.Models.Utility_Models.TradeDialogs;

namespace BackToBg.Core.Models.Buildings.SpecialBuildings.Shops
{
    public class MallShop : Shop
    {
        private IPlayerManager playerManager;

        public MallShop(IPlayerManager playerManager, int id, string name, string description, int x, int y, int sizeFactor = 1) : base(id, name,
            description, x, y, sizeFactor)
        {
            this.playerManager = playerManager;
        }

        public MallShop(int id, string name, string description, int x, int y, int sizeFactor = 1) : base(id, name,
            description, x, y, sizeFactor)
        {
        }
        
        public override (int row, int col, string[] figure) GetDrawingInfo()
        {
            return (this.x, this.y, this.GetFigure());
        }

        public override void Interact()
        {
            var tradeDialog = new TradeDialog(new Point(0,0),this.playerManager.Player,this);
            tradeDialog.Use();
        }

        //***************
        //*  |\    /|   *
        //*  |  \ / |   *
        //*  |      |   *
        //***************
        
        private string[] GetFigure()
        {
            var figure = new string[Constants.ShoppingMallHeight];

            figure[0] = new string('*',Constants.ShoppingMallWidth);
            figure[1] = @"*   |\   /|   *";
            figure[2] = @"*   | \ / |   *";
            figure[3] = @"*   |     |   *";
            figure[4] = figure[0];

            return figure;
        }
    }
}