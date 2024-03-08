using Productos.Domain.Entities;
using Productos.Domain.Ports;

namespace Productos.Domain.Services;

public class ProductService( IUnitOfWork unitOfWork ) : IProductoService
{
    public async Task<bool> CreateProductoAsync( Product product )
    {
        return await unitOfWork.product.CreateProductAsync(product);
    }

    public ICollection<Product> GetProductsAsync()
    {
        return [.. ( unitOfWork.product.GetAllProductsAsync())];
    }
}