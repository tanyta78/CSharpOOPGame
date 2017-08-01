using System;
using BackToBg.Business.ServiceInterfaces.EntityServiceInterfaces;
using BackToBg.Models;
using System.Linq.Expressions;

namespace BackToBg.Services.EntityServices
{
    class PlayerService : IPlayerDataService
    {
        public void Add(params Player[] items)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IList<Player> GetAll(params Expression<Func<Player, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IList<Player> GetList(Func<Player, bool> where, params Expression<Func<Player, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public Player GetSingle(Func<Player, bool> where, params Expression<Func<Player, object>>[] navigationProperties)
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
