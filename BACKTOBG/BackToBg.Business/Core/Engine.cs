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
        private IList<ITown> towns;
        private ITown town;
        private readonly IPlayer player;
        private readonly IReader reader;
        private readonly IWriter writer;
        private IPlayerActionFactory playerActionFactory;

        public Engine(IPlayer player, IReader reader, IWriter writer, ITown town)
        {
            this.player = player;
            this.reader = reader;
            this.writer = writer;
            this.town = town;
            this.towns = new List<ITown>() { town };
            this.playerActionFactory = new PlayerActionFactory(this, this.player, this.reader, this.writer);
        }

        public ITown Town
        {
            get { return this.town; }
        }

        public IReadOnlyCollection<ITown> Towns
        {
            get { return (IReadOnlyCollection<ITown>)this.towns; }
        }


        public void Run()
        {
            while (true)
            {
                this.Town.Map.DrawMap();
                var key = this.reader.ReadKey();
                try
                {
                    var action = this.playerActionFactory.CreateAction(key.Key);
                    action.Execute();
                    this.town.Map.GenerateMap();
                    //this.Town.Map.Update(action);
                }
                catch (Exception e)
                    when (e is NotImplementedException || e is InvalidActionException || e is NotSupportedException)
                {
                    this.writer.DisplayException(e.Message);
                    this.Town.Map.DrawMap();
                }
            }
        }

        public ITown GetCurrentTown()
        {
            return this.town;
        }

        public IList<ITown> GetTowns()
        {
            return this.towns;
        }

        public void AddTown(ITown newTown)
        {
            this.towns.Add(newTown);
        }

        public void SetCurrentTown(ITown newTown)
        {
            this.town = newTown;
            this.town.Map.GenerateMap();
            this.player.ResetPosition();
        }
    }
}