using System;

namespace BackToBg.Core.Business.Exceptions
{
    public abstract class InvalidActionException : Exception
    {
        public InvalidActionException(string message) : base(message)
        {
        }
    }
}