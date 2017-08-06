using System.Collections.Generic;
using BackToBg.Core.Business.Attributes;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.People;

namespace BackToBg.Core.Models.Quests
{
    public class BanditQuest : Quest
    {
        private readonly IList<IPunchable> bandits;

<<<<<<< HEAD
        [Inject] private IMap map;
=======
        [Inject]
        private ITown town;
>>>>>>> cd78453d4a543777e45c5275f30c04e921ff3a6b

        public BanditQuest(string name, string description, int rewardExperiancePoints, int rewardMoney)
            : base(name, description, rewardExperiancePoints, rewardMoney)
        {
            this.bandits = new List<IPunchable> {new Bandit(this, 30, 30)};
        }

        [Invoke]
        private void InitializeMap()
        {
            foreach (var bandit in this.bandits)
<<<<<<< HEAD
                this.map.AddPunchable(bandit);
=======
            {
                this.town.Map.AddPunchable(bandit);
            }
>>>>>>> cd78453d4a543777e45c5275f30c04e921ff3a6b
        }

        public override void StartQuest()
        {
        }

        public void RemoveBandint(IPunchable bandit)
        {
            this.bandits.Remove(bandit);
            if (this.bandits.Count == 0)
                this.IsFinished = true;
<<<<<<< HEAD
            this.map.RefreshQuest(this);
=======
            }
            this.town.RefreshQuest(this);
>>>>>>> cd78453d4a543777e45c5275f30c04e921ff3a6b
        }
    }
}