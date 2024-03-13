using Productos.Domain.Entities;
using Productos.Domain.Ports;

namespace Productos.Domain.Services;

public class CategoryService( IUnitOfWork unitOfWork ) : ICategoryService
{
    public async Task<bool> CreateCategoryAsync( Category category )
    {
        var result = await unitOfWork.category.CreateAsync(category);
        await unitOfWork.SaveAsync();
        return result;
    }

    public async Task<bool> DeleteCategoryAsync( int id )
    {
        var result = await unitOfWork.category.DeleteAsync(id);
        await unitOfWork.SaveAsync();
        return result;
    }

    public ICollection<Category> GetCategoriesAsync()
    {
        return [.. (unitOfWork.category.GetAllAsync())];
    }

    public async Task<bool> UpdateCategoryAsync( Category category )
    {
        var result = unitOfWork.category.Update(category);
        await unitOfWork.SaveAsync();
        return result;
    }
}