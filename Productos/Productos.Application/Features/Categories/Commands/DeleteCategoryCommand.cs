using MediatR;

namespace Productos.Application.Features.Categories.Commands;

public record DeleteCategoryCommand( int id ) : IRequest<bool>;