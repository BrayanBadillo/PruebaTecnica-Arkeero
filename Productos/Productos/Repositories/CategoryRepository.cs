using Productos.Data;
using Productos.Models;

namespace Productos.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository( ApplicationDbContext context ) : base(context)
        {
            _context = context;
        }
    }
}