using System.Text;
using BackToBg.Core.Business.Menu;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Enums;
using BackToBg.Core.Models.Items.Boots;
using BackToBg.Core.Models.Items.Weapons;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Business.Encounters
{
    public class ItemsFound
    {
        private readonly IPlayer player;
        private readonly IReader reader;
        private readonly IWriter writer;


        public ItemsFound(IPlayer player, IWriter writer, IReader reader)
        {
            this.player = player;
            this.writer = writer;
            this.reader = reader;
        }

        public void AxeFound()
        {
            var item = new Axe(1, "DragonSlayerAxe", 100, Rarity.Rare);
            this.player.Inventory.Add(item);
            this.player.Experience += 10;
            var menu = new EncounterMenu(GetMessage(item.Name), this.reader, this.writer);
            menu.StartMenu();
        }

        public void BootsFound()
        {
            var item = new Overshoe(1, "Chepicite na baba", 200, Rarity.Epic);
            this.player.Inventory.Add(item);
            this.player.Experience += 50;
            var menu = new EncounterMenu(GetMessage(item.Name), this.reader, this.writer);
            menu.StartMenu();
        }

        public void MoneyFound()
        {
            this.player.Money += Constants.FoundMoneyAmmount;
            this.player.Experience += 5;
            var menu = new EncounterMenu(Constants.FoundMoneyMsg, this.reader, this.writer);
            menu.StartMenu();
        }

        private string GetMessage(string name)
        {
            var sb = new StringBuilder();
            sb.Append("You found the super rare ");
            sb.Append(name);
            sb.Append(" - Well done!");

            return sb.ToString();
        }
    }
}