using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Client.Core;
using BackToBg.Models.EntityInterfaces;
using BACKTOBG.Models;

namespace BackToBg.Map
{
    public class Map : IMap
    {
        private static int mapSize = 30;
        private char[][] map;
        private IList<IBuilding> buildings;
        private IPlayer player;
        private PlayerActionFactory playerActionFactory;

        public Map(IList<IBuilding> buildings, IPlayer player)
        {
            this.buildings = buildings;
            this.player = player;
            this.playerActionFactory = new PlayerActionFactory(this, this.player);
            this.GenerateMap();
        }

        private void GenerateMap()
        {
            //create the map array
            this.map = new char[mapSize][];
            for (int i = 0; i < mapSize; i++)
            {
                this.map[i] = new string(' ', mapSize).ToCharArray();
            }

            //draw all buildings
            foreach (var building in this.buildings)
            {
                var info = building.GetDrawingInfo();
                var figure = info.figure;
                var x = info.x;
                var y = info.y;
                for (int row = x; row < Math.Min(x + figure.Length, mapSize - 1); row++)
                {
                    for (int col = y; col < Math.Min(y + figure[0].Length, mapSize - 1); col++)
                    {
                        this.map[row][col] = figure[row - x][col - y];
                    }
                }
            }

            //draw the player
            var playerInfo = this.player.GetDrawingInfo();
            this.map[playerInfo.x][playerInfo.y] = playerInfo.figure[0][0];

            //draw the borders
            var border = '*';
            this.map[0] = new string(border, mapSize).ToCharArray();
            for (int i = 1; i < mapSize - 1; i++)
            {
                this.map[i][0] = border;
                this.map[i][this.map[0].Length - 1] = border;
            }
            this.map[mapSize - 1] = new string(border, mapSize).ToCharArray();

            //TODO: Center the camera
        }

        public char[][] GetMap()
        {
            return this.map;
        }

        public void Update(ConsoleKey key)
        {
            //remove the player from map
            var playerInfo = this.player.GetDrawingInfo();
            this.map[playerInfo.x][playerInfo.y] = ' ';

            //update the players coords
            var movement = this.playerActionFactory.CreateAction(key);
            movement.Execute();

            //add the updated player to the map again
            playerInfo = this.player.GetDrawingInfo();
            this.map[playerInfo.x][playerInfo.y] = playerInfo.figure[0][0];
        }
    }
}
