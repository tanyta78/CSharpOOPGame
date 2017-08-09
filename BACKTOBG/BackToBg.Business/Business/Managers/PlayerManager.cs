using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.Managers
{
    public class PlayerManager : IPlayerManager
    {
        private readonly IPlayer player;

        public PlayerManager(IPlayer player)
        {
            this.player = player;
        }

        public IPlayer Player
        {
            get => this.player;
        }
        
        public void AddQuest(IQuest quest)
        {
            this.player.AddQuest(quest);
        }
    }
}
