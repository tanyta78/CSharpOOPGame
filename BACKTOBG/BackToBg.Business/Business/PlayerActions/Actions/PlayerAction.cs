using BackToBg.Core.Business.UtilityInterfaces;

namespace BackToBg.Core.Business.PlayerActions.Actions
{
    public abstract class PlayerAction : IPlayerAction
    {
        public abstract void Execute();
    }
}