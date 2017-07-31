using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKTOBG.Models
{
    internal interface IPlayerQuest
    {
        IQuest Details { get; set; }
        bool IsCompleted { get; set; }
    }
}