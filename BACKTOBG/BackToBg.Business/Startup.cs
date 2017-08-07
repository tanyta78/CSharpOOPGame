using BackToBg.Core.Business.Common;
using BackToBg.Core.Business.Factories;
using BackToBg.Core.Business.Map;
using BackToBg.Core.Business.Reader;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Business.Writer;
using BackToBg.Core.Core;
using BackToBg.Core.Models;
using BackToBg.Core.Models.Buildings.SpecialBuildings;
using BackToBg.Core.Models.Buildings.SpecialBuildings.Shops;
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

            IPlayer player = new Player(1, 1);
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter(Constants.ConsoleHeight, Constants.ConsoleWidth);

            var engine = new Engine(player, reader, writer);

            IMap sofiaMap = new Map(player, writer, reader);
            ITown sofia = new Town("Sofia", sofiaMap, writer);
			sofia.AddBuilding(new Banicharnitsa(1, "Banicharnitsa", "Topli zakuski", 10, 50));
            sofia.AddBuilding(new PoliceOffice(engine, 1, "Police Station", "Just a police station", 30, 15));
            foreach (var building in buildings)
            {
                sofia.AddBuilding(building);
            }

            engine.AddTown(sofia);
            engine.SetCurrentTown(sofia);

            IMap montanaMap = new Map(player, writer, reader);
            ITown montana = new Town("Montana", montanaMap, writer);
            
            engine.AddTown(montana);
            
            engine.Run();
        }
    }
}