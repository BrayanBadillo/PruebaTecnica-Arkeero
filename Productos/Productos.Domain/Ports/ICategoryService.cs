using Productos.Domain.Entities;

namespace Productos.Domain.Ports;

public interface ICategoryService
{
    Task<bool> CreateCategoryAsync( Category category );

    Task<bool> DeleteCategoryAsync( int id );

    Task<bool> UpdateCategoryAsync( Category category );

    ICollection<Category> GetCategoriesAsync();
}