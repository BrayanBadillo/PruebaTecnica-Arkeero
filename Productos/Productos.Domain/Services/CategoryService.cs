using Productos.Domain.Entities;
using Productos.Domain.Ports;

namespace Productos.Domain.Services;

public class CategoryService( IUnitOfWork unitOfWork ) : ICategoryService
{
    public async Task<bool> CreateProductoAsync( Category category )
    {
        return await unitOfWork.category.CreateAsync( category );
    }

    public  ICollection<Category> GetCategoriesAsync()
    {
       return [..( unitOfWork.category.GetAllAsync())];
    }
}
