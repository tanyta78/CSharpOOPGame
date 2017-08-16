namespace BackToBg.Core.Business.Exceptions
{
    public class NotEnoughMoneyException : InvalidActionException
    {
        public NotEnoughMoneyException(string message) : base(message)
        {
        }
    }
}