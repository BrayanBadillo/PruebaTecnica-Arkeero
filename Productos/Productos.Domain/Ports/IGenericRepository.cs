namespace Productos.Domain.Ports;

public interface IGenericRepository<T> where T : class
{
    Task<bool> CreateAsync( T value );

    Task<T?> GetByIdAsync( int id );

    IQueryable<T> GetAllAsync();

    bool Update( T value );

    Task<bool> DeleteAsync( int id );
}