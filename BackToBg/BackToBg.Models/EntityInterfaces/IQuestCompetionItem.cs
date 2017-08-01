namespace BACKTOBG.Models
{
    public interface IQuestCompetionItem
    {
        IItem Details { get; set; }
        int Quantity { get; set; }
    }
}