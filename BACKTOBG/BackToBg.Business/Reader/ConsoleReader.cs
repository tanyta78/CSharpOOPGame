using BackToBg.Business.UtilityInterfaces;
using System;

namespace BackToBg.Business.Reader
{
    public class ConsoleReader : IReader
    {
        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }
    }
}
