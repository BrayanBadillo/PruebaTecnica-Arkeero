using MediatR;

namespace Productos.Application.Features.Products.Commands;

public record UpdateProductCommand( int Id,
                                string Name,
                                string Description,
                                decimal Price,
                                int Quantity,
                                int CategoryId ) : IRequest<bool>;