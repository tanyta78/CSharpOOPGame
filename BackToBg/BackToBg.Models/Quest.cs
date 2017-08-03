using BACKTOBG.Models;
using System.Collections.Generic;

namespace BackToBg.Models
{
    public class Quest : IQuest
    {
        public Quest(int id, string name, string description, int rewardExperiancePoints, int rewardMoney)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
            this.RewardExperiancePoints = rewardExperiancePoints;
            this.RewardMoney = rewardMoney;
            this.QuestCompetionItems = new List<IQuestCompetionItem>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RewardExperiancePoints { get; set; }
        public int RewardMoney { get; set; }
        public IItem RewardItem { get; set; }
        public List<IQuestCompetionItem> QuestCompetionItems { get; set; }
    }
}