using System;
using BackToBg.Core.Business.UtilityInterfaces;

namespace BackToBg.Core.Business.Reader
{
    public class ConsoleReader : IReader
    {
        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }
    }
}