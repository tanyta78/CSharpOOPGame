using System.Collections.Generic;

namespace BACKTOBG.Models
{
    public interface IQuest
    {
        int ID { get; }
        string Name { get; }
        string Description { get; set; }
        int RewardExperiancePoints { get; set; }
        int RewardMoney { get; set; }
        IItem RewardItem { get; set; }
        List<IQuestCompetionItem> QuestCompetionItems { get; set; }
    }
}