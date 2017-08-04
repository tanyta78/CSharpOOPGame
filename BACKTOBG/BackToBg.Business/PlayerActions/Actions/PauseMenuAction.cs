using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Business.Attributes;
using BackToBg.Business.Writer;

namespace BackToBg.Business.PlayerActions.Actions
{
    [PlayerAction("Escape")]
    public class PauseMenuAction : PlayerAction
    {
        private IDictionary<int, Action> actions = new Dictionary<int, Action>()
        {
            {0, () => shouldBeRunning = false},
            {4, () => { Console.Clear(); Environment.Exit(0); } }
        };

        private int selectedIndex = 0;

        private IList<string> menuText = new List<string>()
        {
            "Resume",
            "Switch Town",
            "View stats",
            "View quests",
            "Exit"
        };

        private static bool shouldBeRunning = true;


        public override void Execute()
        {
            while (shouldBeRunning)
            {
                this.PrintMenu();

                this.ReadKeyInput();
            }
            shouldBeRunning = true;
        }

        private void PrintMenu()
        {
            Console.Clear();
            for (int i = 0; i < this.menuText.Count; i++)
            {
                //set-up so that the menu is drawn on the middle of the screen
                Console.SetCursorPosition(Console.WindowWidth / 2 - this.menuText[0].Length, (Console.WindowHeight - this.menuText.Count) / 2 + i);
                if (i == this.selectedIndex)
                {
                    Console.WriteLine($">{this.menuText[i]}<");
                }
                else
                {
                    Console.WriteLine(this.menuText[i]);
                }
            }
        }

        private void ReadKeyInput()
        {
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (this.selectedIndex == 0)
                    {
                        this.selectedIndex = this.menuText.Count - 1;
                    }
                    else
                    {
                        this.selectedIndex--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (this.selectedIndex == this.menuText.Count - 1)
                    {
                        this.selectedIndex = 0;
                    }
                    else
                    {
                        this.selectedIndex++;
                    }
                    break;
                case ConsoleKey.Enter:
                    if (!this.actions.ContainsKey(this.selectedIndex))
                    {
                        throw new NotImplementedException($"{this.menuText[this.selectedIndex]} not available yet.");
                    }
                    this.actions[this.selectedIndex]();
                    break;
            }
        }
    }
}
