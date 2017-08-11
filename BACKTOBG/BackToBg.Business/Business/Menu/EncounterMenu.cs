using System;
using System.Collections.Generic;
using BackToBg.Core.Business.UtilityInterfaces;

namespace BackToBg.Core.Business.Menu
{
	public class EncounterMenu:Menu
	{
		private IReader reader;
		private IWriter writer;
		private string name;

		public EncounterMenu(string name, IReader reader, IWriter writer) : base(name, reader, writer)
		{

		}
		protected override IDictionary<int, Action> Actions => new Dictionary<int, Action>
		{
			{0, () => ShouldBeRunning = false},
			{1, () => { ShouldBeRunning = false; }
			}
		};
		protected override IList<string> MenuText => new List<string>
		{
			"Ok",
			//"Story of my live"
		};
	}
}
