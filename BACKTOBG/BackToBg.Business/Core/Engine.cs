using System;
using BackToBg.Core.Business.Exceptions;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Core
{
    public class Engine : IEngine
    {
        private readonly IPlayer player;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IMap map;

        public Engine(IPlayer player, IReader reader, IWriter writer, IMap map)
        {
            this.player = player;
            this.reader = reader;
            this.writer = writer;
            this.map = map;
        }

        public void Run()
        {
            while (true)
            {
                this.map.DrawMap();
                var key = this.reader.ReadKey();
                try
                {
                    this.map.Update(key.Key);
                }
                catch (Exception e)
                    when (e is NotImplementedException || e is InvalidActionException || e is NotSupportedException)
                {
                    this.writer.DisplayException(e.Message);
                    this.map.DrawMap();
                }
            }
        }
    }
}