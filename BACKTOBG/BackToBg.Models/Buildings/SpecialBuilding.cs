using BackToBg.Models.EntityInterfaces;
using BackToBg.Models.Items;
using BACKTOBG.Models;
using System;

namespace BackToBg.Models.Buildings
{
    public abstract class SpecialBuilding : Building, ILocation, IInteractable
    {
        private int id;
        private string name;

        public SpecialBuilding(int id, string name, string description, int x, int y, int sizeFactor = 1) : base(x, y, sizeFactor)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
            this.ItemRequeredToEnter = null;
            this.QuestAvailableHere = null;
            this.sizeFactor = sizeFactor;
        }

        public int ID
        {
            get { return this.id; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.id)} should be positive integer!");
                }

                this.id = value;
            }
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(this.name)} should not be null empty or white space!");
                }

                this.name = value;
            }
        }

        public string Description { get; set; }
        public IItem ItemRequeredToEnter { get; set; }
        public IQuest QuestAvailableHere { get; set; }

        public abstract void Interact();
    }
}