using BACKTOBG.Models;
using System;

namespace BackToBg.Models
{
    public abstract class Item : IItem
    {
        public int ID => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public int Price => throw new NotImplementedException();
    }
}