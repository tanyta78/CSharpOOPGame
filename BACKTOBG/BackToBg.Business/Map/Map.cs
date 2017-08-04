using System;
using System.Collections.Generic;
using BackToBg.Business.PlayerActions;
using BackToBg.Business.UtilityInterfaces;
using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Business
{
    public class Map : IMap
    {
        private static readonly int mapSize = 100;
        private readonly IList<IBuilding> buildings;
        private char[][] map;
        private readonly IPlayer player;
        private readonly PlayerActionFactory playerActionFactory;

        public Map(IList<IBuilding> buildings, IPlayer player)
        {
            this.buildings = buildings;
            this.player = player;
            GenerateMap();
            this.playerActionFactory = new PlayerActionFactory(this, this.player);
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