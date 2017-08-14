using BackToBg.Core.Business.Common;
using BackToBg.Core.Business.Factories;
using BackToBg.Core.Business.Managers;
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
            IPlayer player = new Player(1, 1);
            IPlayerManager playerManager = new PlayerManager(player);

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter(Constants.ConsoleHeight, Constants.ConsoleWidth);

            ITownsManager townsManager = new TownsManager();

            IMap sofiaMap = new Map(player, writer, reader);
            ITown sofia = new Town("Sofia", sofiaMap, writer);
            sofia.AddBuilding(new Banicharnitsa(1, "Banicharnica", "Topli zakuski", 10, 50, playerManager));
            sofia.AddBuilding(new PoliceOffice(townsManager, playerManager, 1, "Police Station", "Just a police station", 30, 15));
            foreach (var building in Initializer.InitializeBuildings())
            {
                sofia.AddBuilding(building);
            }

            townsManager.AddTown(sofia);
            townsManager.SetCurrentTown(sofia);


            IMap montanaMap = new Map(player, writer, reader);
            ITown montana = new Town("Montana", montanaMap, writer);

            townsManager.AddTown(montana);

            IPlayerActionFactory playerActionFactory = new PlayerActionFactory(townsManager, playerManager, reader, writer);
            IRandomEncountersManager randomEncountersManager = new RandomEncountersManager(playerManager, reader, writer);
            IRandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();

            IEngine engine = new Engine(playerManager, townsManager, reader, writer, playerActionFactory, randomEncountersManager, randomNumberGenerator);
            engine.Run();
        }
    }
}