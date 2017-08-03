namespace BackToBg.Models.EntityInterfaces
{
    public interface IPlayerQuest
    {
        IQuest Details { get; set; }
        bool IsCompleted { get; set; }
    }
}