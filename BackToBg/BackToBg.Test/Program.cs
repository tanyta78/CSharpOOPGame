using System;
using System.Collections.Generic;
using BackToBg.Core.Business.Managers;
using BackToBg.Core.Business.Reader;
using BackToBg.Core.Business.Writer;
using BackToBg.Core.Models;
using BackToBg.Core.Models.Buildings.SpecialBuildings.Shops;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Enums;
using BackToBg.Core.Models.Items.Books;
using BackToBg.Core.Models.Items.Boots;
using BackToBg.Core.Models.Items.Weapons;
using BackToBg.Core.Models.Utilities;
using BackToBg.Core.Models.Utility_Models;
using BackToBg.Core.Models.Utility_Models.TradeDialogs;

namespace BackToBg.Test
{
    class Program
    {
        static void Main(string[] args)
        {
//			var writer = new ConsoleWriter(50,50);
//			var reader = new ConsoleReader();
//			Player pesho = new Player("Pesho");
//			var manager = new PlayerManager(pesho);
//			var enc = new RandomEncountersManager(manager,reader,writer);
//			enc.RandomEncounters[5].Invoke();

            SLTest test1 = new SLTest();
            test1.Execute();
        }
    }
}