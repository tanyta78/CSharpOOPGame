﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToBg.Business.Exceptions
{
    public class InvalidKeyPressException : InvalidActionException
    {
        public InvalidKeyPressException() : base("They key you just pressed does nothing!")
        {
        }
    }
}
