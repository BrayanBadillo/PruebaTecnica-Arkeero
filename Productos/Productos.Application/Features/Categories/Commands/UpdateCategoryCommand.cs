using MediatR;

namespace Productos.Application.Features.Categories.Commands;

public record UpdateCategoryCommand( int Id,
                                    string Name ) : IRequest<bool>;