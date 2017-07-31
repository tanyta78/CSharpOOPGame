using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKTOBG.Models
{
    internal interface IQuest
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int RewardExperiancePoints { get; set; }
        int RewardMoney { get; set; }
        IItem RewardItem { get; set; }
        List<IQuestCompetionItem> QuestCompetionItems { get; set; }
    }
}