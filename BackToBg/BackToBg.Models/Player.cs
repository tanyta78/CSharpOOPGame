using System;
using System.Collections.Generic;
using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Models
{
    public class Player : IPlayer
    {
        private readonly char figure;
        private int x;
        private int y;

        public Player(int x, int y, char figure = '☻')
        {
            this.x = x;
            this.y = y;
            this.figure = figure;
        }

        public int ID { get; }

        public string Name
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public int CurrentHitPoints { get; }
        public int MaxHitPoints { get; }

        public int Money => throw new NotImplementedException();

        public int Experiance => throw new NotImplementedException();

        public ILocation CurrentLocation
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public List<IItem> PersonalInventory => throw new NotImplementedException();

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

        public void MoveWest()
        {
            this.y--;
        }

        public (int row, int col, string[] figure) GetDrawingInfo()
        {
            //TODO: COHERENT IMPLEMENTATION
            return (this.x, this.y, new[] {this.figure.ToString()});
        }
    }
}