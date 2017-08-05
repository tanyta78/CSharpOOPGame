using System;
using System.Collections.Generic;
using BackToBg.Business.Common;
using BackToBg.Business.Models.EntityInterfaces;
using BackToBg.Business.UtilityInterfaces;
using BackToBg.Models.EntityInterfaces;
using BackToBg.Models.Utilities;

namespace BackToBg.Models
{
    public class Player : IPlayer
    {
        private readonly char figure;
        private int x;
        private int y;
        private int attackDamage;

        public Player(int x, int y, char figure = Constants.DefaultPlayerFigure)
        {
            this.x = x;
            this.y = y;
            this.figure = figure;
            this.attackDamage = Constants.DefaultPlayerAttack;
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

        public int ID { get; }

        public string Name { get; set; }

        //intended hiding (to use IInventoryOwner's Name property)
        string IInventoryOwner.Name
        {
            get { return this.Name; }
            set { }
        }

        public void Trade()
        {
            throw new NotImplementedException();
        }

        public int CurrentHitPoints { get; }
        public int MaxHitPoints { get; }
        public double Money { get; set; }
        public int Experience { get; set; }
        public ILocation CurrentLocation { get; set; }

        public IList<IItem> Inventory { get; set; }

        public void MoveEast()
        {
            this.y++;
        }

        public void MoveHome()
        {
            throw new NotImplementedException();
        }

        public void MoveNorth()
        {
            this.x--;
        }

        public void MoveSouth()
        {
            this.x++;
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

        public void MoveWest()
        {
            this.y--;
        }

        public (int row, int col, string[] figure) GetDrawingInfo()
        {
            //TODO: COHERENT IMPLEMENTATION
            return (this.x, this.y, new[] { this.figure.ToString() });
        }
    }
}