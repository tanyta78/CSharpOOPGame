using System;
using System.Collections.Generic;
using System.Linq;
using BackToBg.Core.Business.Factories;
using BackToBg.Core.Business.PlayerActions;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Business.Map
{
    public class Map : IMap
    {
        private readonly int mapSize = Constants.DefaultMapSize;
        private readonly IList<IBuilding> buildings;
        private readonly IList<IPunchable> punchables;
        private char[][] map;
        private readonly IPlayer player;
        private IWriter writer;

        public Map(IPlayer player, IWriter writer)
        {
            this.punchables = new List<IPunchable>();
            this.buildings = new List<IBuilding>();
            this.writer = writer;
            this.player = player;
            this.GenerateMap();
        }

        public IEnumerable<IBuilding> Drawables => this.buildings;

        public IEnumerable<IPunchable> Punchables => this.punchables;

        public int Size => this.mapSize;

        public char[][] GetMap()
        {
            return this.map;
        }

        //public void Update(IPlayerAction action)
        //{
        //    //remove the player from map
        //    var playerInfo = this.player.GetDrawingInfo();
        //    this.map[playerInfo.row][playerInfo.col] = Constants.RoadChar;

        //    try
        //    {
        //        //update the players coords
        //        action.Execute();
        //    }
        //    finally
        //    {
        //        //add the updated player to the map again
        //        playerInfo = this.player.GetDrawingInfo();
        //        this.map[playerInfo.row][playerInfo.col] = playerInfo.figure[0][0];
        //    }                   
        //}

        public void DrawMap()
        {
            this.writer.Clear();
            var map = this.map;
            var playerInfo = this.player.GetDrawingInfo();
            var consoleWidth = this.writer.ConsoleWidth;
            var consoleHeight = this.writer.ConsoleHeight;


            //some stupid math for the drawing. only god knows why it works.
            var verticalCalculations = map.Length - (consoleWidth - 1) -
                                       (playerInfo.col - consoleWidth / 2);
            if (verticalCalculations > 0)
                verticalCalculations = 0;

            var horizontalCalculations = map.Length - (consoleHeight - 1) -
                                         (playerInfo.row - consoleHeight / 2);
            if (horizontalCalculations > 0)
                horizontalCalculations = 0;

            var counter = 0;
            if (horizontalCalculations == 0)
            {
                counter = 1;
            }

            //drawing
            this.writer.WriteLine($"Player: HP:{this.player.CurrentHitPoints} Stamina:{this.player.Stamina}");
            for (int row = Math.Max(0, playerInfo.row - consoleHeight / 2);
                counter < this.writer.ConsoleHeight - 1 + horizontalCalculations;
                row++, counter++)
            {
                var line = string.Join("", map[row]);
                this.writer.WriteLine(line.Substring(Math.Max(0, playerInfo.col - consoleWidth / 2),
                    consoleWidth - 1 + verticalCalculations));
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

        public void AddPunchable(IPunchable punchable)
        {
            this.punchables.Add(punchable);
            this.GenerateMap();
        }

        public void RemovePunchable(IPunchable punchable)
        {
            this.punchables.Remove(punchable);
            this.GenerateMap();
        }

        public void AddBuilding(IBuilding building)
        {
            this.buildings.Add(building);
            this.GenerateMap();
        }

        public bool CanSpawnEntityInSpot(int row, int col)
        {
            //check if it tries to spawn in a building
            foreach (var building in this.buildings)
            {
                var buildingInfo = building.GetDrawingInfo();
                var rowCheck = buildingInfo.row <= row && buildingInfo.row + buildingInfo.figure.Length > row;
                var colCheck = buildingInfo.col <= col && buildingInfo.col + buildingInfo.figure[0].Length > col;
                if (rowCheck && colCheck)
                {
                    return false;
                }
            }

            //check if it tries to spawn on another entity
            //foreach (var drawable in this.Drawables)
            //{
            //    if (drawable.GetDrawingInfo().row == row && drawable.GetDrawingInfo().col == col)
            //    {
            //        return true;
            //    }
            //}

            return true;
        }

        public void GenerateMap()
        {
            //create the map array
            this.map = new char[this.mapSize][];
            for (var i = 0; i < this.mapSize; i++)
                this.map[i] = new string(Constants.RoadChar, this.mapSize).ToCharArray();

            //draw all buildings
            foreach (var building in this.buildings)
            {
                var info = building.GetDrawingInfo();
                var figure = info.figure;
                var x = info.row;
                var y = info.col;
                for (var row = x; row < Math.Min(x + figure.Length, this.mapSize - 1); row++)
                    for (var col = y; col < Math.Min(y + figure[0].Length, this.mapSize - 1); col++)
                        this.map[row][col] = figure[row - x][col - y];
            }

            //draw all creatures
            foreach (var creature in this.punchables.Where(p => !p.IsDead()))
            {
                var info = creature.GetDrawingInfo();
                var figure = info.figure;
                var x = info.row;
                var y = info.col;
                for (var row = x; row < Math.Min(x + figure.Length, this.mapSize - 1); row++)
                    for (var col = y; col < Math.Min(y + figure[0].Length, this.mapSize - 1); col++)
                        this.map[row][col] = figure[row - x][col - y];
            }

            //draw the player
            var playerInfo = this.player.GetDrawingInfo();
            this.map[playerInfo.row][playerInfo.col] = playerInfo.figure[0][0];

            //draw the borders
            var border = Constants.BasicBuildingBorder;
            this.map[0] = new string(border, this.mapSize).ToCharArray();
            for (var i = 1; i < this.mapSize - 1; i++)
            {
                this.map[i][0] = border;
                this.map[i][this.map[0].Length - 1] = border;
            }
            this.map[this.mapSize - 1] = new string(border, this.mapSize).ToCharArray();
        }
    }
}