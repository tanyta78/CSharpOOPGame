using System;

namespace BackToBg.Core.Business.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class QuestAttribute : Attribute
    {
        public QuestAttribute(Type questType, string name, string description, int rewardExperiancePoints, int rewardMoney)
        {
            this.Name = name;
            this.Description = description;
            this.RewardExperiancePoints = rewardExperiancePoints;
            this.RewardMoney = rewardMoney;
            this.QuestType = questType;
        }

        public Type QuestType { get; }

        public string Name { get; }

        public string Description { get; }

        public int RewardExperiancePoints { get; }

        public int RewardMoney { get; }
    }
}
