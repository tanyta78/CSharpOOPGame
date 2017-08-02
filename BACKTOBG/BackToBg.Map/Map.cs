using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Models.EntityInterfaces;
using BACKTOBG.Models;
using IDrawable = BackToBg.Business.UtilityInterfaces.IDrawable;

namespace BackToBg.Map
{
    public class Map : IMap
    {
        private static int mapSize = 200;

        private List<IBuilding> buildings;

        private IPlayer player;

        public Map(List<IBuilding> buildings, IPlayer player)
        {
            this.buildings = buildings;
            this.player = player;
        }

        public void GetMap()
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
                for (int row = x; row < x + figure.GetLength(0); row++)
                {
                    for (int col = y; col < y + figure.GetLength(1); col++)
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
            }
            map[mapSize - 1] = new string(border, mapSize).ToCharArray();

            //TODO: Center the camera
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
