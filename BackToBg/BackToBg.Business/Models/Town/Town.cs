using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Models.Town
{
    public class Town : ITown
    {
        private IMap map;
        private IWriter writer;

        public Town(string name, IMap map, IWriter writer)
        {
            this.Name = name;
            this.map = map;
            this.writer = writer;
        }

        public string Name { get; }

        public IMap Map
        {
            get => this.map;
        }

        public void RefreshQuest(IQuest quest)
        {
            this.map.GenerateMap();
        }

        public void AddBuilding(IBuilding building)
        {
            this.map.AddBuilding(building);
        }
    }
}
