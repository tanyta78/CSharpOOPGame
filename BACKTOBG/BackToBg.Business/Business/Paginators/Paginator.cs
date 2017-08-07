using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Core.Business.UtilityInterfaces;

namespace BackToBg.Core.Business.Paginators
{
    public abstract class Paginator : IPaginator
    {
        protected int pageNumber;
        protected bool shouldBeRunning;
        protected IReader reader;
        protected IWriter writer;

        public Paginator(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.pageNumber = 0;
            this.shouldBeRunning = true;
        }

        public IList<string> Text;

        public void Start()
        {
            while (this.shouldBeRunning)
            {
                this.DisplayPages();
                this.ReadKeyInput();
            }
        }

        protected abstract int PagesCount { get; }

        protected abstract void DisplayPages();

        protected abstract void ExecuteAction();

        protected virtual void ReadKeyInput()
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
                    break;
                case ConsoleKey.Enter:
                    this.ExecuteAction();
                    break;
                case ConsoleKey.Escape:
                    this.shouldBeRunning = false;
                    break;
            }
        }
    }
}
