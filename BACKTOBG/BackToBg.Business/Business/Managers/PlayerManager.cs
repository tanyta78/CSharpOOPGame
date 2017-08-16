using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.Managers
{
    public class PlayerManager : IPlayerManager
    {
        public PlayerManager(IPlayer player)
        {
            this.Player = player;
        }

        public IPlayer Player { get; }

        public void AddQuest(IQuest quest)
        {
            this.Player.AddQuest(quest);
        }
    }
}