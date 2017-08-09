using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.UtilityInterfaces
{
    public interface IPlayerManager
    {
        IPlayer Player { get; }
        void AddQuest(IQuest quest);
    }
}
