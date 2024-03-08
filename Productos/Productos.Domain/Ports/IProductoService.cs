using Productos.Domain.Entities;

namespace Productos.Domain.Ports;

public interface IProductoService
{
    Task<bool> CreateProductoAsync( Product product );
    ICollection<Product> GetProductsAsync();  
}