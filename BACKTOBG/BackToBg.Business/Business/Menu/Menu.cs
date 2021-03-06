﻿using System;
using System.Collections.Generic;
using BackToBg.Core.Business.UtilityInterfaces;

namespace BackToBg.Core.Business.Menu
{
    public abstract class Menu : IMenu
    {
        protected static bool ShouldBeRunning = true;
        protected string name;
        protected int selectedIndex;
        protected IWriter writer;

        public Menu(string name, IReader reader, IWriter writer)
        {
            this.Reader = reader;
            this.writer = writer;
            this.name = name;
        }

        protected abstract IDictionary<int, Action> Actions { get; }
        protected abstract IList<string> MenuText { get; }

        protected IReader Reader { get; }

        protected IWriter Writer => this.writer;

        public void StartMenu()
        {
            while (ShouldBeRunning)
            {
                PrintMenu();
                ReadKeyInput();
            }
            ShouldBeRunning = true;
        }

        protected virtual void PrintMenu()
        {
            this.Writer.Clear();
            this.Writer.SetCursorPosition((this.Writer.ConsoleWidth - this.name.Length) / 2,
                (this.Writer.ConsoleHeight - this.MenuText.Count) / 2 - 1);
            this.Writer.DisplayMessageInColor(this.name, ConsoleColor.Green);
            for (var i = 0; i < this.MenuText.Count; i++)
            {
                //set-up so that the menu is drawn on the middle of the screen				
                this.Writer.SetCursorPosition(this.Writer.ConsoleWidth / 2 - this.MenuText[0].Length,
                    (this.Writer.ConsoleHeight - this.MenuText.Count) / 2 + i + 1);
                if (i == this.selectedIndex)
                    this.Writer.WriteLine($">{this.MenuText[i]}<");
                else
                    this.Writer.WriteLine(this.MenuText[i]);
            }
        }

        protected virtual void ReadKeyInput()
        {
            var key = this.Reader.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    this.selectedIndex--;
                    if (this.selectedIndex < 0)
                        this.selectedIndex = this.MenuText.Count - 1;
                    break;
                case ConsoleKey.DownArrow:
                    this.selectedIndex++;
                    if (this.selectedIndex >= this.MenuText.Count)
                        this.selectedIndex = 0;
                    break;
                case ConsoleKey.Enter:
                    ExecuteCommand(this.selectedIndex);
                    break;
                case ConsoleKey.Escape:
                    ShouldBeRunning = false;
                    break;
            }
        }

        protected virtual void ExecuteCommand(int commandNumber)
        {
            if (!this.Actions.ContainsKey(this.selectedIndex))
                throw new NotImplementedException($"{this.MenuText[this.selectedIndex]} not available yet.");

            this.Actions[commandNumber]();
        }
    }
}