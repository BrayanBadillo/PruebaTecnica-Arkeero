using AutoMapper;
using MediatR;
using Productos.Domain.Entities;
using Productos.Domain.Ports;

namespace Productos.Application.Features.Categories.Commands;

public class DeleteCategoryCommandHandler( ICategoryService categoryService, IMapper mapper ) : IRequestHandler<DeleteCategoryCommand, bool>
{
    public async Task<bool> Handle( DeleteCategoryCommand request, CancellationToken cancellationToken )
    {
        Category category = mapper.Map<Category>(request);

        return await categoryService.DeleteCategoryAsync(category.Id);
    }
}