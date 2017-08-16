using System;

namespace BackToBg.Core.Models.Utilities
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private static readonly int numOne = 0;
        private static readonly int numTwo = 500;
        private readonly Random r = new Random();

        public int GetNextNumber()
        {
            var num = this.r.Next(numOne, numTwo);
            return num;
        }

        public int GetNextNumber(int lower, int upper)
        {
            var num = this.r.Next(lower, upper);
            return num;
        }

        public int GetNextNumber(int upper)
        {
            var num = this.r.Next(upper);
            return num;
        }
    }
}