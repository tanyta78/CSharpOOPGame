using BackToBg.Business.UtilityInterfaces;
using System;
using System.Collections.Generic;
using BackToBg.Models.Buildings;
using BackToBg.Models.EntityInterfaces;
using BackToBg.Map;
using BackToBg.Models;

namespace BackToBg.Client.Core
{
    public class Engine : IEngine
    {
        private static int ConsoleHeight = 40;
        private static int ConsoleWidth = 100;

        private void PerformConsoleSetup()
        {
            Console.BufferHeight = ConsoleHeight;
            Console.BufferWidth = ConsoleWidth;
            Console.WindowHeight = ConsoleHeight;
            Console.WindowWidth = ConsoleWidth;
        }

        public void Run()
        {
            this.PerformConsoleSetup();
            var buildings = new List<IBuilding>();
            buildings.Add(new BasicBuilding(5, 26));
            buildings.Add(new BasicBuilding(10, 4));
            //buildings.Add(new BasicBuilding(7, 6));
            var player = new Player(3, 3);
            var map = new Map.Map(buildings, player);
            foreach (char[] arr in map.GetMap())
            {
                Console.WriteLine(arr);
            }
        }
    }
}