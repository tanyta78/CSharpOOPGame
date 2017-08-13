using BackToBg.Core.Models.Enums;

namespace BackToBg.Core.Models.EntityInterfaces
{
    public interface ITradingEntity : IInventoryOwner
    {
        void Trade(IItem item,TradingOption tradingOption);
    }
}