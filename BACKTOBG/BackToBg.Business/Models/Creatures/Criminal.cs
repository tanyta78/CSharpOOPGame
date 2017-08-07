using System;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Models.Creatures
{
    public class Criminal : ICreature
    {
        private const int MoneyReward = 50;
        private const int ExperiancePointReward = 50;
        private int currentHitPoints;

        private int id;
        private int maxHitPoints;
        private string name;

        public Criminal(int id, string name, int currentHitPoints, int maxHitPoints)
        {
            this.ID = id;
            this.Name = name;
            this.CurrentHitPoints = currentHitPoints;
            this.MaxHitPoints = maxHitPoints;
            this.RewardExperiancePoints = MoneyReward;
            this.RewardMoney = ExperiancePointReward;
        }

        public int RewardExperiancePoints { get; set; }

        public int RewardMoney { get; set; }

        public (int row, int col, string[] figure) GetDrawingInfo()
        {
            throw new NotImplementedException();
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

        public int CurrentHitPoints
        {
            get => this.currentHitPoints;

            private set
            {
				Validator.IsPositive(value, nameof(this.currentHitPoints) + Messages.ValueShouldBePositive);
				this.currentHitPoints = value;
            }
        }

        public int MaxHitPoints
        {
            get => this.maxHitPoints;

            private set
            {
				Validator.IsPositive(value, nameof(this.maxHitPoints) + Messages.ValueShouldBePositive);
				this.maxHitPoints = value;
            }
        }
    }
}