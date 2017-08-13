using System;
using System.Collections.Generic;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Enums;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Models
{
	public class Player : IPlayer
	{
	    private IList<IQuest> quests;
		private readonly char figure;
		private readonly int attackDamage;
		private int x;
		private int y;
		private int agility;
		private int strength;
		private int intelligence;
		private int health;
		private int stamina;
		private double money;
		private int expirience;

		public Player(int x, int y, char figure = Constants.DefaultPlayerFigure)
		{
			this.x = x;
			this.y = y;
			this.figure = figure;
			this.attackDamage = Constants.DefaultPlayerAttack;
			this.Intelligence = Constants.PlayerStartingIntelligence;
			this.Experience = Constants.PlayerStartingExpirience;
			this.Strength = Constants.PlayerStartingStrength;
			this.Agility = Constants.PlayerStartingAgility;
			this.Money = Constants.PlayerStartingMoney;
			this.Stamina = Constants.PlayerStartingStamina;
			this.Inventory = new List<IItem>();
            this.quests = new List<IQuest>();
		}

		public Player()
		{
			this.figure = Constants.DefaultPlayerFigure;
			this.Inventory = new List<IItem>();
		}

		public Player(string name) : this()
		{
			this.Name = name;
		}
		//Properties
		public int ID { get; }
		public string Name { get; set; }

	    public void Trade(IItem item, TradingOption tradingOption)
	    {
	        if (tradingOption == TradingOption.Buy)
	        {
	            this.Inventory.Add(item);
	        }
	        else if (tradingOption == TradingOption.Sell)
	        {
	            this.Inventory.Remove(item);
	        }
	    }

        //intended hiding (to use IInventoryOwner's Name property)
        string IInventoryOwner.Name
		{
			get { return this.Name; }
			set { }
		}

		public int CurrentHitPoints
		{
			get => this.health;
			set => this.health = value;
		}

		public int MaxHitPoints
		{
			get => Constants.PlayerStartingHitPoints;
		}
		public double Money
		{
			get => this.money;
			set
			{
				Validator.IsPositiveDouble(value, nameof(this.money) + Messages.ValueShouldBePositive);
				this.money = value;
			}
		}

		public int Experience
		{
			get => this.expirience;
			set
			{
				Validator.IsPositive(value, nameof(this.expirience) + Messages.ValueShouldBePositive);
				this.expirience = value;
			}
		}

		public int Agility
		{
			get => this.agility;
			set
			{
				Validator.IsPositive(value, nameof(this.agility) + Messages.ValueShouldBePositive);
				this.agility = value;
			}
		}

		public int Strength
		{
			get => this.strength;
			set
			{
				Validator.IsPositive(value, nameof(this.strength) + Messages.ValueShouldBePositive);
				this.agility = value;
			}
		}

		public int Intelligence
		{
			get => this.intelligence;
			set
			{
				Validator.IsPositive(value, nameof(this.intelligence) + Messages.ValueShouldBePositive);
				this.agility = value;
			}
		}

		public int Stamina
		{
			get { return this.stamina; }
			set
			{
				this.stamina = value;
				if (this.stamina < 0)
				{
					this.stamina = 0;
					this.health--;
				}
			}
		}

		public ILocation CurrentLocation { get; set; }
		public IList<IItem> Inventory { get; set; }

		public void MoveEast()
		{
			this.y++;
			this.Stamina--;
		}

		public void MoveNorth()
		{
			this.x--;
			this.Stamina--;
		}

		public void MoveSouth()
		{
			this.x++;
			this.Stamina--;
		}

		public void MoveWest()
		{
			this.y--;
			this.Stamina--;
		}

		public void MoveHome()
		{
			throw new NotImplementedException();
		}

		public void MoveTo()
		{
			throw new NotImplementedException();
		}

		public void Interact(IInteractable interactable)
		{
			interactable.Interact();
		}

		public bool AdjacentTo(IBuilding building)
		{
			var buildingInfo = building.GetDrawingInfo();
			var buildingX = buildingInfo.row;
			var buildingY = buildingInfo.col;
			var buildingHeight = buildingInfo.figure.Length;
			var buildingWidth = buildingInfo.figure[0].Length;

			var horizontalCheck = this.x >= buildingX - 1 && this.x <= buildingX + buildingWidth + 1;
			var verticalCheck = this.y >= buildingY - 1 && this.y <= buildingY + buildingHeight + 1;

			return horizontalCheck && verticalCheck;
		}

		public void Attack(IPunchable target)
		{
			target.TakeDamage(this.attackDamage);
		}

		public void ResetPosition()
		{
			this.x = 1;
			this.y = 1;
		}

	    public void AddQuest(IQuest quest)
	    {
	        this.quests.Add(quest);
	    }

	    public void RemoveQuest(IQuest quest)
	    {
	        this.quests.Remove(quest);
	    }

	    public IReadOnlyList<IQuest> GetQuests()
	    {
	        return (IReadOnlyList<IQuest>) this.quests;
	    }

	    public (int row, int col, string[] figure) GetDrawingInfo()
		{
			//TODO: COHERENT IMPLEMENTATION
			return (this.x, this.y, new[] { this.figure.ToString() });
		}
	}
}