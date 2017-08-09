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
        string Name { get; }
        IMap Map { get; }
        
        void RefreshQuest(IQuest quest);
        void AddBuilding(IBuilding building);
    }
}
