using System.Collections.Generic;
using BackToBg.Core.Business.UtilityInterfaces;

namespace BackToBg.Core.Business.Managers
{
    public class TownsManager : ITownsManager
    {
        private readonly IList<ITown> towns;

        public TownsManager()
        {
            this.towns = new List<ITown>();
        }

        public ITown Town { get; private set; }

        public IReadOnlyCollection<ITown> Towns => (IReadOnlyCollection<ITown>) this.towns;

        public ITown GetCurrentTown()
        {
            return this.Town;
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
            this.Town = newTown;
            this.Town.Map.GenerateMap();
        }
    }
}