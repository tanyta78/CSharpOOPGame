using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Core.Business.Attributes;
using BackToBg.Core.Business.Menu;
using BackToBg.Core.Business.Reader;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Business.Writer;
using BackToBg.Core.Models.Utilities;
using BackToBg.Core.Models.Utility_Models;
using BackToBg.Core.Models.Utility_Models.TradeDialogs;

namespace BackToBg.Core.Models.Buildings.SpecialBuildings.Shops
{
	public class Banicharnitsa : Shop
	{
		[Inject] private IReader reader = new ConsoleReader();
		[Inject] private IWriter writer = new ConsoleWriter(Constants.ConsoleHeight, Constants.ConsoleWidth);
		
		public Banicharnitsa(int id, string name, string description, int x, int y, int sizeFactor = 1)
			: base(id, name, description, x, y, sizeFactor)
		{

		}

		public override (int row, int col, string[] figure) GetDrawingInfo()
		{
			return (this.x, this.y, this.GetFigure());
		}

		private string[] GetFigure()
		{
			var figure = new string[6];

			figure[0] = "********";
			figure[1] = "*      *";
			figure[2] = "* Bani *";
			figure[3] = "* tsi  *";
			figure[4] = "*      *";
			figure[5] = "********";

			return figure;
		}
		public override void Interact()
		{
			var menu = new BuyMenu("Banicharnitsa",this.reader,this.writer);
			menu.StartMenu();
		}
	}
}
