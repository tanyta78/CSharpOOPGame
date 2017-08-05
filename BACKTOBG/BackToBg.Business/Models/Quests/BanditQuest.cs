using System.Collections.Generic;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.People;

namespace BackToBg.Core.Models.Quests
{
    public class BanditQuest : Quest
    {
        private IList<IPunchable> bandits;
        private IMap map;

        public BanditQuest(int id, string name, string description, int rewardExperiancePoints, int rewardMoney, IMap map) : base(id, name, description, rewardExperiancePoints, rewardMoney)
        {
            this.map = map;
            this.bandits = new List<IPunchable>() { new Bandit(this, 30, 30) };
            foreach (var bandit in this.bandits)
            {
                this.map.AddPunchable(bandit);
            }
        }

        public override void StartQuest()
        {
            
        }

        public void RemoveBandint(IPunchable bandit)
        {
            this.bandits.Remove(bandit);
            if (this.bandits.Count == 0)
            {
                this.IsFinished = true;
            }
            this.map.RefreshQuest(this);
        }
    }
}
