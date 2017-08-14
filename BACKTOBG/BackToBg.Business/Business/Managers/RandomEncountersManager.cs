using System;
using System.Collections.Generic;
using BackToBg.Core.Business.Encounters;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.Managers
{
	public class RandomEncountersManager: IRandomEncountersManager
	{
		private IDictionary<int, Action> randomEncounters;
		private IPlayerManager playerManager;
		private IReader reader;
		private IWriter writer;

		public RandomEncountersManager(IPlayerManager playerManager, IReader reader, IWriter writer)
		{
			this.writer = writer;
			this.reader = reader;
			this.playerManager = playerManager;
			this.randomEncounters = new Dictionary<int, Action>();
			this.PopulateEncounters();
		}

		private void PopulateEncounters()
		{
			this.randomEncounters.Add(5, new Injures(this.playerManager.Player, this.writer,this.reader).FallingBranch);
			this.randomEncounters.Add(6, new Injures(this.playerManager.Player, this.writer, this.reader).BrokenLeg);
			this.randomEncounters.Add(8, new ItemsFound(this.playerManager.Player, this.writer, this.reader).AxeFound);
			this.randomEncounters.Add(7, new ItemsFound(this.playerManager.Player, this.writer, this.reader).BootsFound);
		}

		public IDictionary<int, Action> RandomEncounters
		{
			get { return this.randomEncounters; }
		}
	}
}
