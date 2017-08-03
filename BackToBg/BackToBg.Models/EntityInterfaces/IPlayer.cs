using System.Collections.Generic;

namespace BackToBg.Models.EntityInterfaces
{
    public interface IPlayer : ICreature
    {
        int Money { get; }
        int Experiance { get; }
        ILocation CurrentLocation { get; set; }
        IList<IItem> PersonalInventory { get; }

        void MoveHome();

        void MoveNorth();

        void MoveSouth();

        void MoveEast();

        void MoveWest();

        void MoveTo();

        void Interact(IInteractable interactable);

        bool AdjacentTo(IBuilding building);
    }
}