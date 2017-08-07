using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Models.Buildings
{
    public abstract class SpecialBuilding : Building, ILocation
    {
        private int id;
        private string name;

        protected SpecialBuilding(int id, string name, string description, int x, int y, int sizeFactor = Constants.DefaultSizeFactor)
            : base(x, y, sizeFactor)
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
            get => this.id;

            private set
            {
				Validator.IsPositive(value, nameof(this.ID) + Messages.ValueShouldBePositive);
				this.id = value;
            }
        }

        public string Name
        {
            get => this.name;

            private set
            {
				Validator.IsNullEmptyOrWhiteSpace(value, nameof(this.name) + Messages.ValueShouldNotBeEmptyOrNull);
				this.name = value;
            }
        }

        public string Description { get; set; }
        public IItem ItemRequeredToEnter { get; set; }
        public IQuest QuestAvailableHere { get; set; }

        public abstract override void Interact();
    }
}