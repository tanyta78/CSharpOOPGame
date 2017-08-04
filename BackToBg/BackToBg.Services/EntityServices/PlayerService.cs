using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BackToBg.Business.ServiceInterfaces.EntityServiceInterfaces;
using BackToBg.Models;

namespace BackToBg.Services.EntityServices
{
    internal class PlayerService : IPlayerDataService
    {
        public void Add(params Player[] items)
        {
            throw new NotImplementedException();
        }

        public IList<Player> GetAll(params Expression<Func<Player, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public IList<Player> GetList(Func<Player, bool> where,
            params Expression<Func<Player, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public Player GetSingle(Func<Player, bool> where,
            params Expression<Func<Player, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(params Player[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params Player[] items)
        {
            throw new NotImplementedException();
        }
    }
}