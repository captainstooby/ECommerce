using BISInventory.Domain.Abstract;
using BISInventory.Domain.Entities;
using System.Linq;

namespace BISInventory.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
