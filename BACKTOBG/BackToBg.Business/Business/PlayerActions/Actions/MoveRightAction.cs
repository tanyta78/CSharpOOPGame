﻿using BackToBg.Core.Business.Attributes;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Utilities;
using Colorful;

namespace BackToBg.Core.Business.PlayerActions.Actions
{
    [PlayerAction("RightArrow")]
    public class MoveRightAction : PlayerAction
    {
        [Inject] private readonly IMap map;

        [Inject] private readonly IPlayer player;

        public override void Execute()
        {
            Console.WriteLine(this.player.Stamina);
            var info = this.player.GetDrawingInfo();
            var x = info.row;
            var y = info.col;
            if (this.map.GetMap()[x][y + 1] == Constants.RoadChar)
                this.player.MoveEast();
        }
    }
}