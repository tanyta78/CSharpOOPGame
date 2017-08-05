using System;

namespace BackToBg.Business.Business.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PlayerActionAttribute : Attribute
    {
        public PlayerActionAttribute(string actionKeyName)
        {
            this.ActionKeyName = actionKeyName;
        }

        public string ActionKeyName { get; }
    }
}