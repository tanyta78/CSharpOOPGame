using BackToBg.Models.Buildings.SpecialBuildings;
using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Models.Utility_Models.TradeDialogs
{
    public abstract class TradeDialog : IDrawable
    {
        #region Fields

        private Shop shop;
        private Player player;

        #endregion

        //Location to draw from

        protected TradeDialog(Point startingLocation, Player player, Shop shop)
        {
            this.Location = startingLocation;
        }

        #region Properties

        protected Point Location { get; set; }

        public Shop Shop
        {
            get { return shop; }
            set { shop = value; }
        }

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        #endregion

        #region Methods

        public (int row, int col, string[] figure) GetDrawingInfo()
        {
            return (this.Location.X, this.Location.Y, GenerateFigure());
        }

        public abstract string[] GenerateFigure();

        protected virtual string[] GetFigure()
        {
            return this.GenerateFigure();
        }

        #endregion
    }
}