using MediatR;

namespace Productos.Application.Features.Products.Commands;

public record DeleteProductoCommand( int Id ) : IRequest<bool>;