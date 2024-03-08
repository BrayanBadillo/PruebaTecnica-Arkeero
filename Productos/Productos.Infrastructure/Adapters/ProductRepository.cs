using Productos.Domain.Entities;
using Productos.Domain.Ports;
using Productos.Infrastructure.Data;

namespace Productos.Infrastructure.Adapters
{
    public class ProductRepository( ApplicationDbContext context ) : GenericRepository<Product>(context), IProductRepository
    {
    }
}