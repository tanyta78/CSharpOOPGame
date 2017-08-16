using System;
using System.Collections.Generic;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Business.Paginators
{
    public abstract class Paginator<T> : IPaginator
    {
        private const int ItemsPerPage = 10;
        protected int lineNumber;
        protected string name;
        protected int pageNumber;
        protected IReader reader;
        protected bool shouldBeRunning;
        protected IWriter writer;


        public Paginator(IReader reader, IWriter writer, string name)
        {
            this.reader = reader;
            this.writer = writer;
            this.name = name;
            this.pageNumber = 0;
            this.lineNumber = 0;
            this.shouldBeRunning = true;
        }

        protected abstract IReadOnlyList<T> Items { get; }

        protected virtual int PagesCount
        {
            get
            {
                var rem = this.Items.Count % ItemsPerPage != 0 ? 1 : 0;
                var result = this.Items.Count / ItemsPerPage + rem;

                return result;
            }
        }

        public void Start()
        {
            while (this.shouldBeRunning)
            {
                DisplayPages();
                ReadKeyInput();
            }
        }

        protected virtual void DisplayPages()
        {
            this.writer.Clear();
            this.writer.SetCursorPosition((Constants.ConsoleWidth - this.name.Length) / 2,
                Constants.ConsoleHeight / 2 - 1);
            this.writer.DisplayMessageInColor(this.name, ConsoleColor.Green);
            var items = this.Items;
            var questCount = items.Count;
            var maxItemsOnCurrentPage = this.pageNumber * this.PagesCount + ItemsPerPage;
            var upperBorder = Math.Min(maxItemsOnCurrentPage, questCount);
            var index = this.pageNumber * ItemsPerPage;
            for (; index < upperBorder; index++)
            {
                var itemAsString = RepresentItem(items[index]);
                this.writer.SetCursorPosition((Constants.ConsoleWidth - itemAsString.Length) / 2,
                    Constants.ConsoleHeight / 2 + index % ItemsPerPage);
                if (index == this.lineNumber + this.pageNumber * ItemsPerPage)
                    this.writer.WriteLine($">{itemAsString}<");
                else
                    this.writer.WriteLine($"{itemAsString}");
            }

            var message = $"Page {this.pageNumber + 1}/{this.PagesCount}";
            this.writer.SetCursorPosition((Constants.ConsoleWidth - message.Length) / 2,
                Constants.ConsoleHeight / 2 + ItemsPerPage + 1);
            this.writer.DisplayMessageInColor(message, ConsoleColor.Magenta);
        }

        protected abstract void ExecuteAction();

        protected virtual void ReadKeyInput()
        {
            var key = this.reader.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (this.pageNumber <= 0)
                        this.pageNumber = this.PagesCount - 1;
                    else
                        this.pageNumber--;
                    this.lineNumber = 0;
                    break;
                case ConsoleKey.RightArrow:
                    if (this.pageNumber >= this.PagesCount - 1)
                        this.pageNumber = 0;
                    else
                        this.pageNumber++;
                    this.lineNumber = 0;
                    break;
                case ConsoleKey.DownArrow:
                    if (this.lineNumber < ItemsPerPage - 1 &&
                        this.lineNumber + this.pageNumber * ItemsPerPage < this.Items.Count - 1)
                        this.lineNumber++;
                    break;
                case ConsoleKey.UpArrow:
                    if (this.lineNumber > 0)
                        this.lineNumber--;
                    break;
                case ConsoleKey.Enter:
                    ExecuteAction();
                    break;
                case ConsoleKey.Escape:
                    this.shouldBeRunning = false;
                    break;
            }
        }

        protected abstract string RepresentItem(T item);
    }
}