using BackToBg.Business.UtilityInterfaces;
using System;
using System.Collections.Generic;
using BackToBg.Business.Exceptions;
using BackToBg.Business;
using BackToBg.Models.Buildings;
using BackToBg.Models.EntityInterfaces;
using BackToBg.Models.Buildings.SpecialBuildings;

namespace BackToBg.Client.Core
{
    public class Engine : IEngine
    {
        private IPlayer player;
        private IList<IBuilding> buildings;
        private IMap map;
        private IReader reader;
        private IWriter writer;

        public Engine(IPlayer player, IReader reader, IWriter writer)
        {
            this.player = player;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            this.InitializeBuildings();
            this.map = new Map(this.buildings, this.player);

            while (true)
            {
                this.DrawMap();
                var key = this.reader.ReadKey();
                try
                {
                    map.Update(key.Key);
                }
                catch (Exception e) when (e is NotImplementedException || e is InvalidActionException || e is NotSupportedException)
                {
                    this.writer.DisplayException(e.Message);
                    this.DrawMap();
                }
            }
        }

        private void InitializeBuildings()
        {
            this.buildings = new List<IBuilding>();
            this.buildings.Add(new BasicBuilding(5, 26));
            this.buildings.Add(new BasicBuilding(10, 4, 2));
            this.buildings.Add(new PoliceOffice(1, "Police Station", "Just a police station", 30, 15));
            this.buildings.Add(new BasicBuilding(20, 23));
        }

        private void DrawMap()
        {
            this.writer.Clear();
            var map = this.map.GetMap();
            var playerInfo = this.player.GetDrawingInfo();

            var verticalCalculations = (map.Length - (this.writer.ConsoleWidth - 1)) - (playerInfo.col - this.writer.ConsoleWidth / 2);
            if (verticalCalculations > 0)
            {
                verticalCalculations = 0;
            }

            var horizontalCalculations = (map.Length - (this.writer.ConsoleHeight - 1)) - (playerInfo.row - this.writer.ConsoleHeight / 2);
            if (horizontalCalculations > 0)
            {
                horizontalCalculations = 0;
            }

            for (int row = Math.Max(0, playerInfo.row - this.writer.ConsoleHeight / 2), counter = 0; counter < (this.writer.ConsoleHeight - 1 + horizontalCalculations); row++, counter++)
            {
                var line = string.Join("", map[row]);
                this.writer.WriteLine(line.Substring(Math.Max(0, playerInfo.col - this.writer.ConsoleWidth / 2), this.writer.ConsoleWidth - 1 + verticalCalculations));
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
    }
}