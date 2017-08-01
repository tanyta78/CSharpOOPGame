using BACKTOBG.Models;
using System;

namespace BackToBg.Models
{
    public class PlayerQuest : IPlayerQuest
    {
        public IQuest Details { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsCompleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}