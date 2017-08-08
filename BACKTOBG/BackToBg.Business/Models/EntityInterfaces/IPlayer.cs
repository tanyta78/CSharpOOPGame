using System.Collections.Generic;

namespace BackToBg.Core.Models.EntityInterfaces
{
    public interface IPlayer : ICreature, ITradingEntity
    {
        double Money { get; set; }
        int Experience { get; set; }
		int Stamina { get; set; }
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

        void ResetPosition();

        void AddQuest(IQuest quest);

        void RemoveQuest(IQuest quest);

        IReadOnlyList<IQuest> GetQuests();
    }
}