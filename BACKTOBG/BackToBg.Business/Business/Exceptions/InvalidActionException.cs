using System;

namespace BackToBg.Business.Exceptions
{
    public abstract class InvalidActionException : Exception
    {
        public InvalidActionException(string message) : base(message)
        {
        }
    }
}