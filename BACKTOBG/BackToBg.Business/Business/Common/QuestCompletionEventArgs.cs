using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToBg.Core.Business.Common
{
    public class QuestCompletionEventArgs : EventArgs
    {
        public string Name { get; }

        public QuestCompletionEventArgs(string name)
        {
            this.Name = name;
        }
    }
}
