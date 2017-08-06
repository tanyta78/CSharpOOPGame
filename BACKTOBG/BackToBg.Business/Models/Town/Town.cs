using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Models.Town
{
    public class Town : ITown
    {
        private IMap map;
        private IList<IQuest> quests;
        private IWriter writer;

        public Town(IMap map, IWriter writer)
        {
            this.map = map;
            this.quests = new List<IQuest>();
            this.writer = writer;
        }

        public IMap Map
        {
            get => this.map;
        }

        public void AddQuest(IQuest quest)
        {
            this.quests.Add(quest);
            this.map.GenerateMap();
        }

        public void RefreshQuest(IQuest quest)
        {
            if (quest.IsFinished)
            {
                this.writer.DisplayQuestCompletionMessage($"Quest {quest.Name} is finished!");
            }
            this.map.GenerateMap();
        }

        public void AddBuilding(IBuilding building)
        {
            this.map.AddBuilding(building);
        }
    }
}
