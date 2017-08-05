using System;
using System.Collections.Generic;
using BackToBg.Core.Business.Attributes;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.PlayerActions.Actions
{
    [PlayerAction("Enter")]
    public class PunchAction : PlayerAction
    {
        [Inject] private readonly IMap map;

        [Inject] private readonly IPlayer player;

        public override void Execute()
        {
            var playerInfo = this.player.GetDrawingInfo();
            foreach (var punchable in this.GetAdjacentPunchables())
            {
                this.player.Attack(punchable);
            }
        }

        private IEnumerable<IPunchable> GetAdjacentPunchables()
        {
            var playerInfo = this.player.GetDrawingInfo();
            var punchables = new List<IPunchable>();
            foreach (var punchable in this.map.Punchables)
            {
                var punchableInfo = punchable.GetDrawingInfo();
                if (Math.Abs(punchableInfo.row - playerInfo.row) <= 1 && Math.Abs(punchableInfo.col - playerInfo.col) <= 1)
                {
                    punchables.Add(punchable);
                }
            }

            return punchables;
        }
    }
}
