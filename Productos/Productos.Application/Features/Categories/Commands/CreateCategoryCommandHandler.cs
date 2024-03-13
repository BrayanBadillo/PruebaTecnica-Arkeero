using AutoMapper;
using MediatR;
using Productos.Domain.Entities;
using Productos.Domain.Ports;

namespace Productos.Application.Features.Categories.Commands;

public class CreateCategoryCommandHandler( ICategoryService categoryService, IMapper mapper ) : IRequestHandler<CreateCategoryCommand, bool>
{
    public async Task<bool> Handle( CreateCategoryCommand request, CancellationToken cancellationToken )
    {
        Category category = mapper.Map<Category>(request);
        return await categoryService.CreateCategoryAsync(category);
    }
}