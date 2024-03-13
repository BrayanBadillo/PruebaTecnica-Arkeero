using MediatR;
using Productos.Domain.Entities;
using Productos.Domain.Ports;

namespace Productos.Application.Features.Products.Queries;

public class GetAllProductsQuery( IProductService productoService ) : IRequestHandler<GetAllProductsQueryHandler, ICollection<Product>>
{
    public async Task<ICollection<Product>> Handle( GetAllProductsQueryHandler request, CancellationToken cancellationToken )
    {
        return productoService.GetProductsAsync();
    }
}