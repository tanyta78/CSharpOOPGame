using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKTOBG.Models
{
    internal interface ILocation
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        IItem ItemRequeredToEnter { get; set; }
        IQuest QuestAvailableHere { get; set; }
        IMonster MonsterLivingHere { get; set; }
    }
}