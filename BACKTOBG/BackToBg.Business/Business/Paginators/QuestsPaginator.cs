using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Business.Paginators
{
    public abstract class QuestsPaginator : Paginator
    {
        private const int ItemsPerPage = 10;

        private int lineNumber;
        private IEngine engine;

        public QuestsPaginator(IReader reader, IWriter writer, IEngine engine) : base(reader, writer)
        {
            this.engine = engine;
            this.lineNumber = 0;
        }

        protected abstract IReadOnlyList<IQuest> Quests { get; }

        protected override int PagesCount
        {
            get
            {
                var rem = this.Quests.Count % ItemsPerPage != 0 ? 1 : 0;
                var result = this.Quests.Count / ItemsPerPage + rem;

                return result;
            }
        }

        protected override void DisplayPages()
        {
            this.writer.Clear();
            var text = "Quests";
            this.writer.SetCursorPosition((Constants.ConsoleWidth - text.Length) / 2, Constants.ConsoleHeight / 2 - 1);
            this.writer.DisplayMessageInColor(text, ConsoleColor.Green);
            var quests = this.Quests;
            var questCount = quests.Count;
            var maxItemsOnCurrentPage = this.pageNumber * (this.PagesCount) + ItemsPerPage;
            var upperBorder = Math.Min(maxItemsOnCurrentPage, questCount);
            var i = this.pageNumber * ItemsPerPage;
            for (; i < upperBorder; i++)
            {
                this.writer.SetCursorPosition((Constants.ConsoleWidth - quests[0].Name.Length) / 2, Constants.ConsoleHeight / 2 + i % ItemsPerPage);
                if (i == this.lineNumber + this.pageNumber * ItemsPerPage)
                {
                    this.writer.WriteLine($">{this.Quests[i].Name}<");
                }
                else
                {
                    this.writer.WriteLine($"{this.Quests[i].Name}");
                }
            }

            var message = $"Page {this.pageNumber + 1}/{this.PagesCount}";
            this.writer.SetCursorPosition((Constants.ConsoleWidth - message.Length) / 2, Constants.ConsoleHeight / 2 + ItemsPerPage + 1);
            this.writer.DisplayMessageInColor(message, ConsoleColor.Magenta);
        }

        protected override void ReadKeyInput()
        {
            var key = this.reader.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (this.pageNumber <= 0)
                    {
                        this.pageNumber = this.PagesCount - 1;
                    }
                    else
                    {
                        this.pageNumber--;
                    }
                    this.lineNumber = 0;
                    break;
                case ConsoleKey.RightArrow:
                    if (this.pageNumber >= this.PagesCount - 1)
                    {
                        this.pageNumber = 0;
                    }
                    else
                    {
                        this.pageNumber++;
                    }
                    this.lineNumber = 0;
                    break;
                case ConsoleKey.DownArrow:
                    if (this.lineNumber < ItemsPerPage - 1 && this.lineNumber + this.pageNumber * ItemsPerPage < this.Quests.Count - 1)
                    {
                        this.lineNumber++;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (this.lineNumber > 0)
                    {
                        this.lineNumber--;
                    }
                    break;
                case ConsoleKey.Enter:
                    this.ExecuteAction();
                    break;
                case ConsoleKey.Escape:
                    this.shouldBeRunning = false;
                    break;
            }
        }

        protected override void ExecuteAction()
        {
            throw new NotImplementedException("Viewing quest details not yet implemented");
        }
    }
}
