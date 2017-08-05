using BackToBg.Business;
using BackToBg.Business.Common;
using BackToBg.Business.PlayerActions;
using BackToBg.Business.Reader;
using BackToBg.Business.UtilityInterfaces;
using BackToBg.Business.Writer;
using BackToBg.Client.Core;
using BackToBg.Models;
using BackToBg.Models.Buildings.SpecialBuildings;
using BackToBg.Models.EntityInterfaces;
using BackToBg.Models.Utilities;

namespace BackToBg.Client
{
    internal class Startup
    {
        public static void Main()
        {
            var buildings = Initializer.InitializeBuildings();

            IPlayer player = new Player(4, 38);
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter(Constants.ConsoleHeight, Constants.ConsoleWidth);
            IMap map = new Map(buildings, player, reader, writer);
            map.AddBuilding(new PoliceOffice(map, 1, "Police Station", "Just a police station", 30, 15));

            var engine = new Engine(player, reader, writer, map);
            engine.Run();
        }
    }
}