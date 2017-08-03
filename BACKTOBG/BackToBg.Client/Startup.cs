using BackToBg.Client.Core;
using BackToBg.Models;
using BackToBg.Models.EntityInterfaces;
using BackToBg.Business.UtilityInterfaces;
using BackToBg.Business.Reader;
using BackToBg.Business.Writer;
using BackToBg.Business.Common;

namespace BackToBg.Client
{
    internal class Startup
    {
        public static void Main()
        {
            IPlayer player = new Player(4, 38);
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter(Constants.ConsoleHeight, Constants.ConsoleWidth);

            Engine engine = new Engine(player, reader, writer);
            engine.Run();
        }
    }
}