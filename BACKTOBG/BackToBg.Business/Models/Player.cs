﻿using System;
using System.Collections.Generic;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Models
{
	public class Player : IPlayer
	{
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
		}

		public Player()
		{
			this.figure = '☻';
			this.Inventory = new List<IItem>();
		}

		public Player(string name)
		{
			this.Name = name;
			this.figure = '☻';
			this.Inventory = new List<IItem>();
		}
		//Properties
		public int ID { get; }
		public string Name { get; set; }
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
			set { this.money = value; } // TO DO Validation
		}

		public int Experience
		{
			get => this.expirience;
			set { this.expirience = value; }// TO DO Validation
		}

		public int Agility
		{
			get => this.agility;
			set => this.agility = value;// TO DO Validation
		}

		public int Strength
		{
			get => this.strength;
			set => this.strength = value;// TO DO Validation
		}

		public int Intelligence
		{
			get => this.intelligence;
			set => this.intelligence = value;// TO DO Validation
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

		public void Trade()
		{
			throw new NotImplementedException();
		}

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
		public (int row, int col, string[] figure) GetDrawingInfo()
		{
			//TODO: COHERENT IMPLEMENTATION
			return (this.x, this.y, new[] { this.figure.ToString() });
		}
	}
}