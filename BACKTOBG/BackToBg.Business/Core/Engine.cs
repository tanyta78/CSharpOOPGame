using System;
using BackToBg.Core.Business.Exceptions;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Core
{
    public class Engine : IEngine
    {
        private ITown town;
        private readonly IPlayer player;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IPlayer player, IReader reader, IWriter writer, ITown town)
        {
            this.player = player;
            this.reader = reader;
            this.writer = writer;
            this.town = town;
        }

        public void Run()
        {
            while (true)
            {
                this.town.Map.DrawMap();
                var key = this.reader.ReadKey();
                try
                {
                    this.town.Map.Update(key.Key);
                }
                catch (Exception e)
                    when (e is NotImplementedException || e is InvalidActionException || e is NotSupportedException)
                {
                    this.writer.DisplayException(e.Message);
                    this.town.Map.DrawMap();
                }
            }
        }
    }
}