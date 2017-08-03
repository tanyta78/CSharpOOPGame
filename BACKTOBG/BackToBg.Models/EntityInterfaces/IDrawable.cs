namespace BackToBg.Models.EntityInterfaces
{
    public interface IDrawable
    {
        (int row, int col, string[] figure) GetDrawingInfo();
    }
}