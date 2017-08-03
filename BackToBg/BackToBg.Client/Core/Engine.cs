using BackToBg.Business.UtilityInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using BackToBg.Business.Exceptions;
using BackToBg.Business.Map;
using BackToBg.Models.Buildings;
using BackToBg.Models.EntityInterfaces;
using BackToBg.Models;
using BackToBg.Models.Buildings.SpecialBuildings;

namespace BackToBg.Client.Core
{
    public class Engine : IEngine
    {
        private static int ConsoleHeight = 41;
        private static int ConsoleWidth = 61;

        private IPlayer player;
        private IList<IBuilding> buildings;
        private IMap map;

        public Engine()
        {
            this.player = new Player(4, 38);
        }

        public void Run()
        {
            this.PerformConsoleSetup();
            this.buildings = new List<IBuilding>();
            this.buildings.Add(new BasicBuilding(5, 26));
            this.buildings.Add(new BasicBuilding(10, 4, 2));
            this.buildings.Add(new PoliceOffice(1, "Police Station", "Just a police station", 30, 15));
            this.buildings.Add(new BasicBuilding(20, 23));

            this.map = new Map(this.buildings, player);

            while (true)
            {
                this.DrawMap();
                var key = Console.ReadKey();
                try
                {
                    map.Update(key.Key);
                }
                catch (Exception e) when (e is NotImplementedException || e is InvalidKeyPressException)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                    Thread.Sleep(750);
                    this.DrawMap();
                }
            }
        }

        private void DrawMap()
        {
            Console.Clear();
            var map = this.map.GetMap();
            var playerInfo = this.player.GetDrawingInfo();
            var drawnRows = 0;
            var drawnCols = 0;

            var verticalCalculations = (map.Length - (ConsoleWidth - 1)) - (playerInfo.col - ConsoleWidth / 2);
            if (verticalCalculations > 0)
            {
                verticalCalculations = 0;
            }

            var horizontalCalculations = (map.Length - (ConsoleHeight - 1)) - (playerInfo.row - ConsoleHeight / 2);
            if (horizontalCalculations > 0)
            {
                horizontalCalculations = 0;
            }

            for (int row = Math.Max(0, playerInfo.row - ConsoleHeight / 2), counter = 0; counter < (ConsoleHeight - 1 + horizontalCalculations); row++, counter++)
            {
                var line = string.Join("", map[row]);
                Console.WriteLine(line.Substring(Math.Max(0, playerInfo.col - ConsoleWidth / 2), ConsoleWidth - 1 + verticalCalculations));
            }

            //for (int i = playerInfo.row - ConsoleHeight / 2; i < playerInfo.row; i++)
            //{
            //    if (i >= 0 && i < map.Length)
            //    {
            //        var line = string.Join("", map[i]);
            //        Console.WriteLine(line.Substring(Math.Max(0, playerInfo.col - ConsoleWidth / 2), ConsoleWidth - 1 + verticalCalculations));
            //        drawnRows++;
            //    }
            //}

            //var remainder = drawnRows - ConsoleHeight / 2 + 1;

            //for (int i = playerInfo.row; i <= playerInfo.row + ConsoleHeight / 2 - remainder; i++)
            //{
            //    if (i >= 0 && i < map.Length)
            //    {
            //        var line = string.Join("", map[i]);
            //        Console.WriteLine(line.Substring(Math.Max(0, playerInfo.col - ConsoleWidth / 2), ConsoleWidth - 1 + verticalCalculations));
            //        drawnRows++;
            //    }
            //}

        }

        private void PerformConsoleSetup()
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.Unicode;
            Console.WindowHeight = ConsoleHeight;
            Console.WindowWidth = ConsoleWidth;
            Console.BufferHeight = ConsoleHeight;
            Console.BufferWidth = ConsoleWidth;
        }
    }
}