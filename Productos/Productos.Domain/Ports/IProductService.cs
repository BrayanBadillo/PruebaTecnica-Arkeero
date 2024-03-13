using Productos.Domain.Entities;

namespace Productos.Domain.Ports;

public interface IProductService
{
    Task<bool> CreateProductoAsync( Product product );

    Task<bool> DeleteProductoAsync( int id );

    Task<bool> UpdateProductoAsync( Product product );

    ICollection<Product> GetProductsAsync();
}