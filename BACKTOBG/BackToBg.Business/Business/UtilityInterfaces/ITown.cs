using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.UtilityInterfaces
{
    public interface ITown
    {
        IMap Map { get; }

        void AddQuest(IQuest quest);
        void RefreshQuest(IQuest quest);
        void AddBuilding(IBuilding building);
    }
}
