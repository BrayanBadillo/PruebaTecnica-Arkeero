using MediatR;
using Productos.Domain.Entities;
using Productos.Domain.Ports;

namespace Productos.Application.Features.Productos.Queries;

public class GetAllProductHandler( IProductoService productoService ) : IRequestHandler<GetAllProductsQueries, ICollection<Product>>
{
    public async Task<ICollection<Product>> Handle( GetAllProductsQueries request, CancellationToken cancellationToken )
    {
        return productoService.GetProductsAsync();
    }
}