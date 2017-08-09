using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToBg.Core.Business.UtilityInterfaces
{
    public interface ITownsManager
    {
        ITown GetCurrentTown();
        IList<ITown> GetTowns();
        void AddTown(ITown town);
        void SetCurrentTown(ITown town);
    }
}
