using System;
using System.Collections.Generic;
using BackToBg.Core.Business.Encounters;
using BackToBg.Core.Business.UtilityInterfaces;

namespace BackToBg.Core.Business.Managers
{
    public class RandomEncountersManager : IRandomEncountersManager
    {
        private readonly IPlayerManager playerManager;
        private readonly IReader reader;
        private readonly IWriter writer;

        public RandomEncountersManager(IPlayerManager playerManager, IReader reader, IWriter writer)
        {
            this.writer = writer;
            this.reader = reader;
            this.playerManager = playerManager;
            this.RandomEncounters = new Dictionary<int, Action>();
            PopulateEncounters();
        }

        public IDictionary<int, Action> RandomEncounters { get; }

        private void PopulateEncounters()
        {
            this.RandomEncounters.Add(5,
                new Injures(this.playerManager.Player, this.writer, this.reader).FallingBranch);
            this.RandomEncounters.Add(6, new Injures(this.playerManager.Player, this.writer, this.reader).BrokenLeg);
            this.RandomEncounters.Add(8, new ItemsFound(this.playerManager.Player, this.writer, this.reader).AxeFound);
            this.RandomEncounters.Add(7,
                new ItemsFound(this.playerManager.Player, this.writer, this.reader).BootsFound);
        }
    }
}