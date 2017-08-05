using System;
using BackToBg.Core.Models.EntityInterfaces;

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
                if (value <= 0)
                    throw new ArgumentException($"{nameof(this.id)} should be positive integer!");

                this.id = value;
            }
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"{nameof(this.name)} should not be null empty or white space!");

                this.name = value;
            }
        }

        public int CurrentHitPoints
        {
            get => this.currentHitPoints;

            private set
            {
                if (value <= 0)
                    throw new ArgumentException($"{nameof(this.currentHitPoints)} should be positive integer!");

                this.currentHitPoints = value;
            }
        }

        public int MaxHitPoints
        {
            get => this.maxHitPoints;

            private set
            {
                if (value <= 0)
                    throw new ArgumentException($"{nameof(this.maxHitPoints)} should be positive integer!");

                this.maxHitPoints = value;
            }
        }
    }
}