using Microsoft.EntityFrameworkCore.ChangeTracking;
using Productos.Domain.Ports;
using Productos.Infrastructure.Data;

namespace Productos.Infrastructure.Adapters;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public GenericRepository( ApplicationDbContext Context )
    {
        _context = Context;
    }

    public async Task<bool> CreateProductAsync( T value )
    {
        EntityEntry<T>? result = await _context.Set<T>().AddAsync(value);
        return result is null ? false : true;
    }

    public async Task<bool> DeleteProductAsync( int id )
    {
        T? entity = await GetProductByIdAsync(id);
        if ( entity == null )
        {
            return false;
        }
        _context.Set<T>().Remove(entity);
        return true;
    }

    public IQueryable<T> GetAllProductsAsync()
    {
        return _context.Set<T>();
    }

    public async Task<T?> GetProductByIdAsync( int id )
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public bool UpdateProduct( T value )
    {
        EntityEntry<T>? result = _context.Set<T>().Update(value);
        return result is null ? false : true;
    }
}