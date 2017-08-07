using System;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Models.Buildings
{
    public class BasicBuilding : Building
    {
        private static readonly char border = Constants.BasicBuildingBorder;
        private static readonly char inner = Constants.BasicBuildingInner;

        public BasicBuilding(int x, int y, int sizeFactor = Constants.DefaultSizeFactor) : base(x, y, sizeFactor)
        {
        }

        public override (int row, int col, string[] figure) GetDrawingInfo()
        {
            return (this.x, this.y, GenerateFigure());
        }

        public override void Interact()
        {
            throw new NotSupportedException(Messages.BasicBuildingInteractEx);
        }

        private string[] GenerateFigure()
        {
            var size = 5 * this.sizeFactor;

            var figure = new string[size];

            figure[0] = new string(border, size);
            for (var i = 1; i < size - 1; i++)
                figure[i] = $"{border}{new string(inner, size - 2)}{border}";
            figure[size - 1] = new string(border, size);
            return figure;
        }
    }
}