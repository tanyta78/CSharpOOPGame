using BACKTOBG.Models;
using System;
using System.Collections.Generic;

namespace BackToBg.Models
{
    public class Quest : IQuest
    {
        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int RewardExperiancePoints { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int RewardMoney { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IItem RewardItem { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IQuestCompetionItem> QuestCompetionItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}