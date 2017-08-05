namespace BackToBg.Core.Business.Exceptions
{
    public class InvalidKeyPressException : InvalidActionException
    {
        public InvalidKeyPressException() : base("They key you just pressed does nothing!")
        {
        }
    }
}