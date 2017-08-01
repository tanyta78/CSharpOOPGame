namespace BACKTOBG.Models
{
    public interface IItem
    {
        int ID { get; }
        string Name { get; }
        int Price { get; }
    }
}