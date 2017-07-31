using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKTOBG.Models
{
    internal interface IPlayer
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