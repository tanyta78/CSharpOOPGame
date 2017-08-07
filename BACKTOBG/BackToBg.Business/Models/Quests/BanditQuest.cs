using System.Collections.Generic;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.People;
using BackToBg.Core.Business.Attributes;

namespace BackToBg.Core.Models.Quests
{
    public class BanditQuest : Quest
    {
        private IList<IPunchable> bandits;

        [Inject]
        private ITown town;

        public BanditQuest(string name, string description, int rewardExperiancePoints, int rewardMoney) 
            : base(name, description, rewardExperiancePoints, rewardMoney)
        {
            this.bandits = new List<IPunchable>() { new Bandit(this, 30, 30) };            
        }

        [Invoke]
        private void InitializeMap()
        {
            foreach (var bandit in this.bandits)
            {
                this.town.Map.AddPunchable(bandit);
            }
        }

        public void RemoveBandint(IPunchable bandit)
        {
            this.bandits.Remove(bandit);
            if (this.bandits.Count == 0)
            {
                this.IsFinished = true;
            }
            this.town.RefreshQuest(this);
        }
    }
}