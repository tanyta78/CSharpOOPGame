using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Business.Models.EntityInterfaces;
using BackToBg.Business.Models.Quests;
using BackToBg.Models.EntityInterfaces;
using BackToBg.Models.Utilities;

namespace BackToBg.Business.Models.People
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
            this.health = MaxHitPoints;
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
                throw new NullReferenceException("maikamustarawe");
                this.quest.RemoveBandint(this);
            }
        }
    }
}
