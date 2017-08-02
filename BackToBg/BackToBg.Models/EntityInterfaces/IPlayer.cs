using System.Collections.Generic;
using BackToBg.Models.EntityInterfaces;

namespace BACKTOBG.Models
{
    public interface IPlayer : IDrawable
    {
        string Name { get; set; }
        int Money { get; }
        int Experiance { get; }
        ILocation CurrentLocation { get; set; }
        List<IItem> PersonalInventory { get; }

        void MoveHome();

        void MoveNorth();

        void MoveSouth();

        void MoveEast();

        void MoveWest();

        void MoveTo();
    }
}