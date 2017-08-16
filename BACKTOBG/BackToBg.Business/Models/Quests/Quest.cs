using System;
using System.Collections.Generic;
using BackToBg.Core.Business.Common;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Models.Quests
{
    public delegate void QuestFinishedEventHandler(object sender, QuestCompletionEventArgs args);

    public abstract class Quest : IQuest
    {
        public event QuestFinishedEventHandler QuestCompletionEvent; 
        private int id;
        private string name;
        protected CustomEventHandler handler;
        private bool isFinished;

        public Quest(string name, string description, int rewardExperiancePoints, int rewardMoney, CustomEventHandler handler)
        {
            this.Name = name;
            this.Description = description;
            this.RewardExperiancePoints = rewardExperiancePoints;
            this.RewardMoney = rewardMoney;
            this.handler = handler;
            this.QuestCompletionEvent += handler.QuestCompletion;
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
            get { return this.isFinished; }
            set
            {
                this.isFinished = value;
                if (value)
                {
                    this.OnQuestCompletionEvent(new QuestCompletionEventArgs(this.name));
                }   
            }
        }

        protected virtual void OnQuestCompletionEvent(QuestCompletionEventArgs args)
        {
            this.QuestCompletionEvent?.Invoke(this, args);
        }
    }
}