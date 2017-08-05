namespace BackToBg.Core.Models.EntityInterfaces
{
    public interface IPlayer : ICreature, ITradingEntity
    {
        double Money { get; }
        int Experience { get; }
        ILocation CurrentLocation { get; set; }

        void MoveHome();

        void MoveNorth();

        void MoveSouth();

        void MoveEast();

        void MoveWest();

        void MoveTo();

        void Interact(IInteractable interactable);

        bool AdjacentTo(IBuilding building);

        void Attack(IPunchable target);
    }
}