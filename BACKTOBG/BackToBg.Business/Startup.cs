using BackToBg.Core.Business.Common;
using BackToBg.Core.Business.Factories;
using BackToBg.Core.Business.Map;
using BackToBg.Core.Business.Reader;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Business.Writer;
using BackToBg.Core.Core;
using BackToBg.Core.Models;
using BackToBg.Core.Models.Buildings.SpecialBuildings;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Quests;
using BackToBg.Core.Models.Town;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core
{
    internal class Startup
    {
        public static void Main()
        {
            var buildings = Initializer.InitializeBuildings();

            IPlayer player = new Player(4, 38);
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter(Constants.ConsoleHeight, Constants.ConsoleWidth);
            IMap map = new Map(buildings, player, writer, reader);
            ITown town = new Town(map, writer);
            town.AddBuilding(new PoliceOffice(town, 1, "Police Station", "Just a police station", 30, 15));

            var engine = new Engine(player, reader, writer, town);
            engine.Run();
        }
    }
}