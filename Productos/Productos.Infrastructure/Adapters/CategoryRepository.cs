using Productos.Domain.Entities;
using Productos.Domain.Ports;
using Productos.Infrastructure.Data;

namespace Productos.Infrastructure.Adapters
{
    public class CategoryRepository( ApplicationDbContext context ) : GenericRepository<Category>(context), ICategoryRepository
    {
    }
}