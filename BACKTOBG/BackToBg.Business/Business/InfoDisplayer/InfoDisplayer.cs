using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Business.InfoDisplayer
{
    public abstract class InfoDisplayer : IInfoDisplayer
    {
        private IReader reader;
        private IWriter writer;

        protected InfoDisplayer(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        protected abstract IList<string> Info { get; }

        public void Display()
        {
            var bottomMessage = "Press any key to go back";
            var topMessage = "Player info:";
            this.writer.Clear();

            var positionLeft = (this.writer.ConsoleWidth - topMessage.Length) / 2;
            var positionTop = (this.writer.ConsoleHeight - this.Info.Count) / 2 - 2;
            this.writer.SetCursorPosition(positionLeft, positionTop);
            this.writer.DisplayMessageInColor("Player info", ConsoleColor.Green);

            var determiner = this.Info.OrderByDescending(s => s.Length).First();
            positionLeft = (this.writer.ConsoleWidth - determiner.Length) / 2;
            for (int i = 0; i < this.Info.Count; i++)
            {
                positionTop = (this.writer.ConsoleHeight - this.Info.Count) / 2 + i;
                this.writer.SetCursorPosition(positionLeft, positionTop);
                this.writer.DisplayMessageInColor(this.Info[i], ConsoleColor.Yellow);
            }

            positionLeft = (this.writer.ConsoleWidth - bottomMessage.Length) / 2;
            this.writer.SetCursorPosition(positionLeft, positionTop + 5);
            this.writer.DisplayMessageInColor(bottomMessage, ConsoleColor.Magenta);
            this.reader.ReadKey();
        }
    }
}
