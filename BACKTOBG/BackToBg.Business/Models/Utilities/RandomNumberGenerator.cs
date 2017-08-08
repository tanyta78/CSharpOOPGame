using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToBg.Core.Models.Utilities
{
	public class RandomNumberGenerator
	{
		Random r = new Random();
		private int numOne;
		private int numTwo;

		public  RandomNumberGenerator(int numOne, int numTwo)
		{
			this.numOne = numOne;
			this.numTwo = numTwo;
		}

		public int GetNumber()
		{
			return this.r.Next(this.numOne, this.numTwo);
		}
	}
}
