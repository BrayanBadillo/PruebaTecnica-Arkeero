using MediatR;
using Productos.Domain.Entities;
using Productos.Domain.Ports;

namespace Productos.Application.Features.Categories.Queries;

public class GetAllCategoryHandler( ICategoryService categoryService ) : IRequestHandler<GetAllCategoriesQueries, ICollection<Category>>
{
    public async Task<ICollection<Category>> Handle( GetAllCategoriesQueries request, CancellationToken cancellationToken )
    {
        return categoryService.GetCategoriesAsync();
    }
}