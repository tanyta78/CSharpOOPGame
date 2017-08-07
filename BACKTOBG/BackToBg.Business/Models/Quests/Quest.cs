using System;
using System.Collections.Generic;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Models
{
    public abstract class Quest : IQuest
    {
        private int id;
        private string name;

        public Quest(string name, string description, int rewardExperiancePoints, int rewardMoney)
        {
            this.Name = name;
            this.Description = description;
            this.RewardExperiancePoints = rewardExperiancePoints;
            this.RewardMoney = rewardMoney;
            this.QuestCompetionItems = new List<IQuestCompetionItem>();
        }

        public int ID
        {
            get => this.id;

            private set
            {
				Validator.IsPositive(value, nameof(this.ID) + Messages.ValueShouldBePositive);
				this.id = value;
            }
        }

        public string Name
        {
            get => this.name;

            private set
            {
				Validator.IsNullEmptyOrWhiteSpace(value, nameof(this.name) + Messages.ValueShouldNotBeEmptyOrNull);
				this.name = value;
            }
        }

        public string Description { get; set; }
        public int RewardExperiancePoints { get; set; }
        public int RewardMoney { get; set; }
        public IItem RewardItem { get; set; }
        public IList<IQuestCompetionItem> QuestCompetionItems { get; set; }
        public bool IsFinished { get; set; }
        public abstract void StartQuest();
    }
}