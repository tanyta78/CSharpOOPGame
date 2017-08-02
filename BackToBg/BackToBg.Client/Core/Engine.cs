using BackToBg.Business.UtilityInterfaces;
using System;
using System.Collections.Generic;
using BackToBg.Models.Buildings;
using BackToBg.Models.EntityInterfaces;
using BackToBg.Map;
using BackToBg.Models;
using BACKTOBG.Models;

namespace BackToBg.Client.Core
{
    public class Engine : IEngine
    {
        private static int ConsoleHeight = 40;
        private static int ConsoleWidth = 100;
        
        private IPlayer player;
        private IList<IBuilding> buildings;
        private IMap map;

        public Engine()
        {
            this.player = new Player(3, 3);
        }

        public void Run()
        {
            this.PerformConsoleSetup();
            this.buildings = new List<IBuilding>();
            this.buildings.Add(new BasicBuilding(5, 26));
            this.buildings.Add(new BasicBuilding(10, 4, 2));
            this.buildings.Add(new BasicBuilding(13, 15));
            this.buildings.Add(new BasicBuilding(20, 23));
            
            this.map = new Map.Map(this.buildings, player);
            
            while (true)
            {
                this.DrawMap();
                var key = Console.ReadKey();
                map.Update(key.Key);
            }
        }

        private void DrawMap()
        {
            Console.Clear();
            foreach (char[] arr in map.GetMap())
            {
                Console.WriteLine(arr);
            }
        }

        private void PerformConsoleSetup()
        {
            Console.BufferHeight = ConsoleHeight;
            Console.BufferWidth = ConsoleWidth;
            Console.WindowHeight = ConsoleHeight;
            Console.WindowWidth = ConsoleWidth;
        }
    }
}