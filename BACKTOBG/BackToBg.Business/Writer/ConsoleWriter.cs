using BackToBg.Business.UtilityInterfaces;
using System;
using System.Text;
using System.Threading;

namespace BackToBg.Business.Writer
{
    public class ConsoleWriter : IWriter
    {
        private readonly int consoleHeight;
        private readonly int consoleWidth;

        public ConsoleWriter(int consoleHeight, int consoleWidth)
        {
            this.consoleHeight = consoleHeight;
            this.consoleWidth = consoleWidth;
            this.PerformConsoleSetup();
        }

        public int ConsoleHeight
        {
            get { return this.consoleHeight; }
        }

        public int ConsoleWidth
        {
            get { return this.consoleWidth; }
        }

        private void PerformConsoleSetup()
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.Unicode;
            Console.WindowHeight = this.consoleHeight;
            Console.WindowWidth = this.consoleWidth;
            Console.BufferHeight = this.consoleHeight;
            Console.BufferWidth = this.consoleWidth;
        }

        public void DisplayException(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition((this.consoleWidth - message.Length) / 2, this.consoleHeight / 2);
            Console.WriteLine(message);
            Console.ResetColor();
            Thread.Sleep(1000);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
