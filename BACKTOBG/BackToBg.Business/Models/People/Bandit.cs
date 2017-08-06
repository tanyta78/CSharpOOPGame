using System;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Quests;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Models.People
{
    public class Bandit : IPunchable
    {
        private readonly int col;
        private readonly char figure;
        private readonly BanditQuest quest;
        private readonly int row;

        public Bandit(BanditQuest quest, int row, int col, char figure = Constants.BanditFigure)
        {
            this.quest = quest;
            this.row = row;
            this.col = col;
            this.figure = figure;
            this.CurrentHitPoints = this.MaxHitPoints;
        }

        public (int row, int col, string[] figure) GetDrawingInfo()
        {
            return (this.row, this.col, new[] {this.figure.ToString()});
        }

        public bool IsDead()
        {
            return this.CurrentHitPoints <= 0;
        }

        public int ID => throw new NotImplementedException(); //TODO
        public string Name => throw new NotImplementedException(); //TODO
        public int CurrentHitPoints { get; private set; }

        public int MaxHitPoints => Constants.DefaultBanditHealth;

        public void TakeDamage(int damage)
        {
            this.CurrentHitPoints -= damage;
            if (IsDead())
                this.quest.RemoveBandint(this);
        }
    }
}