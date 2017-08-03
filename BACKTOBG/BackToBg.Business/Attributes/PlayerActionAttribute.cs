using System;

namespace BackToBg.Business.Attributes
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = false)]
    public class PlayerActionAttribute : Attribute
    {
        public PlayerActionAttribute(string actionKeyName)
        {
            this.ActionKeyName = actionKeyName;
        }

        public string ActionKeyName { get; private set; }
    }
}
