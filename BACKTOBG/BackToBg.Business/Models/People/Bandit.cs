using System;
using BackToBg.Core.Models.EntityInterfaces;
using BackToBg.Core.Models.Quests;
using BackToBg.Core.Models.Utilities;

namespace BackToBg.Core.Models.People
{
    public class Bandit : IPunchable
    {
        private int row;
        private int col;
        private char figure;
        private int health;
        private BanditQuest quest;

        public Bandit(BanditQuest quest, int row, int col, char figure = Constants.BanditFigure)
        {
            this.quest = quest;
            this.row = row;
            this.col = col;
            this.figure = figure;
            this.health = this.MaxHitPoints;
        }

        public (int row, int col, string[] figure) GetDrawingInfo()
        {
            return (this.row, this.col, new string[] { this.figure.ToString() });
        }

        public bool IsDead() => this.health <= 0;

        public int ID => throw new NotImplementedException(); //TODO
        public string Name => throw new NotImplementedException(); //TODO
        public int CurrentHitPoints => this.health;
        public int MaxHitPoints => Constants.DefaultBanditHealth;
        public void TakeDamage(int damage)
        {
            this.health -= damage;
            if (this.IsDead())
            {
                this.quest.RemoveBandint(this);
            }
        }
    }
}
