using System.Collections.Generic;
using BackToBg.Core.Business.Common;
using BackToBg.Core.Business.Factories;
using BackToBg.Core.Business.IO.Reader;
using BackToBg.Core.Business.IO.Writer;
using BackToBg.Core.Business.Managers;
using BackToBg.Core.Business.Map;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Core;
using BackToBg.Core.Models;
using BackToBg.Core.Models.Buildings;
using BackToBg.Core.Models.Buildings.SpecialBuildings;
using BackToBg.Core.Models.Buildings.SpecialBuildings.Shops;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Enums;
using BackToBg.Core.Models.Items.Books;
using BackToBg.Core.Models.Items.Boots;
using BackToBg.Core.Models.Items.Weapons;
using BackToBg.Core.Models.Town;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core
{
    internal class Startup
    {
        public static void Main()
        {
            //IO
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter(Constants.ConsoleHeight, Constants.ConsoleWidth);

            //player
            IPlayer player = new Player("Pesho")
            {
                Inventory = new List<IItem>
                {
                    new Axe(1, "Cepeni4kata", 99, Rarity.Common),
                    new Hammer(2, "Za dinozavrite", 15, Rarity.Epic),
                    new Sword(3, "Me4a na Ahil", 15, Rarity.Epic),
                    new Booklet(4, "Priklu4eniq", 15, Rarity.Epic),
                    new Sneaker(5, "Adidas", 15, Rarity.Epic),
                    new Sneaker(6, "Nike", 15, Rarity.Epic),
                    new Sneaker(7, "Reebok", 15, Rarity.Epic),
                    new Sneaker(8, "Puma", 15, Rarity.Epic),
                    new Sneaker(9, "Guma", 15, Rarity.Epic)
                }
            };

            //MANAGERS AND UTILITIES
            IRandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();
            ICustomEventHandler handler = new CustomEventHandler(writer);
            IPlayerManager playerManager = new PlayerManager(player);
            ITownsManager townsManager = new TownsManager();
            IRandomEncountersManager randomEncountersManager =
                new RandomEncountersManager(playerManager, reader, writer);
            IPlayerActionFactory playerActionFactory =
                new PlayerActionFactory(townsManager, playerManager, reader, writer);

            //SOFIA
            IMap sofiaMap = new Map(player, writer);
            ITown sofia = new Town("Sofia", sofiaMap, writer);
            sofia.AddBuilding(new Banicharnitsa(1, "Banicharnica", "Topli zakuski", 10, 50, playerManager));
            sofia.AddBuilding(new PoliceOffice(townsManager, playerManager, randomNumberGenerator, 1, "Police Station",
                "Just a police station", 30, 15, handler));
            IBuilding mall = new MallShop(playerManager, 1, "Mall of Sofia", null, 30, 50)
            {
                Inventory = new List<IItem>
                {
                    new Primer(10, "Primer", 55, Rarity.Epic),
                    new Overshoe(11, "Obushta", 60, Rarity.Epic)
                }
            };
            sofia.AddBuilding(mall);
            foreach (var building in Initializer.InitializeBuildings())
                sofia.AddBuilding(building);
            townsManager.AddTown(sofia);
            townsManager.SetCurrentTown(sofia);

            //MONTANA
            IMap montanaMap = new Map(player, writer);
            ITown montana = new Town("Montana", montanaMap, writer);
            montana.AddBuilding(new BasicBuilding(10, 10, 3));
            townsManager.AddTown(montana);

            //ENGINE
            IEngine engine = new Engine(playerManager, townsManager, reader, writer, playerActionFactory,
                randomEncountersManager, randomNumberGenerator);
            engine.Run();
        }
    }
}