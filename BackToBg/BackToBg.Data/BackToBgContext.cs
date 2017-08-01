using BackToBg.Models;
using System.Data.Entity;

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