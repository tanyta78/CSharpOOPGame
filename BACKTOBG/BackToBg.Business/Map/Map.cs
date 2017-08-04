﻿using System;
using System.Collections.Generic;
using BackToBg.Business.UtilityInterfaces;
using BackToBg.Models.EntityInterfaces;
using BackToBg.Business.PlayerActions;

namespace BackToBg.Business
{
    public class Map : IMap
    {
        private static readonly int mapSize = 100;
        private readonly IList<IBuilding> buildings;
        private char[][] map;
        private readonly IPlayer player;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IPlayerActionFactory playerActionFactory;

        public Map(IList<IBuilding> buildings, IPlayer player, IReader reader, IWriter writer)
        {
            this.buildings = buildings;
            this.player = player;
            this.reader = reader;
            this.writer = writer;
            GenerateMap();
            this.playerActionFactory = new PlayerActionFactory(this, this.player, this.reader, this.writer);
        }

        public IEnumerable<IBuilding> Drawables => this.buildings;

        public char[][] GetMap()
        {
            return this.map;
        }

        public void Update(ConsoleKey key)
        {
            //crucial code that throws exception
            var action = this.playerActionFactory.CreateAction(key);

            //remove the player from map
            var playerInfo = this.player.GetDrawingInfo();
            this.map[playerInfo.row][playerInfo.col] = ' ';

            try
            {
                //update the players coords
                action.Execute();
            }
            finally
            {
                //add the updated player to the map again
                playerInfo = this.player.GetDrawingInfo();
                this.map[playerInfo.row][playerInfo.col] = playerInfo.figure[0][0];
            }
        }

        public void DrawMap()
        {
            this.writer.Clear();
            var map = this.map;
            var playerInfo = this.player.GetDrawingInfo();

            var verticalCalculations = map.Length - (this.writer.ConsoleWidth - 1) -
                                       (playerInfo.col - this.writer.ConsoleWidth / 2);
            if (verticalCalculations > 0)
                verticalCalculations = 0;

            var horizontalCalculations = map.Length - (this.writer.ConsoleHeight - 1) -
                                         (playerInfo.row - this.writer.ConsoleHeight / 2);
            if (horizontalCalculations > 0)
                horizontalCalculations = 0;

            for (int row = Math.Max(0, playerInfo.row - this.writer.ConsoleHeight / 2), counter = 0;
                counter < this.writer.ConsoleHeight - 1 + horizontalCalculations;
                row++, counter++)
            {
                var line = string.Join("", map[row]);
                this.writer.WriteLine(line.Substring(Math.Max(0, playerInfo.col - this.writer.ConsoleWidth / 2),
                    this.writer.ConsoleWidth - 1 + verticalCalculations));
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

        private void GenerateMap()
        {
            //create the map array
            this.map = new char[mapSize][];
            for (var i = 0; i < mapSize; i++)
                this.map[i] = new string(' ', mapSize).ToCharArray();

            //draw all buildings
            foreach (var building in this.buildings)
            {
                var info = building.GetDrawingInfo();
                var figure = info.figure;
                var x = info.row;
                var y = info.col;
                for (var row = x; row < Math.Min(x + figure.Length, mapSize - 1); row++)
                    for (var col = y; col < Math.Min(y + figure[0].Length, mapSize - 1); col++)
                        this.map[row][col] = figure[row - x][col - y];
            }

            //draw the player
            var playerInfo = this.player.GetDrawingInfo();
            this.map[playerInfo.row][playerInfo.col] = playerInfo.figure[0][0];

            //draw the borders
            var border = '*';
            this.map[0] = new string(border, mapSize).ToCharArray();
            for (var i = 1; i < mapSize - 1; i++)
            {
                this.map[i][0] = border;
                this.map[i][this.map[0].Length - 1] = border;
            }
            this.map[mapSize - 1] = new string(border, mapSize).ToCharArray();
        }
    }
}