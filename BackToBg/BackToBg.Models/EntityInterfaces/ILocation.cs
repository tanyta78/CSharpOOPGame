namespace BACKTOBG.Models
{
    public interface ILocation
    {
        int ID { get; }
        string Name { get; }
        string Description { get; set; }
        IItem ItemRequeredToEnter { get; set; }
        IQuest QuestAvailableHere { get; set; }
    }
}