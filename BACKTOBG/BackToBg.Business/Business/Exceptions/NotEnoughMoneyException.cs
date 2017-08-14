using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToBg.Core.Business.Exceptions
{
    public class NotEnoughMoneyException : InvalidActionException
    {
        public NotEnoughMoneyException(string message) : base(message)
        {

        }
    }
}
