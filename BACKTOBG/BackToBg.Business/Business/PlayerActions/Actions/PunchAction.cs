using System;
using System.Collections.Generic;
using BackToBg.Business.Attributes;
using BackToBg.Business.Models.EntityInterfaces;
using BackToBg.Business.PlayerActions.Actions;
using BackToBg.Business.UtilityInterfaces;
using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Business.Business.PlayerActions.Actions
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
