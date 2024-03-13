using Productos.Domain.Ports;
using Productos.Infrastructure.Data;

namespace Productos.Infrastructure.Adapters
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IProductRepository product { get; private set; }
        public ICategoryRepository category { get; private set; }

        public UnitOfWork( ApplicationDbContext context )
        {
            _context = context;
            product = new ProductRepository(_context);
            category = new CategoryRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}