using AutoMapper;
using MediatR;
using Productos.Domain.Entities;
using Productos.Domain.Ports;

namespace Productos.Application.Features.Products.Commands;

public class UpdateProductCommandHandler( IProductService productService, IMapper mapper ) : IRequestHandler<UpdateProductCommand, bool>
{
    public async Task<bool> Handle( UpdateProductCommand request, CancellationToken cancellationToken )
    {
        Product product = mapper.Map<Product>(request);
        return await productService.UpdateProductoAsync(product);
    }
}