using System;
using System.Collections.Generic;
using BackToBg.Business.Attributes;
using BackToBg.Business.UtilityInterfaces;

namespace BackToBg.Business.PlayerActions.Actions
{
    [PlayerAction("Escape")]
    public class PauseMenuAction : PlayerAction
    {
        [Inject] IReader reader;

        [Inject] IWriter writer;

        private static bool shouldBeRunning = true;

        private readonly IDictionary<int, Action> actions = new Dictionary<int, Action>
        {
            {0, () => shouldBeRunning = false},
            {
                4, () =>
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
            }
        };

        private readonly IList<string> menuText = new List<string>
        {
            "Resume",
            "Switch Town",
            "View stats",
            "View quests",
            "Exit"
        };

        private int selectedIndex;

        public override void Execute()
        {
            while (shouldBeRunning)
            {
                PrintMenu();
                ReadKeyInput();
            }
            shouldBeRunning = true;
        }

        private void PrintMenu()
        {
            this.writer.Clear();
            for (var i = 0; i < this.menuText.Count; i++)
            {
                //set-up so that the menu is drawn on the middle of the screen
                this.writer.SetCursorPosition(Console.WindowWidth / 2 - this.menuText[0].Length,
                    (Console.WindowHeight - this.menuText.Count) / 2 + i);
                if (i == this.selectedIndex)
                    this.writer.WriteLine($">{this.menuText[i]}<");
                else
                    this.writer.WriteLine(this.menuText[i]);
            }
        }

        private void ReadKeyInput()
        {
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    this.selectedIndex--;
                    this.selectedIndex = (this.menuText.Count + this.selectedIndex) % this.menuText.Count;
                    break;
                case ConsoleKey.DownArrow:
                    this.selectedIndex++;
                    this.selectedIndex %= this.menuText.Count;
                    break;
                case ConsoleKey.Enter:
                    if (!this.actions.ContainsKey(this.selectedIndex))
                        throw new NotImplementedException($"{this.menuText[this.selectedIndex]} not available yet.");
                    this.actions[this.selectedIndex]();
                    break;
            }
        }
    }
}