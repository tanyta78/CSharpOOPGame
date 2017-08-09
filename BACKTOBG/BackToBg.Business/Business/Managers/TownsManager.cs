using System.Collections.Generic;
using BackToBg.Core.Business.UtilityInterfaces;

namespace BackToBg.Core.Business.Managers
{
    public class TownsManager : ITownsManager
    {
        private IList<ITown> towns;
        private ITown town;

        public TownsManager()
        {
            this.towns = new List<ITown>();
        }

        public ITown Town
        {
            get { return this.town; }
        }

        public IReadOnlyCollection<ITown> Towns
        {
            get { return (IReadOnlyCollection<ITown>)this.towns; }
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
        }
    }
}
