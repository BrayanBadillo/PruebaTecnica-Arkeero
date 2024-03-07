using Productos.Data;
using Productos.Models;

namespace Productos.Repositories
{
    public class ProductDetailsRepository : GenericRepository<ProductDetail>, IProductDetailsRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductDetailsRepository( ApplicationDbContext context ) : base(context)
        {
            _context = context;
        }
    }
}