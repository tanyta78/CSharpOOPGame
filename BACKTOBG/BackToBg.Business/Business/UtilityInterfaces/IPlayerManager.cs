using BackToBg.Core.Models.EntityInterfaces;

namespace BackToBg.Core.Business.UtilityInterfaces
{
    public interface IPlayerManager
    {
        IPlayer Player { get; }
        void AddQuest(IQuest quest);
    }
}
