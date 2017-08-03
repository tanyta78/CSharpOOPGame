using System;
using BACKTOBG.Models;
using System.Collections.Generic;

namespace BackToBg.Models
{
    public class Quest : IQuest
    {
        private int id;
        private string name;

        public Quest(int id, string name, string description, int rewardExperiancePoints, int rewardMoney)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
            this.RewardExperiancePoints = rewardExperiancePoints;
            this.RewardMoney = rewardMoney;
            this.QuestCompetionItems = new List<IQuestCompetionItem>();
        }

        public int ID
        {
            get { return this.id; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.id)} should be positive integer!");
                }

                this.id = value;
            }
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(this.name)} should not be null empty or white space!");
                }

                this.name = value;
            }
        }

        public string Description { get; set; }
        public int RewardExperiancePoints { get; set; }
        public int RewardMoney { get; set; }
        public IItem RewardItem { get; set; }
        public List<IQuestCompetionItem> QuestCompetionItems { get; set; }
    }
}