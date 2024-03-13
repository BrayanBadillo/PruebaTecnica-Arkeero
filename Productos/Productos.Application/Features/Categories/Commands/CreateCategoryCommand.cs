using MediatR;

namespace Productos.Application.Features.Categories.Commands;

public record CreateCategoryCommand( string name ) : IRequest<bool>;