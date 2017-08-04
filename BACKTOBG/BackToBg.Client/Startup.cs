using BackToBg.Business.Common;
using BackToBg.Business.Reader;
using BackToBg.Business.UtilityInterfaces;
using BackToBg.Business.Writer;
using BackToBg.Client.Core;
using BackToBg.Models;
using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Client
{
    internal class Startup
    {
        public static void Main()
        {
            IPlayer player = new Player(4, 38);
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter(Constants.ConsoleHeight, Constants.ConsoleWidth);

            var engine = new Engine(player, reader, writer);
            engine.Run();
        }
    }
}