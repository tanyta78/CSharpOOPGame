using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Models.Town
{
    public class Town : ITown
    {
        private IWriter writer;

        public Town(string name, IMap map, IWriter writer)
        {
            this.Name = name;
            this.Map = map;
            this.writer = writer;
        }

        public string Name { get; }

        public IMap Map { get; }

        public void RefreshQuest(IQuest quest)
        {
            this.Map.GenerateMap();
        }

        public void AddBuilding(IBuilding building)
        {
            this.Map.AddBuilding(building);
        }
    }
}