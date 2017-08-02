using BackToBg.Business.UtilityInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BACKTOBG.Models;

namespace BackToBg.Map
{
    public class Map : IMap
    {
        private List<IDrawable> entities;

        private IPlayer player;

        public Map(List<IDrawable> entities, IPlayer player)
        {
            this.entities = entities;
            this.player = player;
        }

        public void GetMap()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
