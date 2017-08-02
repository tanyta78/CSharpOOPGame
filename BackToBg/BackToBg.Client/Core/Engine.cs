using BackToBg.Business.UtilityInterfaces;
using System;

namespace BackToBg.Client.Core
{
    public class Engine : IEngine
    {
        private static int ConsoleHeight = 40;
        private static int ConsoleWidth  = 100;

        private void PerformConsoleSetup()
        {
            Console.BufferHeight = ConsoleHeight;
            Console.BufferWidth = ConsoleWidth;
            Console.WindowHeight = ConsoleHeight;
            Console.WindowWidth = ConsoleWidth;
        }

        public void Run()
        {
            this.PerformConsoleSetup();
        }
    }
}