using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBg.Models.EntityInterfaces;

namespace BackToBg.Business.Models.EntityInterfaces
{
    public interface IPunchable : ICreature
    {
        void TakeDamage(int damage);
        bool IsDead();
    }
}
