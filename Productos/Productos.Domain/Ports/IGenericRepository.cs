namespace Productos.Domain.Ports;

public interface IGenericRepository<T> where T : class
{
    Task<bool> CreateProductAsync( T value );

    Task<T?> GetProductByIdAsync( int id );

    IQueryable<T> GetAllProductsAsync();

    bool UpdateProduct( T value );

    Task<bool> DeleteProductAsync( int id );
}