namespace BackToBg.Business.Models.EntityInterfaces
{
    public interface ICreature : IDrawable
    {
        int ID { get; }
        string Name { get; }
        int CurrentHitPoints { get; }
        int MaxHitPoints { get; }
    }
}