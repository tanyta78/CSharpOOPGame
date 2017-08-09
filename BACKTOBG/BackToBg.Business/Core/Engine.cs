using System;
using System.Collections.Generic;
using BackToBg.Core.Business.Exceptions;
using BackToBg.Core.Business.Factories;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Core
{
    public class Engine : IEngine
    {
        private ITownsManager townsManager;
        private IPlayerManager playerManager;
        private readonly IReader reader;
        private readonly IWriter writer;
        private IPlayerActionFactory playerActionFactory;

        public Engine(IPlayerManager playerManager, ITownsManager townsManager, IReader reader, IWriter writer)
        {
            this.playerManager = playerManager;
            this.townsManager = townsManager;
            this.reader = reader;
            this.writer = writer;
            this.playerActionFactory = new PlayerActionFactory(this.townsManager, this.playerManager, reader, writer);
        }

        public void Run()
        {
            while (true)
            {
                var town = this.townsManager.GetCurrentTown();
                town.Map.DrawMap();
                var key = this.reader.ReadKey();
                try
                {
                    var action = this.playerActionFactory.CreateAction(key.Key);
                    action.Execute();
                    town.Map.GenerateMap();
                    //this.Town.Map.Update(action);
                }
                catch (Exception e)
                    when (e is NotImplementedException || e is InvalidActionException || e is NotSupportedException)
                {
                    this.writer.DisplayException(e.Message);
                    town.Map.DrawMap();
                }
            }
        }
    }
}