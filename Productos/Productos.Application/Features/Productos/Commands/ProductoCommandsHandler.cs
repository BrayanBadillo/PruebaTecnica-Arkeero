using AutoMapper;
using MediatR;
using Productos.Domain.Entities;
using Productos.Domain.Ports;

namespace Productos.Application.Features.Productos.Commands;

public class ProductoCommandsHandler( IProductoService productoService, IMapper mapper ) : IRequestHandler<CreateProductoCommands, bool>
{
    public async Task<bool> Handle( CreateProductoCommands request, CancellationToken cancellationToken )
    {
        Product product = mapper.Map<Product>(request);
        return await productoService.CreateProductoAsync(product);
    }
}