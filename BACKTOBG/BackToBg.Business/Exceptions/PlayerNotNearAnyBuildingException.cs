using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToBg.Business.Exceptions
{
    public class PlayerNotNearAnyBuildingException : InvalidActionException
    {
        public PlayerNotNearAnyBuildingException() : base("The player is not near any interactable building.")
        {
        }
    }
}
