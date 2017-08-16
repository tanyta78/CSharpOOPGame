using System.Collections.Generic;
using BackToBg.Core.Business.Common;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Models.Quests
{
    public delegate void QuestFinishedEventHandler(object sender, QuestCompletionEventArgs args);

    public abstract class Quest : IQuest
    {
        protected ICustomEventHandler handler;
        private int id;
        private bool isFinished;
        private string name;

        public Quest(string name, string description, int rewardExperiancePoints, int rewardMoney,
            ICustomEventHandler handler)
        {
            this.Name = name;
            this.Description = description;
            this.RewardExperiancePoints = rewardExperiancePoints;
            this.RewardMoney = rewardMoney;
            this.handler = handler;
            QuestCompletionEvent += handler.QuestCompletion;
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

        public bool IsFinished
        {
            get => this.isFinished;
            set
            {
                this.isFinished = value;
                if (value)
                    OnQuestCompletionEvent(new QuestCompletionEventArgs(this.name));
            }
        }

        public event QuestFinishedEventHandler QuestCompletionEvent;

        protected virtual void OnQuestCompletionEvent(QuestCompletionEventArgs args)
        {
            QuestCompletionEvent?.Invoke(this, args);
        }
    }
}