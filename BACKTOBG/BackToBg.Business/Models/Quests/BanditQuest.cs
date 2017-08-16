using System.Collections.Generic;
using BackToBg.Core.Business.Attributes;
using BackToBg.Core.Business.Common;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.People;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Models.Quests
{
    public class BanditQuest : Quest
    {
        private IList<IPunchable> bandits;

        [Inject] private IRandomNumberGenerator randomNumberGenerator;

        [Inject] private ITown town;

        public BanditQuest(string name, string description, int rewardExperiancePoints, int rewardMoney,
            CustomEventHandler handler) : base(name, description, rewardExperiancePoints, rewardMoney, handler)
        {
        }

        public void RemoveBandint(IPunchable bandit)
        {
            this.bandits.Remove(bandit);
            if (this.bandits.Count == 0)
                this.IsFinished = true;
            this.town.RefreshQuest(this);
        }

        [Invoke]
        private void InitialiseBandits()
        {
            this.bandits = new List<IPunchable>();
            var banditsCounter = this.randomNumberGenerator.GetNextNumber(5, 8);
            while (true)
            {
                if (this.bandits.Count == banditsCounter)
                    break;
                var row = this.randomNumberGenerator.GetNextNumber(1, this.town.Map.Size);
                var col = this.randomNumberGenerator.GetNextNumber(1, this.town.Map.Size);
                if (this.town.Map.CanSpawnEntityInSpot(row, col))
                    this.bandits.Add(new Bandit(this, row, col));
            }
        }

        [Invoke]
        private void InitializeMap()
        {
            foreach (var bandit in this.bandits)
                this.town.Map.AddPunchable(bandit);
        }
    }
}