using Productos.Domain.Entities;

namespace Productos.Domain.Ports
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}