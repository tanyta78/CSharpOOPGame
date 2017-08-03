using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Models.Creatures
{
    public class Criminal : ICreature
    {
        private const int MoneyReward = 50;
        private const int ExperiancePointReward = 50;

        private int id;
        private string name;
        private int currentHitPoints;
        private int maxHitPoints;

        public Criminal(int id, string name, int currentHitPoints, int maxHitPoints)
        {
            this.ID = id;
            this.Name = name;
            this.CurrentHitPoints = currentHitPoints;
            this.MaxHitPoints = maxHitPoints;
            this.RewardExperiancePoints = MoneyReward;
            this.RewardMoney = ExperiancePointReward;
        }

        public (int row, int col, string[] figure) GetDrawingInfo()
        {
            throw new NotImplementedException();
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

        public int CurrentHitPoints
        {
            get { return this.currentHitPoints; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.currentHitPoints)} should be positive integer!");
                }

                this.currentHitPoints = value;
            }
        }

        public int MaxHitPoints
        {
            get { return this.maxHitPoints; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.maxHitPoints)} should be positive integer!");
                }

                this.maxHitPoints = value;
            }
        }

        public int RewardExperiancePoints { get; set; }

        public int RewardMoney { get; set; }
    }
}