using BackToBg.Business.UtilityInterfaces;

namespace BackToBg.Business.PlayerActions.Actions
{
    public abstract class PlayerAction : IPlayerAction
    {
        public abstract void Execute();
    }
}