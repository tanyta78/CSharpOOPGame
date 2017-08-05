using BackToBg.Core.Business.Attributes;
using BackToBg.Core.Business.UtilityInterfaces;
using BackToBg.Core.Models.EntityInterfaces;
using System;
using System.Linq;
using System.Reflection;

namespace BackToBg.Core.Business.Factories
{
    public class QuestFactory
    {
        private readonly IMap map;

        public QuestFactory(IMap map)
        {
            this.map = map;
        }

        //public IQuest CreateQuest(Type questType, object[] parameters)
        //{
        //    var quest = (IQuest)Activator.CreateInstance(questType, parameters);

        //    if (quest == null)
        //    {
        //        throw new ArgumentException("Unsupported quest type");
        //    }

        //    this.InjectDependencies(quest);

        //    return quest;
        //}

        
    }
}
