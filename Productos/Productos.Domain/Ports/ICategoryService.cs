using Productos.Domain.Entities;

namespace Productos.Domain.Ports;

public interface ICategoryService
{
    Task<bool> CreateProductoAsync( Category category );

    ICollection<Category> GetCategoriesAsync();
}