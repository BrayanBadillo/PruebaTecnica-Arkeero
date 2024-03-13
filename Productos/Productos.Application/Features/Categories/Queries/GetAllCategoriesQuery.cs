using MediatR;
using Productos.Domain.Entities;
using Productos.Domain.Ports;

namespace Productos.Application.Features.Categories.Queries;

public class GetAllCategoriesQuery( ICategoryService categoryService ) : IRequestHandler<GetAllCategoriesQueryHandler, ICollection<Category>>
{
    public async Task<ICollection<Category>> Handle( GetAllCategoriesQueryHandler request, CancellationToken cancellationToken )
    {
        return categoryService.GetCategoriesAsync();
    }
}