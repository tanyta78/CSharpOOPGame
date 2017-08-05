namespace BackToBg.Business.Exceptions
{
    public class PlayerNotNearAnyBuildingException : InvalidActionException
    {
        public PlayerNotNearAnyBuildingException() : base("The player is not near any interactable building.")
        {
        }
    }
}