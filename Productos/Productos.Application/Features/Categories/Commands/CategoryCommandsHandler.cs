using AutoMapper;
using MediatR;
using Productos.Domain.Entities;
using Productos.Domain.Ports;

namespace Productos.Application.Features.Categories.Commands;

public class CategoryCommandsHandler( ICategoryService categoryService, IMapper mapper ) : IRequestHandler<CreateCategoryCommands, bool>
{
    public async Task<bool> Handle( CreateCategoryCommands request, CancellationToken cancellationToken )
    {
        Category category = mapper.Map<Category>(request);
        return await categoryService.CreateProductoAsync(category);
    }
}