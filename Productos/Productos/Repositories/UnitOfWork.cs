
using Productos.Data;

namespace Productos.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IProductRepository product { get; private set; }
        public ICategoryRepository category { get; private set; }
        public IProductDetailsRepository productDetails { get; private set; }

        public UnitOfWork( ApplicationDbContext context)
        {
            _context = context;
            product = new ProductRepository(_context);
            category = new CategoryRepository( _context);
            productDetails = new ProductDetailsRepository( _context);
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
