namespace BACKTOBG.Models
{
    public interface IPlayerQuest
    {
        IQuest Details { get; set; }
        bool IsCompleted { get; set; }
    }
}