namespace BACKTOBG.Models
{
    public interface ILocation
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        IItem ItemRequeredToEnter { get; set; }
        IQuest QuestAvailableHere { get; set; }
    }
}