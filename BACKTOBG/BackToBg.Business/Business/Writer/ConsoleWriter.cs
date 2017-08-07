using System;
using System.Text;
using System.Threading;
using BackToBg.Core.Business.UtilityInterfaces;

namespace BackToBg.Core.Business.Writer
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
            //this.CenterCursor(message); 
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void DisplayQuestCompletionMessage(string message)
        {
            this.CenterCursor(message);
            DisplayMessageInColor(message, ConsoleColor.Green);
            Thread.Sleep(1000);
        }

        public void DisplayException(string message)
        {
            this.CenterCursor(message);
            DisplayMessageInColor(message, ConsoleColor.Red);
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

        public void DisplayMessageInColorCentered(string message, ConsoleColor color)
        {
            Console.Clear();
            this.CenterCursor(message);
            this.DisplayMessageInColor(message, color);
        }

        private void CenterCursor(string message)
        {
            Console.SetCursorPosition((this.ConsoleWidth - message.Length) / 2, this.ConsoleHeight / 2);
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