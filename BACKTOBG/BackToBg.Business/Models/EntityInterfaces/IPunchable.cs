namespace BackToBg.Core.Models.EntityInterfaces
{
    public interface IPunchable : ICreature
    {
        void TakeDamage(int damage);
        bool IsDead();
    }
}