using System;
using System.Collections.Generic;
using BackToBg.Core.Business.Attributes;
using BackToBg.Core.Business.UtilityInterfaces;

namespace BackToBg.Core.Business.Menu
{
    public abstract class Menu : IMenu
    {
        [Inject]
        private IReader reader;

        [Inject]
        private IWriter writer;

        public Menu(string name, IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.name = name;
        }

        protected abstract IDictionary<int, Action> Actions { get; }
        protected abstract IList<string> MenuText { get; }
        protected static bool ShouldBeRunning = true;
        private int selectedIndex;
        private string name;

        public void StartMenu()
        {
            while (ShouldBeRunning)
            {
                this.PrintMenu();
                this.ReadKeyInput();
            }
            ShouldBeRunning = true;
        }

        private void PrintMenu()
        {
            this.writer.Clear();
            this.writer.SetCursorPosition((Console.WindowWidth - this.name.Length) / 2, (Console.WindowHeight - this.MenuText.Count) / 2 - 1);
            this.writer.DisplayMessageInColor(this.name, ConsoleColor.Green);
            for (var i = 0; i < this.MenuText.Count; i++)
            {
                //set-up so that the menu is drawn on the middle of the screen
                this.writer.SetCursorPosition(Console.WindowWidth / 2 - this.MenuText[0].Length,
                    (Console.WindowHeight - this.MenuText.Count) / 2 + i);
                if (i == this.selectedIndex)
                    this.writer.WriteLine($">{this.MenuText[i]}<");
                else
                    this.writer.WriteLine(this.MenuText[i]);
            }
        }

        private void ReadKeyInput()
        {
            var key = this.reader.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    this.selectedIndex--;
                    this.selectedIndex = (this.MenuText.Count + this.selectedIndex) % this.MenuText.Count;
                    break;
                case ConsoleKey.DownArrow:
                    this.selectedIndex++;
                    this.selectedIndex %= this.MenuText.Count;
                    break;
                case ConsoleKey.Enter:
                    if (!this.Actions.ContainsKey(this.selectedIndex))
                        throw new NotImplementedException($"{this.MenuText[this.selectedIndex]} not available yet.");
                    this.Actions[this.selectedIndex]();
                    break;
                case ConsoleKey.Escape:
                    ShouldBeRunning = false;
                    break;
            }
        }
    }
}
