using System;
using BackToBg.Business.UtilityInterfaces;

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