using System.Collections.Generic;

namespace BackToBg.Models.EntityInterfaces
{
    public interface IQuest
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int RewardExperiancePoints { get; set; }
        int RewardMoney { get; set; }
        IItem RewardItem { get; set; }
        List<IQuestCompetionItem> QuestCompetionItems { get; set; }
    }
}