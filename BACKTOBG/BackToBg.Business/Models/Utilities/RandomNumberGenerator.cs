using System;

namespace BackToBg.Core.Models.Utilities
{
	public class RandomNumberGenerator:IRandomNumberGenerator
	{
		
		private static readonly int numOne = 0;
		private static readonly int numTwo = 500;
		Random r = new Random();

		public int GetNextNumber()
		{
			var num =  this.r.Next(numOne, numTwo);
			return num;
		}
	}
}
