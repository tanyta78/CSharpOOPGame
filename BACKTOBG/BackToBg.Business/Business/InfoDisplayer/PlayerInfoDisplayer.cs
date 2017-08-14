using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.InfoDisplayer
{
    public class PlayerInfoDisplayer : InfoDisplayer
    {
        private IPlayer player;

        public PlayerInfoDisplayer(IReader reader, IWriter writer, IPlayer player) : base(reader, writer)
        {
            this.player = player;
        }

        protected override IList<string> Info => this.GenerateInfo();

        private IList<string> GenerateInfo()
        {
            var info = new List<string>();
            info.Add($"HP: {this.player.CurrentHitPoints}");
            info.Add($"Stamina: {this.player.Stamina}");
            info.Add($"Money: {this.player.Money}");
            info.Add($"Experience: {this.player.Experience}");
            info.Add($"Items:");
            foreach (var item in this.player.Inventory)
            {
                info.Add($"{item.Name}");
            }
            return info;
        }
    }
}
