using BISInventory.Domain.Entities;
using System.Data.Entity;

namespace BISInventory.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
