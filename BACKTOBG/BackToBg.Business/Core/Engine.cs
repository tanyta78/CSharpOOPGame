using System;
using System.Collections.Generic;
using BackToBg.Business;
using BackToBg.Business.Exceptions;
using BackToBg.Business.UtilityInterfaces;
using BackToBg.Models.Buildings;
using BackToBg.Models.Buildings.SpecialBuildings;
using BackToBg.Models.EntityInterfaces;
using BackToBg.Business.Common;

namespace BackToBg.Client.Core
{
    public class Engine : IEngine
    {
        private IMap map;
        private readonly IPlayer player;
        private readonly IReader reader;
        private readonly IWriter writer;

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
                catch (Exception e) when (e is NotImplementedException || e is InvalidActionException ||
                                          e is NotSupportedException)
                {
                    this.writer.DisplayException(e.Message);
                    this.map.DrawMap();
                }
            }
        }
    }
}