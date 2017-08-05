using System.Data.Entity;
using BackToBg.Core.Models;

namespace BackToBg.Data
{
    public class BackToBgContext : DbContext
    {
        public BackToBgContext()
            : base("name=BackToBgContext")
        {
        }

        public virtual DbSet<Player> Players { get; set; }
    }
}