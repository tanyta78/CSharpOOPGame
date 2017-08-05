namespace BackToBg.Core.Models.EntityInterfaces
{
    public interface IQuestCompetionItem
    {
        IItem Details { get; set; }
        int Quantity { get; set; }
    }
}