using System;
using System.Collections.Generic;
using BackToBg.Core.Business.Exceptions;
using BackToBg.Core.Business.Factories;
using BackToBg.Core.Business.Managers;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Core
{
    public class Engine : IEngine
    {
        private ITownsManager townsManager;
        private IPlayerManager playerManager;
        private readonly IReader reader;
        private readonly IWriter writer;
        private IPlayerActionFactory playerActionFactory;
	    private IRandomEncountersManager randomEncountersManager;
	    private IRandomNumberGenerator randomNumberGenerator;

        public Engine(IPlayerManager playerManager, ITownsManager townsManager, IReader reader, IWriter writer, IPlayerActionFactory playerActionFactory, IRandomEncountersManager randomEncountersManager, IRandomNumberGenerator randomNumberGenerator)
        {
            this.playerManager = playerManager;
            this.townsManager = townsManager;
            this.reader = reader;
            this.writer = writer;
            this.playerActionFactory = playerActionFactory;
            this.randomEncountersManager = randomEncountersManager;
            this.randomNumberGenerator = randomNumberGenerator;
            //this.playerActionFactory = new PlayerActionFactory(this.townsManager, this.playerManager, reader, writer);
			//this.randomEncountersManager = new RandomEncountersManager(this.playerManager,this.reader,this.writer);
			//this.randomNumberGenerator = new RandomNumberGenerator();
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
	                var randomNumber = this.randomNumberGenerator.GetNextNumber();
					Console.WriteLine(randomNumber);
					if (this.randomEncountersManager.RandomEncounters.ContainsKey(randomNumber))
					{
						this.randomEncountersManager.RandomEncounters[randomNumber].Invoke();
					}
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