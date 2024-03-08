using MediatR;

namespace Productos.Application.Features.Productos.Commands;

public record CreateProductoCommands( string Name,
                                string Description,
                                decimal Price,
                                int Quantity,
                                DateTime CreatedAt,
                                int CategoryId ) : IRequest<bool>;