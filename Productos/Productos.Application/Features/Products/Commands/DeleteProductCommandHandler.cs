using AutoMapper;
using MediatR;
using Productos.Domain.Entities;
using Productos.Domain.Ports;

namespace Productos.Application.Features.Products.Commands;

public class DeleteProductCommandHandler( IProductService productService, IMapper mapper ) : IRequestHandler<DeleteProductoCommand, bool>
{
    public async Task<bool> Handle( DeleteProductoCommand request, CancellationToken cancellationToken )
    {
        Product product = mapper.Map<Product>(request);
        return await productService.DeleteProductoAsync(product.Id);
    }
}