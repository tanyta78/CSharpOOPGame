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
<<<<<<< HEAD
=======
using BackToBg.Core.Models.Quests;
using BackToBg.Core.Models.Town;
>>>>>>> cd78453d4a543777e45c5275f30c04e921ff3a6b
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
            IMap map = new Map(player, writer, reader);
            IMap map2 = new Map(player, writer, reader);

            ITown Sofia = new Town("Sofia", map, writer);
            Sofia.AddBuilding(new PoliceOffice(Sofia, 1, "Police Station", "Just a police station", 30, 15));
            foreach (var building in buildings)
            {
                Sofia.AddBuilding(building);
            }
            
            ITown Montana = new Town("Montana", map2, writer);

            var engine = new Engine(player, reader, writer, Sofia);
            engine.AddTown(Montana);
            engine.Run();
        }
    }
}