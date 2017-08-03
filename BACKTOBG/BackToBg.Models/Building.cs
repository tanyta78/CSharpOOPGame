using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Models
{
    public abstract class Building : IBuilding
    {
        protected int sizeFactor; // coefficient of how big compared to the default size of the building the current instance should be

        protected int x;
        protected int y;

        protected Building(int x, int y, int sizeFactor = 1)
        {
            this.x = x;
            this.y = y;
            this.sizeFactor = sizeFactor;
        }

        public abstract (int row, int col, string[] figure) GetDrawingInfo();

        public abstract void Interact();
    }
}