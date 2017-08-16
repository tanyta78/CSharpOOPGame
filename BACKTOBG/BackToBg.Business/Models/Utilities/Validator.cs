using System;

namespace BackToBg.Core.Models.Utilities
{
    public static class Validator
    {
        public static void IsPositive(int num, string message)
        {
            if (num < 0)
                throw new ArgumentException(message);
        }

        public static void IsPositiveDouble(double num, string message)
        {
            if (num < 0)
                throw new ArgumentException(message);
        }

        public static void IsNullEmptyOrWhiteSpace(string value, string message)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(message);
        }
    }
}