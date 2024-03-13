using Productos.Domain.Entities;
using Productos.Domain.Ports;

namespace Productos.Domain.Services;

public class ProductService( IUnitOfWork unitOfWork ) : IProductService
{
    public async Task<bool> CreateProductoAsync( Product product )
    {
        var result = await unitOfWork.product.CreateAsync(product);
        await unitOfWork.SaveAsync();
        return result;
    }

    public async Task<bool> DeleteProductoAsync( int id )
    {
        var result = await unitOfWork.product.DeleteAsync(id);
        await unitOfWork.SaveAsync();
        return result;
    }

    public ICollection<Product> GetProductsAsync()
    {
        return [.. (unitOfWork.product.GetAllAsync())];
    }

    public async Task<bool> UpdateProductoAsync( Product product )
    {
        var result = unitOfWork.product.Update(product);
        await unitOfWork.SaveAsync();
        return result;
    }
}