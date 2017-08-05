using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models;
using BackToBg.Core.Models.Quests;

namespace BackToBg.Core.Business.Factories
{
    public class QuestFactory
    {
        private IMap map;

        public QuestFactory(IMap map)
        {
            this.map = map;
        }

        public Quest CreateQuest(Type questType)
        {
            switch (questType.Name)
            {
                case "BanditQuest":
                    return new BanditQuest("Bandit Quest", "Finding the bandits and punching them to death", 100, 10, this.map);
                default:
                    throw new ArgumentException("Unsupported quest type");
            }
        }
    }
}
