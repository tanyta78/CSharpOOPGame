using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToBg.Models.EntityInterfaces
{
    public interface ICreature : IDrawable
    {
        int ID { get; }
        string Name { get; }
        int CurrentHitPoints { get; }
        int MaxHitPoints { get; }
    }
}