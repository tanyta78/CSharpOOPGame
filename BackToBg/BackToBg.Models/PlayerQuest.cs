using System;
using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Models
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