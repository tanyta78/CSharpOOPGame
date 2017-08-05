using System;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Models
{
    public class PlayerQuest : IPlayerQuest
    {
        public IQuest Details
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public bool IsCompleted
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}