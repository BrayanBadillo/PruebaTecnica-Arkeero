using AutoMapper;
using MediatR;
using Productos.Domain.Entities;
using Productos.Domain.Ports;

namespace Productos.Application.Features.Categories.Commands;

public class UpdateCategoryCommandHandler( ICategoryService categoryService, IMapper mapper ) : IRequestHandler<UpdateCategoryCommand, bool>
{
    public async Task<bool> Handle( UpdateCategoryCommand request, CancellationToken cancellationToken )
    {
        Category category = mapper.Map<Category>(request);
        return await categoryService.UpdateCategoryAsync(category);
    }
}