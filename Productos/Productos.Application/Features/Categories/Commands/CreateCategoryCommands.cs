using MediatR;

namespace Productos.Application.Features.Categories.Commands;

public record CreateCategoryCommands( string name ) : IRequest<bool>;