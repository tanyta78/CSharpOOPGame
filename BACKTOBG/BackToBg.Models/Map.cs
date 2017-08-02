using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Models.EntityInterfaces;
using BACKTOBG.Models;

namespace BackToBg.Map
{
    public class Map : IMap
    {
        private static int mapSize = 30;

        private List<IBuilding> buildings;

        private IPlayer player;

        public Map(List<IBuilding> buildings, IPlayer player)
        {
            this.buildings = buildings;
            this.player = player;
        }

        public char[][] GetMap()
        {
            //create the map array
            var map = new char[mapSize][];
            for (int i = 0; i < mapSize; i++)
            {
                map[i] = new char[mapSize];
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
                        map[row][col] = figure[row - x][col - y];
                    }
                }
            }

            //draw the player
            var playerInfo = this.player.GetDrawingInfo();
            map[playerInfo.x][playerInfo.y] = playerInfo.figure[0][0];

            //draw the borders
            var border = '*';
            map[0] = new string(border, mapSize).ToCharArray();
            for (int i = 1; i < mapSize - 1; i++)
            {
                map[i][0] = border;
                map[i][map[0].Length - 1] = border;
            }
            map[mapSize - 1] = new string(border, mapSize).ToCharArray();

            //TODO: Center the camera

            return map;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
