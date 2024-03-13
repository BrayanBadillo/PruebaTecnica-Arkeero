using AutoMapper;
using MediatR;
using Productos.Domain.Entities;
using Productos.Domain.Ports;

namespace Productos.Application.Features.Products.Commands;

public class CreateProductCommandHandler( IProductService productoService, IMapper mapper ) : IRequestHandler<CreateProductCommand, bool>
{
    public async Task<bool> Handle( CreateProductCommand request, CancellationToken cancellationToken )
    {
        Product product = mapper.Map<Product>(request);
        return await productoService.CreateProductoAsync(product);
    }
}