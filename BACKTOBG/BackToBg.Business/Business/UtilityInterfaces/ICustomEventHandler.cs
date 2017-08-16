using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Core.Business.Common;

namespace BackToBg.Core.Business.UtilityInterfaces
{
    public interface ICustomEventHandler
    {
        void QuestCompletion(object sender, QuestCompletionEventArgs args);
    }
}
