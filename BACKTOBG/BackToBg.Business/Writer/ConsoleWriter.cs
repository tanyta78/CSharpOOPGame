using System;
using System.Text;
using System.Threading;
using BackToBg.Business.UtilityInterfaces;

namespace BackToBg.Business.Writer
{
    public class ConsoleWriter : IWriter
    {
        public ConsoleWriter(int consoleHeight, int consoleWidth)
        {
            this.ConsoleHeight = consoleHeight;
            this.ConsoleWidth = consoleWidth;
            PerformConsoleSetup();
        }

        public int ConsoleHeight { get; }

        public int ConsoleWidth { get; }

        public void DisplayMessageInColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void DisplayException(string message)
        {
            Console.SetCursorPosition((this.ConsoleWidth - message.Length) / 2, this.ConsoleHeight / 2);
            this.DisplayMessageInColor(message, ConsoleColor.Red);
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

        public void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }
        
        private void PerformConsoleSetup()
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.Unicode;
            Console.WindowHeight = this.ConsoleHeight;
            Console.WindowWidth = this.ConsoleWidth;
            Console.BufferHeight = this.ConsoleHeight;
            Console.BufferWidth = this.ConsoleWidth;
        }
    }
}