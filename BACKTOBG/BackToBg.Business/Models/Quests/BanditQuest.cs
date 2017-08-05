using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Business.Models.EntityInterfaces;
using BackToBg.Business.Models.People;
using BackToBg.Business.UtilityInterfaces;
using BackToBg.Models;

namespace BackToBg.Business.Models.Quests
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
            //write quest started
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
