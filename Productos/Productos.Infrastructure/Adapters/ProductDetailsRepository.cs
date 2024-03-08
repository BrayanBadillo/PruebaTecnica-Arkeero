using Productos.Domain.Entities;
using Productos.Domain.Ports;
using Productos.Infrastructure.Data;

namespace Productos.Infrastructure.Adapters
{
    public class ProductDetailsRepository( ApplicationDbContext context ) : GenericRepository<ProductDetail>(context), IProductDetailsRepository
    {
    }
}