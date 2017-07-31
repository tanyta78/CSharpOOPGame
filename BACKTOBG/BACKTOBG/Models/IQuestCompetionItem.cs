using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKTOBG.Models
{
    internal interface IQuestCompetionItem
    {
        IItem Details { get; set; }
        int Quantity { get; set; }
    }
}