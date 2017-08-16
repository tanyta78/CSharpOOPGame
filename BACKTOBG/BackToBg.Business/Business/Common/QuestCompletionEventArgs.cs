using System;

namespace BackToBg.Core.Business.Common
{
    public class QuestCompletionEventArgs : EventArgs
    {
        public QuestCompletionEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}