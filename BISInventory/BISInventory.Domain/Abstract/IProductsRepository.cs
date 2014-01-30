using System.Linq;
using BISInventory.Domain.Entities;

namespace BISInventory.Domain.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
