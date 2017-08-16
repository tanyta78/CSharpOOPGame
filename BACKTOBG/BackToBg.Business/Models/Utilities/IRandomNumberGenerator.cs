namespace BackToBg.Core.Models.Utilities
{
    public interface IRandomNumberGenerator
    {
        int GetNextNumber();
        int GetNextNumber(int lower, int upper);
        int GetNextNumber(int upper);
    }
}