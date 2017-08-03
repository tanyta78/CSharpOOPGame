using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BACKTOBG.Models;

namespace BackToBg.Business.PlayerActions.Actions
{
    public class InteractAction : PlayerAction
    {
        public InteractAction(IPlayer player, char[][] map) : base(player, map)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException($"{this.GetType().Name} not implemented yet!");
        }
    }
}
