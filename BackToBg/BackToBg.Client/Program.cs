using System;
using BackToBg.Client.Core;
using BackToBg.Models.Buildings;

namespace BackToBg.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var building = new BasicBuilding(0, 0, 2);
            Console.WriteLine(string.Join(Environment.NewLine, building.GetDrawingInfo().figure));
            //Engine engine = new Engine();
            //engine.Run();
        }
    }
}