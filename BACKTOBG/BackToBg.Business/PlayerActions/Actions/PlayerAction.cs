using BackToBg.Business.UtilityInterfaces;
using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Business.PlayerActions.Actions
{
    public abstract class PlayerAction : IPlayerAction
    {
        protected IPlayer player;
        protected char[][] map;

        protected PlayerAction(IPlayer player, char[][] map)
        {
            this.player = player;
            this.map = map;
        }

        public abstract void Execute();
    }
}
